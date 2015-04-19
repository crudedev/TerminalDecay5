using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TerminalDecay5Server
{
    class Server
    {

        Universe universe = new Universe();
        private TcpListener _tcpListener;
        private Thread _listenThread;
        private Timer _serverTick;

        public void Serve()
        {
            Cmn.Init();
            universe.InitUniverse();
            MessageConstants.InitValues();
            _tcpListener = new TcpListener(IPAddress.Any, 3000);
            _listenThread = new Thread(new ThreadStart(ListenForClients));
            _listenThread.Start();
            universe.players = new List<Player>();
            _serverTick = new Timer(RunUniverse, universe, 0, 30000);
        }

        static void RunUniverse(object ob)
        {
            #region add resoureces from buildings
            Universe u = (Universe)ob;
            foreach (Outpost outpost in u.outposts)
            {
                for (int i = 0; i < Cmn.BuildType.Count; i++)
                {
                    for (int ii = 0; ii < Cmn.Resource.Count; ii++)
                    {

                        bool found = false;
                        List<int> pickedTiles = new List<int>();

                        while (!found)
                        {
                            int pickedTile = (int)(u.r.Next(outpost.Tiles.Count));
                            if (!pickedTiles.Contains(pickedTile))
                            {
                                MapTile m = u.Maptiles[getTileFromPosition(outpost.Tiles[pickedTile])];
                                if (m.Resources[ii] > Cmn.BuildingProduction[i][ii])
                                {
                                    found = true;
                                    m.Resources[ii] -= Cmn.BuildingProduction[i][ii];
                                    u.players[outpost.OwnerID].Resources[ii] += Cmn.BuildingProduction[i][ii];
                                }
                                else
                                {
                                    u.players[outpost.OwnerID].Resources[ii] += m.Resources[ii];
                                    m.Resources[ii] = 0;
                                    pickedTiles.Add(pickedTile);
                                }
                            }

                            if (pickedTiles.Count == outpost.Tiles.Count)
                            {
                                found = true;
                            }

                        }

                    }
                }
            }
            #endregion

            #region update teh map
            foreach (MapTile item in u.Maptiles)
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

            #region Update Buildings Build Queue
            

            foreach (BuildQueueItem item in u.BuildQueue)
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

                    long total = Cmn.BuildCost[item.ItemType][i] * item.ItemTotal;
                    long completed = Cmn.BuildCost[item.ItemType][i] * item.Complete;

                    if ((total - completed) - (total - item.resourcesRemaining[i]) > Cmn.BuildCost[item.ItemType][i])
                    {
                        float mod = (total - item.resourcesRemaining[i]) % Cmn.BuildCost[item.ItemType][i];
                        float built = ((total - item.resourcesRemaining[i]) - mod) / Cmn.BuildCost[item.ItemType][i];

                        if (built > 0)
                        {
                            if (itemCompleted > built)
                            {
                                itemCompleted = Convert.ToInt64(built);

                            }
                        }
                    }

                }

                if (itemCompleted != 99999999999999)
                {
                    long toBuild = itemCompleted - item.Complete;
                    o.Buildings[item.ItemType] += toBuild;
                    item.Complete = itemCompleted;

                    if (item.Complete >= item.ItemTotal)
                    {
                        u.BuildQueue.Remove(item);
                    }
                }

            }
            #endregion
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
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            ASCIIEncoding encoder = new ASCIIEncoding();

            string transmitionString = "";


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

                    transmitionString += encoder.GetString(message, 0, bytesRead);
                    if (bytesRead < 4096)
                    {
                        break;
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


            transmitionString = transmitionString.Replace(MessageConstants.messageCompleteToken, "");


            string[] messages;
            messages = transmitionString.Split(new string[] { MessageConstants.nextMessageToken }, StringSplitOptions.None);

            List<List<string>> Transmitions = new List<List<string>>();

            foreach (string m in messages)
            {
                List<string> messageList = new List<string>();
                messageList.AddRange(m.Split(new string[] { MessageConstants.splitMessageToken }, StringSplitOptions.None));

                Transmitions.Add(messageList);

            }


            if (Transmitions[0][0] == MessageConstants.MessageTypes[0])
            {
                SendResMap(Transmitions, tcpClient);
            }

            if (Transmitions[0][0] == MessageConstants.MessageTypes[1])
            {
                CreateAccount(Transmitions, tcpClient);
            }

            if (Transmitions[0][0] == MessageConstants.MessageTypes[2])
            {
                Login(Transmitions, tcpClient);
            }

            if (Transmitions[0][0] == MessageConstants.MessageTypes[3])
            {
                SendBuildMap(Transmitions, tcpClient);
            }

            if (Transmitions[0][0] == MessageConstants.MessageTypes[4])
            {
                SendResTile(Transmitions, tcpClient);
            }

            if (Transmitions[0][0] == MessageConstants.MessageTypes[5])
            {
                SendBuildTile(Transmitions, tcpClient);
            }

            if (Transmitions[0][0] == MessageConstants.MessageTypes[6])
            {
                SendPlayerResources(Transmitions, tcpClient);
            }

            if (Transmitions[0][0] == MessageConstants.MessageTypes[7])
            {
                SendBuildList(Transmitions, tcpClient);
            }

            if (Transmitions[0][0] == MessageConstants.MessageTypes[8])
            {
                AddToBuildingBuildQueue(Transmitions, tcpClient);
            }



            tcpClient.Close();
            client = null;

        }

        private void AddToBuildingBuildQueue(List<List<string>> message, TcpClient tcpClient)
        {

            for (int i = 0; i < message[1].Count - 1; i++)
            {
                if (Convert.ToInt32(message[1][i]) > 0)
                {
                    BuildQueueItem b = new BuildQueueItem(getPlayer(message[0][1]).PlayerID, getOutpost(message[2][0], message[2][1]).ID, Convert.ToInt32(message[1][i]), i, Cmn.BuildCost[i]);
                    universe.BuildQueue.Add(b);
                }
            }
        }

        private void SendBuildList(List<List<string>> message, TcpClient tcpClient)
        {
            string response = MessageConstants.MessageTypes[7] + MessageConstants.nextMessageToken;
            response += SendBuildingsOntile(message);
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

            //add additional details here from build queue

            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private void SendPlayerResources(List<List<string>> message, TcpClient tcpClient)
        {

            Player pl = getPlayer(message[0][1]);
            if (pl == null)
            {
                return;
            }


            string reply = MessageConstants.MessageTypes[6] + MessageConstants.nextMessageToken;
            reply += pl.Resources[Cmn.Resource[Cmn.Renum.Food]] + MessageConstants.splitMessageToken + pl.Resources[Cmn.Resource[Cmn.Renum.Metal]] + MessageConstants.splitMessageToken + pl.Resources[Cmn.Resource[Cmn.Renum.Population]] + MessageConstants.splitMessageToken + pl.Resources[Cmn.Resource[Cmn.Renum.Power]] + MessageConstants.splitMessageToken + pl.Resources[Cmn.Resource[Cmn.Renum.Water]] + MessageConstants.splitMessageToken;
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

            if (getPlayer(message[0][1]) != null) ;
            {
                auth = true;
            }

            if (auth)
            {
                string Message = MessageConstants.MessageTypes[0] + MessageConstants.nextMessageToken;

                foreach (MapTile m in universe.Maptiles)
                {
                    Message = Message + Convert.ToString(m.X) + MessageConstants.splitMessageToken + Convert.ToString(m.Y) + MessageConstants.splitMessageToken + m.Resources[Cmn.Resource[Cmn.Renum.Metal]] + MessageConstants.splitMessageToken + m.Resources[Cmn.Resource[Cmn.Renum.Food]] + MessageConstants.splitMessageToken + m.Resources[Cmn.Resource[Cmn.Renum.Water]];
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

                o.Tiles = new List<Position>();

                o.Tiles.Add(v);

                o.Buildings[Cmn.BuildType[Cmn.BldTenum.Mine]] = 1;
                o.Buildings[Cmn.BuildType[Cmn.BldTenum.Farm]] = 2;
                o.Buildings[Cmn.BuildType[Cmn.BldTenum.Habitat]] = 1;
                o.Buildings[Cmn.BuildType[Cmn.BldTenum.SolarPLant]] = 1;
                o.Buildings[Cmn.BuildType[Cmn.BldTenum.Well]] = 1;
                o.Buildings[Cmn.BuildType[Cmn.BldTenum.Fabricator]] = 2;

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

            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(reply);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private void SendBuildMap(List<List<string>> message, TcpClient tcpClient)
        {

            long playerid = getPlayer(message[0][1]).PlayerID;

            string response = MessageConstants.MessageTypes[3] + MessageConstants.nextMessageToken;

            foreach (Outpost o in universe.outposts)
            {
                foreach (Position p in o.Tiles)
                {
                    response += p.X + MessageConstants.splitMessageToken + p.Y + MessageConstants.splitMessageToken + o.OwnerID + MessageConstants.splitMessageToken;
                    if (playerid == o.OwnerID)
                    {
                        response += "mine";
                    }
                    else
                    {
                        response += "foe";
                    }

                    response += MessageConstants.nextMessageToken;
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

            string response = MessageConstants.MessageTypes[4] + MessageConstants.nextMessageToken + universe.Maptiles[index].Resources[Cmn.Resource[Cmn.Renum.Metal]] + MessageConstants.splitMessageToken + universe.Maptiles[index].Resources[Cmn.Resource[Cmn.Renum.Food]] + MessageConstants.splitMessageToken + universe.Maptiles[index].Resources[Cmn.Resource[Cmn.Renum.Water]] + MessageConstants.splitMessageToken;

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
            response += SendBuildingsOntile(message);
            response += MessageConstants.messageCompleteToken;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes(response);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private string SendBuildingsOntile(List<List<string>> message)
        {

            string response = "";
            bool found = false;


            Outpost op = getOutpost(message[0][2], message[0][3]);

            if (op == null)
            {
                response += "-1" + MessageConstants.splitMessageToken;
            }
            else
            {
                long freeBuild = op.Capacity - (op.Buildings[Cmn.BuildType[Cmn.BldTenum.Farm]] + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Habitat]] + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Mine]] + op.Buildings[Cmn.BuildType[Cmn.BldTenum.SolarPLant]] + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Well]] + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Fabricator]]);
                response += op.OwnerID + MessageConstants.splitMessageToken + freeBuild + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Farm]] + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Habitat]] + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Mine]] + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.SolarPLant]] + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Well]] + MessageConstants.splitMessageToken + op.Buildings[Cmn.BuildType[Cmn.BldTenum.Fabricator]] + MessageConstants.nextMessageToken; ;
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
                foreach (Position p in o.Tiles)
                {
                    if (p.X == Convert.ToInt32(x) && p.Y == Convert.ToInt32(y))
                    {
                        return o;
                    }
                }
            }
            return null;
        }

        private static int getTileFromPosition(Position tile)
        {
            return tile.Y * 25 + tile.X;
        }
    }
}
