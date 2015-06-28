﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TDCore5;

namespace TerminalDecay5Server
{
    class Server
    {

        Universe universe = new Universe();
        private TcpListener _tcpListener;
        private Thread _listenThread;
        private Timer _serverTick;
        private Timer _serverSave;

        private Player AIID;

        public void Serve()
        {
            Cmn.Init();
            universe.InitUniverse();

            BirthAI();

            string path = "C:\\TDSave\\642df721-6d96-4851-895e-d0e84ad925e2.loldongs";

            Serialiser s = new Serialiser();
            Serialised sd = new Serialised();

            //   sd = s.DeSerializeUniverse(path);
            //   universe = sd.tu;

            MessageConstants.InitValues();
            _tcpListener = new TcpListener(IPAddress.Any, 42666);
            _listenThread = new Thread(new ThreadStart(ListenForClients));
            _listenThread.Start();
            _serverTick = new Timer(RunUniverse, universe, 800, 1600);
            _serverSave = new Timer(SaveUnivsere, universe, 200000, 400000);
        }

        static void SaveUnivsere(object ob)
        {
            Universe u = (Universe)ob;
            string path = "C:\\TDSave\\" + Guid.NewGuid().ToString() + ".loldongs";
            Serialiser s = new Serialiser();
            //   s.SerializeUniverse(path, new Serialised(u));

        }

        static void RunUniverse(object ob)
        {

            Universe u = (Universe)ob;

            u.CurrentTick++;

            if (u.deadOutposts.Count > 0)
            {
                foreach (var item in u.deadOutposts)
                {
                    u.outposts.Remove(item);
                }
            }

            Dictionary<int, long> popcap;
            popcap = new Dictionary<int, long>();

            #region add resoureces from buildings

            foreach (Outpost outpost in u.outposts)
            {
                for (int i = 0; i < Cmn.BuildType.Count; i++)
                {
                    for (int ii = 0; ii < Cmn.Resource.Count; ii++)
                    {

                        MapTile m = u.clusters[0].solarSystems[0].planets[0].mapTiles[getTileFromPosition(outpost.Tile)];
                        if (m.Resources[ii] > Cmn.BuildingProduction[i][ii])
                        {
                            m.Resources[ii] -= Cmn.BuildingProduction[i][ii];
                            u.players[outpost.OwnerID].Resources[ii] += Cmn.BuildingProduction[i][ii];
                        }
                        else
                        {
                            u.players[outpost.OwnerID].Resources[ii] += m.Resources[ii];
                            m.Resources[ii] = 0;
                        }
                    }

                }
                u.players[outpost.OwnerID].Resources[Cmn.Resource[Cmn.Renum.Population]] += u.players[outpost.OwnerID].Resources[Cmn.Resource[Cmn.Renum.Population]] / 10;
                u.players[outpost.OwnerID].Resources[Cmn.Resource[Cmn.Renum.Population]] += 1;

                if (!popcap.ContainsKey(outpost.OwnerID))
                {
                    popcap.Add(outpost.OwnerID, 0);
                }

                popcap[outpost.OwnerID] += outpost.Buildings[Cmn.BuildType[Cmn.BldTenum.Habitat]] * 50;


                //check for POI creation
                if (outpost.CoreShards > 5)
                {
                    CreatePOI(outpost, u);
                }

                //update based on POI's


            }

            foreach (var item in popcap)
            {
                if (u.players[item.Key].Resources[0] > item.Value)
                {
                    u.players[item.Key].Resources[0] -= u.players[item.Key].Resources[0] / 10;
                }
            }

            #endregion

            #region update teh map
            foreach (MapTile item in u.clusters[0].solarSystems[0].planets[0].mapTiles)
            {
                item.Resources[Cmn.Resource[Cmn.Renum.Food]] = (long)(item.Resources[Cmn.Resource[Cmn.Renum.Food]] * 1.001);
                item.Resources[Cmn.Resource[Cmn.Renum.Water]] = (long)(item.Resources[Cmn.Resource[Cmn.Renum.Water]] * 1.001);

                if (item.Resources[Cmn.Resource[Cmn.Renum.Food]] > item.MaxResources[Cmn.Resource[Cmn.Renum.Food]])
                {
                    item.Resources[Cmn.Resource[Cmn.Renum.Food]] = item.MaxResources[Cmn.Resource[Cmn.Renum.Food]];
                }

                if (item.Resources[Cmn.Resource[Cmn.Renum.Water]] > item.MaxResources[Cmn.Resource[Cmn.Renum.Water]])
                {
                    item.Resources[Cmn.Resource[Cmn.Renum.Water]] = item.MaxResources[Cmn.Resource[Cmn.Renum.Water]];
                }

            }
            #endregion

            List<BuildQueueItem> remove = new List<BuildQueueItem>();

            foreach (BuildQueueItem item in u.BuildingBuildQueue)
            {
                long itemCompleted = UpdateBuildQueue(item, u, Cmn.BuildCost);

                if (itemCompleted != 99999999999999)
                {
                    long toBuild = itemCompleted - item.Complete;
                    u.outposts[item.OutpostId].Buildings[item.ItemType] += toBuild;
                    item.Complete = itemCompleted;

                    if (item.Complete >= item.ItemTotal)
                    {
                        remove.Add(item);
                    }
                }
            }

            foreach (var item in remove)
            {
                u.BuildingBuildQueue.Remove(item);
            }

            remove = new List<BuildQueueItem>();

            foreach (BuildQueueItem item in u.DefenceBuildQueue)
            {
                long itemCompleted = UpdateBuildQueue(item, u, Cmn.DefenceCost);

                if (itemCompleted != 99999999999999)
                {
                    long toBuild = itemCompleted - item.Complete;
                    u.outposts[item.OutpostId].Defence[item.ItemType] += toBuild;
                    item.Complete = itemCompleted;

                    if (item.Complete >= item.ItemTotal)
                    {
                        remove.Add(item);
                    }
                }
            }


            foreach (var item in remove)
            {
                u.DefenceBuildQueue.Remove(item);
            }


            remove = new List<BuildQueueItem>();

            foreach (BuildQueueItem item in u.OffenceBuildQueue)
            {
                long itemCompleted = UpdateBuildQueue(item, u, Cmn.OffenceCost);

                if (itemCompleted != 99999999999999)
                {
                    long toBuild = itemCompleted - item.Complete;
                    u.outposts[item.OutpostId].Offence[item.ItemType] += toBuild;
                    item.Complete = itemCompleted;

                    if (item.Complete >= item.ItemTotal)
                    {
                        remove.Add(item);
                    }
                }
            }


            foreach (var item in remove)
            {
                u.OffenceBuildQueue.Remove(item);
            }

            List<TroopMovement> CompleteMovements = new List<TroopMovement>();

            foreach (var item in u.TroopMovements)
            {
                if (item.StartTick + item.Duration < u.CurrentTick)
                {
                    switch (item.MovementType)
                    {
                        case Cmn.MovType.Reinforcement:
                            //dump the troops in the base and add the troop movement to a temp remove list
                            for (int def = 0; def < item.Defence.Count; def++)
                            {
                                item.DestinationOutpost.Defence[def] += item.Defence[def];
                            }

                            for (int off = 0; off < item.Offence.Count; off++)
                            {
                                item.DestinationOutpost.Offence[off] += item.Offence[off];
                            }

                            CompleteMovements.Add(item);

                            break;
                        case Cmn.MovType.Attack:
                            CalculateBattle(item, u);
                            Outpost orig = item.OriginOutpost;
                            item.OriginOutpost = item.DestinationOutpost;
                            item.DestinationOutpost = orig;
                            item.StartTick = u.CurrentTick;
                            item.MovementType = Cmn.MovType.Reinforcement;
                            //send it back change it to a reinforcement
                            break;
                        default:
                            break;
                    }
                }
            }

            foreach (var item in CompleteMovements)
            {
                u.TroopMovements.Remove(item);
            }

        }

        private static void CreatePOI(Outpost outpost, Universe u)
        {


            int space = u.r.Next(9);
            int tileToTest = 0;

            Position p = new Position(-1, -1);

            for (int i = 0; i < 9; i++)
            {
                tileToTest = 9 % (space + i);

                int x = (tileToTest % 3) - 1;
                int y = ((tileToTest - (tileToTest % 3)) / 3) - 1;

                x = outpost.Tile.X + x;
                y = outpost.Tile.Y + y;

                bool blocked = false;

                if (x < 0 && x > 26)
                {
                    blocked = true;
                }

                if (y < 0 && y > 26)
                {
                    blocked = true;
                }

                if (!blocked)
                {
                    foreach (var item in u.outposts)
                    {
                        if (item.Tile.X == x)
                        {
                            if (item.Tile.Y == y)
                            {
                                blocked = true;
                            }
                        }
                    }
                }

                if (blocked == false)
                {
                    i = 10;
                    p = new Position(x, y);
                    SpecialStructure ss = new SpecialStructure();
                    ss.Tile = p;
                    
                    //choose between resource bonus and the others; 

                    //find if there are any 
                    if(u.r.Next(1000)<800)
                    {
                       ss.specialType = Cmn.SpecialType.ResourceWell;
                       ss.resourceType = u.r.Next(1, 5);
                       ss.ProductionSize = u.r.Next(100, 1000);
                    }
                    else
                    {
                        //create a non resource one
                        if(u.r.Next(1000)<800)
                        {
                            int type = u.r.Next(3);                            
                            switch(type)
                            {
                                case 0:
                                    ss.specialType = Cmn.SpecialType.DeffenceBoost;
                                    break;
                                case 1:
                                    ss.specialType = Cmn.SpecialType.OffenceBoost;
                                    break;
                                case 2:
                                    ss.specialType = Cmn.SpecialType.ManufacturingBoost;
                                    break;
                            }
                        }
                        else
                        {
                            ss.specialType = Cmn.SpecialType.Portal;
                        }
                    }

                    u.SpecialStructures.Add(ss);
                }
            }



        }

        private static long UpdateBuildQueue(BuildQueueItem item, Universe u, List<List<long>> cost)
        {

            Outpost o = u.outposts[item.OutpostId];
            long FabCapacity = o.Buildings[Cmn.BuildType[Cmn.BldTenum.Fabricator]];


            long itemCompleted = 99999999999999;

            for (int i = 0; i < item.resourcesRemaining.Count; i++)
            {

                long removeValue = 0;

                if (item.resourcesRemaining[i] > FabCapacity)
                {
                    removeValue = FabCapacity;
                }
                else
                {
                    removeValue = item.resourcesRemaining[i];
                }

                if (u.players[item.PlayerId].Resources[i] > removeValue)
                {
                    item.resourcesRemaining[i] -= removeValue;
                    u.players[item.PlayerId].Resources[i] -= removeValue;
                }
                else
                {
                    item.resourcesRemaining[i] -= u.players[item.PlayerId].Resources[i];
                    u.players[item.PlayerId].Resources[i] = 0;
                }

                long total = cost[item.ItemType][i] * item.ItemTotal;
                long completed = cost[item.ItemType][i] * item.Complete;

                if ((total - item.resourcesRemaining[i]) - completed >= cost[item.ItemType][i])
                {
                    float mod = (total - item.resourcesRemaining[i]) % cost[item.ItemType][i];
                    float built = ((total - item.resourcesRemaining[i]) - mod) / cost[item.ItemType][i];

                    if (built > 0)
                    {
                        if (itemCompleted > built)
                        {
                            itemCompleted = Convert.ToInt64(built);

                        }
                    }
                }
                else
                {
                    itemCompleted = 99999999999999;
                }

            }

            return itemCompleted;
        }

        private void ListenForClients()
        {
            _tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = _tcpListener.AcceptTcpClient();

                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(HandleClientComm);
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {

            #region networking
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            ASCIIEncoding encoder = new ASCIIEncoding();

            string transmissionString = "";


            bytesRead = 0;

            try
            {
                //blocks until a client sends a message
                bytesRead = clientStream.Read(message, 0, 4096);

                //keep reading until the message is done;
                while (bytesRead != 0)
                {
                    //message has successfully been received
                    encoder = new ASCIIEncoding();

                    transmissionString += encoder.GetString(message, 0, bytesRead);


                    if (transmissionString.Substring(transmissionString.Length - MessageConstants.messageCompleteToken.Length, MessageConstants.messageCompleteToken.Length) == MessageConstants.messageCompleteToken)
                    {
                        break;
                    }

                    if (bytesRead < 4096)
                    {
                        //  break;
                    }

                    bytesRead = clientStream.Read(message, 0, 4096);
                }
            }
            catch
            {
                //a socket error has occured
                return;
            }

            if (bytesRead == 0)
            {
                //the client has disconnected from the server
                return;
            }

            //message has successfully been received

            #endregion

            #region Message Proccessing

            transmissionString = transmissionString.Replace(MessageConstants.messageCompleteToken, "");


            string[] messages;
            messages = transmissionString.Split(new string[] { MessageConstants.nextMessageToken }, StringSplitOptions.None);

            List<List<string>> transmissions = new List<List<string>>();

            foreach (string m in messages)
            {
                List<string> messageList = new List<string>();
                messageList.AddRange(m.Split(new string[] { MessageConstants.splitMessageToken }, StringSplitOptions.None));

                transmissions.Add(messageList);

            }

            #endregion

            #region message dispatch

            if (transmissions[0][0] == MessageConstants.MessageTypes[0])
            {
                SendResMap(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[1])
            {
                CreateAccount(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[2])
            {
                Login(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[3])
            {
                SendMainMap(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[4])
            {
                SendResTile(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[5])
            {
                SendBuildTile(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[6])
            {
                SendPlayerResources(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[7])
            {
                SendBuildList(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[8])
            {
                AddToBuildingBuildQueue(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[9])
            {
                SendDefenceBuildList(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[10])
            {
                AddToDefenceBuildQueue(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[11])
            {
                SendOffenceBuildList(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[12])
            {
                AddToOffenceBuildQueue(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[13])
            {
                SendOffenceForAttack(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[14])
            {
                Attack(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[15])
            {
                SendMessages(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[16])
            {
                ReadMessage(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[17])
            {
                SendSolarMap(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[18])
            {
                SendClusterMap(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[19])
            {
                SendUniverseMap(transmissions, tcpClient);
            }

            if (transmissions[0][0] == MessageConstants.MessageTypes[20])
            {
                SendHomePlanet(transmissions, tcpClient);
            }

            tcpClient.Close();
            client = null;

            #endregion
        }

        private void SendHomePlanet(List<List<string>> message, TcpClient tcpClient)
        {

            Player player;
            try
            {
                player = getPlayer(message[0][1]);
            }
            catch (Exception)
            {
                rejectConnection(3, "player token wrong", tcpClient);
                return;
            }

            string response = MessageConstants.MessageTypes[20] + MessageConstants.nextMessageToken;

            response += Convert.ToString(player.home.ClusterID);
            response += MessageConstants.splitMessageToken + Convert.ToString(player.home.SolarSytemID);
            response += MessageConstants.splitMessageToken + Convert.ToString(universe.clusters[player.home.ClusterID].solarSystems[player.home.SolarSytemID].planets[player.home.PlanetID].position.X);
            response += MessageConstants.splitMessageToken + Convert.ToString(universe.clusters[player.home.ClusterID].solarSystems[player.home.SolarSytemID].planets[player.home.PlanetID].position.Y);

            response += MessageConstants.messageCompleteToken;

            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        private void SendUniverseMap(List<List<string>> message, TcpClient tcpClient)
        {
            long playerid = -1;
            string response = MessageConstants.MessageTypes[19] + MessageConstants.nextMessageToken;

            try
            {
                playerid = getPlayer(message[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(17, "player token wrong", tcpClient);
                return;
            }

            foreach (Cluster c in universe.clusters)
            {
                response += c.position.X + MessageConstants.splitMessageToken + c.position.Y + MessageConstants.splitMessageToken + c.ClusterType + MessageConstants.nextMessageToken;
            }

            response += MessageConstants.messageCompleteToken;

            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        private void SendClusterMap(List<List<string>> message, TcpClient tcpClient)
        {
            long playerid = -1;
            string response = MessageConstants.MessageTypes[18] + MessageConstants.nextMessageToken;

            try
            {
                playerid = getPlayer(message[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(18, "player token wrong", tcpClient);
                return;
            }

            Cluster SelectedCluster = new Cluster();
            foreach (Cluster item in universe.clusters)
            {
                if (item.position.X == Convert.ToInt32(message[0][2]) && item.position.Y == Convert.ToInt32(message[0][3]))
                {
                    SelectedCluster = item;
                }
            }

            if (SelectedCluster == null)
            {
                SelectedCluster = universe.clusters[0];
            }

            response += SelectedCluster.ClusterID + MessageConstants.nextMessageToken;



            foreach (SolarSystem s in SelectedCluster.solarSystems)
            {
                response += s.position.X + MessageConstants.splitMessageToken + s.position.Y + MessageConstants.splitMessageToken + s.SolarSystemType + MessageConstants.nextMessageToken;
            }



            response += MessageConstants.messageCompleteToken;

            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        private void SendSolarMap(List<List<string>> message, TcpClient tcpClient)
        {
            long playerid = -1;
            string response = MessageConstants.MessageTypes[17] + MessageConstants.nextMessageToken;

            try
            {
                playerid = getPlayer(message[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(17, "player token wrong", tcpClient);
                return;
            }


            foreach (Planet p in universe.clusters[0].solarSystems[0].planets)
            {
                response += p.position.X + MessageConstants.splitMessageToken + p.position.Y + MessageConstants.splitMessageToken + p.planetType + MessageConstants.nextMessageToken;
            }

            response += MessageConstants.messageCompleteToken;

            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        private void ReadMessage(List<List<string>> transmissions, TcpClient tcpClient)
        {

            try
            {
                int playerid = getPlayer(transmissions[1][0]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(15, "player token wrong", tcpClient);
                return;
            }

            string response = MessageConstants.MessageTypes[16] + MessageConstants.nextMessageToken;

            Player pl = getPlayer(transmissions[1][0]);

            int messageCount = 0;

            foreach (var item in universe.Messages)
            {
                if (item.recipientID == pl.PlayerID)
                {
                    messageCount++;
                    if (messageCount == Convert.ToInt32(transmissions[2][0]) + 1)
                    {
                        response += item.messageTitle + MessageConstants.splitMessageToken + item.senderID + MessageConstants.splitMessageToken + item.messageBody + MessageConstants.splitMessageToken + item.sentDate;
                        item.read = true;
                        break;
                    }
                }
            }

            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        private void SendMessages(List<List<string>> transmissions, TcpClient tcpClient)
        {
            try
            {
                int playerid = getPlayer(transmissions[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(15, "player token wrong", tcpClient);
                return;
            }

            string response = MessageConstants.MessageTypes[15] + MessageConstants.nextMessageToken;


            Player pl = getPlayer(transmissions[0][1]);

            List<Message> Mes = new List<Message>();

            foreach (var item in universe.Messages)
            {
                if (item.recipientID == pl.PlayerID)
                {
                    Mes.Add(item);
                }
            }


            foreach (var item in Mes)
            {
                response += item.senderID + ": " + item.messageTitle + MessageConstants.splitMessageToken;
            }

            response += MessageConstants.nextMessageToken;

            foreach (var item in universe.players)
            {
                response += item.PlayerID + ":" + item.Name + MessageConstants.splitMessageToken;
            }

            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        private void Attack(List<List<string>> transmissions, TcpClient tcpClient)
        {
            string response = MessageConstants.MessageTypes[14] + MessageConstants.nextMessageToken;

            Player Attacker = getPlayer(transmissions[0][1]);
            Outpost AttackOp = getOutpost(transmissions[1][0], transmissions[1][1]);
            Outpost DeffenceOp = getOutpost(transmissions[1][2], transmissions[1][3]);

            string ErrorResponse = "";

            if (Attacker != null && AttackOp != null && DeffenceOp != null)
            {
                if (AttackOp.OwnerID == Attacker.PlayerID && DeffenceOp.OwnerID != Attacker.PlayerID)
                {

                    for (int i = 0; i < Cmn.OffenceType.Count; i++)
                    {

                        if (Convert.ToInt32(transmissions[2][i]) > AttackOp.Offence[i])
                        {
                            ErrorResponse = "Not Enough Units";
                        }
                    }

                    if (ErrorResponse == "")
                    {

                        TroopMovement t = new TroopMovement();
                        t.Offence = new List<long>();
                        for (int i = 0; i < Cmn.OffenceType.Count; i++)
                        {
                            t.Offence.Add(Convert.ToInt32(transmissions[2][i]));
                            AttackOp.Offence[i] -= Convert.ToInt32(transmissions[2][i]);
                        }

                        t.OriginOutpost = AttackOp;
                        t.DestinationOutpost = DeffenceOp;
                        t.MovementType = Cmn.MovType.Attack;

                        t.StartTick = universe.CurrentTick;

                        int dx = DeffenceOp.Tile.X - AttackOp.Tile.X;
                        int dy = DeffenceOp.Tile.Y - AttackOp.Tile.Y;

                        double dist = Math.Sqrt(dx * dx + dy * dy);

                        t.Duration = Convert.ToInt32(dist) + t.StartTick;

                        universe.TroopMovements.Add(t);

                    }
                    else
                    {
                        ErrorResponse = "Identity of players conflicts with owners of bases";
                    }

                }
                else
                {
                    ErrorResponse = "Cannot find bases";
                }

                if (ErrorResponse != "")
                {
                    response = "Error" + MessageConstants.splitMessageToken + ErrorResponse;
                }

                response += MessageConstants.messageCompleteToken;
                response = MessageConstants.MessageTypes[14] + MessageConstants.splitMessageToken + response;
                NetworkStream clientStream = tcpClient.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();

                byte[] buffer = encoder.GetBytes(response);

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();

            }
        }

        public static void CalculateBattle(TroopMovement t, Universe u)
        {
            long attackOff = 0;
            long defenceOff = 0;

            for (int i = 0; i < Cmn.DefenceType.Count; i++)
            {
                defenceOff += Cmn.DefenceAttack[i] * t.DestinationOutpost.Defence[i];
                defenceOff += Cmn.OffenceAttack[i] * (t.DestinationOutpost.Offence[i] / 2);
            }

            for (int i = 0; i < Cmn.OffenceType.Count; i++)
            {
                attackOff += Cmn.OffenceAttack[i] * t.Offence[i];
            }

            string AttackerMessage = "";
            string DeffenceMessage = "";

            float result = defenceOff / attackOff;

            float attackDeath = 0;
            float deffenceDeath = 0;

            if (result <= 1)
            {
                if (result <= 1)
                {
                    deffenceDeath = 0.10f;
                    attackDeath = 0.20f;
                    AttackerMessage = "A closely faught battle";
                    DeffenceMessage = "A closely faught battle";
                }

                if (result < 0.83)
                {
                    deffenceDeath = 0.20f;
                    attackDeath = 0.15f;
                    AttackerMessage = "A close victory";
                    DeffenceMessage = "A minor defeat";
                }

                if (result < 0.66)
                {
                    deffenceDeath = 0.3f;
                    attackDeath = 0.15f;
                    AttackerMessage = "Victory";
                    DeffenceMessage = "Defeat";
                }

                if (result < 0.5)
                {
                    deffenceDeath = 0.4f;
                    attackDeath = 0.1f;
                    AttackerMessage = "An impressive victiory";
                    DeffenceMessage = "A miserable defeat";
                }

                if (result < 0.2)
                {
                    deffenceDeath = 0.6f;
                    attackDeath = 0.1f;
                    AttackerMessage = "A triumphant victiory";
                    DeffenceMessage = "A crushing defeat";
                }

                if (result < 0.1)
                {
                    deffenceDeath = 1;
                    attackDeath = 0.05f;
                    AttackerMessage = "Total victiory";
                    DeffenceMessage = "Total defeat";
                }
            }
            else
            {
                if (result >= 1)
                {
                    attackDeath = 0.10f;
                    deffenceDeath = 0.20f;
                    AttackerMessage = "A closely faught battle";
                    DeffenceMessage = "A closely faught battle";
                }

                if (result > 1.2)
                {
                    attackDeath = 0.25f;
                    deffenceDeath = 0.15f;
                    AttackerMessage = "A minor defeat";
                    DeffenceMessage = "A close victory";
                }

                if (result > 1.5)
                {
                    attackDeath = 0.3f;
                    deffenceDeath = 0.2f;
                    AttackerMessage = "Defeat";
                    DeffenceMessage = "Victory";
                }

                if (result > 2)
                {
                    attackDeath = 0.4f;
                    deffenceDeath = 0.1f;
                    AttackerMessage = "A miserable defeat";
                    DeffenceMessage = "An impressive victiory";
                }

                if (result > 5)
                {
                    attackDeath = 0.8f;
                    deffenceDeath = 0.05f;
                    AttackerMessage = "A crushing defeat";
                    DeffenceMessage = "A triumphant victiory";
                }

                if (result > 10)
                {
                    attackDeath = 1;
                    deffenceDeath = 0f;
                    AttackerMessage = "Total defeat";
                    DeffenceMessage = "Total victiory";
                }
            }

            foreach (var item in Cmn.OffenceType)
            {
                float death = t.Offence[item.Value];
                death = death * attackDeath;

                int sign = u.r.Next(1000);
                float remove = death * 0.3f;
                remove = u.r.Next(Convert.ToInt32(remove));

                if (sign > 500)
                {
                    death = death + remove;
                }
                else
                {
                    death = death - remove;
                }

                if (death < 1 && death > 0)
                {
                    death = 1;
                }

                t.Offence[item.Value] = t.Offence[item.Value] - Convert.ToInt64(death);
                if (t.Offence[item.Value] < 0)
                {
                    t.Offence[item.Value] = 0;
                }
            }

            foreach (var item in Cmn.DefenceType)
            {
                float death = t.DestinationOutpost.Defence[item.Value];
                death = death * deffenceDeath;

                int sign = u.r.Next(1000);
                float remove = u.r.Next(Convert.ToInt32(death * 0.3));

                if (sign > 500)
                {
                    death += remove;
                }
                else
                {
                    death -= remove;
                }

                t.DestinationOutpost.Defence[item.Value] = t.DestinationOutpost.Defence[item.Value] - Convert.ToInt64(death);
                if (t.DestinationOutpost.Defence[item.Value] < 0)
                {
                    t.DestinationOutpost.Defence[item.Value] = 0;
                }
            }

            foreach (var item in Cmn.OffenceType)
            {
                float death = t.DestinationOutpost.Offence[item.Value];
                death = death * deffenceDeath;

                int sign = u.r.Next(1000);
                float remove = u.r.Next(Convert.ToInt32(death * 0.3));

                if (sign > 500)
                {
                    death += remove;
                }
                else
                {
                    death -= remove;
                }

                t.DestinationOutpost.Offence[item.Value] = t.DestinationOutpost.Offence[item.Value] - Convert.ToInt64(death);
                if (t.DestinationOutpost.Offence[item.Value] < 0)
                {
                    t.DestinationOutpost.Offence[item.Value] = 0;
                }
            }


            // calculate the damage for buildings
            long totalbuild = 0;
            foreach (var item in t.DestinationOutpost.Buildings)
            {
                totalbuild += item;
            }

            float loss = totalbuild * (deffenceDeath / 3);

            if (loss < 1 && totalbuild != 0)
            {
                loss = 2;
            }

            bool basedeath = false;

            for (int i = Convert.ToInt32(loss); i > 0; i--)
            {
                int temp = u.r.Next(Cmn.BuildType.Count);

                if (t.DestinationOutpost.Buildings[temp] > 0)
                {
                    t.DestinationOutpost.Buildings[temp]--;
                }
                else
                {
                    i++;
                    bool empty = true;
                    foreach (var item in t.DestinationOutpost.Buildings)
                    {
                        if (item > 0)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        basedeath = true;
                        break;
                    }
                }

            }

            if (totalbuild <= 0)
            {
                basedeath = true;
            }


            if (result <= 1)
            {
                float removeRes = deffenceDeath / 2;

                foreach (var item in Cmn.Resource)
                {
                    u.players[t.OriginOutpost.OwnerID].Resources[item.Value] += Convert.ToInt64(u.players[t.DestinationOutpost.Home.PlanetID].Resources[item.Value] * removeRes);

                    AttackerMessage += " Gained " + item.Key + ": " + Convert.ToString(Convert.ToInt64(u.players[t.DestinationOutpost.OwnerID].Resources[item.Value] * removeRes));
                    DeffenceMessage += " Lost " + item.Key + ": " + Convert.ToString(Convert.ToInt64(u.players[t.DestinationOutpost.OwnerID].Resources[item.Value] * removeRes));
                    u.players[t.DestinationOutpost.OwnerID].Resources[item.Value] -= Convert.ToInt64(u.players[t.DestinationOutpost.OwnerID].Resources[item.Value] * removeRes);
                }
            }

            if (basedeath)
            {
                AttackerMessage += Environment.NewLine + " Base Destroyed Shard Retrieved";
                DeffenceMessage += Environment.NewLine + "Our Base Was Lost";
                t.OriginOutpost.CoreShards++;

            }

            Message tempMessage = new Message(-1, t.OriginOutpost.OwnerID, "Attacking Another Player", AttackerMessage);
            u.Messages.Add(tempMessage);
            tempMessage = new Message(-1, t.DestinationOutpost.OwnerID, "Attacked by Another Player", DeffenceMessage);
            u.Messages.Add(tempMessage);

            // response = "Success" + MessageConstants.splitMessageToken + AttackerMessage;


        }

        private void SendOffenceForAttack(List<List<string>> transmissions, TcpClient tcpClient)
        {

            try
            {
                int playerid = getPlayer(transmissions[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(13, "player token wrong", tcpClient);
                return;
            }


            string response = MessageConstants.MessageTypes[13] + MessageConstants.nextMessageToken;

            try
            {
                if (getPlayer(transmissions[0][1]).PlayerID == getOutpost(transmissions[0][2], transmissions[0][3]).OwnerID)
                {
                    Player pl = getPlayer(transmissions[0][1]);
                    response += SendOffenceOntile(transmissions);
                }
            }
            catch
            {
                response += "Player and outpost owner not the same";
            }

            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        private void SendOffenceBuildList(List<List<string>> transmissions, TcpClient tcpClient)
        {

            try
            {
                int playerid = getPlayer(transmissions[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(7, "player token wrong", tcpClient);
                return;
            }

            string response = MessageConstants.MessageTypes[11] + MessageConstants.nextMessageToken;


            if (getPlayer(transmissions[0][1]).PlayerID == getOutpost(transmissions[0][2], transmissions[0][3]).OwnerID)
            {

                response += SendOffenceOntile(transmissions);
                response += MessageConstants.nextMessageToken;

                foreach (List<long> d in Cmn.OffenceCost)
                {
                    foreach (long val in d)
                    {
                        response += val + MessageConstants.splitMessageToken;
                    }

                    response += MessageConstants.nextMessageToken;
                }

                foreach (long prod in Cmn.OffenceAttack)
                {
                    response += prod + MessageConstants.splitMessageToken;
                }

                response += MessageConstants.nextMessageToken;

                List<long> inProgress = new List<long>();
                foreach (var item in Cmn.OffenceType)
                {
                    inProgress.Add(0);
                }

                Player pl = getPlayer(transmissions[0][1]);

                foreach (var item in universe.OffenceBuildQueue)
                {
                    if (item.PlayerId == pl.PlayerID)
                    {
                        inProgress[item.ItemType] += item.ItemTotal - item.Complete;
                    }
                }

                foreach (var item in inProgress)
                {
                    response += item + MessageConstants.splitMessageToken;
                }

                response += MessageConstants.nextMessageToken;

                foreach (var item in Cmn.OffenceAttack)
                {
                    response += item + MessageConstants.splitMessageToken;
                }

                response += MessageConstants.nextMessageToken;

                foreach (var item in Cmn.OffenceAttack)
                {
                    response += item + MessageConstants.splitMessageToken;
                }

            }
            else
            {
                response += "Player and outpost owner not the same";
            }

            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private string SendOffenceOntile(List<List<string>> transmissions)
        {
            string response = "";

            Outpost op = getOutpost(transmissions[0][2], transmissions[0][3]);

            if (op == null)
            {
                response += "-1" + MessageConstants.splitMessageToken;
            }
            else
            {
                //response += op.OwnerID;
                foreach (var item in Cmn.OffenceType)
                {
                    response += op.Offence[item.Value] + MessageConstants.splitMessageToken;
                }
            }

            return response;

        }

        private void AddToDefenceBuildQueue(List<List<string>> transmissions, TcpClient tcpClient)
        {

            try
            {
                int playerid = getPlayer(transmissions[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(10, "player token wrong", tcpClient);
                return;
            }

            string response = "";

            if (getPlayer(transmissions[0][1]).PlayerID == getOutpost(transmissions[2][0], transmissions[2][1]).OwnerID)
            {

                for (int i = 0; i < transmissions[1].Count - 1; i++)
                {
                    if (Convert.ToInt32(transmissions[1][i]) > 0)
                    {
                        BuildQueueItem b = new BuildQueueItem(getPlayer(transmissions[0][1]).PlayerID, getOutpost(transmissions[2][0], transmissions[2][1]).ID, Convert.ToInt32(transmissions[1][i]), i, Cmn.DefenceCost[i]);
                        universe.DefenceBuildQueue.Add(b);
                    }
                }

                response = "Success, added to queue";
            }
            else
            {
                response = "Player and outpost owner not the same";
            }

            response = MessageConstants.MessageTypes[10] + MessageConstants.splitMessageToken + response;
            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        private void AddToOffenceBuildQueue(List<List<string>> transmissions, TcpClient tcpClient)
        {

            try
            {
                int playerid = getPlayer(transmissions[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(12, "player token wrong", tcpClient);
                return;
            }

            string response = "";

            if (getPlayer(transmissions[0][1]).PlayerID == getOutpost(transmissions[2][0], transmissions[2][1]).OwnerID)
            {

                for (int i = 0; i < transmissions[1].Count - 1; i++)
                {
                    if (Convert.ToInt32(transmissions[1][i]) > 0)
                    {
                        BuildQueueItem b = new BuildQueueItem(getPlayer(transmissions[0][1]).PlayerID, getOutpost(transmissions[2][0], transmissions[2][1]).ID, Convert.ToInt32(transmissions[1][i]), i, Cmn.OffenceCost[i]);
                        universe.OffenceBuildQueue.Add(b);
                    }
                }

                response = "Success, added to queue";
            }
            else
            {
                response = "Player and outpost owner not the same";
            }

            response = MessageConstants.MessageTypes[12] + MessageConstants.splitMessageToken + response;
            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        private void SendDefenceBuildList(List<List<string>> transmissions, TcpClient tcpClient)
        {
            string response = MessageConstants.MessageTypes[9] + MessageConstants.nextMessageToken;
            response += SendDefencesOntile(transmissions);
            response += MessageConstants.nextMessageToken;

            foreach (List<long> d in Cmn.DefenceCost)
            {
                foreach (long val in d)
                {
                    response += val + MessageConstants.splitMessageToken;
                }

                response += MessageConstants.nextMessageToken;
            }

            foreach (long prod in Cmn.DefenceAttack)
            {
                response += prod + MessageConstants.splitMessageToken;
            }

            response += MessageConstants.nextMessageToken;

            List<long> inProgress = new List<long>();
            foreach (var item in Cmn.DefenceType)
            {
                inProgress.Add(0);
            }

            Player pl = getPlayer(transmissions[0][1]);

            foreach (var item in universe.DefenceBuildQueue)
            {
                if (item.PlayerId == pl.PlayerID)
                {
                    inProgress[item.ItemType] = item.ItemTotal - item.Complete;
                }
            }

            foreach (var item in inProgress)
            {
                response += item + MessageConstants.splitMessageToken;
            }



            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private string SendDefencesOntile(List<List<string>> transmissions)
        {
            string response = "";
            bool found = false;

            Outpost op = getOutpost(transmissions[0][2], transmissions[0][3]);

            if (op == null)
            {
                response += "-1" + MessageConstants.splitMessageToken;
            }
            else
            {
                response += op.OwnerID + MessageConstants.splitMessageToken + op.Defence[Cmn.DefenceType[Cmn.DefTenum.Patrol]] + MessageConstants.splitMessageToken + op.Defence[Cmn.DefenceType[Cmn.DefTenum.Gunner]] + MessageConstants.splitMessageToken + op.Defence[Cmn.DefenceType[Cmn.DefTenum.Turret]] + MessageConstants.splitMessageToken + op.Defence[Cmn.DefenceType[Cmn.DefTenum.Artillery]] + MessageConstants.splitMessageToken + op.Defence[Cmn.DefenceType[Cmn.DefTenum.DroneBase]] + MessageConstants.nextMessageToken; ;
            }

            return response;

        }

        private void AddToBuildingBuildQueue(List<List<string>> transmissions, TcpClient tcpClient)
        {

            try
            {
                int playerid = getPlayer(transmissions[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(8, "player token wrong", tcpClient);
                return;
            }


            string response = "";

            if (getPlayer(transmissions[0][1]).PlayerID == getOutpost(transmissions[2][0], transmissions[2][1]).OwnerID)
            {
                for (int i = 0; i < transmissions[1].Count - 1; i++)
                {
                    if (Convert.ToInt32(transmissions[1][i]) > 0)
                    {
                        BuildQueueItem b = new BuildQueueItem(getPlayer(transmissions[0][1]).PlayerID, getOutpost(transmissions[2][0], transmissions[2][1]).ID, Convert.ToInt32(transmissions[1][i]), i, Cmn.BuildCost[i]);
                        universe.BuildingBuildQueue.Add(b);
                    }
                }

                response = "Success, added to queue";
            }
            else
            {
                response = "Player and outpost owner not the same";
            }

            response = MessageConstants.MessageTypes[8] + MessageConstants.splitMessageToken + response;
            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        private void SendBuildList(List<List<string>> transmissions, TcpClient tcpClient)
        {
            string response = MessageConstants.MessageTypes[7] + MessageConstants.nextMessageToken;

            try
            {
                int playerid = getPlayer(transmissions[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(7, "player token wrong", tcpClient);
                return;
            }

            response += SendBuildingsOntile(transmissions);
            response += MessageConstants.nextMessageToken;


            foreach (List<long> build in Cmn.BuildCost)
            {
                foreach (long val in build)
                {
                    response += val + MessageConstants.splitMessageToken;
                }

                response += MessageConstants.nextMessageToken;
            }

            foreach (List<long> prod in Cmn.BuildingProduction)
            {
                foreach (long val in prod)
                {
                    response += val + MessageConstants.splitMessageToken;
                }
                response += MessageConstants.nextMessageToken;
            }

            List<long> inProgress = new List<long>();
            foreach (var item in Cmn.BuildType)
            {
                inProgress.Add(0);
            }

            Player pl = getPlayer(transmissions[0][1]);

            foreach (var item in universe.BuildingBuildQueue)
            {
                if (item.PlayerId == pl.PlayerID)
                {
                    inProgress[item.ItemType] = item.ItemTotal - item.Complete;
                }
            }

            foreach (var item in inProgress)
            {
                response += item + MessageConstants.splitMessageToken;
            }

            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private void SendPlayerResources(List<List<string>> message, TcpClient tcpClient)
        {

            Player pl = new Player(); ;

            try
            {
                pl = getPlayer(message[0][1]);
            }
            catch (Exception)
            {
                rejectConnection(6, "player token wrong", tcpClient);
                return;
            }


            string reply = MessageConstants.MessageTypes[6] + MessageConstants.nextMessageToken;
            reply += pl.Resources[Cmn.Resource[Cmn.Renum.Food]] + MessageConstants.splitMessageToken + pl.Resources[Cmn.Resource[Cmn.Renum.Metal]] + MessageConstants.splitMessageToken + pl.Resources[Cmn.Resource[Cmn.Renum.Population]] + MessageConstants.splitMessageToken + pl.Resources[Cmn.Resource[Cmn.Renum.Power]] + MessageConstants.splitMessageToken + pl.Resources[Cmn.Resource[Cmn.Renum.Water]] + MessageConstants.splitMessageToken;

            int mescount = 0;
            foreach (var item in universe.Messages)
            {
                if (item.recipientID == pl.PlayerID && item.read == false)
                {
                    mescount++;
                }

            }
            reply += MessageConstants.nextMessageToken + mescount.ToString();

            reply += MessageConstants.messageCompleteToken;

            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(reply);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private void SendResMap(List<List<string>> message, TcpClient tcpClient)
        {

            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            bool auth = false;

            if (getPlayer(message[0][1]) != null)
            {
                auth = true;
            }

            if (auth)
            {
                string Message = MessageConstants.MessageTypes[0] + MessageConstants.nextMessageToken;

                foreach (MapTile m in universe.clusters[Convert.ToInt32(message[0][4])].solarSystems[Convert.ToInt32(message[0][3])].planets[Convert.ToInt32(message[0][2])].mapTiles)
                {
                    Message = Message + Convert.ToString(m.position.X) + MessageConstants.splitMessageToken + Convert.ToString(m.position.Y) + MessageConstants.splitMessageToken + m.Resources[Cmn.Resource[Cmn.Renum.Metal]] + MessageConstants.splitMessageToken + m.Resources[Cmn.Resource[Cmn.Renum.Food]] + MessageConstants.splitMessageToken + m.Resources[Cmn.Resource[Cmn.Renum.Water]];
                    Message = Message + MessageConstants.nextMessageToken;
                }

                Message += MessageConstants.messageCompleteToken;

                byte[] buffer = encoder.GetBytes(Message);

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
            else
            {
                string Message = "nope";
                byte[] buffer = encoder.GetBytes(Message);

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }

        }

        private void CreateAccount(List<List<string>> message, TcpClient tcpClient)
        {
            bool makeaccount = true;

            if (universe.players != null)
            {
                foreach (Player p in universe.players)
                {
                    if (p.Name == message[0][1])
                    {
                        makeaccount = false;
                    }
                    if (p.Email == message[0][2])
                    {
                        makeaccount = false;
                    }
                }
            }

            if (makeaccount)
            {
                Player newp = new Player();
                newp.Name = message[0][1];
                newp.Email = message[0][2];
                newp.Password = message[0][3];

                newp.PlayerID = universe.players.Count;

                newp.Resources[Cmn.Resource[Cmn.Renum.Food]] = 1000;
                newp.Resources[Cmn.Resource[Cmn.Renum.Metal]] = 10000;
                newp.Resources[Cmn.Resource[Cmn.Renum.Population]] = 100;
                newp.Resources[Cmn.Resource[Cmn.Renum.Power]] = 3000;
                newp.Resources[Cmn.Resource[Cmn.Renum.Water]] = 1000;

                universe.players.Add(newp);

                if (universe.outposts == null)
                {
                    universe.outposts = new List<Outpost>();
                }

                Outpost o = new Outpost();
                o.Capacity = 25;
                o.ID = universe.outposts.Count;
                o.OwnerID = newp.PlayerID;

                Position v = new Position();
                Random r = new Random();
                v.X = r.Next(3, 22);
                v.Y = r.Next(3, 22);

                o.Tile = new Position();

                o.Tile = v;

                o.Home = new UniversalAddress();
                o.Home.ClusterID = 0;
                o.Home.SolarSytemID = 0;
                o.Home.PlanetID = 0;

                newp.home = new UniversalAddress();


                newp.home = o.Home;

                o.Buildings[Cmn.BuildType[Cmn.BldTenum.Mine]] = 1;
                o.Buildings[Cmn.BuildType[Cmn.BldTenum.Farm]] = 2;
                o.Buildings[Cmn.BuildType[Cmn.BldTenum.Habitat]] = 1;
                o.Buildings[Cmn.BuildType[Cmn.BldTenum.SolarPLant]] = 1;
                o.Buildings[Cmn.BuildType[Cmn.BldTenum.Well]] = 1;
                o.Buildings[Cmn.BuildType[Cmn.BldTenum.Fabricator]] = 2;

                o.Defence[Cmn.DefenceType[Cmn.DefTenum.Patrol]] = 5;
                o.Defence[Cmn.DefenceType[Cmn.DefTenum.Gunner]] = 2;

                o.Offence[Cmn.OffenceType[Cmn.OffTenum.Scout]] = 5;
                o.Offence[Cmn.OffenceType[Cmn.OffTenum.Battleship]] = 500;

                universe.outposts.Add(o);

                string reply = MessageConstants.MessageTypes[1] + MessageConstants.nextMessageToken + "AccountCreated" + MessageConstants.nextMessageToken;
                reply += MessageConstants.messageCompleteToken;

                NetworkStream clientStream = tcpClient.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();

                byte[] buffer = encoder.GetBytes(reply);

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();

            }
            else
            {
                string reply = MessageConstants.MessageTypes[1] + MessageConstants.nextMessageToken + "nope";
                reply += MessageConstants.messageCompleteToken;

                NetworkStream clientStream = tcpClient.GetStream();
                ASCIIEncoding encoder = new ASCIIEncoding();

                byte[] buffer = encoder.GetBytes(reply);

                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
        }

        private void Login(List<List<string>> message, TcpClient tcpClient)
        {

            string reply = "";

            foreach (Player p in universe.players)
            {
                if (p.Email == message[0][1] && p.Password == message[0][2])
                {
                    p.token = Guid.NewGuid();
                    reply = MessageConstants.MessageTypes[2] + MessageConstants.nextMessageToken + "Yeppers" + MessageConstants.nextMessageToken + p.token + MessageConstants.nextMessageToken;
                    break;
                }
            }
            if (reply == "")
            {
                reply = MessageConstants.MessageTypes[2] + MessageConstants.nextMessageToken + "nope";
            }

            reply += MessageConstants.messageCompleteToken;

            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(reply);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private void SendMainMap(List<List<string>> message, TcpClient tcpClient)
        {
            long playerid = -1;
            string response = MessageConstants.MessageTypes[3] + MessageConstants.nextMessageToken;

            try
            {
                playerid = getPlayer(message[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(3, "player token wrong", tcpClient);
                return;
            }

            int planetId = 0;

            foreach (Planet item in universe.clusters[Convert.ToInt32(message[0][4])].solarSystems[Convert.ToInt32(message[0][5])].planets)
            {
                if (item.position.X == Convert.ToInt32(message[0][2]) && item.position.Y == Convert.ToInt32(message[0][3]))
                {
                    planetId = item.PlanetID;
                }
            }


            foreach (Outpost o in universe.outposts)
            {
                if (o.Home.ClusterID.ToString() == message[0][4] && o.Home.SolarSytemID.ToString() == message[0][5] && o.Home.PlanetID == planetId)
                {
                    response += o.Tile.X + MessageConstants.splitMessageToken + o.Tile.Y + MessageConstants.splitMessageToken + o.OwnerID + MessageConstants.splitMessageToken;
                    if (playerid == o.OwnerID)
                    {
                        response += "mine";
                    }
                    else
                    {
                        if (o.OwnerID == AIID.PlayerID)
                        {
                            response += "AI";
                        }
                        else
                        {
                            response += "otherPlayer";
                        }
                    }

                    long def = 0;
                    for (int index = 0; index < Cmn.DefenceType.Count; index++)
                    {
                        def += o.Defence[index] * Cmn.DefenceAttack[index];
                    }

                    response += MessageConstants.splitMessageToken + def.ToString();


                    response += MessageConstants.nextMessageToken;
                }
            }

            //send the movements here

            foreach (var item in universe.TroopMovements)
            {
                if (item.OriginOutpost.Home.ClusterID.ToString() == message[0][4] && item.OriginOutpost.Home.SolarSytemID.ToString() == message[0][5] && item.OriginOutpost.Home.PlanetID == planetId)
                {
                    response += MessageConstants.nextMessageToken;
                    response += item.OriginOutpost.Tile.X + MessageConstants.splitMessageToken + item.OriginOutpost.Tile.Y + MessageConstants.splitMessageToken + item.DestinationOutpost.Tile.X + MessageConstants.splitMessageToken + item.DestinationOutpost.Tile.Y + MessageConstants.splitMessageToken + item.StartTick + MessageConstants.splitMessageToken + item.Duration + MessageConstants.splitMessageToken + universe.CurrentTick;
                }
            }


            response += MessageConstants.messageCompleteToken;

            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        private void SendResTile(List<List<string>> message, TcpClient tcpClient)
        {

            //find the tile involved from the message 
            int index = Convert.ToInt32(message[0][2]) * 25 + Convert.ToInt32(message[0][3]);

            string response = MessageConstants.MessageTypes[4] + MessageConstants.nextMessageToken + universe.clusters[0].solarSystems[0].planets[0].mapTiles[index].Resources[Cmn.Resource[Cmn.Renum.Metal]] + MessageConstants.splitMessageToken + universe.clusters[0].solarSystems[0].planets[0].mapTiles[index].Resources[Cmn.Resource[Cmn.Renum.Food]] + MessageConstants.splitMessageToken + universe.clusters[0].solarSystems[0].planets[0].mapTiles[index].Resources[Cmn.Resource[Cmn.Renum.Water]] + MessageConstants.splitMessageToken;

            response += MessageConstants.messageCompleteToken;

            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private void SendBuildTile(List<List<string>> message, TcpClient tcpClient)
        {
            string response = MessageConstants.MessageTypes[5] + MessageConstants.nextMessageToken;

            long playerid = -1;

            try
            {
                playerid = getPlayer(message[0][1]).PlayerID;
            }
            catch (Exception)
            {
                rejectConnection(5, "player token wrong", tcpClient);
            }

            response += SendBuildingsOntile(message);
            response += SendDefenceOnTile(message);
            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private string SendDefenceOnTile(List<List<string>> message)
        {
            string response = "";

            Outpost op = getOutpost(message[0][2], message[0][3]);

            if (op == null)
            {
                response += "-1" + MessageConstants.splitMessageToken;
            }
            else
            {
                response += op.Defence[Cmn.DefenceType[Cmn.DefTenum.Patrol]] + MessageConstants.splitMessageToken + op.Defence[Cmn.DefenceType[Cmn.DefTenum.Gunner]] + MessageConstants.splitMessageToken + op.Defence[Cmn.DefenceType[Cmn.DefTenum.Turret]] + MessageConstants.splitMessageToken + op.Defence[Cmn.DefenceType[Cmn.DefTenum.Artillery]] + MessageConstants.splitMessageToken + op.Defence[Cmn.DefenceType[Cmn.DefTenum.DroneBase]] + MessageConstants.nextMessageToken; ;
            }
            return response;
        }

        private string SendBuildingsOntile(List<List<string>> message)
        {

            string response = "";

            Outpost op = getOutpost(message[0][2], message[0][3]);

            if (op == null)
            {
                response += "-1" + MessageConstants.splitMessageToken;
            }
            else
            {
                Player pl = getPlayer(message[0][1]);
                if (pl.PlayerID == op.OwnerID)
                {
                    long freeBuild = op.Capacity - (op.Buildings[Cmn.BuildType[Cmn.BldTenum.Farm]] + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Habitat]] + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Mine]] + op.Buildings[Cmn.BuildType[Cmn.BldTenum.SolarPLant]] + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Well]] + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Fabricator]]);
                    response += op.OwnerID + MessageConstants.splitMessageToken + freeBuild + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Farm]] + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Habitat]] + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Mine]] + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.SolarPLant]] + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Well]] + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Fabricator]] + MessageConstants.nextMessageToken; ;
                }
                else
                {
                    response += "Enemy" + MessageConstants.splitMessageToken + op.OwnerID + MessageConstants.splitMessageToken;
                }
            }

            return response;


        }

        private Player getPlayer(string s)
        {
            //long playerid = -1;

            foreach (Player p in universe.players)
            {
                if (p.token == new Guid(s))
                {
                    return p;
                }
            }
            return null;
        }

        private Outpost getOutpost(string x, string y)
        {
            foreach (Outpost o in universe.outposts)
            {
                if (o.Tile.X == Convert.ToInt32(x) && o.Tile.Y == Convert.ToInt32(y))
                {
                    return o;
                }
            }
            return null;
        }

        private static int getTileFromPosition(Position tile)
        {
            return tile.Y * 25 + tile.X;
        }

        private void rejectConnection(int mesmnum, string message, TcpClient tcpClient)
        {
            string response = MessageConstants.MessageTypes[mesmnum];
            response += MessageConstants.nextMessageToken + "Logout" + MessageConstants.messageCompleteToken;

            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

            return;
        }

        public void BirthAI()
        {

            AIID = new Player();
            AIID.Name = "Darla";
            AIID.Email = "fdsajh;sdaf;hjladsfkjhlasdfkjhlasdflkjhqweropuxcjklh,aseiusdaf,lbmnasdiufjhasdfkasd.,mnzxdck.jh;sdrflgsdfmng.,mzxdf";
            AIID.Password = "fdsajh;sdaf;hjladsfkjhlasdfkjhlasdflkjhqweropuxcjklh,aseiusdaf,lbmnasdiufjhasdfkasd.,mnzxdck.jh;sdrflgsdfmng.,mzxdf";

            AIID.PlayerID = universe.players.Count;

            AIID.Resources[Cmn.Resource[Cmn.Renum.Food]] = 1000;
            AIID.Resources[Cmn.Resource[Cmn.Renum.Metal]] = 10000;
            AIID.Resources[Cmn.Resource[Cmn.Renum.Population]] = 100;
            AIID.Resources[Cmn.Resource[Cmn.Renum.Power]] = 3000;
            AIID.Resources[Cmn.Resource[Cmn.Renum.Water]] = 1000;

            universe.players.Add(AIID);

            for (int i = 0; i < 10; i++)
            {
                AddAIOutpost();
            }
        }

        public void AddAIOutpost()
        {
            if (universe.outposts == null)
            {
                universe.outposts = new List<Outpost>();
            }

            Outpost o = new Outpost();
            o.Capacity = 25;
            o.ID = universe.outposts.Count;
            o.OwnerID = AIID.PlayerID;

            Position v = new Position();
            v.X = universe.r.Next(3, 22);
            v.Y = universe.r.Next(3, 22);

            o.Tile = new Position();
            o.Tile = v;

            o.Home = new UniversalAddress();
            o.Home.ClusterID = 0;
            o.Home.SolarSytemID = 0;
            o.Home.PlanetID = 0;

            o.Buildings[Cmn.BuildType[Cmn.BldTenum.Mine]] = 1;
            o.Buildings[Cmn.BuildType[Cmn.BldTenum.Farm]] = 2;
            o.Buildings[Cmn.BuildType[Cmn.BldTenum.Habitat]] = 1;
            o.Buildings[Cmn.BuildType[Cmn.BldTenum.SolarPLant]] = 1;
            o.Buildings[Cmn.BuildType[Cmn.BldTenum.Well]] = 1;
            o.Buildings[Cmn.BuildType[Cmn.BldTenum.Fabricator]] = 2;

            o.Defence[Cmn.DefenceType[Cmn.DefTenum.Patrol]] = 5;
            o.Defence[Cmn.DefenceType[Cmn.DefTenum.Gunner]] = 2;

            o.Offence[Cmn.OffenceType[Cmn.OffTenum.Scout]] = 5;

            universe.outposts.Add(o);
        }
    }
}
