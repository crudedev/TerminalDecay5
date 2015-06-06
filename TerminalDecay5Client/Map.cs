﻿using System;
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

        private int _currentX;
        private int _currentY;

        private int _targetX;
        private int _targetY;

        private int _currentPlanet = 0;
        private int _currentSolarSystem = 0;
        private int _currentCluster = 0;



        Messages frmMessage = new Messages();

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
            sc.ServerRequest(DrawPlayerResources, 6, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken);
        }

        private void DrawPlayerResources(List<List<string>> transmission)
        {
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
            sc.ServerRequest(RenderResMap, 0, MessageConstants.splitMessageToken + Convert.ToString(playerToken));
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

        private void button2_Click(object sender, EventArgs e)
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(RenderMainMap, 3, MessageConstants.splitMessageToken + Convert.ToString(playerToken));
            hideMenus();
        }

        private void RenderMainMap(List<List<string>> transmission)
        {

            CheckLoggedOut(transmission);


            CurrentView = 1;
            Bitmap MapImage = new Bitmap(MapCanvas.Width, MapCanvas.Height);

            Graphics mapgraph = Graphics.FromImage(MapImage);

            Bitmap maptile = new Bitmap(26, 26);
            Graphics tilegraph = Graphics.FromImage(maptile);

            Color PlayerColor = Color.Green;
            Color FoeColor = Color.Red;

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

                    if (l[3] == "foe")
                    {
                        c = FoeColor;
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
            MapCanvas.Image = MapImage;
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
                    sc.ServerRequest(UpdateSidePanel, 4, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken + Convert.ToString(mx) + MessageConstants.splitMessageToken + Convert.ToString(my) + MessageConstants.splitMessageToken);
                }
            }

            if (CurrentView == 1)
            {
                if (m.Button == MouseButtons.Left)
                {
                    _currentX = mx;
                    _currentY = my;
                    ServerConnection sc = new ServerConnection();
                    sc.ServerRequest(UpdateSidePanel, 5, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken + Convert.ToString(mx) + MessageConstants.splitMessageToken + Convert.ToString(my) + MessageConstants.splitMessageToken);
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
                    sc.ServerRequest(DisplayAttack, 13, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken + Convert.ToString(_currentX) + MessageConstants.splitMessageToken + Convert.ToString(_currentY) + MessageConstants.splitMessageToken);

                }
            }

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
            //show the build list
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(UpdateBuildPanel, 7, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken + Convert.ToString(_currentX) + MessageConstants.splitMessageToken + Convert.ToString(_currentY));

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


            //draw lblbuildxxxxxx values here when the queue has been built

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
        }

        private string updateBuildPanelCostString(List<List<string>> transmission, int x)
        {
            return string.Format("Population: {0}, Metal: {1}, Water: {2}, Power: {3}, Food {4}", transmission[x][0], transmission[x][1], transmission[x][2], transmission[x][3], transmission[x][4]);
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

            lblProduction.Visible = show;
            lblProductionFabricator.Visible = show;
            lblProductionFarm.Visible = show;
            lblProductionHabitat.Visible = show;
            lblProductionMine.Visible = show;
            lblProductionSolar.Visible = show;
            lblProductionWell.Visible = show;


            cmdBuild.Visible = show;

            MapCanvas.Visible = !show;

            BtnBuild.Visible = !show;
            btnBuildDefence.Visible = !show;

            BtnDef.Visible = !show;

            LblSidePanel.Visible = !show;

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

                string request = MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.nextMessageToken;

                foreach (int i in buildList)
                {
                    request += i + MessageConstants.splitMessageToken;
                }

                request += MessageConstants.nextMessageToken;
                request += _currentX + MessageConstants.splitMessageToken + _currentY;

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

            if (transmission[0][0] == MessageConstants.MessageTypes[8])
            {
                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(UpdateBuildPanel, 7, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken + Convert.ToString(_currentX) + MessageConstants.splitMessageToken + Convert.ToString(_currentY));
            }

            if (transmission[0][0] == MessageConstants.MessageTypes[10])
            {
                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(UpdateBuildDefPanel, 9, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken + Convert.ToString(_currentX) + MessageConstants.splitMessageToken + Convert.ToString(_currentY));
            }

            if (transmission[0][0] == MessageConstants.MessageTypes[12])
            {
                ServerConnection sc = new ServerConnection();
                sc.ServerRequest(UpdateBuildOffPanel, 11, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken + Convert.ToString(_currentX) + MessageConstants.splitMessageToken + Convert.ToString(_currentY));
            }


        }

        private void lblBuild_Click(object sender, EventArgs e)
        {

        }

        private void BtnDef_Click(object sender, EventArgs e)
        {
            //show the build list
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(UpdateBuildDefPanel, 9, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken + Convert.ToString(_currentX) + MessageConstants.splitMessageToken + Convert.ToString(_currentY)); ;


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

                string request = MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.nextMessageToken;

                foreach (int i in defBuildList)
                {
                    request += i + MessageConstants.splitMessageToken;
                }

                request += MessageConstants.nextMessageToken;
                request += _currentX + MessageConstants.splitMessageToken + _currentY;
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
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(UpdateBuildOffPanel, 11, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken + Convert.ToString(_currentX) + MessageConstants.splitMessageToken + Convert.ToString(_currentY)); ;
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

            LblSidePanel.Visible = !show;
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

            //lblScoutDefence.Text = transmission[13][0];
            //lblGunshipDefence.Text = transmission[13][1];
            //lblBomberDefence.Text = transmission[13][2];
            //lblFrigateDefence.Text = transmission[13][3];
            //lblDestroyerDefence.Text = transmission[13][4];
            //lblCarrierDefence.Text = transmission[13][5];
            //lblBattleshipDeffence.Text = transmission[13][6];
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

                string request = MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.nextMessageToken;

                foreach (int i in OffBuildList)
                {
                    request += i + MessageConstants.splitMessageToken;
                }

                request += MessageConstants.nextMessageToken;
                request += _currentX + MessageConstants.splitMessageToken + _currentY;

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

                string request = MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.nextMessageToken;

                request += _currentX + MessageConstants.splitMessageToken + _currentY + MessageConstants.splitMessageToken + _targetX + MessageConstants.splitMessageToken + _targetY + MessageConstants.nextMessageToken;

                foreach (int i in AttackList)
                {
                    request += i + MessageConstants.splitMessageToken;
                }

                request += MessageConstants.nextMessageToken;
                request += _currentX + MessageConstants.splitMessageToken + _currentY;

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
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(RenderSolarMap, 17, MessageConstants.splitMessageToken + Convert.ToString(playerToken));
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
                            c = Color.FromArgb(245, 234, 111);
                            break;

                        case "1":
                            c = Color.FromArgb(252, 248, 0);
                            break;

                        case "2":
                            c = Color.FromArgb(252, 88, 0);
                            break;

                        case "3":
                            c = Color.FromArgb(222, 59, 27);
                            break;

                        case "4":
                            c = Color.FromArgb(157, 238, 242);
                            break;

                        case "5":
                            c = Color.FromArgb(120, 198, 250);
                            break;

                        case "6":
                            c = Color.FromArgb(238, 247, 136);
                            break;

                        case "7":
                            c = Color.FromArgb(221, 255, 0);
                            break;

                        case "8":
                            c = Color.FromArgb(255, 226, 61);
                            break;

                        case "9":
                            c = Color.FromArgb(245, 234, 211);
                            break;

                        case "10":
                            c = Color.FromArgb(245, 234, 211);
                            break;

                        default:
                            c = Color.FromArgb(225, 224, 111);
                            break;
                    }

                    maptile = new Bitmap(26, 26);
                    tilegraph = Graphics.FromImage(maptile);
                    b = new SolidBrush(c);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(Convert.ToInt32(l[0]) * 26, Convert.ToInt32(l[1]) * 26));

                    maptile = new Bitmap(10, 10);
                    tilegraph = Graphics.FromImage(maptile);
                    b = new SolidBrush(c);
                    tilegraph.FillRectangle(b, 0, 0, 25, 25);
                    mapgraph.DrawImage(maptile, new Point(Convert.ToInt32(l[0]) * 26, Convert.ToInt32(l[1]) * 26));
                }
            }
            MapCanvas.Image = MapImage;
        }
    }
}
