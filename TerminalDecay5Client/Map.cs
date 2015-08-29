using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TDCore5;

namespace TerminalDecay5Client
{
    public partial class Map : Form
    {

        Universe universe;
        Guid playerToken;

        int CurrentView = -1;
        //0 = resource;
        //1 = buildview;
        //2 = attackView
        //3 = solarsystem view
        //4 = cluster view
        //5 = universe view
        //6 = reinforce view
        //7 = move base view

        private int _currentX;
        private int _currentY;

        private int _targetX;
        private int _targetY;

        private int _currentPlanet = 0;
        private int _currentSolarSystem = 0;
        private int _currentCluster = 0;

        Messages frmMessage = new Messages();

        private Bitmap mainMapBuffer;

        public Dictionary<int, Guid> BuildGuidList;

        public Map()
        {
            InitializeComponent();
            universe = new Universe();
            MessageConstants.InitValues();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cmn.Init();
            Timer t = new Timer();
            t.Tick += UpdatePlayerResoureces;
            t.Interval = 5000;
            t.Enabled = true;
        }

        void UpdatePlayerResoureces(object sender, EventArgs e)
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(DrawPlayerResources, 6, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken);
        }

        private void DrawPlayerResources(List<List<string>> transmission)
        {
            if (transmission[1][0] == "Logout")
            {
                return;
            }

            LblEnergy.Text = "Power: " + transmission[1][3];
            LblFood.Text = "Food: " + transmission[1][0];
            LblMetal.Text = "Metal: " + transmission[1][1];
            LblPopulation.Text = "Population: " + transmission[1][2];
            LblWater.Text = "Water: " + transmission[1][4];

            BtnMessages.Text = "Messages (" + transmission[2][0] + ")";
        }

        public void SetPlayerToken(Guid tok)
        {
            playerToken = tok;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(RenderResMap, 0, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(_currentPlanet) + MessageConstants.splitToken + _currentSolarSystem + MessageConstants.splitToken + _currentCluster + MessageConstants.completeToken);
            hideMenus();
        }

        private void RenderResMap(List<List<string>> transmission)
        {
            CurrentView = 0;
            universe.clusters = new List<Cluster>();
            universe.clusters.Add(new Cluster());
            universe.clusters[0].solarSystems = new List<SolarSystem>();
            universe.clusters[0].solarSystems.Add(new SolarSystem());
            universe.clusters[0].solarSystems[0].planets = new List<Planet>();
            universe.clusters[0].solarSystems[0].planets.Add(new Planet());
            universe.clusters[0].solarSystems[0].planets[0].mapTiles = new List<MapTile>();
            universe.clusters[0].solarSystems[0].planets[0].mapTiles = new List<MapTile>();
            for (int i = 1; i < transmission.Count - 1; i++)
            {
                MapTile m = new MapTile();
                m.position = new Position();
                m.position.X = Convert.ToInt32(transmission[i][0]);
                m.position.Y = Convert.ToInt32(transmission[i][1]);
                m.Resources[Cmn.Resource[Cmn.Renum.Metal]] = Convert.ToInt64(transmission[i][2]);
                m.Resources[Cmn.Resource[Cmn.Renum.Food]] = Convert.ToInt64(transmission[i][3]);
                m.Resources[Cmn.Resource[Cmn.Renum.Water]] = Convert.ToInt64(transmission[i][4]);
                universe.clusters[0].solarSystems[0].planets[0].mapTiles.Add(m);
            }

            Bitmap MapImage = new Bitmap(MapCanvas.Width, MapCanvas.Height);

            Graphics mapgraph = Graphics.FromImage(MapImage);

            Bitmap maptile = new Bitmap(26, 26);
            Graphics tilegraph = Graphics.FromImage(maptile);

            Color c;

            foreach (MapTile m in universe.clusters[0].solarSystems[0].planets[0].mapTiles)
            {

                double fr = Convert.ToDouble(m.Resources[Cmn.Resource[Cmn.Renum.Metal]]) / 20000f * 255f;
                double fg = Convert.ToDouble(m.Resources[Cmn.Resource[Cmn.Renum.Food]]) / 500 * 255;
                double fb = Convert.ToDouble(m.Resources[Cmn.Resource[Cmn.Renum.Water]]) / 10000 * 255;

                int red = Convert.ToInt32(fr);
                int green = Convert.ToInt32(fg);
                int blue = Convert.ToInt32(fb);

                c = Color.FromArgb(red, green, blue);
                maptile = new Bitmap(26, 26);
                tilegraph = Graphics.FromImage(maptile);
                SolidBrush b = new SolidBrush(c);
                tilegraph.FillRectangle(b, 0, 0, 25, 25);
                mapgraph.DrawImage(maptile, new Point(Convert.ToInt32(m.position.X * 26), Convert.ToInt32(m.position.Y * 26)));

            }

            MapCanvas.Image = MapImage;
        }


        private void RenderMainMap(List<List<string>> transmission)
        {

            CheckLoggedOut(transmission);

            hideMenus();
            MapCanvas.Show();

            CurrentView = 1;
            Bitmap MapImage = new Bitmap(MapCanvas.Width, MapCanvas.Height);

            Graphics mapgraph = Graphics.FromImage(MapImage);

            Bitmap maptile = new Bitmap(26, 26);
            Graphics tilegraph = Graphics.FromImage(maptile);

            Color PlayerColor = Color.Green;
            Color FoeColor = Color.Red;
            Color OtherColor = Color.Blue;

            Color c = Color.Gray;
            SolidBrush b = new SolidBrush(c);
            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    maptile = new Bitmap(26, 26);
                    tilegraph = Graphics.FromImage(maptile);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(x * 26, y * 26));
                }
            }

            foreach (List<string> l in transmission)
            {
                if (l.Count == 5)
                {
                    c = Color.White;
                    if (l[3] == "mine")
                    {
                        c = PlayerColor;
                    }

                    if (l[3] == "AI")
                    {
                        c = FoeColor;
                    }

                    if (l[3] == "otherPlayer")
                    {
                        c = OtherColor;
                    }

                    maptile = new Bitmap(26, 26);
                    tilegraph = Graphics.FromImage(maptile);
                    b = new SolidBrush(c);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(Convert.ToInt32(l[0]) * 26, Convert.ToInt32(l[1]) * 26));

                    maptile = new Bitmap(10, 10);
                    tilegraph = Graphics.FromImage(maptile);
                    int temp = Convert.ToInt32(transmission[1][4]);
                    if (temp > 255)
                    {
                        temp = 255;
                    }
                    c = Color.FromArgb(0, temp, temp);
                    b = new SolidBrush(c);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(Convert.ToInt32(l[0]) * 26, Convert.ToInt32(l[1]) * 26));
                }
            }

            foreach (List<string> l in transmission)
            {
                if (l.Count == 8)
                {
                    Pen myPen;
                    myPen = new System.Drawing.Pen(System.Drawing.Color.Yellow);
                    myPen.Width = 2;
                    if (l[7] == "Attack")
                    {
                        myPen.Color = Color.Tomato;
                    }

                    if (l[7] == "Reinforcement")
                    {
                        myPen.Color = Color.Green;
                    }

                    mapgraph.DrawLine(myPen, Convert.ToInt32(l[0]) * 26 + 13, Convert.ToInt32(l[1]) * 26 + 13, Convert.ToInt32(l[2]) * 26 + 13, Convert.ToInt32(l[3]) * 26 + 13);

                    myPen.Color = Color.Yellow;
                    mapgraph.DrawLine(myPen, Convert.ToInt32(l[2]) * 26, Convert.ToInt32(l[3]) * 26, Convert.ToInt32(l[2]) * 26 + 26, Convert.ToInt32(l[3]) * 26 + 26);
                    mapgraph.DrawLine(myPen, Convert.ToInt32(l[2]) * 26 + 26, Convert.ToInt32(l[3]) * 26, Convert.ToInt32(l[2]) * 26, Convert.ToInt32(l[3]) * 26 + 26);

                    myPen.Width = 6;

                    float delta = Convert.ToInt32(l[6]) - Convert.ToInt32(l[4]);
                    float result = delta / Convert.ToInt32(l[5]);

                    if (result > 1)
                    {
                        result = 1;
                    }

                    int origX = Convert.ToInt32(l[0]);
                    int origY = Convert.ToInt32(l[1]);

                    int destX = Convert.ToInt32(l[2]);
                    int destY = Convert.ToInt32(l[3]);

                    int x = 0;
                    int y = 0;

                    float fx = 0;
                    float fy = 0;

                    if (origX >= destX)
                    {
                        x = destX - origX;
                        x = x * 26;
                        fx = x * result;
                        x = (origX) * 26;
                        x = x + Convert.ToInt32(fx) + 13;
                    }
                    else
                    {
                        x = destX - origX;
                        x = x * 26;
                        fx = x * result;
                        x = (origX) * 26;
                        x = x + Convert.ToInt32(fx) + 13;
                    }

                    if (origY >= destY)
                    {
                        y = origY - destY;
                        y = y * 26;
                        fy = y * result;
                        y = (origY) * 26;
                        y = y - Convert.ToInt32(fy) + 13;
                    }
                    else
                    {
                        y = origY - destY;
                        y = y * 26;
                        fy = y * result;
                        y = (origY) * 26;
                        y = y - Convert.ToInt32(fy) + 13;
                    }


                    myPen.Color = Color.Yellow;
                    mapgraph.DrawLine(myPen, new Point(x - 2, y - 2), new Point(x + 2, y + 2));



                    myPen.Dispose();
                }
            }

            //draw the special structures

            foreach (List<string> l in transmission)
            {
                if (l.Count == 4)
                {
                    if (l[2] == "ResourceWell")
                    {
                        c = Color.White;

                        switch (l[3])
                        {
                            case "1":
                                c = Color.Orchid;
                                break;
                            case "2":
                                c = Color.Aqua;
                                break;
                            case "3":
                                c = Color.Yellow;
                                break;
                            case "4":
                                c = Color.Olive;
                                break;
                        }
                    }
                    else
                    {
                        switch (l[2])
                        {
                            case "Portal":
                                c = Color.AliceBlue;
                                break;

                            case "OffenceBoost":
                                c = Color.DarkRed;
                                break;

                            case "DeffenceBoost":
                                c = Color.DarkOrange;
                                break;

                            case "ManufacturingBoost":
                                c = Color.DarkGreen;
                                break;
                        }
                    }

                    maptile = new Bitmap(26, 26);
                    tilegraph = Graphics.FromImage(maptile);
                    b = new SolidBrush(c);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(Convert.ToInt32(l[0]) * 26, Convert.ToInt32(l[1]) * 26));
                }
            }




            foreach (List<string> l in transmission)
            {
                if (l.Count == 7)
                {
                    Pen myPen;
                    myPen = new System.Drawing.Pen(System.Drawing.Color.Blue);
                    myPen.Width = 2;


                    mapgraph.DrawLine(myPen, Convert.ToInt32(l[0]) * 26 + 13, Convert.ToInt32(l[1]) * 26 + 13, Convert.ToInt32(l[2]) * 26 + 13, Convert.ToInt32(l[3]) * 26 + 13);

                    myPen.Color = Color.Yellow;
                    mapgraph.DrawLine(myPen, Convert.ToInt32(l[2]) * 26, Convert.ToInt32(l[3]) * 26, Convert.ToInt32(l[2]) * 26 + 26, Convert.ToInt32(l[3]) * 26 + 26);
                    mapgraph.DrawLine(myPen, Convert.ToInt32(l[2]) * 26 + 26, Convert.ToInt32(l[3]) * 26, Convert.ToInt32(l[2]) * 26, Convert.ToInt32(l[3]) * 26 + 26);

                    myPen.Width = 6;

                    float delta = Convert.ToInt32(l[6]) - Convert.ToInt32(l[4]);
                    float result = delta / Convert.ToInt32(l[5]);

                    if (result > 1)
                    {
                        result = 1;
                    }

                    int origX = Convert.ToInt32(l[0]);
                    int origY = Convert.ToInt32(l[1]);

                    int destX = Convert.ToInt32(l[2]);
                    int destY = Convert.ToInt32(l[3]);

                    int x = 0;
                    int y = 0;

                    float fx = 0;
                    float fy = 0;

                    if (origX >= destX)
                    {
                        x = destX - origX;
                        x = x * 26;
                        fx = x * result;
                        x = (origX) * 26;
                        x = x + Convert.ToInt32(fx) + 13;
                    }
                    else
                    {
                        x = destX - origX;
                        x = x * 26;
                        fx = x * result;
                        x = (origX) * 26;
                        x = x + Convert.ToInt32(fx) + 13;
                    }

                    if (origY >= destY)
                    {
                        y = origY - destY;
                        y = y * 26;
                        fy = y * result;
                        y = (origY) * 26;
                        y = y - Convert.ToInt32(fy) + 13;
                    }
                    else
                    {
                        y = origY - destY;
                        y = y * 26;
                        fy = y * result;
                        y = (origY) * 26;
                        y = y - Convert.ToInt32(fy) + 13;
                    }


                    myPen.Color = Color.Yellow;
                    mapgraph.DrawLine(myPen, new Point(x - 2, y - 2), new Point(x + 2, y + 2));



                    myPen.Dispose();
                }
            }

            mainMapBuffer = MapImage;
            MapCanvas.Image = MapImage;
        }

        void MapCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentView == 2)
            {
                if (mainMapBuffer == null)
                {
                    mainMapBuffer = (Bitmap)MapCanvas.Image;
                }

                Bitmap Conduit = new Bitmap(1, 1);
                Conduit = (Bitmap)mainMapBuffer.Clone();


                MapCanvas.Image = Conduit;

                Graphics mapgraph = Graphics.FromImage(MapCanvas.Image);
                Pen myPen;
                myPen = new System.Drawing.Pen(System.Drawing.Color.DarkRed, 2);

                mapgraph.DrawLine(myPen, new Point(_currentX * 26 + 13, _currentY * 26 + 13), new Point((e.X) - (e.X % 26) + 13, (e.Y) - (e.Y % 26) + 13));
            }

            if (CurrentView == 7)
            {
                if (mainMapBuffer == null)
                {
                    mainMapBuffer = (Bitmap)MapCanvas.Image;
                }

                Bitmap Conduit = new Bitmap(1, 1);
                Conduit = (Bitmap)mainMapBuffer.Clone();

                MapCanvas.Image = Conduit;

                Graphics mapgraph = Graphics.FromImage(MapCanvas.Image);
                Pen myPen;
                myPen = new System.Drawing.Pen(System.Drawing.Color.Green, 2);

                mapgraph.DrawLine(myPen, new Point(_currentX * 26 + 13, _currentY * 26 + 13), new Point((e.X) - (e.X % 26) + 13, (e.Y) - (e.Y % 26) + 13));
            }
        }

        private void MapCanvas_Click(object sender, EventArgs e)
        {
            MouseEventArgs m = (MouseEventArgs)e;

            int mx = m.X;
            int my = m.Y;

            mx = (mx - (mx % 26)) / 26;
            my = (my - (my % 26)) / 26;

            LblSelectedBase.Text = "";

            hideMenus();

            if (CurrentView == 0)
            {
                if (m.Button == MouseButtons.Left)
                {
                    ServerConnection sc = new ServerConnection();
                    sc.ServerRequest(UpdateSidePanel, 4, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(mx) + MessageConstants.splitToken + Convert.ToString(my) + MessageConstants.nextToken + SendCurrentAddress() + MessageConstants.completeToken);
                }
            }

            if (CurrentView == 1)
            {
                if (m.Button == MouseButtons.Left)
                {
                    _currentX = mx;
                    _currentY = my;
                    ServerConnection sc = new ServerConnection();
                    sc.ServerRequest(UpdateSidePanel, 5, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(mx) + MessageConstants.splitToken + Convert.ToString(my) + MessageConstants.nextToken + SendCurrentAddress() + MessageConstants.completeToken);
                }
            }

            if (CurrentView == 2)
            {
                if (m.Button == MouseButtons.Left)
                {
                    _targetX = mx;
                    _targetY = my;

                    //get the current offence in that place now, and allow them to use it;
                    ServerConnection sc = new ServerConnection();
                    sc.ServerRequest(DisplayAttack, 13, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(_currentX) + MessageConstants.splitToken + Convert.ToString(_currentY) + MessageConstants.nextToken + SendCurrentAddress() + MessageConstants.completeToken);

                }
            }

            if (CurrentView == 3)
            {
                if (m.Button == MouseButtons.Left)
                {
                    _currentX = mx;
                    _currentY = my;
                    RefreshMainMap();
                }
            }

            if (CurrentView == 4)
            {
                if (m.Button == MouseButtons.Left)
                {
                    _currentX = mx;
                    _currentY = my;
                    ServerConnection sc = new ServerConnection();
                    sc.ServerRequest(RenderSolarMap, 17, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(mx) + MessageConstants.splitToken + Convert.ToString(my) + MessageConstants.splitToken + _currentCluster + MessageConstants.completeToken);
                }
            }

            if (CurrentView == 5)
            {
                if (m.Button == MouseButtons.Left)
                {
                    _currentX = mx;
                    _currentY = my;
                    ServerConnection sc = new ServerConnection();
                    sc.ServerRequest(RenderClusterMap, 18, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(mx) + MessageConstants.splitToken + Convert.ToString(my) + MessageConstants.completeToken);
                }
            }


            if (CurrentView == 6)
            {
                if (m.Button == MouseButtons.Left)
                {
                    _targetX = mx;
                    _targetY = my;
                    ServerConnection sc = new ServerConnection();
                    sc.ServerRequest(UpdateReinforcePanel, 21, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(_currentX) + MessageConstants.splitToken + Convert.ToString(_currentY) + MessageConstants.nextToken + SendCurrentAddress());
                }
            }

            if (CurrentView == 7)
            {
                _targetX = mx;
                _targetY = my;
                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(UpdateMoveBase, 26, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.nextToken + Convert.ToString(_currentX) + MessageConstants.splitToken + Convert.ToString(_currentY) + MessageConstants.splitToken + Convert.ToString(_targetX) + MessageConstants.splitToken + Convert.ToString(_targetY) + MessageConstants.nextToken + SendCurrentAddress());
            }
        }

        private void UpdateMoveBase(List<List<string>> transmission)
        {

            hideMenus();
            CurrentView = 1;
            if (transmission[1][0] == "success")
            {
                MessageBox.Show("Base Moving");
            }
            else
            {
                MessageBox.Show(transmission[1][0]);
                return;
            }
            RefreshMainMap();

        }

        private void RefreshMainMap()
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(RenderMainMap, 3, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(_currentX) + MessageConstants.splitToken + Convert.ToString(_currentY) + MessageConstants.splitToken + _currentCluster + MessageConstants.splitToken + _currentSolarSystem + MessageConstants.completeToken);
        }

        private void DisplayAttack(List<List<string>> transmission)
        {

            hideMenus();
            if (transmission[1][0] == "-1")
            {
                MessageBox.Show("You don't own an outpost here");
                return;
            }
            showAttackMenu(true);

            lblAttackScout.Text = "Scout: " + transmission[1][0];
            lblAttackGunship.Text = "Gunship: " + transmission[1][1];
            lblAttackBomber.Text = "Bomber: " + transmission[1][2];
            lblAttaackFrigate.Text = "Frigate: " + transmission[1][3];
            lblAttackDestroyer.Text = "Destroyer: " + transmission[1][4];
            lblAttackCarrier.Text = "Carrier: " + transmission[1][5];
            lblAttackBattleship.Text = "BattleShip: " + transmission[1][6];

        }

        private void showAttackMenu(bool show)
        {
            MapCanvas.Visible = !show;

            lblAttaackFrigate.Visible = show;
            lblAttackBattleship.Visible = show;
            lblAttackBomber.Visible = show;
            lblAttackCarrier.Visible = show;
            lblAttackDestroyer.Visible = show;
            lblAttackGunship.Visible = show;
            lblAttackScout.Visible = show;

            txtAttackBattleship.Visible = show;
            txtAttackBomber.Visible = show;
            txtAttackCarrier.Visible = show;
            txtAttackDestroyer.Visible = show;
            txtAttackFrigate.Visible = show;
            txtAttackGunship.Visible = show;
            txtAttackScout.Visible = show;

            btnSendAttack.Visible = show;
        }

        private void hideMenus()
        {
            showBuildmenu(false);
            showDefenceMenu(false);
            showOffenceMenu(false);
            showAttackMenu(false);
            showReinforcemenu(false);

            LblNewBaseCost.Visible = false;

            if (CurrentView == 3)
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }

        }

        private void UpdateSidePanel(List<List<string>> transmission)
        {
            if (transmission[0][0] == MessageConstants.MessageTypes[4])
            {
                LblSidePanel.Text = "Metal: " + transmission[1][0] + " Organics: " + transmission[1][1] + " Water: " + transmission[1][2];

            }

            if (transmission[0][0] == MessageConstants.MessageTypes[5])
            {

                if (transmission[1][0] == "-1")
                {
                    LblSidePanel.Text = "unoccipied land";
                    _currentX = -1;
                    _currentY = -1;
                }

                if (transmission[1][0] == "Enemy")
                {
                    LblSidePanel.Text = "Land occupied by other forces";
                    _currentX = -1;
                    _currentY = -1;
                }
            }
        }

        private void BtnBuild_Click(object sender, EventArgs e)
        {
            GetBuildingView();
        }

        private void GetBuildingView()
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(UpdateBuildPanel, 7, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(_currentX) + MessageConstants.splitToken + Convert.ToString(_currentY) + MessageConstants.nextToken + SendCurrentAddress());
        }

        private void UpdateBuildPanel(List<List<string>> transmission)
        {
            hideMenus();
            if (transmission[1][0] == "-1")
            {
                MessageBox.Show("You don't own an outpost here");
                return;
            }



            showBuildmenu(true);
            lblEmpty.Text = "Empty: " + transmission[1][1];
            LblFarm.Text = "farm: " + transmission[1][2];
            lblHabitat.Text = "habitat: " + transmission[1][3];
            lblMine.Text = "mine: " + transmission[1][4];
            LblSolarPlant.Text = "solar plant: " + transmission[1][5];
            lblWell.Text = "well: " + transmission[1][6];
            lblfabricator.Text = "fabricator: " + transmission[1][7];

            lblCostFarm.Text = updateBuildPanelCostString(transmission, 3);
            LblCostHabitabt.Text = updateBuildPanelCostString(transmission, 4);
            LblCostMine.Text = updateBuildPanelCostString(transmission, 5);
            lblCostSolarPlant.Text = updateBuildPanelCostString(transmission, 6);
            lblCostWell.Text = updateBuildPanelCostString(transmission, 7);
            lblCostFabricator.Text = updateBuildPanelCostString(transmission, 8);

            int nonEmptyValue = -1;

            for (int i = 9; i < 15; i++)
            {

                foreach (string s in transmission[i])
                {
                    nonEmptyValue++;
                    if (s != "0")
                    {
                        switch (nonEmptyValue)
                        {
                            case 0:
                                lblProductionMine.Text = "metal: " + s;
                                break;
                            case 1:
                                lblProductionWell.Text = "water: " + s;
                                break;
                            case 2:
                                lblProductionHabitat.Text = "population: " + s;
                                break;
                            case 3:
                                lblProductionFarm.Text = "food: " + s;
                                break;
                            case 4:
                                lblProductionSolar.Text = "power: " + s;
                                break;
                        }
                    }
                }
                nonEmptyValue = -1;
            }

            lblBuildFarm.Text = transmission[15][3];
            lblBuildHabitat.Text = transmission[15][2];
            lblBuildMine.Text = transmission[15][0];
            LblBuildSolarPlant.Text = transmission[15][4];
            lblBuildWell.Text = transmission[15][1];
            lblBuildFabricator.Text = transmission[15][5];

            LstBuildingsBuildQueue.Items.Clear();
            BuildGuidList = new Dictionary<int, Guid>();

            for (int i = 16; i < transmission.Count; i++)
            {
                if (transmission[i].Count == 4)
                {
                    LstBuildingsBuildQueue.Items.Add(transmission[i][0] + "  " + transmission[i][2] + "/" + transmission[i][1]);
                    BuildGuidList.Add(i - 16, new Guid(transmission[i][3]));
                }
            }

            LblCostEmpty.Text = "metal: " + transmission[16][0] + " water: " + transmission[16][1] + " population: " + transmission[16][2] + " food: " + transmission[16][3] + " power: " + transmission[16][4];

        }

        private string updateBuildPanelCostString(List<List<string>> transmission, int x)
        {
            return string.Format("Population: {0}, Metal: {1}, Water: {2}, Power: {3}, Food {4}", transmission[x][0], transmission[x][1], transmission[x][2], transmission[x][3], transmission[x][4]);
        }

        private void showReinforcemenu(bool show)
        {
            lblReinforceArtillery.Visible = show;
            lblReinforceBattleShip.Visible = show;
            lblReinforceBomber.Visible = show;
            lblReinforceCarrier.Visible = show;
            lblReinforceDestroyer.Visible = show;
            lblReinforceDroneBase.Visible = show;
            lblReinforceFrigate.Visible = show;
            lblReinforceGunner.Visible = show;
            lblReinforceGunship.Visible = show;
            lblReinforcePatrol.Visible = show;
            lblReinforceScout.Visible = show;
            lblReinforceTurret.Visible = show;

            txtReinforceArtillery.Visible = show;
            txtReinforceBattleship.Visible = show;
            txtReinforceBomber.Visible = show;
            txtReinforceCarrier.Visible = show;
            txtReinforceDestroyer.Visible = show;
            txtReinforceDroneBase.Visible = show;
            txtReinforceFrigate.Visible = show;
            txtReinforceGunner.Visible = show;
            txtReinforceGunship.Visible = show;
            txtReinforcePartrol.Visible = show;
            txtReinforceScout.Visible = show;
            txtReinforceTurret.Visible = show;

            cmdReinforce.Visible = show;
            button7.Visible = !show;

        }

        private void showBuildmenu(bool show)
        {
            lblExtant.Visible = show;
            lblBuild.Visible = show;
            lblFuture.Visible = show;

            LblFarm.Visible = show;
            lblHabitat.Visible = show;
            lblWell.Visible = show;
            lblfabricator.Visible = show;
            lblMine.Visible = show;
            lblEmpty.Visible = show;
            LblSolarPlant.Visible = show;

            txtFabricator.Visible = show;
            txtFarm.Visible = show;
            txtHabitat.Visible = show;
            txtMine.Visible = show;
            txtSolarPlant.Visible = show;
            txtWell.Visible = show;

            lblBuildFabricator.Visible = show;
            lblBuildFarm.Visible = show;
            lblBuildHabitat.Visible = show;
            lblBuildMine.Visible = show;
            lblBuildWell.Visible = show;
            LblBuildSolarPlant.Visible = show;

            LblCostHabitabt.Visible = show;
            LblCostMine.Visible = show;
            lblCostFabricator.Visible = show;
            lblCostFarm.Visible = show;
            lblCostSolarPlant.Visible = show;
            lblCostWell.Visible = show;
            lblCost.Visible = show;
            LblCostEmpty.Visible = show;

            lblProduction.Visible = show;
            lblProductionFabricator.Visible = show;
            lblProductionFarm.Visible = show;
            lblProductionHabitat.Visible = show;
            lblProductionMine.Visible = show;
            lblProductionSolar.Visible = show;
            lblProductionWell.Visible = show;

            BtnExpandBase.Visible = show;

            cmdBuild.Visible = show;

            MapCanvas.Visible = !show;

            BtnBuild.Visible = !show;
            btnBuildDefence.Visible = !show;

            BtnDef.Visible = !show;

            LblSidePanel.Visible = !show;

            LstBuildingsBuildQueue.Visible = show;
            btnRemoveBuildings.Visible = show;

        }

        private void showDefenceMenu(bool show)
        {

            lblDefExtant.Visible = show;
            lblDefBuild.Visible = show;
            lblDefFuture.Visible = show;
            lblDefCost.Visible = show;
            lblDefPoints.Visible = show;

            lblPatrol.Visible = show;
            lblGunner.Visible = show;
            lblTurret.Visible = show;
            lblArtillery.Visible = show;
            lblDroneBase.Visible = show;

            txtPatrol.Visible = show;
            txtGunner.Visible = show;
            txtTurret.Visible = show;
            txtArtillery.Visible = show;
            txtDroneBase.Visible = show;

            lblPatrolBuild.Visible = show;
            lblGunnerBuild.Visible = show;
            lblTurretBuild.Visible = show;
            lblArtilleryBuild.Visible = show;
            lblDroneBaseBuild.Visible = show;

            lblCostPatrol.Visible = show;
            lblCostGunner.Visible = show;
            lblCostTurret.Visible = show;
            lblCostArtillery.Visible = show;
            lblCostDroneBase.Visible = show;


            lblDefencePatrol.Visible = show;
            lblDefenceGunner.Visible = show;
            lblDefenceTurret.Visible = show;
            lblDefenceArtillery.Visible = show;
            lblDefenceDroneBase.Visible = show;

            btnBuildDefence.Visible = show;

            MapCanvas.Visible = !show;

            BtnBuild.Visible = !show;
            btnBuildDefence.Visible = show;
            BtnDef.Visible = !show;

            LblSidePanel.Visible = !show;

            LstRemoveDefenceList.Visible = show;
            btnRemoveDefenceList.Visible = show;
        }

        private void cmdBuild_Click(object sender, EventArgs e)
        {
            List<int> buildList = new List<int>();
            try
            {
                buildList.Add(Convert.ToInt32(txtMine.Text));
                buildList.Add(Convert.ToInt32(txtWell.Text));
                buildList.Add(Convert.ToInt32(txtHabitat.Text));
                buildList.Add(Convert.ToInt32(txtFarm.Text));
                buildList.Add(Convert.ToInt32(txtSolarPlant.Text));
                buildList.Add(Convert.ToInt32(txtFabricator.Text));

                string request = MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.nextToken;

                foreach (int i in buildList)
                {
                    request += i + MessageConstants.splitToken;
                }

                request += MessageConstants.nextToken;
                request += _currentX + MessageConstants.splitToken + _currentY;

                request += MessageConstants.nextToken + SendCurrentAddress();


                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(ConfirmBuildQueue, 8, request);



            }
            catch (Exception)
            {
                txtMine.Text = "0";
                txtWell.Text = "0";
                txtHabitat.Text = "0";
                txtFarm.Text = "0";
                txtSolarPlant.Text = "0";
                txtFabricator.Text = "0";

                MessageBox.Show("Invalid Input");

            }

        }

        private void ConfirmBuildQueue(List<List<string>> transmission)
        {

            MessageBox.Show(transmission[0][1]);

            if (transmission[0][0] == MessageConstants.MessageTypes[8] || transmission[0][0] == MessageConstants.MessageTypes[30])
            {
                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(UpdateBuildPanel, 7, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(_currentX) + MessageConstants.splitToken + Convert.ToString(_currentY) + MessageConstants.nextToken + SendCurrentAddress());
            }

            if (transmission[0][0] == MessageConstants.MessageTypes[10])
            {
                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(UpdateBuildDefPanel, 9, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(_currentX) + MessageConstants.splitToken + Convert.ToString(_currentY) + MessageConstants.nextToken + SendCurrentAddress());
            }

            if (transmission[0][0] == MessageConstants.MessageTypes[12])
            {
                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(UpdateBuildOffPanel, 11, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(_currentX) + MessageConstants.splitToken + Convert.ToString(_currentY) + MessageConstants.nextToken + SendCurrentAddress());
            }


        }

        private void lblBuild_Click(object sender, EventArgs e)
        {

        }

        private void BtnDef_Click(object sender, EventArgs e)
        {
            GetDefenceList();
        }

        private void GetDefenceList()
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(UpdateBuildDefPanel, 9, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(_currentX) + MessageConstants.splitToken + Convert.ToString(_currentY) + MessageConstants.nextToken + SendCurrentAddress());
        }

        private void UpdateBuildDefPanel(List<List<string>> transmission)
        {
            hideMenus();
            if (transmission[1][0] == "-1")
            {
                MessageBox.Show("You don't own an outpost here");
                return;
            }
            showDefenceMenu(true);
            lblPatrol.Text = "patrol: " + transmission[1][1];
            lblGunner.Text = "gunner: " + transmission[1][2];
            lblTurret.Text = "turret: " + transmission[1][3];
            lblArtillery.Text = "artillery: " + transmission[1][4];
            lblDroneBase.Text = "drone base: " + transmission[1][5];

            lblCostPatrol.Text = updateBuildPanelCostString(transmission, 3);
            lblCostGunner.Text = updateBuildPanelCostString(transmission, 4);
            lblCostTurret.Text = updateBuildPanelCostString(transmission, 5);
            lblCostArtillery.Text = updateBuildPanelCostString(transmission, 6);
            lblCostDroneBase.Text = updateBuildPanelCostString(transmission, 7);



            int nonEmptyValue = -1;

            for (int i = 3; i < 9; i++)
            {

                foreach (string s in transmission[i])
                {
                    nonEmptyValue++;
                    if (s != "0")
                    {
                        switch (nonEmptyValue)
                        {
                            case 0:
                                lblProductionMine.Text = "metal: " + s;
                                break;
                            case 1:
                                lblProductionWell.Text = "water: " + s;
                                break;
                            case 2:
                                lblProductionHabitat.Text = "population: " + s;
                                break;
                            case 3:
                                lblProductionFarm.Text = "food: " + s;
                                break;
                            case 4:
                                lblProductionSolar.Text = "power: " + s;
                                break;
                        }
                    }
                }
                nonEmptyValue = -1;
            }

            lblPatrolBuild.Text = transmission[9][0];
            lblGunnerBuild.Text = transmission[9][1];
            lblTurretBuild.Text = transmission[9][2];
            lblArtilleryBuild.Text = transmission[9][3];
            lblDroneBaseBuild.Text = transmission[9][4];


            LstRemoveDefenceList.Items.Clear();
            BuildGuidList = new Dictionary<int, Guid>();

            for (int i = 10; i < transmission.Count; i++)
            {
                if (transmission[i].Count == 4)
                {
                    LstRemoveDefenceList.Items.Add(transmission[i][0] + "  " + transmission[i][2] + "/" + transmission[i][1]);
                    BuildGuidList.Add(i - 10, new Guid(transmission[i][3]));
                }
            }

        }

        private void btnBuildDefence_Click(object sender, EventArgs e)
        {
            List<int> defBuildList = new List<int>();
            try
            {
                defBuildList.Add(Convert.ToInt32(txtPatrol.Text));
                defBuildList.Add(Convert.ToInt32(txtGunner.Text));
                defBuildList.Add(Convert.ToInt32(txtTurret.Text));
                defBuildList.Add(Convert.ToInt32(txtArtillery.Text));
                defBuildList.Add(Convert.ToInt32(txtDroneBase.Text));

                string request = MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.nextToken;

                foreach (int i in defBuildList)
                {
                    request += i + MessageConstants.splitToken;
                }

                request += MessageConstants.nextToken;
                request += _currentX + MessageConstants.splitToken + _currentY;
                request += MessageConstants.nextToken + SendCurrentAddress();
                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(ConfirmBuildQueue, 10, request);


            }
            catch (Exception)
            {
                txtMine.Text = "0";
                txtWell.Text = "0";
                txtHabitat.Text = "0";
                txtFarm.Text = "0";
                txtSolarPlant.Text = "0";
                txtFabricator.Text = "0";

                MessageBox.Show("Invalid Input");

            }


        }

        private void BtnOffence_Click(object sender, EventArgs e)
        {
            GetoffenceList();
        }

        private void GetoffenceList()
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(UpdateBuildOffPanel, 11, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(_currentX) + MessageConstants.splitToken + Convert.ToString(_currentY) + MessageConstants.nextToken + SendCurrentAddress());
        }

        private void showOffenceMenu(bool show)
        {

            lblOffExtant.Visible = show;
            lblOffBuild.Visible = show;
            lblOffFuture.Visible = show;
            lblOffCost.Visible = show;
            lblOffenceAttack.Visible = show;

            lblScout.Visible = show;
            lblGunship.Visible = show;
            lblBomber.Visible = show;
            lblFrigate.Visible = show;
            lblDestroyer.Visible = show;
            lblCarrier.Visible = show;
            lblBattleship.Visible = show;

            lblScoutBuild.Visible = show;
            lblGunshipBuild.Visible = show;
            lblBomberBuild.Visible = show;
            lblFrigateBuild.Visible = show;
            lblDestroyerBuild.Visible = show;
            lblCarrierBuild.Visible = show;
            lblBattleshipBuild.Visible = show;

            lblCostScout.Visible = show;
            lblCostGunship.Visible = show;
            lblCostBomber.Visible = show;
            lblCostFrigate.Visible = show;
            lblCostDestroyer.Visible = show;
            lblCostCarrier.Visible = show;
            lblCostBattleship.Visible = show;

            lblScoutAttack.Visible = show;
            lblGunshipAttack.Visible = show;
            lblBomberAttack.Visible = show;
            lblFrigateAttack.Visible = show;
            lblDestoyerAttack.Visible = show;
            lblCarrierAttack.Visible = show;
            lblBattleshipAttack.Visible = show;

            txtScout.Visible = show;
            txtGunship.Visible = show;
            txtBomber.Visible = show;
            txtFrigate.Visible = show;
            txtDestroyer.Visible = show;
            txtCarrier.Visible = show;
            txtBattleship.Visible = show;

            btnOffenceBuild.Visible = show;

            MapCanvas.Visible = !show;

            BtnBuild.Visible = !show;
            btnBuildDefence.Visible = !show;
            BtnDef.Visible = !show;
            BtnOffence.Visible = !show;
            BtnAttack.Visible = !show;
            BtnMoveOutpost.Visible = !show;

            LblSidePanel.Visible = !show;

            LstRemoveOffenceList.Visible = show;
            btnRemoveOffenceList.Visible = show;
        }

        private void UpdateBuildOffPanel(List<List<string>> transmission)
        {

            hideMenus();
            if (transmission[1][0] == "-1")
            {
                MessageBox.Show("You don't own an outpost here");
                return;
            }
            showOffenceMenu(true);

            lblScout.Text = "scout: " + transmission[1][0];
            lblGunship.Text = "gunship: " + transmission[1][1];
            lblBomber.Text = "bomber: " + transmission[1][2];
            lblFrigate.Text = "frigate: " + transmission[1][3];
            lblDestroyer.Text = "destroyer: " + transmission[1][4];
            lblCarrier.Text = "carrier:" + transmission[1][5];
            lblBattleship.Text = "battleship:" + transmission[1][6];

            lblCostScout.Text = updateBuildPanelCostString(transmission, 3);
            lblCostGunship.Text = updateBuildPanelCostString(transmission, 4);
            lblCostBomber.Text = updateBuildPanelCostString(transmission, 5);
            lblCostFrigate.Text = updateBuildPanelCostString(transmission, 6);
            lblCostDestroyer.Text = updateBuildPanelCostString(transmission, 7);
            lblCostCarrier.Text = updateBuildPanelCostString(transmission, 8);
            lblCostBattleship.Text = updateBuildPanelCostString(transmission, 9);



            int nonEmptyValue = -1;

            for (int i = 3; i < 9; i++)
            {

                foreach (string s in transmission[i])
                {
                    nonEmptyValue++;
                    if (s != "0")
                    {
                        switch (nonEmptyValue)
                        {
                            case 0:
                                lblProductionMine.Text = "metal: " + s;
                                break;
                            case 1:
                                lblProductionWell.Text = "water: " + s;
                                break;
                            case 2:
                                lblProductionHabitat.Text = "population: " + s;
                                break;
                            case 3:
                                lblProductionFarm.Text = "food: " + s;
                                break;
                            case 4:
                                lblProductionSolar.Text = "power: " + s;
                                break;
                        }
                    }
                }
                nonEmptyValue = -1;
            }

            lblScoutBuild.Text = transmission[10][0];
            lblGunshipBuild.Text = transmission[10][1];
            lblBomberBuild.Text = transmission[10][2];
            lblFrigateBuild.Text = transmission[10][3];
            lblDestroyerBuild.Text = transmission[10][4];
            lblCarrierBuild.Text = transmission[10][5];
            lblBattleshipBuild.Text = transmission[10][6];

            lblScoutAttack.Text = transmission[12][0];
            lblGunshipAttack.Text = transmission[12][1];
            lblBomberAttack.Text = transmission[12][2];
            lblFrigateAttack.Text = transmission[12][3];
            lblDestoyerAttack.Text = transmission[12][4];
            lblCarrierAttack.Text = transmission[12][5];
            lblBattleshipAttack.Text = transmission[12][6];

            LstRemoveOffenceList.Items.Clear();
            BuildGuidList = new Dictionary<int, Guid>();

            for (int i = 13; i < transmission.Count; i++)
            {
                if (transmission[i].Count == 4)
                {
                    LstRemoveOffenceList.Items.Add(transmission[i][0] + "  " + transmission[i][2] + "/" + transmission[i][1]);
                    BuildGuidList.Add(i - 13, new Guid(transmission[i][3]));
                }
            }
        }

        private void btnOffenceBuild_Click(object sender, EventArgs e)
        {
            List<int> OffBuildList = new List<int>();
            try
            {
                OffBuildList.Add(Convert.ToInt32(txtScout.Text));
                OffBuildList.Add(Convert.ToInt32(txtGunship.Text));
                OffBuildList.Add(Convert.ToInt32(txtBomber.Text));
                OffBuildList.Add(Convert.ToInt32(txtFrigate.Text));
                OffBuildList.Add(Convert.ToInt32(txtDestroyer.Text));
                OffBuildList.Add(Convert.ToInt32(txtCarrier.Text));
                OffBuildList.Add(Convert.ToInt32(txtBattleship.Text));

                string request = MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.nextToken;

                foreach (int i in OffBuildList)
                {
                    request += i + MessageConstants.splitToken;
                }

                request += MessageConstants.nextToken;
                request += _currentX + MessageConstants.splitToken + _currentY;

                request += MessageConstants.nextToken + SendCurrentAddress();

                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(ConfirmBuildQueue, 12, request);

            }
            catch (Exception)
            {
                txtScout.Text = "0";
                txtGunship.Text = "0";
                txtBomber.Text = "0";
                txtFrigate.Text = "0";
                txtDestroyer.Text = "0";
                txtCarrier.Text = "0";
                txtBattleship.Text = "0";

                MessageBox.Show("Invalid Input");

            }
        }

        private void BtnAttack_Click(object sender, EventArgs e)
        {
            LblSidePanel.Text = "SelectTarget";
            CurrentView = 2;
        }

        private void btnSendAttack_Click(object sender, EventArgs e)
        {
            List<int> AttackList = new List<int>();
            try
            {
                AttackList.Add(Convert.ToInt32(txtAttackScout.Text));
                AttackList.Add(Convert.ToInt32(txtAttackGunship.Text));
                AttackList.Add(Convert.ToInt32(txtAttackBomber.Text));
                AttackList.Add(Convert.ToInt32(txtAttackFrigate.Text));
                AttackList.Add(Convert.ToInt32(txtAttackDestroyer.Text));
                AttackList.Add(Convert.ToInt32(txtAttackCarrier.Text));
                AttackList.Add(Convert.ToInt32(txtAttackBattleship.Text));

                string request = MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.nextToken;

                request += _currentX + MessageConstants.splitToken + _currentY + MessageConstants.splitToken + _targetX + MessageConstants.splitToken + _targetY + MessageConstants.nextToken;

                foreach (int i in AttackList)
                {
                    request += i + MessageConstants.splitToken;
                }

                request += MessageConstants.nextToken;
                request += _currentX + MessageConstants.splitToken + _currentY;

                request += MessageConstants.nextToken + SendCurrentAddress() + MessageConstants.completeToken;

                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(ResultsOfAttack, 14, request);

            }
            catch (Exception)
            {
                txtAttackScout.Text = "0";
                txtAttackGunship.Text = "0";
                txtAttackBomber.Text = "0";
                txtAttackFrigate.Text = "0";
                txtAttackDestroyer.Text = "0";
                txtAttackCarrier.Text = "0";
                txtAttackBattleship.Text = "0";

                MessageBox.Show("Invalid Input");

            }
        }

        private void ResultsOfAttack(List<List<string>> transmission)
        {
            if (transmission[0][1] == "Error")
            {
                MessageBox.Show(transmission[0][2]);
            }
            RefreshMainMap();
        }

        private void BtnMessages_Click(object sender, EventArgs e)
        {

            if (frmMessage == null || frmMessage.IsDisposed)
            {
                frmMessage = new Messages();
            }
            frmMessage.Init(playerToken);
            frmMessage.Show();

        }

        private void CheckLoggedOut(List<List<string>> transmission)
        {
            if (transmission[1][0] == "Logout")
            {
                MessageBox.Show("user token wrong, user logged out");
                this.Close();
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CurrentView = 3;
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(RenderSolarMap, 17, MessageConstants.splitToken + Convert.ToString(playerToken));
            hideMenus();
        }

        private void RenderSolarMap(List<List<string>> transmission)
        {
            CurrentView = 3;
            CheckLoggedOut(transmission);

            Bitmap MapImage = new Bitmap(MapCanvas.Width, MapCanvas.Height);

            Graphics mapgraph = Graphics.FromImage(MapImage);

            Bitmap maptile = new Bitmap(26, 26);
            Graphics tilegraph = Graphics.FromImage(maptile);

            Color c = Color.Black;
            SolidBrush b = new SolidBrush(c);
            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    maptile = new Bitmap(26, 26);
                    tilegraph = Graphics.FromImage(maptile);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(x * 26, y * 26));
                }
            }

            foreach (List<string> l in transmission)
            {
                if (l.Count == 3)
                {
                    c = Color.White;

                    switch (l[2])
                    {
                        case "0":
                            c = Color.FromArgb(255, 255, 3);
                            break;

                        case "1":
                            c = Color.FromArgb(151, 189, 0);
                            break;

                        case "2":
                            c = Color.FromArgb(255, 255, 255);
                            break;

                        case "3":
                            c = Color.FromArgb(255, 255, 255);
                            break;

                        case "4":
                            c = Color.FromArgb(255, 255, 150);
                            break;

                        case "5":
                            c = Color.FromArgb(3, 3, 250);
                            break;

                        case "6":
                            c = Color.FromArgb(238, 247, 136);
                            break;

                        case "7":
                            c = Color.FromArgb(143, 155, 255);
                            break;

                        case "8":
                            c = Color.FromArgb(255, 255, 166);
                            break;

                        case "9":
                            c = Color.FromArgb(106, 106, 166);
                            break;

                        case "10":
                            c = Color.FromArgb(140, 140, 52);
                            break;

                        default:
                            c = Color.FromArgb(130, 130, 10);
                            break;
                    }

                    maptile = new Bitmap(26, 26);
                    tilegraph = Graphics.FromImage(maptile);
                    b = new SolidBrush(c);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(Convert.ToInt32(l[0]) * 26, Convert.ToInt32(l[1]) * 26));

                }
            }
            MapCanvas.Image = MapImage;
        }

        private void RenderClusterMap(List<List<string>> transmission)
        {
            CurrentView = 4;
            CheckLoggedOut(transmission);

            _currentCluster = Convert.ToInt32(transmission[1][0]);

            Bitmap MapImage = new Bitmap(MapCanvas.Width, MapCanvas.Height);

            Graphics mapgraph = Graphics.FromImage(MapImage);

            Bitmap maptile = new Bitmap(26, 26);
            Graphics tilegraph = Graphics.FromImage(maptile);

            Color c = Color.Black;
            SolidBrush b = new SolidBrush(c);
            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    maptile = new Bitmap(26, 26);
                    tilegraph = Graphics.FromImage(maptile);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(x * 26, y * 26));
                }
            }

            foreach (List<string> l in transmission)
            {
                if (l.Count == 3)
                {
                    c = Color.White;

                    switch (l[2])
                    {
                        case "0":
                            c = Color.FromArgb(255, 255, 3);
                            break;

                        case "1":
                            c = Color.FromArgb(151, 189, 0);
                            break;

                        case "2":
                            c = Color.FromArgb(255, 255, 255);
                            break;

                        case "3":
                            c = Color.FromArgb(255, 255, 255);
                            break;

                        case "4":
                            c = Color.FromArgb(255, 255, 150);
                            break;

                        case "5":
                            c = Color.FromArgb(3, 3, 250);
                            break;

                        case "6":
                            c = Color.FromArgb(238, 247, 136);
                            break;

                        case "7":
                            c = Color.FromArgb(143, 155, 255);
                            break;

                        case "8":
                            c = Color.FromArgb(255, 255, 166);
                            break;

                        case "9":
                            c = Color.FromArgb(106, 106, 166);
                            break;

                        case "10":
                            c = Color.FromArgb(140, 140, 52);
                            break;

                        default:
                            c = Color.FromArgb(130, 130, 10);
                            break;
                    }

                    maptile = new Bitmap(26, 26);
                    tilegraph = Graphics.FromImage(maptile);
                    b = new SolidBrush(c);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(Convert.ToInt32(l[0]) * 26, Convert.ToInt32(l[1]) * 26));

                }
            }
            MapCanvas.Image = MapImage;
        }


        private void RenderUniverse(List<List<string>> transmission)
        {
            CheckLoggedOut(transmission);

            Bitmap MapImage = new Bitmap(MapCanvas.Width, MapCanvas.Height);

            Graphics mapgraph = Graphics.FromImage(MapImage);

            Bitmap maptile = new Bitmap(26, 26);
            Graphics tilegraph = Graphics.FromImage(maptile);

            Color c = Color.Black;
            SolidBrush b = new SolidBrush(c);
            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    maptile = new Bitmap(26, 26);
                    tilegraph = Graphics.FromImage(maptile);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(x * 26, y * 26));
                }
            }

            foreach (List<string> l in transmission)
            {
                if (l.Count == 3)
                {
                    c = Color.White;

                    switch (l[2])
                    {
                        case "0":
                            c = Color.FromArgb(189, 189, 189);
                            break;

                        case "1":
                            c = Color.FromArgb(151, 151, 151);
                            break;

                        case "2":
                            c = Color.FromArgb(255, 255, 255);
                            break;

                        case "3":
                            c = Color.FromArgb(200, 200, 200);
                            break;

                        case "4":
                            c = Color.FromArgb(220, 220, 220);
                            break;

                        case "5":
                            c = Color.FromArgb(240, 240, 240);
                            break;

                        case "6":
                            c = Color.FromArgb(190, 190, 190);
                            break;

                        case "7":
                            c = Color.FromArgb(180, 180, 180);
                            break;

                        case "8":
                            c = Color.FromArgb(226, 226, 226);
                            break;

                        case "9":
                            c = Color.FromArgb(205, 205, 205);
                            break;

                        case "10":
                            c = Color.FromArgb(222, 222, 222);
                            break;

                        default:
                            c = Color.FromArgb(240, 240, 240);
                            break;
                    }

                    maptile = new Bitmap(26, 26);
                    tilegraph = Graphics.FromImage(maptile);
                    b = new SolidBrush(c);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(Convert.ToInt32(l[0]) * 26, Convert.ToInt32(l[1]) * 26));
                }
            }
            MapCanvas.Image = MapImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CurrentView = 5;
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(RenderUniverse, 19, MessageConstants.splitToken + Convert.ToString(playerToken));
            hideMenus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetPlayerHome();
        }

        private void GetPlayerHome()
        {
            CurrentView = 3;
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(renderHome, 20, MessageConstants.splitToken + Convert.ToString(playerToken));
            hideMenus();
        }

        private void renderHome(List<List<string>> transmission)
        {
            _currentCluster = Convert.ToInt32(transmission[1][0]);
            _currentSolarSystem = Convert.ToInt32(transmission[1][1]);
            _currentX = Convert.ToInt32(transmission[1][2]);
            _currentY = Convert.ToInt32(transmission[1][3]);

            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(RenderMainMap, 3, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + Convert.ToString(_currentX) + MessageConstants.splitToken + Convert.ToString(_currentY) + MessageConstants.splitToken + _currentCluster + MessageConstants.splitToken + _currentSolarSystem + MessageConstants.completeToken);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LblSidePanel.Text = "SelectTarget";
            CurrentView = 6;
        }

        private void cmdReinforce_Click(object sender, EventArgs e)
        {
            List<long> ReinforcementList = new List<long>();
            try
            {

                showReinforcemenu(true);



                ReinforcementList.Add(Convert.ToInt64(txtReinforceScout.Text));
                ReinforcementList.Add(Convert.ToInt64(txtReinforceGunship.Text));
                ReinforcementList.Add(Convert.ToInt64(txtReinforceBomber.Text));
                ReinforcementList.Add(Convert.ToInt64(txtReinforceFrigate.Text));
                ReinforcementList.Add(Convert.ToInt64(txtReinforceDestroyer.Text));
                ReinforcementList.Add(Convert.ToInt64(txtReinforceCarrier.Text));
                ReinforcementList.Add(Convert.ToInt64(txtReinforceBattleship.Text));
                ReinforcementList.Add(Convert.ToInt64(txtReinforcePartrol.Text));
                ReinforcementList.Add(Convert.ToInt64(txtReinforceGunner.Text));
                ReinforcementList.Add(Convert.ToInt64(txtReinforceTurret.Text));
                ReinforcementList.Add(Convert.ToInt64(txtReinforceArtillery.Text));
                ReinforcementList.Add(Convert.ToInt64(txtDroneBase.Text));


                string request = MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.nextToken;

                request += _currentX + MessageConstants.splitToken + _currentY + MessageConstants.splitToken + _targetX + MessageConstants.splitToken + _targetY + MessageConstants.nextToken;

                foreach (int i in ReinforcementList)
                {
                    request += i + MessageConstants.splitToken;
                }

                request += MessageConstants.nextToken;
                request += _currentX + MessageConstants.splitToken + _currentY + MessageConstants.nextToken;

                request += SendCurrentAddress();

                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(ResultsOfAttack, 22, request);

            }
            catch (Exception)
            {

                txtReinforceArtillery.Text = "0";
                txtReinforceBattleship.Text = "0";
                txtReinforceBomber.Text = "0";
                txtReinforceCarrier.Text = "0";
                txtReinforceDestroyer.Text = "0";
                txtReinforceDroneBase.Text = "0";
                txtReinforceFrigate.Text = "0";
                txtReinforceGunner.Text = "0";
                txtReinforceGunship.Text = "0";
                txtReinforcePartrol.Text = "0";
                txtReinforceScout.Text = "0";
                txtReinforceTurret.Text = "0";

                MessageBox.Show("Invalid Input");

            }


        }

        private void UpdateReinforcePanel(List<List<string>> transmission)
        {

            hideMenus();
            if (transmission[1][0] == "-1")
            {
                MessageBox.Show("You don't own an outpost here");
                return;
            }


            showReinforcemenu(true);
            lblReinforceScout.Text = "scout: " + transmission[1][0];
            lblReinforceGunship.Text = "gunship: " + transmission[1][1];
            lblReinforceBomber.Text = "bomber: " + transmission[1][2];
            lblReinforceFrigate.Text = "frigate: " + transmission[1][3];
            lblReinforceDestroyer.Text = "destroyer: " + transmission[1][4];
            lblReinforceCarrier.Text = "carrier:" + transmission[1][5];
            lblReinforceBattleShip.Text = "battleship:" + transmission[1][6];


            lblReinforcePatrol.Text = "patrol: " + transmission[1][7];
            lblReinforceGunner.Text = "gunner: " + transmission[1][8];
            lblReinforceTurret.Text = "turret: " + transmission[1][9];
            lblReinforceArtillery.Text = "artillery: " + transmission[1][10];
            lblReinforceDroneBase.Text = "drone base: " + transmission[1][11];


            txtReinforceArtillery.Text = "0";
            txtReinforceBattleship.Text = "0";
            txtReinforceBomber.Text = "0";
            txtReinforceCarrier.Text = "0";
            txtReinforceDestroyer.Text = "0";
            txtReinforceDroneBase.Text = "0";
            txtReinforceFrigate.Text = "0";
            txtReinforceGunner.Text = "0";
            txtReinforceGunship.Text = "0";
            txtReinforcePartrol.Text = "0";
            txtReinforceScout.Text = "0";
            txtReinforceTurret.Text = "0";

        }

        private void txtRemoveBuildings_Click(object sender, EventArgs e)
        {
            if (LstBuildingsBuildQueue.SelectedIndex != -1)
            {
                if (BuildGuidList.ContainsKey(LstBuildingsBuildQueue.SelectedIndex))
                {
                    ServerConnection sc = new ServerConnection();
                    sc.ServerRequest(RemoveFromQueueBuildResponse, 23, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + BuildGuidList[LstBuildingsBuildQueue.SelectedIndex]);
                }
            }
            else
            {
                MessageBox.Show("No selected item");
            }

        }

        private void RemoveFromQueueBuildResponse(List<List<string>> transmission)
        {
            if (transmission[1][0] == "success")
            {
                MessageBox.Show("Successfully Removed From Queue");
            }
            GetBuildingView();
        }

        private void btnRemoveOffenceList_Click(object sender, EventArgs e)
        {

            if (LstRemoveOffenceList.SelectedIndex != -1)
            {
                if (BuildGuidList.ContainsKey(LstRemoveOffenceList.SelectedIndex))
                {
                    ServerConnection sc = new ServerConnection();
                    sc.ServerRequest(RemoveFromQueueOffResponse, 24, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + BuildGuidList[LstRemoveOffenceList.SelectedIndex]);
                }
            }
            else
            {
                MessageBox.Show("No selected item");
            }
        }

        private void RemoveFromQueueOffResponse(List<List<string>> transmission)
        {
            if (transmission[1][0] == "success")
            {
                MessageBox.Show("Successfully Removed From Queue");
            }
            GetoffenceList();
        }

        private void btnRemoveDefenceList_Click(object sender, EventArgs e)
        {

            if (LstRemoveDefenceList.SelectedIndex != -1)
            {
                if (BuildGuidList.ContainsKey(LstRemoveDefenceList.SelectedIndex))
                {
                    ServerConnection sc = new ServerConnection();
                    sc.ServerRequest(RemoveFromQueueDefResponse, 25, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.splitToken + BuildGuidList[LstRemoveDefenceList.SelectedIndex]);
                }
            }
            else
            {
                MessageBox.Show("No selected item");
            }
        }

        private void RemoveFromQueueDefResponse(List<List<string>> transmission)
        {
            if (transmission[1][0] == "success")
            {
                MessageBox.Show("Successfully Removed From Queue");
            }
            GetDefenceList();
        }

        private void BtnMoveOutpost_Click(object sender, EventArgs e)
        {
            CurrentView = 7;
            MapCanvas.Show();
        }

        private string SendAddress(UniversalAddress ad)
        {
            return ad.ClusterID + MessageConstants.splitToken + ad.SolarSytemID + MessageConstants.splitToken + ad.PlanetID + MessageConstants.splitToken;
        }

        private string SendCurrentAddress()
        {
            return SendAddress(new UniversalAddress(_currentCluster, _currentSolarSystem, _currentPlanet));
        }

        private void BtnCreateNewBase_Click(object sender, EventArgs e)
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(UpdateBuildBasePanel, 27, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.nextToken + SendCurrentAddress() + MessageConstants.nextToken + _currentX + MessageConstants.splitToken + _currentY);
        }

        private void UpdateBuildBasePanel(List<List<string>> transmission)
        {
            hideMenus();
            MapCanvas.Visible = false;
            LblNewBaseCost.Visible = true;
            BtnBuildNewBase.Visible = true;

            LblNewBaseCost.Text = "Food: " + transmission[1][0] + " Metal: " + transmission[1][1] + " Population: " + transmission[1][2] + " Power: " + transmission[1][3] + " Water: " + transmission[1][4];
            
            if (transmission[1][0] == "-1")
            {
                MessageBox.Show("You don't own an outpost here");
                return;
            }

        }

        private void BuildBaseResponse(List<List<string>> transmission)
        {
            MessageBox.Show(transmission[1][0]);
            hideMenus();
        }

        private void BtnExpandBase_Click(object sender, EventArgs e)
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(ExpandBaseResponse, 30, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.nextToken + SendCurrentAddress() + MessageConstants.nextToken + _currentX + MessageConstants.splitToken + _currentY);
        }

        private void ExpandBaseResponse(List<List<string>>transmission)
        {
            ConfirmBuildQueue(transmission);
        }

        private void BtnBuildNewBase_Click(object sender, EventArgs e)
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(BuildBaseResponse, 28, MessageConstants.splitToken + Convert.ToString(playerToken) + MessageConstants.nextToken + SendCurrentAddress() + MessageConstants.nextToken + _currentX + MessageConstants.splitToken + _currentY);
        }
    }
}
