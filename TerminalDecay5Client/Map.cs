﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TerminalDecay5Server;

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

        private void DrawPlayerResources(List<List<string>> transmition)
        {
            LblEnergy.Text = "Power: " + transmition[1][3];
            LblFood.Text = "Food: " + transmition[1][0];
            LblMetal.Text = "Metal: " + transmition[1][1];
            LblPopulation.Text = "Population: " + transmition[1][2];
            LblWater.Text = "Water: " + transmition[1][4];
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

        private void RenderResMap(List<List<string>> transmition)
        {
            CurrentView = 0;
            universe.Maptiles = new List<MapTile>();
            for (int i = 1; i < transmition.Count - 1; i++)
            {
                MapTile m = new MapTile();
                m.X = Convert.ToInt64(transmition[i][0]);
                m.Y = Convert.ToInt64(transmition[i][1]);
                m.Resources[Cmn.Resource[Cmn.Renum.Metal]] = Convert.ToInt64(transmition[i][2]);
                m.Resources[Cmn.Resource[Cmn.Renum.Food]] = Convert.ToInt64(transmition[i][3]);
                m.Resources[Cmn.Resource[Cmn.Renum.Water]] = Convert.ToInt64(transmition[i][4]);
                universe.Maptiles.Add(m);
            }

            Bitmap MapImage = new Bitmap(MapCanvas.Width, MapCanvas.Height);

            Graphics mapgraph = Graphics.FromImage(MapImage);

            Bitmap maptile = new Bitmap(26, 26);
            Graphics tilegraph = Graphics.FromImage(maptile);

            Color c;

            foreach (MapTile m in universe.Maptiles)
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
                mapgraph.DrawImage(maptile, new Point(Convert.ToInt32(m.X * 26), Convert.ToInt32(m.Y * 26)));

            }

            MapCanvas.Image = MapImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(RenderMainMap, 3, MessageConstants.splitMessageToken + Convert.ToString(playerToken));
            hideMenus();
        }

        private void RenderMainMap(List<List<string>> transmition)
        {
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

            foreach (List<string> l in transmition)
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
                    int temp = Convert.ToInt32(transmition[1][4]);
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
        
        private void DisplayAttack(List<List<string>> transmition)
        {
            hideMenus();
            showAttackMenu(true);
            
            lblAttackScout.Text = "Scout: " + transmition[1][0];
            lblAttackGunship.Text = "Gunship: " + transmition[1][1];
            lblAttackBomber.Text = "Bomber: " + transmition[1][2];
            lblAttaackFrigate.Text = "Frigate: " + transmition[1][3];
            lblAttackDestroyer.Text = "Destroyer: " + transmition[1][4];
            lblAttackCarrier.Text = "Carrier: " + transmition[1][5];
            lblAttackBattleship.Text = "BattleShip: " + transmition[1][6];
            
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

        private void UpdateSidePanel(List<List<string>> transmition)
        {
            if (transmition[0][0] == MessageConstants.MessageTypes[4])
            {
                LblSidePanel.Text = "Metal: " + transmition[1][0] + " Organics: " + transmition[1][1] + " Water: " + transmition[1][2];

            }

            if (transmition[0][0] == MessageConstants.MessageTypes[5])
            {
                if (transmition[1][0] == "-1")
                {
                    LblSidePanel.Text = "unoccipied land";
                }

                if (transmition[1][0] == "Enemy")
                {
                    LblSidePanel.Text = "Land occupied by other forces";
                }
            }
        }

        private void BtnBuild_Click(object sender, EventArgs e)
        {
            //show the build list
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(UpdateBuildPanel, 7, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken + Convert.ToString(_currentX) + MessageConstants.splitMessageToken + Convert.ToString(_currentY));

            hideMenus();
            showBuildmenu(true);
        }

        private void UpdateBuildPanel(List<List<string>> transmition)
        {
            lblEmpty.Text = "Empty: " + transmition[1][1];
            LblFarm.Text = "farm: " + transmition[1][2];
            lblHabitat.Text = "habitat: " + transmition[1][3];
            lblMine.Text = "mine: " + transmition[1][4];
            LblSolarPlant.Text = "solar plant: " + transmition[1][5];
            lblWell.Text = "well: " + transmition[1][6];
            lblfabricator.Text = "fabricator: " + transmition[1][7];

            lblCostFarm.Text = updateBuildPanelCostString(transmition, 3);
            LblCostHabitabt.Text = updateBuildPanelCostString(transmition, 4);
            LblCostMine.Text = updateBuildPanelCostString(transmition, 5);
            lblCostSolarPlant.Text = updateBuildPanelCostString(transmition, 6);
            lblCostWell.Text = updateBuildPanelCostString(transmition, 7);
            lblCostFabricator.Text = updateBuildPanelCostString(transmition, 8);


            //draw lblbuildxxxxxx values here when the queue has been built

            int nonEmptyValue = -1;

            for (int i = 9; i < 15; i++)
            {

                foreach (string s in transmition[i])
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

            lblBuildFarm.Text = transmition[15][3];
            lblBuildHabitat.Text = transmition[15][2];
            lblBuildMine.Text = transmition[15][0];
            LblBuildSolarPlant.Text = transmition[15][4];
            lblBuildWell.Text = transmition[15][1];
            lblBuildFabricator.Text = transmition[15][5];
        }

        private string updateBuildPanelCostString(List<List<string>> transmition, int x)
        {
            return string.Format("Population: {0}, Metal: {1}, Water: {2}, Power: {3}, Food {4}", transmition[x][0], transmition[x][1], transmition[x][2], transmition[x][3], transmition[x][4]);
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
                sc.ServerRequest(UpdateBuildPanel, 8, request);

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

        private void lblBuild_Click(object sender, EventArgs e)
        {

        }

        private void BtnDef_Click(object sender, EventArgs e)
        {
            //show the build list
            ServerConnection sc = new ServerConnection();
            sc.ServerRequest(UpdateBuildDefPanel, 9, MessageConstants.splitMessageToken + Convert.ToString(playerToken) + MessageConstants.splitMessageToken + Convert.ToString(_currentX) + MessageConstants.splitMessageToken + Convert.ToString(_currentY)); ;
            hideMenus();
            showDefenceMenu(true);
        }

        private void UpdateBuildDefPanel(List<List<string>> transmition)
        {
            lblPatrol.Text = "patrol: " + transmition[1][1];
            lblGunner.Text = "gunner: " + transmition[1][2];
            lblTurret.Text = "turret: " + transmition[1][3];
            lblArtillery.Text = "artillery: " + transmition[1][4];
            lblDroneBase.Text = "drone base: " + transmition[1][5];

            lblCostPatrol.Text = updateBuildPanelCostString(transmition, 3);
            lblCostGunner.Text = updateBuildPanelCostString(transmition, 4);
            lblCostTurret.Text = updateBuildPanelCostString(transmition, 5);
            lblCostArtillery.Text = updateBuildPanelCostString(transmition, 6);
            lblCostDroneBase.Text = updateBuildPanelCostString(transmition, 7);



            int nonEmptyValue = -1;

            for (int i = 3; i < 9; i++)
            {

                foreach (string s in transmition[i])
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

            lblPatrolBuild.Text = transmition[9][0];
            lblGunnerBuild.Text = transmition[9][1];
            lblTurretBuild.Text = transmition[9][2];
            lblArtilleryBuild.Text = transmition[9][3];
            lblDroneBaseBuild.Text = transmition[9][4];

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
                sc.ServerRequest(UpdateBuildPanel, 10, request);

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
            hideMenus();
            showOffenceMenu(true);
        }

        private void showOffenceMenu(bool show)
        {

            lblOffExtant.Visible = show;
            lblOffBuild.Visible = show;
            lblOffFuture.Visible = show;
            lblOffCost.Visible = show;
            lblOffenceAttack.Visible = show;
            lblOffenceDefence.Visible = show;

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

            lblScoutDefence.Visible = show;
            lblGunshipDefence.Visible = show;
            lblBomberDefence.Visible = show;
            lblFrigateDefence.Visible = show;
            lblDestroyerDefence.Visible = show;
            lblCarrierDefence.Visible = show;
            lblBattleshipDeffence.Visible = show;

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

        private void UpdateBuildOffPanel(List<List<string>> transmition)
        {
            lblScout.Text = "scout: " + transmition[1][1];
            lblGunship.Text = "gunship: " + transmition[1][2];
            lblBomber.Text = "bomber: " + transmition[1][3];
            lblFrigate.Text = "frigate: " + transmition[1][4];
            lblDestroyer.Text = "destroyer: " + transmition[1][5];
            lblCarrier.Text = "carrier:" + transmition[1][6];
            lblBattleship.Text = "battleship:" + transmition[1][7];

            lblCostScout.Text = updateBuildPanelCostString(transmition, 3);
            lblCostGunship.Text = updateBuildPanelCostString(transmition, 4);
            lblCostBomber.Text = updateBuildPanelCostString(transmition, 5);
            lblCostFrigate.Text = updateBuildPanelCostString(transmition, 6);
            lblCostDestroyer.Text = updateBuildPanelCostString(transmition, 7);
            lblCostCarrier.Text = updateBuildPanelCostString(transmition, 8);
            lblCostBattleship.Text = updateBuildPanelCostString(transmition, 9);



            int nonEmptyValue = -1;

            for (int i = 3; i < 9; i++)
            {

                foreach (string s in transmition[i])
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

            lblScoutBuild.Text = transmition[11][0];
            lblGunshipBuild.Text = transmition[11][1];
            lblBomberBuild.Text = transmition[11][2];
            lblFrigateBuild.Text = transmition[11][3];
            lblDestroyerBuild.Text = transmition[11][4];
            lblCarrierBuild.Text = transmition[11][5];
            lblBattleshipBuild.Text = transmition[11][6];

            lblScoutAttack.Text = transmition[12][0];
            lblGunshipAttack.Text = transmition[12][1];
            lblBomberAttack.Text = transmition[12][2];
            lblFrigateAttack.Text = transmition[12][3];
            lblDestoyerAttack.Text = transmition[12][4];
            lblCarrierAttack.Text = transmition[12][5];
            lblBattleshipAttack.Text = transmition[12][6];

            //lblScoutDefence.Text = transmition[13][0];
            //lblGunshipDefence.Text = transmition[13][1];
            //lblBomberDefence.Text = transmition[13][2];
            //lblFrigateDefence.Text = transmition[13][3];
            //lblDestroyerDefence.Text = transmition[13][4];
            //lblCarrierDefence.Text = transmition[13][5];
            //lblBattleshipDeffence.Text = transmition[13][6];
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
                sc.ServerRequest(UpdateBuildPanel, 12, request);

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
        private void ResultsOfAttack(List<List<string>> transmition)
        {

        }
    }
}
