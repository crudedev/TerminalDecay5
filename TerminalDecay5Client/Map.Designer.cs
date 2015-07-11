using System.ComponentModel;
using System.Windows.Forms;

namespace TerminalDecay5Client
{
    partial class Map
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
            this.button1 = new System.Windows.Forms.Button();
            this.MapCanvas = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.LblSidePanel = new System.Windows.Forms.Label();
            this.LblMetal = new System.Windows.Forms.Label();
            this.LblEnergy = new System.Windows.Forms.Label();
            this.LblPopulation = new System.Windows.Forms.Label();
            this.LblFood = new System.Windows.Forms.Label();
            this.LblWater = new System.Windows.Forms.Label();
            this.BtnBuild = new System.Windows.Forms.Button();
            this.lblMine = new System.Windows.Forms.Label();
            this.txtMine = new System.Windows.Forms.TextBox();
            this.txtWell = new System.Windows.Forms.TextBox();
            this.lblWell = new System.Windows.Forms.Label();
            this.txtHabitat = new System.Windows.Forms.TextBox();
            this.lblHabitat = new System.Windows.Forms.Label();
            this.txtFarm = new System.Windows.Forms.TextBox();
            this.LblFarm = new System.Windows.Forms.Label();
            this.txtSolarPlant = new System.Windows.Forms.TextBox();
            this.LblSolarPlant = new System.Windows.Forms.Label();
            this.txtFabricator = new System.Windows.Forms.TextBox();
            this.lblfabricator = new System.Windows.Forms.Label();
            this.lblExtant = new System.Windows.Forms.Label();
            this.lblFuture = new System.Windows.Forms.Label();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.label666 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBuildFabricator = new System.Windows.Forms.Label();
            this.LblBuildSolarPlant = new System.Windows.Forms.Label();
            this.lblBuildFarm = new System.Windows.Forms.Label();
            this.lblBuildHabitat = new System.Windows.Forms.Label();
            this.lblBuildWell = new System.Windows.Forms.Label();
            this.lblBuildMine = new System.Windows.Forms.Label();
            this.lblBuild = new System.Windows.Forms.Label();
            this.cmdBuild = new System.Windows.Forms.Button();
            this.lblCostFabricator = new System.Windows.Forms.Label();
            this.lblCostSolarPlant = new System.Windows.Forms.Label();
            this.lblCostFarm = new System.Windows.Forms.Label();
            this.LblCostHabitabt = new System.Windows.Forms.Label();
            this.lblCostWell = new System.Windows.Forms.Label();
            this.LblCostMine = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblProductionFabricator = new System.Windows.Forms.Label();
            this.lblProductionSolar = new System.Windows.Forms.Label();
            this.lblProductionFarm = new System.Windows.Forms.Label();
            this.lblProductionHabitat = new System.Windows.Forms.Label();
            this.lblProductionWell = new System.Windows.Forms.Label();
            this.lblProductionMine = new System.Windows.Forms.Label();
            this.lblProduction = new System.Windows.Forms.Label();
            this.BtnDef = new System.Windows.Forms.Button();
            this.lblDefenceDroneBase = new System.Windows.Forms.Label();
            this.lblDefenceArtillery = new System.Windows.Forms.Label();
            this.lblDefenceTurret = new System.Windows.Forms.Label();
            this.lblDefenceGunner = new System.Windows.Forms.Label();
            this.lblDefencePatrol = new System.Windows.Forms.Label();
            this.lblDefPoints = new System.Windows.Forms.Label();
            this.lblCostDroneBase = new System.Windows.Forms.Label();
            this.lblCostArtillery = new System.Windows.Forms.Label();
            this.lblCostTurret = new System.Windows.Forms.Label();
            this.lblCostGunner = new System.Windows.Forms.Label();
            this.lblCostPatrol = new System.Windows.Forms.Label();
            this.lblDefCost = new System.Windows.Forms.Label();
            this.btnBuildDefence = new System.Windows.Forms.Button();
            this.lblDefBuild = new System.Windows.Forms.Label();
            this.lblDroneBaseBuild = new System.Windows.Forms.Label();
            this.lblArtilleryBuild = new System.Windows.Forms.Label();
            this.lblTurretBuild = new System.Windows.Forms.Label();
            this.lblGunnerBuild = new System.Windows.Forms.Label();
            this.lblPatrolBuild = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lblDefFuture = new System.Windows.Forms.Label();
            this.lblDefExtant = new System.Windows.Forms.Label();
            this.txtDroneBase = new System.Windows.Forms.TextBox();
            this.lblDroneBase = new System.Windows.Forms.Label();
            this.txtArtillery = new System.Windows.Forms.TextBox();
            this.lblArtillery = new System.Windows.Forms.Label();
            this.txtTurret = new System.Windows.Forms.TextBox();
            this.lblTurret = new System.Windows.Forms.Label();
            this.txtGunner = new System.Windows.Forms.TextBox();
            this.lblGunner = new System.Windows.Forms.Label();
            this.txtPatrol = new System.Windows.Forms.TextBox();
            this.lblPatrol = new System.Windows.Forms.Label();
            this.lblCostDestroyer = new System.Windows.Forms.Label();
            this.lblCostFrigate = new System.Windows.Forms.Label();
            this.lblCostBomber = new System.Windows.Forms.Label();
            this.lblCostGunship = new System.Windows.Forms.Label();
            this.lblCostScout = new System.Windows.Forms.Label();
            this.lblOffCost = new System.Windows.Forms.Label();
            this.lblOffBuild = new System.Windows.Forms.Label();
            this.lblDestroyerBuild = new System.Windows.Forms.Label();
            this.lblFrigateBuild = new System.Windows.Forms.Label();
            this.lblBomberBuild = new System.Windows.Forms.Label();
            this.lblGunshipBuild = new System.Windows.Forms.Label();
            this.lblScoutBuild = new System.Windows.Forms.Label();
            this.lblDestroyer = new System.Windows.Forms.Label();
            this.lblFrigate = new System.Windows.Forms.Label();
            this.lblBomber = new System.Windows.Forms.Label();
            this.lblGunship = new System.Windows.Forms.Label();
            this.lblScout = new System.Windows.Forms.Label();
            this.lblOffFuture = new System.Windows.Forms.Label();
            this.lblOffExtant = new System.Windows.Forms.Label();
            this.txtDestroyer = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtFrigate = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.txtBomber = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtGunship = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtScout = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.lblDestoyerAttack = new System.Windows.Forms.Label();
            this.lblFrigateAttack = new System.Windows.Forms.Label();
            this.lblBomberAttack = new System.Windows.Forms.Label();
            this.lblGunshipAttack = new System.Windows.Forms.Label();
            this.lblScoutAttack = new System.Windows.Forms.Label();
            this.lblOffenceAttack = new System.Windows.Forms.Label();
            this.lblCostBattleship = new System.Windows.Forms.Label();
            this.lblCostCarrier = new System.Windows.Forms.Label();
            this.lblBattleshipBuild = new System.Windows.Forms.Label();
            this.lblCarrierBuild = new System.Windows.Forms.Label();
            this.lblBattleship = new System.Windows.Forms.Label();
            this.lblCarrier = new System.Windows.Forms.Label();
            this.txtBattleship = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.txtCarrier = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.lblBattleshipAttack = new System.Windows.Forms.Label();
            this.lblCarrierAttack = new System.Windows.Forms.Label();
            this.BtnOffence = new System.Windows.Forms.Button();
            this.btnOffenceBuild = new System.Windows.Forms.Button();
            this.LblSelectedBase = new System.Windows.Forms.Label();
            this.BtnAttack = new System.Windows.Forms.Button();
            this.lblAttackBattleship = new System.Windows.Forms.Label();
            this.lblAttackCarrier = new System.Windows.Forms.Label();
            this.lblAttackDestroyer = new System.Windows.Forms.Label();
            this.lblAttaackFrigate = new System.Windows.Forms.Label();
            this.lblAttackBomber = new System.Windows.Forms.Label();
            this.lblAttackGunship = new System.Windows.Forms.Label();
            this.lblAttackScout = new System.Windows.Forms.Label();
            this.txtAttackBattleship = new System.Windows.Forms.TextBox();
            this.txtAttackCarrier = new System.Windows.Forms.TextBox();
            this.txtAttackDestroyer = new System.Windows.Forms.TextBox();
            this.txtAttackFrigate = new System.Windows.Forms.TextBox();
            this.txtAttackBomber = new System.Windows.Forms.TextBox();
            this.txtAttackGunship = new System.Windows.Forms.TextBox();
            this.txtAttackScout = new System.Windows.Forms.TextBox();
            this.btnSendAttack = new System.Windows.Forms.Button();
            this.BtnMessages = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.cmdReinforce = new System.Windows.Forms.Button();
            this.txtReinforceBattleship = new System.Windows.Forms.TextBox();
            this.txtReinforceCarrier = new System.Windows.Forms.TextBox();
            this.txtReinforceDestroyer = new System.Windows.Forms.TextBox();
            this.txtReinforceFrigate = new System.Windows.Forms.TextBox();
            this.txtReinforceBomber = new System.Windows.Forms.TextBox();
            this.txtReinforceGunship = new System.Windows.Forms.TextBox();
            this.txtReinforceScout = new System.Windows.Forms.TextBox();
            this.lblReinforceBattleShip = new System.Windows.Forms.Label();
            this.lblReinforceCarrier = new System.Windows.Forms.Label();
            this.lblReinforceDestroyer = new System.Windows.Forms.Label();
            this.lblReinforceFrigate = new System.Windows.Forms.Label();
            this.lblReinforceBomber = new System.Windows.Forms.Label();
            this.lblReinforceGunship = new System.Windows.Forms.Label();
            this.lblReinforceScout = new System.Windows.Forms.Label();
            this.lblReinforceDroneBase = new System.Windows.Forms.Label();
            this.lblReinforceArtillery = new System.Windows.Forms.Label();
            this.lblReinforceTurret = new System.Windows.Forms.Label();
            this.lblReinforceGunner = new System.Windows.Forms.Label();
            this.lblReinforcePatrol = new System.Windows.Forms.Label();
            this.txtReinforceDroneBase = new System.Windows.Forms.TextBox();
            this.txtReinforceArtillery = new System.Windows.Forms.TextBox();
            this.txtReinforceTurret = new System.Windows.Forms.TextBox();
            this.txtReinforceGunner = new System.Windows.Forms.TextBox();
            this.txtReinforcePartrol = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.LstBuildingsBuildQueue = new System.Windows.Forms.ListBox();
            this.btnRemoveBuildings = new System.Windows.Forms.Button();
            this.btnRemoveOffenceList = new System.Windows.Forms.Button();
            this.LstRemoveOffenceList = new System.Windows.Forms.ListBox();
            this.btnRemoveDefenceList = new System.Windows.Forms.Button();
            this.LstRemoveDefenceList = new System.Windows.Forms.ListBox();
            this.BtnMoveOutpost = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MapCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Resource View";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MapCanvas
            // 
            this.MapCanvas.Image = ((System.Drawing.Image)(resources.GetObject("MapCanvas.Image")));
            this.MapCanvas.Location = new System.Drawing.Point(127, 47);
            this.MapCanvas.Name = "MapCanvas";
            this.MapCanvas.Size = new System.Drawing.Size(709, 645);
            this.MapCanvas.TabIndex = 1;
            this.MapCanvas.TabStop = false;
            this.MapCanvas.Click += new System.EventHandler(this.MapCanvas_Click);
            this.MapCanvas.MouseMove += MapCanvas_MouseMove;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 740);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LblSidePanel
            // 
            this.LblSidePanel.AutoSize = true;
            this.LblSidePanel.Location = new System.Drawing.Point(811, 103);
            this.LblSidePanel.Name = "LblSidePanel";
            this.LblSidePanel.Size = new System.Drawing.Size(69, 13);
            this.LblSidePanel.TabIndex = 3;
            this.LblSidePanel.Text = "LblSidePanel";
            // 
            // LblMetal
            // 
            this.LblMetal.AutoSize = true;
            this.LblMetal.Location = new System.Drawing.Point(167, 12);
            this.LblMetal.Name = "LblMetal";
            this.LblMetal.Size = new System.Drawing.Size(39, 13);
            this.LblMetal.TabIndex = 4;
            this.LblMetal.Text = "Metal: ";
            // 
            // LblEnergy
            // 
            this.LblEnergy.AutoSize = true;
            this.LblEnergy.Location = new System.Drawing.Point(237, 12);
            this.LblEnergy.Name = "LblEnergy";
            this.LblEnergy.Size = new System.Drawing.Size(46, 13);
            this.LblEnergy.TabIndex = 5;
            this.LblEnergy.Text = "Energy: ";
            // 
            // LblPopulation
            // 
            this.LblPopulation.AutoSize = true;
            this.LblPopulation.Location = new System.Drawing.Point(314, 12);
            this.LblPopulation.Name = "LblPopulation";
            this.LblPopulation.Size = new System.Drawing.Size(63, 13);
            this.LblPopulation.TabIndex = 6;
            this.LblPopulation.Text = "Population: ";
            // 
            // LblFood
            // 
            this.LblFood.AutoSize = true;
            this.LblFood.Location = new System.Drawing.Point(391, 12);
            this.LblFood.Name = "LblFood";
            this.LblFood.Size = new System.Drawing.Size(34, 13);
            this.LblFood.TabIndex = 7;
            this.LblFood.Text = "Food:";
            // 
            // LblWater
            // 
            this.LblWater.AutoSize = true;
            this.LblWater.Location = new System.Drawing.Point(489, 12);
            this.LblWater.Name = "LblWater";
            this.LblWater.Size = new System.Drawing.Size(39, 13);
            this.LblWater.TabIndex = 8;
            this.LblWater.Text = "Water:";
            // 
            // BtnBuild
            // 
            this.BtnBuild.Location = new System.Drawing.Point(864, 47);
            this.BtnBuild.Name = "BtnBuild";
            this.BtnBuild.Size = new System.Drawing.Size(75, 23);
            this.BtnBuild.TabIndex = 9;
            this.BtnBuild.Text = "Show Build";
            this.BtnBuild.UseVisualStyleBackColor = true;
            this.BtnBuild.Visible = false;
            this.BtnBuild.Click += new System.EventHandler(this.BtnBuild_Click);
            // 
            // lblMine
            // 
            this.lblMine.AutoSize = true;
            this.lblMine.Location = new System.Drawing.Point(237, 264);
            this.lblMine.Name = "lblMine";
            this.lblMine.Size = new System.Drawing.Size(32, 13);
            this.lblMine.TabIndex = 10;
            this.lblMine.Text = "mine:";
            this.lblMine.Visible = false;
            // 
            // txtMine
            // 
            this.txtMine.Location = new System.Drawing.Point(920, 256);
            this.txtMine.Name = "txtMine";
            this.txtMine.Size = new System.Drawing.Size(100, 20);
            this.txtMine.TabIndex = 11;
            this.txtMine.Text = "0";
            this.txtMine.Visible = false;
            // 
            // txtWell
            // 
            this.txtWell.Location = new System.Drawing.Point(920, 301);
            this.txtWell.Name = "txtWell";
            this.txtWell.Size = new System.Drawing.Size(100, 20);
            this.txtWell.TabIndex = 13;
            this.txtWell.Text = "0";
            this.txtWell.Visible = false;
            // 
            // lblWell
            // 
            this.lblWell.AutoSize = true;
            this.lblWell.Location = new System.Drawing.Point(237, 309);
            this.lblWell.Name = "lblWell";
            this.lblWell.Size = new System.Drawing.Size(28, 13);
            this.lblWell.TabIndex = 12;
            this.lblWell.Text = "well:";
            this.lblWell.Visible = false;
            // 
            // txtHabitat
            // 
            this.txtHabitat.Location = new System.Drawing.Point(920, 347);
            this.txtHabitat.Name = "txtHabitat";
            this.txtHabitat.Size = new System.Drawing.Size(100, 20);
            this.txtHabitat.TabIndex = 15;
            this.txtHabitat.Text = "0";
            this.txtHabitat.Visible = false;
            // 
            // lblHabitat
            // 
            this.lblHabitat.AutoSize = true;
            this.lblHabitat.Location = new System.Drawing.Point(237, 355);
            this.lblHabitat.Name = "lblHabitat";
            this.lblHabitat.Size = new System.Drawing.Size(42, 13);
            this.lblHabitat.TabIndex = 14;
            this.lblHabitat.Text = "habitat:";
            this.lblHabitat.Visible = false;
            // 
            // txtFarm
            // 
            this.txtFarm.Location = new System.Drawing.Point(920, 391);
            this.txtFarm.Name = "txtFarm";
            this.txtFarm.Size = new System.Drawing.Size(100, 20);
            this.txtFarm.TabIndex = 17;
            this.txtFarm.Text = "0";
            this.txtFarm.Visible = false;
            // 
            // LblFarm
            // 
            this.LblFarm.AutoSize = true;
            this.LblFarm.Location = new System.Drawing.Point(237, 399);
            this.LblFarm.Name = "LblFarm";
            this.LblFarm.Size = new System.Drawing.Size(30, 13);
            this.LblFarm.TabIndex = 16;
            this.LblFarm.Text = "farm:";
            this.LblFarm.Visible = false;
            // 
            // txtSolarPlant
            // 
            this.txtSolarPlant.Location = new System.Drawing.Point(920, 437);
            this.txtSolarPlant.Name = "txtSolarPlant";
            this.txtSolarPlant.Size = new System.Drawing.Size(100, 20);
            this.txtSolarPlant.TabIndex = 19;
            this.txtSolarPlant.Text = "0";
            this.txtSolarPlant.Visible = false;
            // 
            // LblSolarPlant
            // 
            this.LblSolarPlant.AutoSize = true;
            this.LblSolarPlant.Location = new System.Drawing.Point(237, 445);
            this.LblSolarPlant.Name = "LblSolarPlant";
            this.LblSolarPlant.Size = new System.Drawing.Size(55, 13);
            this.LblSolarPlant.TabIndex = 18;
            this.LblSolarPlant.Text = "solar plant";
            this.LblSolarPlant.Visible = false;
            // 
            // txtFabricator
            // 
            this.txtFabricator.Location = new System.Drawing.Point(920, 492);
            this.txtFabricator.Name = "txtFabricator";
            this.txtFabricator.Size = new System.Drawing.Size(100, 20);
            this.txtFabricator.TabIndex = 21;
            this.txtFabricator.Text = "0";
            this.txtFabricator.Visible = false;
            // 
            // lblfabricator
            // 
            this.lblfabricator.AutoSize = true;
            this.lblfabricator.Location = new System.Drawing.Point(237, 500);
            this.lblfabricator.Name = "lblfabricator";
            this.lblfabricator.Size = new System.Drawing.Size(51, 13);
            this.lblfabricator.TabIndex = 20;
            this.lblfabricator.Text = "fabricator";
            this.lblfabricator.Visible = false;
            // 
            // lblExtant
            // 
            this.lblExtant.AutoSize = true;
            this.lblExtant.Location = new System.Drawing.Point(237, 161);
            this.lblExtant.Name = "lblExtant";
            this.lblExtant.Size = new System.Drawing.Size(43, 13);
            this.lblExtant.TabIndex = 22;
            this.lblExtant.Text = " Extant:";
            this.lblExtant.Visible = false;
            // 
            // lblFuture
            // 
            this.lblFuture.AutoSize = true;
            this.lblFuture.Location = new System.Drawing.Point(315, 161);
            this.lblFuture.Name = "lblFuture";
            this.lblFuture.Size = new System.Drawing.Size(40, 13);
            this.lblFuture.TabIndex = 23;
            this.lblFuture.Text = "Future:";
            this.lblFuture.Visible = false;
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.Location = new System.Drawing.Point(237, 218);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(39, 13);
            this.lblEmpty.TabIndex = 24;
            this.lblEmpty.Text = "Empty:";
            this.lblEmpty.Visible = false;
            // 
            // label666
            // 
            this.label666.AutoSize = true;
            this.label666.Location = new System.Drawing.Point(134, 221);
            this.label666.Name = "label666";
            this.label666.Size = new System.Drawing.Size(39, 13);
            this.label666.TabIndex = 31;
            this.label666.Text = "Empty:";
            this.label666.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 503);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "fabricator";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(134, 448);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "solar plant";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(134, 402);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "farm:";
            this.label7.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(134, 358);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "habitat:";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(134, 312);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "well:";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(134, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "mine:";
            this.label10.Visible = false;
            // 
            // lblBuildFabricator
            // 
            this.lblBuildFabricator.AutoSize = true;
            this.lblBuildFabricator.Location = new System.Drawing.Point(315, 499);
            this.lblBuildFabricator.Name = "lblBuildFabricator";
            this.lblBuildFabricator.Size = new System.Drawing.Size(51, 13);
            this.lblBuildFabricator.TabIndex = 37;
            this.lblBuildFabricator.Text = "fabricator";
            this.lblBuildFabricator.Visible = false;
            // 
            // LblBuildSolarPlant
            // 
            this.LblBuildSolarPlant.AutoSize = true;
            this.LblBuildSolarPlant.Location = new System.Drawing.Point(315, 444);
            this.LblBuildSolarPlant.Name = "LblBuildSolarPlant";
            this.LblBuildSolarPlant.Size = new System.Drawing.Size(55, 13);
            this.LblBuildSolarPlant.TabIndex = 36;
            this.LblBuildSolarPlant.Text = "solar plant";
            this.LblBuildSolarPlant.Visible = false;
            // 
            // lblBuildFarm
            // 
            this.lblBuildFarm.AutoSize = true;
            this.lblBuildFarm.Location = new System.Drawing.Point(315, 398);
            this.lblBuildFarm.Name = "lblBuildFarm";
            this.lblBuildFarm.Size = new System.Drawing.Size(30, 13);
            this.lblBuildFarm.TabIndex = 35;
            this.lblBuildFarm.Text = "farm:";
            this.lblBuildFarm.Visible = false;
            // 
            // lblBuildHabitat
            // 
            this.lblBuildHabitat.AutoSize = true;
            this.lblBuildHabitat.Location = new System.Drawing.Point(315, 354);
            this.lblBuildHabitat.Name = "lblBuildHabitat";
            this.lblBuildHabitat.Size = new System.Drawing.Size(42, 13);
            this.lblBuildHabitat.TabIndex = 34;
            this.lblBuildHabitat.Text = "habitat:";
            this.lblBuildHabitat.Visible = false;
            // 
            // lblBuildWell
            // 
            this.lblBuildWell.AutoSize = true;
            this.lblBuildWell.Location = new System.Drawing.Point(315, 308);
            this.lblBuildWell.Name = "lblBuildWell";
            this.lblBuildWell.Size = new System.Drawing.Size(28, 13);
            this.lblBuildWell.TabIndex = 33;
            this.lblBuildWell.Text = "well:";
            this.lblBuildWell.Visible = false;
            // 
            // lblBuildMine
            // 
            this.lblBuildMine.AutoSize = true;
            this.lblBuildMine.Location = new System.Drawing.Point(315, 263);
            this.lblBuildMine.Name = "lblBuildMine";
            this.lblBuildMine.Size = new System.Drawing.Size(32, 13);
            this.lblBuildMine.TabIndex = 32;
            this.lblBuildMine.Text = "mine:";
            this.lblBuildMine.Visible = false;
            // 
            // lblBuild
            // 
            this.lblBuild.AutoSize = true;
            this.lblBuild.Location = new System.Drawing.Point(917, 161);
            this.lblBuild.Name = "lblBuild";
            this.lblBuild.Size = new System.Drawing.Size(30, 13);
            this.lblBuild.TabIndex = 39;
            this.lblBuild.Text = "Build";
            this.lblBuild.Visible = false;
            this.lblBuild.Click += new System.EventHandler(this.lblBuild_Click);
            // 
            // cmdBuild
            // 
            this.cmdBuild.Location = new System.Drawing.Point(901, 548);
            this.cmdBuild.Name = "cmdBuild";
            this.cmdBuild.Size = new System.Drawing.Size(119, 23);
            this.cmdBuild.TabIndex = 40;
            this.cmdBuild.Text = "Add To Build Queue";
            this.cmdBuild.UseVisualStyleBackColor = true;
            this.cmdBuild.Visible = false;
            this.cmdBuild.Click += new System.EventHandler(this.cmdBuild_Click);
            // 
            // lblCostFabricator
            // 
            this.lblCostFabricator.AutoSize = true;
            this.lblCostFabricator.Location = new System.Drawing.Point(412, 499);
            this.lblCostFabricator.Name = "lblCostFabricator";
            this.lblCostFabricator.Size = new System.Drawing.Size(28, 13);
            this.lblCostFabricator.TabIndex = 47;
            this.lblCostFabricator.Text = "Cost";
            this.lblCostFabricator.Visible = false;
            // 
            // lblCostSolarPlant
            // 
            this.lblCostSolarPlant.AutoSize = true;
            this.lblCostSolarPlant.Location = new System.Drawing.Point(412, 444);
            this.lblCostSolarPlant.Name = "lblCostSolarPlant";
            this.lblCostSolarPlant.Size = new System.Drawing.Size(28, 13);
            this.lblCostSolarPlant.TabIndex = 46;
            this.lblCostSolarPlant.Text = "Cost";
            this.lblCostSolarPlant.Visible = false;
            // 
            // lblCostFarm
            // 
            this.lblCostFarm.AutoSize = true;
            this.lblCostFarm.Location = new System.Drawing.Point(412, 398);
            this.lblCostFarm.Name = "lblCostFarm";
            this.lblCostFarm.Size = new System.Drawing.Size(28, 13);
            this.lblCostFarm.TabIndex = 45;
            this.lblCostFarm.Text = "Cost";
            this.lblCostFarm.Visible = false;
            // 
            // LblCostHabitabt
            // 
            this.LblCostHabitabt.AutoSize = true;
            this.LblCostHabitabt.Location = new System.Drawing.Point(412, 354);
            this.LblCostHabitabt.Name = "LblCostHabitabt";
            this.LblCostHabitabt.Size = new System.Drawing.Size(28, 13);
            this.LblCostHabitabt.TabIndex = 44;
            this.LblCostHabitabt.Text = "Cost";
            this.LblCostHabitabt.Visible = false;
            // 
            // lblCostWell
            // 
            this.lblCostWell.AutoSize = true;
            this.lblCostWell.Location = new System.Drawing.Point(412, 308);
            this.lblCostWell.Name = "lblCostWell";
            this.lblCostWell.Size = new System.Drawing.Size(28, 13);
            this.lblCostWell.TabIndex = 43;
            this.lblCostWell.Text = "Cost";
            this.lblCostWell.Visible = false;
            // 
            // LblCostMine
            // 
            this.LblCostMine.AutoSize = true;
            this.LblCostMine.Location = new System.Drawing.Point(412, 263);
            this.LblCostMine.Name = "LblCostMine";
            this.LblCostMine.Size = new System.Drawing.Size(28, 13);
            this.LblCostMine.TabIndex = 42;
            this.LblCostMine.Text = "Cost";
            this.LblCostMine.Visible = false;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(412, 161);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(31, 13);
            this.lblCost.TabIndex = 41;
            this.lblCost.Text = "Cost:";
            this.lblCost.Visible = false;
            // 
            // lblProductionFabricator
            // 
            this.lblProductionFabricator.AutoSize = true;
            this.lblProductionFabricator.Location = new System.Drawing.Point(802, 499);
            this.lblProductionFabricator.Name = "lblProductionFabricator";
            this.lblProductionFabricator.Size = new System.Drawing.Size(58, 13);
            this.lblProductionFabricator.TabIndex = 54;
            this.lblProductionFabricator.Text = "Production";
            this.lblProductionFabricator.Visible = false;
            // 
            // lblProductionSolar
            // 
            this.lblProductionSolar.AutoSize = true;
            this.lblProductionSolar.Location = new System.Drawing.Point(802, 444);
            this.lblProductionSolar.Name = "lblProductionSolar";
            this.lblProductionSolar.Size = new System.Drawing.Size(58, 13);
            this.lblProductionSolar.TabIndex = 53;
            this.lblProductionSolar.Text = "Production";
            this.lblProductionSolar.Visible = false;
            // 
            // lblProductionFarm
            // 
            this.lblProductionFarm.AutoSize = true;
            this.lblProductionFarm.Location = new System.Drawing.Point(802, 398);
            this.lblProductionFarm.Name = "lblProductionFarm";
            this.lblProductionFarm.Size = new System.Drawing.Size(58, 13);
            this.lblProductionFarm.TabIndex = 52;
            this.lblProductionFarm.Text = "Production";
            this.lblProductionFarm.Visible = false;
            // 
            // lblProductionHabitat
            // 
            this.lblProductionHabitat.AutoSize = true;
            this.lblProductionHabitat.Location = new System.Drawing.Point(802, 354);
            this.lblProductionHabitat.Name = "lblProductionHabitat";
            this.lblProductionHabitat.Size = new System.Drawing.Size(58, 13);
            this.lblProductionHabitat.TabIndex = 51;
            this.lblProductionHabitat.Text = "Production";
            this.lblProductionHabitat.Visible = false;
            // 
            // lblProductionWell
            // 
            this.lblProductionWell.AutoSize = true;
            this.lblProductionWell.Location = new System.Drawing.Point(802, 308);
            this.lblProductionWell.Name = "lblProductionWell";
            this.lblProductionWell.Size = new System.Drawing.Size(58, 13);
            this.lblProductionWell.TabIndex = 50;
            this.lblProductionWell.Text = "Production";
            this.lblProductionWell.Visible = false;
            // 
            // lblProductionMine
            // 
            this.lblProductionMine.AutoSize = true;
            this.lblProductionMine.Location = new System.Drawing.Point(802, 263);
            this.lblProductionMine.Name = "lblProductionMine";
            this.lblProductionMine.Size = new System.Drawing.Size(58, 13);
            this.lblProductionMine.TabIndex = 49;
            this.lblProductionMine.Text = "Production";
            this.lblProductionMine.Visible = false;
            // 
            // lblProduction
            // 
            this.lblProduction.AutoSize = true;
            this.lblProduction.Location = new System.Drawing.Point(811, 161);
            this.lblProduction.Name = "lblProduction";
            this.lblProduction.Size = new System.Drawing.Size(61, 13);
            this.lblProduction.TabIndex = 48;
            this.lblProduction.Text = "Production:";
            this.lblProduction.Visible = false;
            // 
            // BtnDef
            // 
            this.BtnDef.Location = new System.Drawing.Point(945, 47);
            this.BtnDef.Name = "BtnDef";
            this.BtnDef.Size = new System.Drawing.Size(100, 23);
            this.BtnDef.TabIndex = 55;
            this.BtnDef.Text = "Show Defence";
            this.BtnDef.UseVisualStyleBackColor = true;
            this.BtnDef.Visible = false;
            this.BtnDef.Click += new System.EventHandler(this.BtnDef_Click);
            // 
            // lblDefenceDroneBase
            // 
            this.lblDefenceDroneBase.AutoSize = true;
            this.lblDefenceDroneBase.Location = new System.Drawing.Point(820, 444);
            this.lblDefenceDroneBase.Name = "lblDefenceDroneBase";
            this.lblDefenceDroneBase.Size = new System.Drawing.Size(46, 13);
            this.lblDefenceDroneBase.TabIndex = 98;
            this.lblDefenceDroneBase.Text = "defence";
            this.lblDefenceDroneBase.Visible = false;
            // 
            // lblDefenceArtillery
            // 
            this.lblDefenceArtillery.AutoSize = true;
            this.lblDefenceArtillery.Location = new System.Drawing.Point(820, 398);
            this.lblDefenceArtillery.Name = "lblDefenceArtillery";
            this.lblDefenceArtillery.Size = new System.Drawing.Size(46, 13);
            this.lblDefenceArtillery.TabIndex = 97;
            this.lblDefenceArtillery.Text = "defence";
            this.lblDefenceArtillery.Visible = false;
            // 
            // lblDefenceTurret
            // 
            this.lblDefenceTurret.AutoSize = true;
            this.lblDefenceTurret.Location = new System.Drawing.Point(820, 354);
            this.lblDefenceTurret.Name = "lblDefenceTurret";
            this.lblDefenceTurret.Size = new System.Drawing.Size(46, 13);
            this.lblDefenceTurret.TabIndex = 96;
            this.lblDefenceTurret.Text = "defence";
            this.lblDefenceTurret.Visible = false;
            // 
            // lblDefenceGunner
            // 
            this.lblDefenceGunner.AutoSize = true;
            this.lblDefenceGunner.Location = new System.Drawing.Point(820, 308);
            this.lblDefenceGunner.Name = "lblDefenceGunner";
            this.lblDefenceGunner.Size = new System.Drawing.Size(46, 13);
            this.lblDefenceGunner.TabIndex = 95;
            this.lblDefenceGunner.Text = "defence";
            this.lblDefenceGunner.Visible = false;
            // 
            // lblDefencePatrol
            // 
            this.lblDefencePatrol.AutoSize = true;
            this.lblDefencePatrol.Location = new System.Drawing.Point(820, 263);
            this.lblDefencePatrol.Name = "lblDefencePatrol";
            this.lblDefencePatrol.Size = new System.Drawing.Size(46, 13);
            this.lblDefencePatrol.TabIndex = 94;
            this.lblDefencePatrol.Text = "defence";
            this.lblDefencePatrol.Visible = false;
            // 
            // lblDefPoints
            // 
            this.lblDefPoints.AutoSize = true;
            this.lblDefPoints.Location = new System.Drawing.Point(820, 161);
            this.lblDefPoints.Name = "lblDefPoints";
            this.lblDefPoints.Size = new System.Drawing.Size(80, 13);
            this.lblDefPoints.TabIndex = 93;
            this.lblDefPoints.Text = "Defence Points";
            this.lblDefPoints.Visible = false;
            // 
            // lblCostDroneBase
            // 
            this.lblCostDroneBase.AutoSize = true;
            this.lblCostDroneBase.Location = new System.Drawing.Point(412, 444);
            this.lblCostDroneBase.Name = "lblCostDroneBase";
            this.lblCostDroneBase.Size = new System.Drawing.Size(28, 13);
            this.lblCostDroneBase.TabIndex = 91;
            this.lblCostDroneBase.Text = "Cost";
            this.lblCostDroneBase.Visible = false;
            // 
            // lblCostArtillery
            // 
            this.lblCostArtillery.AutoSize = true;
            this.lblCostArtillery.Location = new System.Drawing.Point(412, 398);
            this.lblCostArtillery.Name = "lblCostArtillery";
            this.lblCostArtillery.Size = new System.Drawing.Size(28, 13);
            this.lblCostArtillery.TabIndex = 90;
            this.lblCostArtillery.Text = "Cost";
            this.lblCostArtillery.Visible = false;
            // 
            // lblCostTurret
            // 
            this.lblCostTurret.AutoSize = true;
            this.lblCostTurret.Location = new System.Drawing.Point(412, 354);
            this.lblCostTurret.Name = "lblCostTurret";
            this.lblCostTurret.Size = new System.Drawing.Size(28, 13);
            this.lblCostTurret.TabIndex = 89;
            this.lblCostTurret.Text = "Cost";
            this.lblCostTurret.Visible = false;
            // 
            // lblCostGunner
            // 
            this.lblCostGunner.AutoSize = true;
            this.lblCostGunner.Location = new System.Drawing.Point(412, 308);
            this.lblCostGunner.Name = "lblCostGunner";
            this.lblCostGunner.Size = new System.Drawing.Size(28, 13);
            this.lblCostGunner.TabIndex = 88;
            this.lblCostGunner.Text = "Cost";
            this.lblCostGunner.Visible = false;
            // 
            // lblCostPatrol
            // 
            this.lblCostPatrol.AutoSize = true;
            this.lblCostPatrol.Location = new System.Drawing.Point(412, 263);
            this.lblCostPatrol.Name = "lblCostPatrol";
            this.lblCostPatrol.Size = new System.Drawing.Size(28, 13);
            this.lblCostPatrol.TabIndex = 87;
            this.lblCostPatrol.Text = "Cost";
            this.lblCostPatrol.Visible = false;
            // 
            // lblDefCost
            // 
            this.lblDefCost.AutoSize = true;
            this.lblDefCost.Location = new System.Drawing.Point(412, 161);
            this.lblDefCost.Name = "lblDefCost";
            this.lblDefCost.Size = new System.Drawing.Size(31, 13);
            this.lblDefCost.TabIndex = 86;
            this.lblDefCost.Text = "Cost:";
            this.lblDefCost.Visible = false;
            // 
            // btnBuildDefence
            // 
            this.btnBuildDefence.Location = new System.Drawing.Point(864, 568);
            this.btnBuildDefence.Name = "btnBuildDefence";
            this.btnBuildDefence.Size = new System.Drawing.Size(119, 23);
            this.btnBuildDefence.TabIndex = 85;
            this.btnBuildDefence.Text = "Add To Build Queue";
            this.btnBuildDefence.UseVisualStyleBackColor = true;
            this.btnBuildDefence.Visible = false;
            this.btnBuildDefence.Click += new System.EventHandler(this.btnBuildDefence_Click);
            // 
            // lblDefBuild
            // 
            this.lblDefBuild.AutoSize = true;
            this.lblDefBuild.Location = new System.Drawing.Point(917, 161);
            this.lblDefBuild.Name = "lblDefBuild";
            this.lblDefBuild.Size = new System.Drawing.Size(30, 13);
            this.lblDefBuild.TabIndex = 84;
            this.lblDefBuild.Text = "Build";
            this.lblDefBuild.Visible = false;
            // 
            // lblDroneBaseBuild
            // 
            this.lblDroneBaseBuild.AutoSize = true;
            this.lblDroneBaseBuild.Location = new System.Drawing.Point(315, 444);
            this.lblDroneBaseBuild.Name = "lblDroneBaseBuild";
            this.lblDroneBaseBuild.Size = new System.Drawing.Size(63, 13);
            this.lblDroneBaseBuild.TabIndex = 82;
            this.lblDroneBaseBuild.Text = "drone base:";
            this.lblDroneBaseBuild.Visible = false;
            // 
            // lblArtilleryBuild
            // 
            this.lblArtilleryBuild.AutoSize = true;
            this.lblArtilleryBuild.Location = new System.Drawing.Point(315, 398);
            this.lblArtilleryBuild.Name = "lblArtilleryBuild";
            this.lblArtilleryBuild.Size = new System.Drawing.Size(39, 13);
            this.lblArtilleryBuild.TabIndex = 81;
            this.lblArtilleryBuild.Text = "artillery";
            this.lblArtilleryBuild.Visible = false;
            // 
            // lblTurretBuild
            // 
            this.lblTurretBuild.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblTurretBuild.AutoSize = true;
            this.lblTurretBuild.Location = new System.Drawing.Point(315, 354);
            this.lblTurretBuild.Name = "lblTurretBuild";
            this.lblTurretBuild.Size = new System.Drawing.Size(34, 13);
            this.lblTurretBuild.TabIndex = 80;
            this.lblTurretBuild.Text = "turret:";
            this.lblTurretBuild.Visible = false;
            // 
            // lblGunnerBuild
            // 
            this.lblGunnerBuild.AutoSize = true;
            this.lblGunnerBuild.Location = new System.Drawing.Point(315, 308);
            this.lblGunnerBuild.Name = "lblGunnerBuild";
            this.lblGunnerBuild.Size = new System.Drawing.Size(43, 13);
            this.lblGunnerBuild.TabIndex = 79;
            this.lblGunnerBuild.Text = "gunner:";
            this.lblGunnerBuild.Visible = false;
            // 
            // lblPatrolBuild
            // 
            this.lblPatrolBuild.AutoSize = true;
            this.lblPatrolBuild.Location = new System.Drawing.Point(315, 263);
            this.lblPatrolBuild.Name = "lblPatrolBuild";
            this.lblPatrolBuild.Size = new System.Drawing.Size(36, 13);
            this.lblPatrolBuild.TabIndex = 78;
            this.lblPatrolBuild.Text = "patrol:";
            this.lblPatrolBuild.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(134, 448);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(63, 13);
            this.label30.TabIndex = 75;
            this.label30.Text = "drone base:";
            this.label30.Visible = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(134, 402);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(42, 13);
            this.label31.TabIndex = 74;
            this.label31.Text = "artillery:";
            this.label31.Visible = false;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(134, 358);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(34, 13);
            this.label32.TabIndex = 73;
            this.label32.Text = "turret:";
            this.label32.Visible = false;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(134, 312);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(43, 13);
            this.label33.TabIndex = 72;
            this.label33.Text = "gunner:";
            this.label33.Visible = false;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(134, 267);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(36, 13);
            this.label34.TabIndex = 71;
            this.label34.Text = "patrol:";
            this.label34.Visible = false;
            // 
            // lblDefFuture
            // 
            this.lblDefFuture.AutoSize = true;
            this.lblDefFuture.Location = new System.Drawing.Point(315, 161);
            this.lblDefFuture.Name = "lblDefFuture";
            this.lblDefFuture.Size = new System.Drawing.Size(40, 13);
            this.lblDefFuture.TabIndex = 69;
            this.lblDefFuture.Text = "Future:";
            this.lblDefFuture.Visible = false;
            // 
            // lblDefExtant
            // 
            this.lblDefExtant.AutoSize = true;
            this.lblDefExtant.Location = new System.Drawing.Point(237, 161);
            this.lblDefExtant.Name = "lblDefExtant";
            this.lblDefExtant.Size = new System.Drawing.Size(43, 13);
            this.lblDefExtant.TabIndex = 68;
            this.lblDefExtant.Text = " Extant:";
            this.lblDefExtant.Visible = false;
            // 
            // txtDroneBase
            // 
            this.txtDroneBase.Location = new System.Drawing.Point(920, 437);
            this.txtDroneBase.Name = "txtDroneBase";
            this.txtDroneBase.Size = new System.Drawing.Size(100, 20);
            this.txtDroneBase.TabIndex = 65;
            this.txtDroneBase.Text = "0";
            this.txtDroneBase.Visible = false;
            // 
            // lblDroneBase
            // 
            this.lblDroneBase.AutoSize = true;
            this.lblDroneBase.Location = new System.Drawing.Point(237, 445);
            this.lblDroneBase.Name = "lblDroneBase";
            this.lblDroneBase.Size = new System.Drawing.Size(60, 13);
            this.lblDroneBase.TabIndex = 64;
            this.lblDroneBase.Text = "drone base";
            this.lblDroneBase.Visible = false;
            // 
            // txtArtillery
            // 
            this.txtArtillery.Location = new System.Drawing.Point(920, 391);
            this.txtArtillery.Name = "txtArtillery";
            this.txtArtillery.Size = new System.Drawing.Size(100, 20);
            this.txtArtillery.TabIndex = 63;
            this.txtArtillery.Text = "0";
            this.txtArtillery.Visible = false;
            // 
            // lblArtillery
            // 
            this.lblArtillery.AutoSize = true;
            this.lblArtillery.Location = new System.Drawing.Point(237, 399);
            this.lblArtillery.Name = "lblArtillery";
            this.lblArtillery.Size = new System.Drawing.Size(39, 13);
            this.lblArtillery.TabIndex = 62;
            this.lblArtillery.Text = "artillery";
            this.lblArtillery.Visible = false;
            // 
            // txtTurret
            // 
            this.txtTurret.Location = new System.Drawing.Point(920, 347);
            this.txtTurret.Name = "txtTurret";
            this.txtTurret.Size = new System.Drawing.Size(100, 20);
            this.txtTurret.TabIndex = 61;
            this.txtTurret.Text = "0";
            this.txtTurret.Visible = false;
            // 
            // lblTurret
            // 
            this.lblTurret.AutoSize = true;
            this.lblTurret.Location = new System.Drawing.Point(237, 355);
            this.lblTurret.Name = "lblTurret";
            this.lblTurret.Size = new System.Drawing.Size(34, 13);
            this.lblTurret.TabIndex = 60;
            this.lblTurret.Text = "turret:";
            this.lblTurret.Visible = false;
            // 
            // txtGunner
            // 
            this.txtGunner.Location = new System.Drawing.Point(920, 301);
            this.txtGunner.Name = "txtGunner";
            this.txtGunner.Size = new System.Drawing.Size(100, 20);
            this.txtGunner.TabIndex = 59;
            this.txtGunner.Text = "0";
            this.txtGunner.Visible = false;
            // 
            // lblGunner
            // 
            this.lblGunner.AutoSize = true;
            this.lblGunner.Location = new System.Drawing.Point(237, 309);
            this.lblGunner.Name = "lblGunner";
            this.lblGunner.Size = new System.Drawing.Size(43, 13);
            this.lblGunner.TabIndex = 58;
            this.lblGunner.Text = "gunner:";
            this.lblGunner.Visible = false;
            // 
            // txtPatrol
            // 
            this.txtPatrol.Location = new System.Drawing.Point(920, 256);
            this.txtPatrol.Name = "txtPatrol";
            this.txtPatrol.Size = new System.Drawing.Size(100, 20);
            this.txtPatrol.TabIndex = 57;
            this.txtPatrol.Text = "0";
            this.txtPatrol.Visible = false;
            // 
            // lblPatrol
            // 
            this.lblPatrol.AutoSize = true;
            this.lblPatrol.Location = new System.Drawing.Point(237, 264);
            this.lblPatrol.Name = "lblPatrol";
            this.lblPatrol.Size = new System.Drawing.Size(36, 13);
            this.lblPatrol.TabIndex = 56;
            this.lblPatrol.Text = "patrol:";
            this.lblPatrol.Visible = false;
            // 
            // lblCostDestroyer
            // 
            this.lblCostDestroyer.AutoSize = true;
            this.lblCostDestroyer.Location = new System.Drawing.Point(504, 416);
            this.lblCostDestroyer.Name = "lblCostDestroyer";
            this.lblCostDestroyer.Size = new System.Drawing.Size(28, 13);
            this.lblCostDestroyer.TabIndex = 133;
            this.lblCostDestroyer.Text = "Cost";
            this.lblCostDestroyer.Visible = false;
            // 
            // lblCostFrigate
            // 
            this.lblCostFrigate.AutoSize = true;
            this.lblCostFrigate.Location = new System.Drawing.Point(504, 370);
            this.lblCostFrigate.Name = "lblCostFrigate";
            this.lblCostFrigate.Size = new System.Drawing.Size(28, 13);
            this.lblCostFrigate.TabIndex = 132;
            this.lblCostFrigate.Text = "Cost";
            this.lblCostFrigate.Visible = false;
            // 
            // lblCostBomber
            // 
            this.lblCostBomber.AutoSize = true;
            this.lblCostBomber.Location = new System.Drawing.Point(504, 326);
            this.lblCostBomber.Name = "lblCostBomber";
            this.lblCostBomber.Size = new System.Drawing.Size(28, 13);
            this.lblCostBomber.TabIndex = 131;
            this.lblCostBomber.Text = "Cost";
            this.lblCostBomber.Visible = false;
            // 
            // lblCostGunship
            // 
            this.lblCostGunship.AutoSize = true;
            this.lblCostGunship.Location = new System.Drawing.Point(504, 280);
            this.lblCostGunship.Name = "lblCostGunship";
            this.lblCostGunship.Size = new System.Drawing.Size(28, 13);
            this.lblCostGunship.TabIndex = 130;
            this.lblCostGunship.Text = "Cost";
            this.lblCostGunship.Visible = false;
            // 
            // lblCostScout
            // 
            this.lblCostScout.AutoSize = true;
            this.lblCostScout.Location = new System.Drawing.Point(504, 235);
            this.lblCostScout.Name = "lblCostScout";
            this.lblCostScout.Size = new System.Drawing.Size(28, 13);
            this.lblCostScout.TabIndex = 129;
            this.lblCostScout.Text = "Cost";
            this.lblCostScout.Visible = false;
            // 
            // lblOffCost
            // 
            this.lblOffCost.AutoSize = true;
            this.lblOffCost.Location = new System.Drawing.Point(504, 159);
            this.lblOffCost.Name = "lblOffCost";
            this.lblOffCost.Size = new System.Drawing.Size(31, 13);
            this.lblOffCost.TabIndex = 128;
            this.lblOffCost.Text = "Cost:";
            this.lblOffCost.Visible = false;
            // 
            // lblOffBuild
            // 
            this.lblOffBuild.AutoSize = true;
            this.lblOffBuild.Location = new System.Drawing.Point(917, 159);
            this.lblOffBuild.Name = "lblOffBuild";
            this.lblOffBuild.Size = new System.Drawing.Size(30, 13);
            this.lblOffBuild.TabIndex = 127;
            this.lblOffBuild.Text = "Build";
            this.lblOffBuild.Visible = false;
            // 
            // lblDestroyerBuild
            // 
            this.lblDestroyerBuild.AutoSize = true;
            this.lblDestroyerBuild.Location = new System.Drawing.Point(407, 416);
            this.lblDestroyerBuild.Name = "lblDestroyerBuild";
            this.lblDestroyerBuild.Size = new System.Drawing.Size(53, 13);
            this.lblDestroyerBuild.TabIndex = 126;
            this.lblDestroyerBuild.Text = "destroyer:";
            this.lblDestroyerBuild.Visible = false;
            // 
            // lblFrigateBuild
            // 
            this.lblFrigateBuild.AutoSize = true;
            this.lblFrigateBuild.Location = new System.Drawing.Point(407, 370);
            this.lblFrigateBuild.Name = "lblFrigateBuild";
            this.lblFrigateBuild.Size = new System.Drawing.Size(39, 13);
            this.lblFrigateBuild.TabIndex = 125;
            this.lblFrigateBuild.Text = "frigate:";
            this.lblFrigateBuild.Visible = false;
            // 
            // lblBomberBuild
            // 
            this.lblBomberBuild.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblBomberBuild.AutoSize = true;
            this.lblBomberBuild.Location = new System.Drawing.Point(407, 326);
            this.lblBomberBuild.Name = "lblBomberBuild";
            this.lblBomberBuild.Size = new System.Drawing.Size(45, 13);
            this.lblBomberBuild.TabIndex = 124;
            this.lblBomberBuild.Text = "bomber:";
            this.lblBomberBuild.Visible = false;
            // 
            // lblGunshipBuild
            // 
            this.lblGunshipBuild.AutoSize = true;
            this.lblGunshipBuild.Location = new System.Drawing.Point(407, 280);
            this.lblGunshipBuild.Name = "lblGunshipBuild";
            this.lblGunshipBuild.Size = new System.Drawing.Size(47, 13);
            this.lblGunshipBuild.TabIndex = 123;
            this.lblGunshipBuild.Text = "gunship:";
            this.lblGunshipBuild.Visible = false;
            // 
            // lblScoutBuild
            // 
            this.lblScoutBuild.AutoSize = true;
            this.lblScoutBuild.Location = new System.Drawing.Point(407, 235);
            this.lblScoutBuild.Name = "lblScoutBuild";
            this.lblScoutBuild.Size = new System.Drawing.Size(36, 13);
            this.lblScoutBuild.TabIndex = 122;
            this.lblScoutBuild.Text = "scout:";
            this.lblScoutBuild.Visible = false;
            // 
            // lblDestroyer
            // 
            this.lblDestroyer.AutoSize = true;
            this.lblDestroyer.Location = new System.Drawing.Point(329, 417);
            this.lblDestroyer.Name = "lblDestroyer";
            this.lblDestroyer.Size = new System.Drawing.Size(53, 13);
            this.lblDestroyer.TabIndex = 121;
            this.lblDestroyer.Text = "destroyer:";
            this.lblDestroyer.Visible = false;
            // 
            // lblFrigate
            // 
            this.lblFrigate.AutoSize = true;
            this.lblFrigate.Location = new System.Drawing.Point(329, 371);
            this.lblFrigate.Name = "lblFrigate";
            this.lblFrigate.Size = new System.Drawing.Size(39, 13);
            this.lblFrigate.TabIndex = 120;
            this.lblFrigate.Text = "frigate:";
            this.lblFrigate.Visible = false;
            // 
            // lblBomber
            // 
            this.lblBomber.AutoSize = true;
            this.lblBomber.Location = new System.Drawing.Point(329, 327);
            this.lblBomber.Name = "lblBomber";
            this.lblBomber.Size = new System.Drawing.Size(45, 13);
            this.lblBomber.TabIndex = 119;
            this.lblBomber.Text = "bomber:";
            this.lblBomber.Visible = false;
            // 
            // lblGunship
            // 
            this.lblGunship.AutoSize = true;
            this.lblGunship.Location = new System.Drawing.Point(329, 281);
            this.lblGunship.Name = "lblGunship";
            this.lblGunship.Size = new System.Drawing.Size(47, 13);
            this.lblGunship.TabIndex = 118;
            this.lblGunship.Text = "gunship:";
            this.lblGunship.Visible = false;
            // 
            // lblScout
            // 
            this.lblScout.AutoSize = true;
            this.lblScout.Location = new System.Drawing.Point(329, 236);
            this.lblScout.Name = "lblScout";
            this.lblScout.Size = new System.Drawing.Size(36, 13);
            this.lblScout.TabIndex = 117;
            this.lblScout.Text = "scout:";
            this.lblScout.Visible = false;
            // 
            // lblOffFuture
            // 
            this.lblOffFuture.AutoSize = true;
            this.lblOffFuture.Location = new System.Drawing.Point(407, 159);
            this.lblOffFuture.Name = "lblOffFuture";
            this.lblOffFuture.Size = new System.Drawing.Size(40, 13);
            this.lblOffFuture.TabIndex = 116;
            this.lblOffFuture.Text = "Future:";
            this.lblOffFuture.Visible = false;
            // 
            // lblOffExtant
            // 
            this.lblOffExtant.AutoSize = true;
            this.lblOffExtant.Location = new System.Drawing.Point(329, 159);
            this.lblOffExtant.Name = "lblOffExtant";
            this.lblOffExtant.Size = new System.Drawing.Size(43, 13);
            this.lblOffExtant.TabIndex = 115;
            this.lblOffExtant.Text = " Extant:";
            this.lblOffExtant.Visible = false;
            // 
            // txtDestroyer
            // 
            this.txtDestroyer.Location = new System.Drawing.Point(920, 409);
            this.txtDestroyer.Name = "txtDestroyer";
            this.txtDestroyer.Size = new System.Drawing.Size(100, 20);
            this.txtDestroyer.TabIndex = 114;
            this.txtDestroyer.Text = "0";
            this.txtDestroyer.Visible = false;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(221, 416);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(50, 13);
            this.label37.TabIndex = 113;
            this.label37.Text = "destroyer";
            this.label37.Visible = false;
            // 
            // txtFrigate
            // 
            this.txtFrigate.Location = new System.Drawing.Point(920, 363);
            this.txtFrigate.Name = "txtFrigate";
            this.txtFrigate.Size = new System.Drawing.Size(100, 20);
            this.txtFrigate.TabIndex = 112;
            this.txtFrigate.Text = "0";
            this.txtFrigate.Visible = false;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(221, 370);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(36, 13);
            this.label38.TabIndex = 111;
            this.label38.Text = "frigate";
            this.label38.Visible = false;
            // 
            // txtBomber
            // 
            this.txtBomber.Location = new System.Drawing.Point(920, 319);
            this.txtBomber.Name = "txtBomber";
            this.txtBomber.Size = new System.Drawing.Size(100, 20);
            this.txtBomber.TabIndex = 110;
            this.txtBomber.Text = "0";
            this.txtBomber.Visible = false;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(221, 326);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(45, 13);
            this.label39.TabIndex = 109;
            this.label39.Text = "bomber:";
            this.label39.Visible = false;
            // 
            // txtGunship
            // 
            this.txtGunship.Location = new System.Drawing.Point(920, 273);
            this.txtGunship.Name = "txtGunship";
            this.txtGunship.Size = new System.Drawing.Size(100, 20);
            this.txtGunship.TabIndex = 108;
            this.txtGunship.Text = "0";
            this.txtGunship.Visible = false;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(221, 280);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(47, 13);
            this.label40.TabIndex = 107;
            this.label40.Text = "gunship:";
            this.label40.Visible = false;
            // 
            // txtScout
            // 
            this.txtScout.Location = new System.Drawing.Point(920, 228);
            this.txtScout.Name = "txtScout";
            this.txtScout.Size = new System.Drawing.Size(100, 20);
            this.txtScout.TabIndex = 106;
            this.txtScout.Text = "0";
            this.txtScout.Visible = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(221, 235);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(36, 13);
            this.label41.TabIndex = 105;
            this.label41.Text = "scout:";
            this.label41.Visible = false;
            // 
            // lblDestoyerAttack
            // 
            this.lblDestoyerAttack.AutoSize = true;
            this.lblDestoyerAttack.Location = new System.Drawing.Point(802, 416);
            this.lblDestoyerAttack.Name = "lblDestoyerAttack";
            this.lblDestoyerAttack.Size = new System.Drawing.Size(58, 13);
            this.lblDestoyerAttack.TabIndex = 104;
            this.lblDestoyerAttack.Text = "Production";
            this.lblDestoyerAttack.Visible = false;
            // 
            // lblFrigateAttack
            // 
            this.lblFrigateAttack.AutoSize = true;
            this.lblFrigateAttack.Location = new System.Drawing.Point(802, 370);
            this.lblFrigateAttack.Name = "lblFrigateAttack";
            this.lblFrigateAttack.Size = new System.Drawing.Size(58, 13);
            this.lblFrigateAttack.TabIndex = 103;
            this.lblFrigateAttack.Text = "Production";
            this.lblFrigateAttack.Visible = false;
            // 
            // lblBomberAttack
            // 
            this.lblBomberAttack.AutoSize = true;
            this.lblBomberAttack.Location = new System.Drawing.Point(802, 326);
            this.lblBomberAttack.Name = "lblBomberAttack";
            this.lblBomberAttack.Size = new System.Drawing.Size(58, 13);
            this.lblBomberAttack.TabIndex = 102;
            this.lblBomberAttack.Text = "Production";
            this.lblBomberAttack.Visible = false;
            // 
            // lblGunshipAttack
            // 
            this.lblGunshipAttack.AutoSize = true;
            this.lblGunshipAttack.Location = new System.Drawing.Point(802, 280);
            this.lblGunshipAttack.Name = "lblGunshipAttack";
            this.lblGunshipAttack.Size = new System.Drawing.Size(58, 13);
            this.lblGunshipAttack.TabIndex = 101;
            this.lblGunshipAttack.Text = "Production";
            this.lblGunshipAttack.Visible = false;
            // 
            // lblScoutAttack
            // 
            this.lblScoutAttack.AutoSize = true;
            this.lblScoutAttack.Location = new System.Drawing.Point(802, 235);
            this.lblScoutAttack.Name = "lblScoutAttack";
            this.lblScoutAttack.Size = new System.Drawing.Size(58, 13);
            this.lblScoutAttack.TabIndex = 100;
            this.lblScoutAttack.Text = "Production";
            this.lblScoutAttack.Visible = false;
            // 
            // lblOffenceAttack
            // 
            this.lblOffenceAttack.AutoSize = true;
            this.lblOffenceAttack.Location = new System.Drawing.Point(811, 161);
            this.lblOffenceAttack.Name = "lblOffenceAttack";
            this.lblOffenceAttack.Size = new System.Drawing.Size(73, 13);
            this.lblOffenceAttack.TabIndex = 99;
            this.lblOffenceAttack.Text = "Attack Points:";
            this.lblOffenceAttack.Visible = false;
            // 
            // lblCostBattleship
            // 
            this.lblCostBattleship.AutoSize = true;
            this.lblCostBattleship.Location = new System.Drawing.Point(504, 508);
            this.lblCostBattleship.Name = "lblCostBattleship";
            this.lblCostBattleship.Size = new System.Drawing.Size(28, 13);
            this.lblCostBattleship.TabIndex = 151;
            this.lblCostBattleship.Text = "Cost";
            this.lblCostBattleship.Visible = false;
            // 
            // lblCostCarrier
            // 
            this.lblCostCarrier.AutoSize = true;
            this.lblCostCarrier.Location = new System.Drawing.Point(504, 462);
            this.lblCostCarrier.Name = "lblCostCarrier";
            this.lblCostCarrier.Size = new System.Drawing.Size(28, 13);
            this.lblCostCarrier.TabIndex = 150;
            this.lblCostCarrier.Text = "Cost";
            this.lblCostCarrier.Visible = false;
            // 
            // lblBattleshipBuild
            // 
            this.lblBattleshipBuild.AutoSize = true;
            this.lblBattleshipBuild.Location = new System.Drawing.Point(407, 508);
            this.lblBattleshipBuild.Name = "lblBattleshipBuild";
            this.lblBattleshipBuild.Size = new System.Drawing.Size(55, 13);
            this.lblBattleshipBuild.TabIndex = 149;
            this.lblBattleshipBuild.Text = "battleship:";
            this.lblBattleshipBuild.Visible = false;
            // 
            // lblCarrierBuild
            // 
            this.lblCarrierBuild.AutoSize = true;
            this.lblCarrierBuild.Location = new System.Drawing.Point(407, 462);
            this.lblCarrierBuild.Name = "lblCarrierBuild";
            this.lblCarrierBuild.Size = new System.Drawing.Size(39, 13);
            this.lblCarrierBuild.TabIndex = 148;
            this.lblCarrierBuild.Text = "carrier:";
            this.lblCarrierBuild.Visible = false;
            // 
            // lblBattleship
            // 
            this.lblBattleship.AutoSize = true;
            this.lblBattleship.Location = new System.Drawing.Point(329, 509);
            this.lblBattleship.Name = "lblBattleship";
            this.lblBattleship.Size = new System.Drawing.Size(56, 13);
            this.lblBattleship.TabIndex = 147;
            this.lblBattleship.Text = "Battleship:";
            this.lblBattleship.Visible = false;
            // 
            // lblCarrier
            // 
            this.lblCarrier.AutoSize = true;
            this.lblCarrier.Location = new System.Drawing.Point(329, 463);
            this.lblCarrier.Name = "lblCarrier";
            this.lblCarrier.Size = new System.Drawing.Size(39, 13);
            this.lblCarrier.TabIndex = 146;
            this.lblCarrier.Text = "carrier:";
            this.lblCarrier.Visible = false;
            // 
            // txtBattleship
            // 
            this.txtBattleship.Location = new System.Drawing.Point(920, 501);
            this.txtBattleship.Name = "txtBattleship";
            this.txtBattleship.Size = new System.Drawing.Size(100, 20);
            this.txtBattleship.TabIndex = 145;
            this.txtBattleship.Text = "0";
            this.txtBattleship.Visible = false;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(221, 508);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(49, 13);
            this.label56.TabIndex = 144;
            this.label56.Text = "batleship";
            this.label56.Visible = false;
            // 
            // txtCarrier
            // 
            this.txtCarrier.Location = new System.Drawing.Point(920, 455);
            this.txtCarrier.Name = "txtCarrier";
            this.txtCarrier.Size = new System.Drawing.Size(100, 20);
            this.txtCarrier.TabIndex = 143;
            this.txtCarrier.Text = "0";
            this.txtCarrier.Visible = false;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(221, 462);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(36, 13);
            this.label57.TabIndex = 142;
            this.label57.Text = "carrier";
            this.label57.Visible = false;
            // 
            // lblBattleshipAttack
            // 
            this.lblBattleshipAttack.AutoSize = true;
            this.lblBattleshipAttack.Location = new System.Drawing.Point(802, 508);
            this.lblBattleshipAttack.Name = "lblBattleshipAttack";
            this.lblBattleshipAttack.Size = new System.Drawing.Size(58, 13);
            this.lblBattleshipAttack.TabIndex = 141;
            this.lblBattleshipAttack.Text = "Production";
            this.lblBattleshipAttack.Visible = false;
            // 
            // lblCarrierAttack
            // 
            this.lblCarrierAttack.AutoSize = true;
            this.lblCarrierAttack.Location = new System.Drawing.Point(802, 462);
            this.lblCarrierAttack.Name = "lblCarrierAttack";
            this.lblCarrierAttack.Size = new System.Drawing.Size(58, 13);
            this.lblCarrierAttack.TabIndex = 140;
            this.lblCarrierAttack.Text = "Production";
            this.lblCarrierAttack.Visible = false;
            // 
            // BtnOffence
            // 
            this.BtnOffence.Location = new System.Drawing.Point(1051, 47);
            this.BtnOffence.Name = "BtnOffence";
            this.BtnOffence.Size = new System.Drawing.Size(100, 23);
            this.BtnOffence.TabIndex = 154;
            this.BtnOffence.Text = "Show Offence";
            this.BtnOffence.UseVisualStyleBackColor = true;
            this.BtnOffence.Visible = false;
            this.BtnOffence.Click += new System.EventHandler(this.BtnOffence_Click);
            // 
            // btnOffenceBuild
            // 
            this.btnOffenceBuild.Location = new System.Drawing.Point(883, 558);
            this.btnOffenceBuild.Name = "btnOffenceBuild";
            this.btnOffenceBuild.Size = new System.Drawing.Size(119, 23);
            this.btnOffenceBuild.TabIndex = 155;
            this.btnOffenceBuild.Text = "Add To Build Queue";
            this.btnOffenceBuild.UseVisualStyleBackColor = true;
            this.btnOffenceBuild.Visible = false;
            this.btnOffenceBuild.Click += new System.EventHandler(this.btnOffenceBuild_Click);
            // 
            // LblSelectedBase
            // 
            this.LblSelectedBase.AutoSize = true;
            this.LblSelectedBase.Location = new System.Drawing.Point(9, 363);
            this.LblSelectedBase.Name = "LblSelectedBase";
            this.LblSelectedBase.Size = new System.Drawing.Size(76, 13);
            this.LblSelectedBase.TabIndex = 156;
            this.LblSelectedBase.Text = "Selected Base";
            // 
            // BtnAttack
            // 
            this.BtnAttack.Location = new System.Drawing.Point(1157, 47);
            this.BtnAttack.Name = "BtnAttack";
            this.BtnAttack.Size = new System.Drawing.Size(62, 23);
            this.BtnAttack.TabIndex = 157;
            this.BtnAttack.Text = "Attack";
            this.BtnAttack.UseVisualStyleBackColor = true;
            this.BtnAttack.Visible = false;
            this.BtnAttack.Click += new System.EventHandler(this.BtnAttack_Click);
            // 
            // lblAttackBattleship
            // 
            this.lblAttackBattleship.AutoSize = true;
            this.lblAttackBattleship.Location = new System.Drawing.Point(834, 519);
            this.lblAttackBattleship.Name = "lblAttackBattleship";
            this.lblAttackBattleship.Size = new System.Drawing.Size(49, 13);
            this.lblAttackBattleship.TabIndex = 164;
            this.lblAttackBattleship.Text = "batleship";
            this.lblAttackBattleship.Visible = false;
            // 
            // lblAttackCarrier
            // 
            this.lblAttackCarrier.AutoSize = true;
            this.lblAttackCarrier.Location = new System.Drawing.Point(834, 473);
            this.lblAttackCarrier.Name = "lblAttackCarrier";
            this.lblAttackCarrier.Size = new System.Drawing.Size(36, 13);
            this.lblAttackCarrier.TabIndex = 163;
            this.lblAttackCarrier.Text = "carrier";
            this.lblAttackCarrier.Visible = false;
            // 
            // lblAttackDestroyer
            // 
            this.lblAttackDestroyer.AutoSize = true;
            this.lblAttackDestroyer.Location = new System.Drawing.Point(834, 427);
            this.lblAttackDestroyer.Name = "lblAttackDestroyer";
            this.lblAttackDestroyer.Size = new System.Drawing.Size(50, 13);
            this.lblAttackDestroyer.TabIndex = 162;
            this.lblAttackDestroyer.Text = "destroyer";
            this.lblAttackDestroyer.Visible = false;
            // 
            // lblAttaackFrigate
            // 
            this.lblAttaackFrigate.AutoSize = true;
            this.lblAttaackFrigate.Location = new System.Drawing.Point(834, 381);
            this.lblAttaackFrigate.Name = "lblAttaackFrigate";
            this.lblAttaackFrigate.Size = new System.Drawing.Size(36, 13);
            this.lblAttaackFrigate.TabIndex = 161;
            this.lblAttaackFrigate.Text = "frigate";
            this.lblAttaackFrigate.Visible = false;
            // 
            // lblAttackBomber
            // 
            this.lblAttackBomber.AutoSize = true;
            this.lblAttackBomber.Location = new System.Drawing.Point(834, 337);
            this.lblAttackBomber.Name = "lblAttackBomber";
            this.lblAttackBomber.Size = new System.Drawing.Size(45, 13);
            this.lblAttackBomber.TabIndex = 160;
            this.lblAttackBomber.Text = "bomber:";
            this.lblAttackBomber.Visible = false;
            // 
            // lblAttackGunship
            // 
            this.lblAttackGunship.AutoSize = true;
            this.lblAttackGunship.Location = new System.Drawing.Point(834, 291);
            this.lblAttackGunship.Name = "lblAttackGunship";
            this.lblAttackGunship.Size = new System.Drawing.Size(47, 13);
            this.lblAttackGunship.TabIndex = 159;
            this.lblAttackGunship.Text = "gunship:";
            this.lblAttackGunship.Visible = false;
            // 
            // lblAttackScout
            // 
            this.lblAttackScout.AutoSize = true;
            this.lblAttackScout.Location = new System.Drawing.Point(834, 247);
            this.lblAttackScout.Name = "lblAttackScout";
            this.lblAttackScout.Size = new System.Drawing.Size(36, 13);
            this.lblAttackScout.TabIndex = 158;
            this.lblAttackScout.Text = "scout:";
            this.lblAttackScout.Visible = false;
            // 
            // txtAttackBattleship
            // 
            this.txtAttackBattleship.Location = new System.Drawing.Point(948, 520);
            this.txtAttackBattleship.Name = "txtAttackBattleship";
            this.txtAttackBattleship.Size = new System.Drawing.Size(100, 20);
            this.txtAttackBattleship.TabIndex = 171;
            this.txtAttackBattleship.Text = "0";
            this.txtAttackBattleship.Visible = false;
            // 
            // txtAttackCarrier
            // 
            this.txtAttackCarrier.Location = new System.Drawing.Point(948, 474);
            this.txtAttackCarrier.Name = "txtAttackCarrier";
            this.txtAttackCarrier.Size = new System.Drawing.Size(100, 20);
            this.txtAttackCarrier.TabIndex = 170;
            this.txtAttackCarrier.Text = "0";
            this.txtAttackCarrier.Visible = false;
            // 
            // txtAttackDestroyer
            // 
            this.txtAttackDestroyer.Location = new System.Drawing.Point(948, 428);
            this.txtAttackDestroyer.Name = "txtAttackDestroyer";
            this.txtAttackDestroyer.Size = new System.Drawing.Size(100, 20);
            this.txtAttackDestroyer.TabIndex = 169;
            this.txtAttackDestroyer.Text = "0";
            this.txtAttackDestroyer.Visible = false;
            // 
            // txtAttackFrigate
            // 
            this.txtAttackFrigate.Location = new System.Drawing.Point(948, 382);
            this.txtAttackFrigate.Name = "txtAttackFrigate";
            this.txtAttackFrigate.Size = new System.Drawing.Size(100, 20);
            this.txtAttackFrigate.TabIndex = 168;
            this.txtAttackFrigate.Text = "0";
            this.txtAttackFrigate.Visible = false;
            // 
            // txtAttackBomber
            // 
            this.txtAttackBomber.Location = new System.Drawing.Point(948, 338);
            this.txtAttackBomber.Name = "txtAttackBomber";
            this.txtAttackBomber.Size = new System.Drawing.Size(100, 20);
            this.txtAttackBomber.TabIndex = 167;
            this.txtAttackBomber.Text = "0";
            this.txtAttackBomber.Visible = false;
            // 
            // txtAttackGunship
            // 
            this.txtAttackGunship.Location = new System.Drawing.Point(948, 292);
            this.txtAttackGunship.Name = "txtAttackGunship";
            this.txtAttackGunship.Size = new System.Drawing.Size(100, 20);
            this.txtAttackGunship.TabIndex = 166;
            this.txtAttackGunship.Text = "0";
            this.txtAttackGunship.Visible = false;
            // 
            // txtAttackScout
            // 
            this.txtAttackScout.Location = new System.Drawing.Point(948, 247);
            this.txtAttackScout.Name = "txtAttackScout";
            this.txtAttackScout.Size = new System.Drawing.Size(100, 20);
            this.txtAttackScout.TabIndex = 165;
            this.txtAttackScout.Text = "0";
            this.txtAttackScout.Visible = false;
            // 
            // btnSendAttack
            // 
            this.btnSendAttack.Location = new System.Drawing.Point(1017, 559);
            this.btnSendAttack.Name = "btnSendAttack";
            this.btnSendAttack.Size = new System.Drawing.Size(119, 23);
            this.btnSendAttack.TabIndex = 172;
            this.btnSendAttack.Text = "Attack";
            this.btnSendAttack.UseVisualStyleBackColor = true;
            this.btnSendAttack.Visible = false;
            this.btnSendAttack.Click += new System.EventHandler(this.btnSendAttack_Click);
            // 
            // BtnMessages
            // 
            this.BtnMessages.Location = new System.Drawing.Point(641, 7);
            this.BtnMessages.Name = "BtnMessages";
            this.BtnMessages.Size = new System.Drawing.Size(117, 23);
            this.BtnMessages.TabIndex = 173;
            this.BtnMessages.Text = "Messages";
            this.BtnMessages.UseVisualStyleBackColor = true;
            this.BtnMessages.Click += new System.EventHandler(this.BtnMessages_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 681);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 174;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 626);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 175;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(10, 75);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 23);
            this.button5.TabIndex = 176;
            this.button5.Text = "Universe";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(10, 156);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(104, 23);
            this.button6.TabIndex = 177;
            this.button6.Text = "Home";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // cmdReinforce
            // 
            this.cmdReinforce.Location = new System.Drawing.Point(1323, 705);
            this.cmdReinforce.Name = "cmdReinforce";
            this.cmdReinforce.Size = new System.Drawing.Size(119, 23);
            this.cmdReinforce.TabIndex = 192;
            this.cmdReinforce.Text = "Reinforce";
            this.cmdReinforce.UseVisualStyleBackColor = true;
            this.cmdReinforce.Visible = false;
            this.cmdReinforce.Click += new System.EventHandler(this.cmdReinforce_Click);
            // 
            // txtReinforceBattleship
            // 
            this.txtReinforceBattleship.Location = new System.Drawing.Point(1233, 396);
            this.txtReinforceBattleship.Name = "txtReinforceBattleship";
            this.txtReinforceBattleship.Size = new System.Drawing.Size(100, 20);
            this.txtReinforceBattleship.TabIndex = 191;
            this.txtReinforceBattleship.Text = "0";
            this.txtReinforceBattleship.Visible = false;
            // 
            // txtReinforceCarrier
            // 
            this.txtReinforceCarrier.Location = new System.Drawing.Point(1233, 350);
            this.txtReinforceCarrier.Name = "txtReinforceCarrier";
            this.txtReinforceCarrier.Size = new System.Drawing.Size(100, 20);
            this.txtReinforceCarrier.TabIndex = 190;
            this.txtReinforceCarrier.Text = "0";
            this.txtReinforceCarrier.Visible = false;
            // 
            // txtReinforceDestroyer
            // 
            this.txtReinforceDestroyer.Location = new System.Drawing.Point(1233, 304);
            this.txtReinforceDestroyer.Name = "txtReinforceDestroyer";
            this.txtReinforceDestroyer.Size = new System.Drawing.Size(100, 20);
            this.txtReinforceDestroyer.TabIndex = 189;
            this.txtReinforceDestroyer.Text = "0";
            this.txtReinforceDestroyer.Visible = false;
            // 
            // txtReinforceFrigate
            // 
            this.txtReinforceFrigate.Location = new System.Drawing.Point(1233, 258);
            this.txtReinforceFrigate.Name = "txtReinforceFrigate";
            this.txtReinforceFrigate.Size = new System.Drawing.Size(100, 20);
            this.txtReinforceFrigate.TabIndex = 188;
            this.txtReinforceFrigate.Text = "0";
            this.txtReinforceFrigate.Visible = false;
            // 
            // txtReinforceBomber
            // 
            this.txtReinforceBomber.Location = new System.Drawing.Point(1233, 214);
            this.txtReinforceBomber.Name = "txtReinforceBomber";
            this.txtReinforceBomber.Size = new System.Drawing.Size(100, 20);
            this.txtReinforceBomber.TabIndex = 187;
            this.txtReinforceBomber.Text = "0";
            this.txtReinforceBomber.Visible = false;
            // 
            // txtReinforceGunship
            // 
            this.txtReinforceGunship.Location = new System.Drawing.Point(1233, 168);
            this.txtReinforceGunship.Name = "txtReinforceGunship";
            this.txtReinforceGunship.Size = new System.Drawing.Size(100, 20);
            this.txtReinforceGunship.TabIndex = 186;
            this.txtReinforceGunship.Text = "0";
            this.txtReinforceGunship.Visible = false;
            // 
            // txtReinforceScout
            // 
            this.txtReinforceScout.Location = new System.Drawing.Point(1233, 123);
            this.txtReinforceScout.Name = "txtReinforceScout";
            this.txtReinforceScout.Size = new System.Drawing.Size(100, 20);
            this.txtReinforceScout.TabIndex = 185;
            this.txtReinforceScout.Text = "0";
            this.txtReinforceScout.Visible = false;
            // 
            // lblReinforceBattleShip
            // 
            this.lblReinforceBattleShip.AutoSize = true;
            this.lblReinforceBattleShip.Location = new System.Drawing.Point(1119, 395);
            this.lblReinforceBattleShip.Name = "lblReinforceBattleShip";
            this.lblReinforceBattleShip.Size = new System.Drawing.Size(49, 13);
            this.lblReinforceBattleShip.TabIndex = 184;
            this.lblReinforceBattleShip.Text = "batleship";
            this.lblReinforceBattleShip.Visible = false;
            // 
            // lblReinforceCarrier
            // 
            this.lblReinforceCarrier.AutoSize = true;
            this.lblReinforceCarrier.Location = new System.Drawing.Point(1119, 349);
            this.lblReinforceCarrier.Name = "lblReinforceCarrier";
            this.lblReinforceCarrier.Size = new System.Drawing.Size(36, 13);
            this.lblReinforceCarrier.TabIndex = 183;
            this.lblReinforceCarrier.Text = "carrier";
            this.lblReinforceCarrier.Visible = false;
            // 
            // lblReinforceDestroyer
            // 
            this.lblReinforceDestroyer.AutoSize = true;
            this.lblReinforceDestroyer.Location = new System.Drawing.Point(1119, 303);
            this.lblReinforceDestroyer.Name = "lblReinforceDestroyer";
            this.lblReinforceDestroyer.Size = new System.Drawing.Size(50, 13);
            this.lblReinforceDestroyer.TabIndex = 182;
            this.lblReinforceDestroyer.Text = "destroyer";
            this.lblReinforceDestroyer.Visible = false;
            // 
            // lblReinforceFrigate
            // 
            this.lblReinforceFrigate.AutoSize = true;
            this.lblReinforceFrigate.Location = new System.Drawing.Point(1119, 257);
            this.lblReinforceFrigate.Name = "lblReinforceFrigate";
            this.lblReinforceFrigate.Size = new System.Drawing.Size(36, 13);
            this.lblReinforceFrigate.TabIndex = 181;
            this.lblReinforceFrigate.Text = "frigate";
            this.lblReinforceFrigate.Visible = false;
            // 
            // lblReinforceBomber
            // 
            this.lblReinforceBomber.AutoSize = true;
            this.lblReinforceBomber.Location = new System.Drawing.Point(1119, 213);
            this.lblReinforceBomber.Name = "lblReinforceBomber";
            this.lblReinforceBomber.Size = new System.Drawing.Size(45, 13);
            this.lblReinforceBomber.TabIndex = 180;
            this.lblReinforceBomber.Text = "bomber:";
            this.lblReinforceBomber.Visible = false;
            // 
            // lblReinforceGunship
            // 
            this.lblReinforceGunship.AutoSize = true;
            this.lblReinforceGunship.Location = new System.Drawing.Point(1119, 167);
            this.lblReinforceGunship.Name = "lblReinforceGunship";
            this.lblReinforceGunship.Size = new System.Drawing.Size(47, 13);
            this.lblReinforceGunship.TabIndex = 179;
            this.lblReinforceGunship.Text = "gunship:";
            this.lblReinforceGunship.Visible = false;
            // 
            // lblReinforceScout
            // 
            this.lblReinforceScout.AutoSize = true;
            this.lblReinforceScout.Location = new System.Drawing.Point(1119, 123);
            this.lblReinforceScout.Name = "lblReinforceScout";
            this.lblReinforceScout.Size = new System.Drawing.Size(36, 13);
            this.lblReinforceScout.TabIndex = 178;
            this.lblReinforceScout.Text = "scout:";
            this.lblReinforceScout.Visible = false;
            // 
            // lblReinforceDroneBase
            // 
            this.lblReinforceDroneBase.AutoSize = true;
            this.lblReinforceDroneBase.Location = new System.Drawing.Point(1121, 633);
            this.lblReinforceDroneBase.Name = "lblReinforceDroneBase";
            this.lblReinforceDroneBase.Size = new System.Drawing.Size(63, 13);
            this.lblReinforceDroneBase.TabIndex = 197;
            this.lblReinforceDroneBase.Text = "drone base:";
            this.lblReinforceDroneBase.Visible = false;
            // 
            // lblReinforceArtillery
            // 
            this.lblReinforceArtillery.AutoSize = true;
            this.lblReinforceArtillery.Location = new System.Drawing.Point(1121, 587);
            this.lblReinforceArtillery.Name = "lblReinforceArtillery";
            this.lblReinforceArtillery.Size = new System.Drawing.Size(42, 13);
            this.lblReinforceArtillery.TabIndex = 196;
            this.lblReinforceArtillery.Text = "artillery:";
            this.lblReinforceArtillery.Visible = false;
            // 
            // lblReinforceTurret
            // 
            this.lblReinforceTurret.AutoSize = true;
            this.lblReinforceTurret.Location = new System.Drawing.Point(1121, 543);
            this.lblReinforceTurret.Name = "lblReinforceTurret";
            this.lblReinforceTurret.Size = new System.Drawing.Size(34, 13);
            this.lblReinforceTurret.TabIndex = 195;
            this.lblReinforceTurret.Text = "turret:";
            this.lblReinforceTurret.Visible = false;
            // 
            // lblReinforceGunner
            // 
            this.lblReinforceGunner.AutoSize = true;
            this.lblReinforceGunner.Location = new System.Drawing.Point(1121, 497);
            this.lblReinforceGunner.Name = "lblReinforceGunner";
            this.lblReinforceGunner.Size = new System.Drawing.Size(43, 13);
            this.lblReinforceGunner.TabIndex = 194;
            this.lblReinforceGunner.Text = "gunner:";
            this.lblReinforceGunner.Visible = false;
            // 
            // lblReinforcePatrol
            // 
            this.lblReinforcePatrol.AutoSize = true;
            this.lblReinforcePatrol.Location = new System.Drawing.Point(1121, 452);
            this.lblReinforcePatrol.Name = "lblReinforcePatrol";
            this.lblReinforcePatrol.Size = new System.Drawing.Size(36, 13);
            this.lblReinforcePatrol.TabIndex = 193;
            this.lblReinforcePatrol.Text = "patrol:";
            this.lblReinforcePatrol.Visible = false;
            // 
            // txtReinforceDroneBase
            // 
            this.txtReinforceDroneBase.Location = new System.Drawing.Point(1233, 628);
            this.txtReinforceDroneBase.Name = "txtReinforceDroneBase";
            this.txtReinforceDroneBase.Size = new System.Drawing.Size(100, 20);
            this.txtReinforceDroneBase.TabIndex = 202;
            this.txtReinforceDroneBase.Text = "0";
            this.txtReinforceDroneBase.Visible = false;
            // 
            // txtReinforceArtillery
            // 
            this.txtReinforceArtillery.Location = new System.Drawing.Point(1233, 582);
            this.txtReinforceArtillery.Name = "txtReinforceArtillery";
            this.txtReinforceArtillery.Size = new System.Drawing.Size(100, 20);
            this.txtReinforceArtillery.TabIndex = 201;
            this.txtReinforceArtillery.Text = "0";
            this.txtReinforceArtillery.Visible = false;
            // 
            // txtReinforceTurret
            // 
            this.txtReinforceTurret.Location = new System.Drawing.Point(1233, 536);
            this.txtReinforceTurret.Name = "txtReinforceTurret";
            this.txtReinforceTurret.Size = new System.Drawing.Size(100, 20);
            this.txtReinforceTurret.TabIndex = 200;
            this.txtReinforceTurret.Text = "0";
            this.txtReinforceTurret.Visible = false;
            // 
            // txtReinforceGunner
            // 
            this.txtReinforceGunner.Location = new System.Drawing.Point(1233, 490);
            this.txtReinforceGunner.Name = "txtReinforceGunner";
            this.txtReinforceGunner.Size = new System.Drawing.Size(100, 20);
            this.txtReinforceGunner.TabIndex = 199;
            this.txtReinforceGunner.Text = "0";
            this.txtReinforceGunner.Visible = false;
            // 
            // txtReinforcePartrol
            // 
            this.txtReinforcePartrol.Location = new System.Drawing.Point(1233, 446);
            this.txtReinforcePartrol.Name = "txtReinforcePartrol";
            this.txtReinforcePartrol.Size = new System.Drawing.Size(100, 20);
            this.txtReinforcePartrol.TabIndex = 198;
            this.txtReinforcePartrol.Text = "0";
            this.txtReinforcePartrol.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(1233, 47);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(62, 23);
            this.button7.TabIndex = 203;
            this.button7.Text = "Reinforce";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // LstBuildingsBuildQueue
            // 
            this.LstBuildingsBuildQueue.FormattingEnabled = true;
            this.LstBuildingsBuildQueue.Location = new System.Drawing.Point(842, 609);
            this.LstBuildingsBuildQueue.Name = "LstBuildingsBuildQueue";
            this.LstBuildingsBuildQueue.Size = new System.Drawing.Size(273, 121);
            this.LstBuildingsBuildQueue.TabIndex = 204;
            this.LstBuildingsBuildQueue.Visible = false;
            // 
            // btnRemoveBuildings
            // 
            this.btnRemoveBuildings.Location = new System.Drawing.Point(1033, 740);
            this.btnRemoveBuildings.Name = "btnRemoveBuildings";
            this.btnRemoveBuildings.Size = new System.Drawing.Size(136, 23);
            this.btnRemoveBuildings.TabIndex = 205;
            this.btnRemoveBuildings.Text = "Remove Build Item";
            this.btnRemoveBuildings.UseVisualStyleBackColor = true;
            this.btnRemoveBuildings.Visible = false;
            this.btnRemoveBuildings.Click += new System.EventHandler(this.txtRemoveBuildings_Click);
            // 
            // btnRemoveOffenceList
            // 
            this.btnRemoveOffenceList.Location = new System.Drawing.Point(1051, 734);
            this.btnRemoveOffenceList.Name = "btnRemoveOffenceList";
            this.btnRemoveOffenceList.Size = new System.Drawing.Size(149, 23);
            this.btnRemoveOffenceList.TabIndex = 207;
            this.btnRemoveOffenceList.Text = "Remove Offence Build Item";
            this.btnRemoveOffenceList.UseVisualStyleBackColor = true;
            this.btnRemoveOffenceList.Visible = false;
            this.btnRemoveOffenceList.Click += new System.EventHandler(this.btnRemoveOffenceList_Click);
            // 
            // LstRemoveOffenceList
            // 
            this.LstRemoveOffenceList.FormattingEnabled = true;
            this.LstRemoveOffenceList.Location = new System.Drawing.Point(854, 607);
            this.LstRemoveOffenceList.Name = "LstRemoveOffenceList";
            this.LstRemoveOffenceList.Size = new System.Drawing.Size(273, 121);
            this.LstRemoveOffenceList.TabIndex = 206;
            this.LstRemoveOffenceList.Visible = false;
            // 
            // btnRemoveDefenceList
            // 
            this.btnRemoveDefenceList.Location = new System.Drawing.Point(1061, 730);
            this.btnRemoveDefenceList.Name = "btnRemoveDefenceList";
            this.btnRemoveDefenceList.Size = new System.Drawing.Size(149, 23);
            this.btnRemoveDefenceList.TabIndex = 209;
            this.btnRemoveDefenceList.Text = "Remove Defence Build Item";
            this.btnRemoveDefenceList.UseVisualStyleBackColor = true;
            this.btnRemoveDefenceList.Visible = false;
            this.btnRemoveDefenceList.Click += new System.EventHandler(this.btnRemoveDefenceList_Click);
            // 
            // LstRemoveDefenceList
            // 
            this.LstRemoveDefenceList.FormattingEnabled = true;
            this.LstRemoveDefenceList.Location = new System.Drawing.Point(864, 603);
            this.LstRemoveDefenceList.Name = "LstRemoveDefenceList";
            this.LstRemoveDefenceList.Size = new System.Drawing.Size(273, 121);
            this.LstRemoveDefenceList.TabIndex = 208;
            this.LstRemoveDefenceList.Visible = false;
            // 
            // BtnMoveOutpost
            // 
            this.BtnMoveOutpost.Location = new System.Drawing.Point(1310, 47);
            this.BtnMoveOutpost.Name = "BtnMoveOutpost";
            this.BtnMoveOutpost.Size = new System.Drawing.Size(89, 23);
            this.BtnMoveOutpost.TabIndex = 210;
            this.BtnMoveOutpost.Text = "Move Outpost";
            this.BtnMoveOutpost.UseVisualStyleBackColor = true;
            this.BtnMoveOutpost.Visible = false;
            this.BtnMoveOutpost.Click += new System.EventHandler(this.BtnMoveOutpost_Click);
            // 
            // Map
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1498, 831);
            this.Controls.Add(this.BtnMoveOutpost);
            this.Controls.Add(this.btnRemoveDefenceList);
            this.Controls.Add(this.LstRemoveDefenceList);
            this.Controls.Add(this.btnRemoveOffenceList);
            this.Controls.Add(this.LstRemoveOffenceList);
            this.Controls.Add(this.btnRemoveBuildings);
            this.Controls.Add(this.LstBuildingsBuildQueue);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.txtReinforceDroneBase);
            this.Controls.Add(this.txtReinforceArtillery);
            this.Controls.Add(this.txtReinforceTurret);
            this.Controls.Add(this.txtReinforceGunner);
            this.Controls.Add(this.txtReinforcePartrol);
            this.Controls.Add(this.lblReinforceDroneBase);
            this.Controls.Add(this.lblReinforceArtillery);
            this.Controls.Add(this.lblReinforceTurret);
            this.Controls.Add(this.lblReinforceGunner);
            this.Controls.Add(this.lblReinforcePatrol);
            this.Controls.Add(this.cmdReinforce);
            this.Controls.Add(this.txtReinforceBattleship);
            this.Controls.Add(this.txtReinforceCarrier);
            this.Controls.Add(this.txtReinforceDestroyer);
            this.Controls.Add(this.txtReinforceFrigate);
            this.Controls.Add(this.txtReinforceBomber);
            this.Controls.Add(this.txtReinforceGunship);
            this.Controls.Add(this.txtReinforceScout);
            this.Controls.Add(this.lblReinforceBattleShip);
            this.Controls.Add(this.lblReinforceCarrier);
            this.Controls.Add(this.lblReinforceDestroyer);
            this.Controls.Add(this.lblReinforceFrigate);
            this.Controls.Add(this.lblReinforceBomber);
            this.Controls.Add(this.lblReinforceGunship);
            this.Controls.Add(this.lblReinforceScout);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.BtnMessages);
            this.Controls.Add(this.btnSendAttack);
            this.Controls.Add(this.txtAttackBattleship);
            this.Controls.Add(this.txtAttackCarrier);
            this.Controls.Add(this.txtAttackDestroyer);
            this.Controls.Add(this.txtAttackFrigate);
            this.Controls.Add(this.txtAttackBomber);
            this.Controls.Add(this.txtAttackGunship);
            this.Controls.Add(this.txtAttackScout);
            this.Controls.Add(this.lblAttackBattleship);
            this.Controls.Add(this.lblAttackCarrier);
            this.Controls.Add(this.lblAttackDestroyer);
            this.Controls.Add(this.lblAttaackFrigate);
            this.Controls.Add(this.lblAttackBomber);
            this.Controls.Add(this.lblAttackGunship);
            this.Controls.Add(this.lblAttackScout);
            this.Controls.Add(this.BtnAttack);
            this.Controls.Add(this.LblSelectedBase);
            this.Controls.Add(this.btnOffenceBuild);
            this.Controls.Add(this.BtnOffence);
            this.Controls.Add(this.lblCostBattleship);
            this.Controls.Add(this.lblCostCarrier);
            this.Controls.Add(this.lblBattleshipBuild);
            this.Controls.Add(this.lblCarrierBuild);
            this.Controls.Add(this.lblBattleship);
            this.Controls.Add(this.lblCarrier);
            this.Controls.Add(this.txtBattleship);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.txtCarrier);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.lblBattleshipAttack);
            this.Controls.Add(this.lblCarrierAttack);
            this.Controls.Add(this.lblCostDestroyer);
            this.Controls.Add(this.lblCostFrigate);
            this.Controls.Add(this.lblCostBomber);
            this.Controls.Add(this.lblCostGunship);
            this.Controls.Add(this.lblCostScout);
            this.Controls.Add(this.lblOffCost);
            this.Controls.Add(this.lblOffBuild);
            this.Controls.Add(this.lblDestroyerBuild);
            this.Controls.Add(this.lblFrigateBuild);
            this.Controls.Add(this.lblBomberBuild);
            this.Controls.Add(this.lblGunshipBuild);
            this.Controls.Add(this.lblScoutBuild);
            this.Controls.Add(this.lblDestroyer);
            this.Controls.Add(this.lblFrigate);
            this.Controls.Add(this.lblBomber);
            this.Controls.Add(this.lblGunship);
            this.Controls.Add(this.lblScout);
            this.Controls.Add(this.lblOffFuture);
            this.Controls.Add(this.lblOffExtant);
            this.Controls.Add(this.txtDestroyer);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.txtFrigate);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.txtBomber);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.txtGunship);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.txtScout);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.lblDestoyerAttack);
            this.Controls.Add(this.lblFrigateAttack);
            this.Controls.Add(this.lblBomberAttack);
            this.Controls.Add(this.lblGunshipAttack);
            this.Controls.Add(this.lblScoutAttack);
            this.Controls.Add(this.lblOffenceAttack);
            this.Controls.Add(this.lblDefenceDroneBase);
            this.Controls.Add(this.lblDefenceArtillery);
            this.Controls.Add(this.lblDefenceTurret);
            this.Controls.Add(this.lblDefenceGunner);
            this.Controls.Add(this.lblDefencePatrol);
            this.Controls.Add(this.lblDefPoints);
            this.Controls.Add(this.lblCostDroneBase);
            this.Controls.Add(this.lblCostArtillery);
            this.Controls.Add(this.lblCostTurret);
            this.Controls.Add(this.lblCostGunner);
            this.Controls.Add(this.lblCostPatrol);
            this.Controls.Add(this.lblDefCost);
            this.Controls.Add(this.btnBuildDefence);
            this.Controls.Add(this.lblDefBuild);
            this.Controls.Add(this.lblDroneBaseBuild);
            this.Controls.Add(this.lblArtilleryBuild);
            this.Controls.Add(this.lblTurretBuild);
            this.Controls.Add(this.lblGunnerBuild);
            this.Controls.Add(this.lblPatrolBuild);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.lblDefFuture);
            this.Controls.Add(this.lblDefExtant);
            this.Controls.Add(this.txtDroneBase);
            this.Controls.Add(this.lblDroneBase);
            this.Controls.Add(this.txtArtillery);
            this.Controls.Add(this.lblArtillery);
            this.Controls.Add(this.txtTurret);
            this.Controls.Add(this.lblTurret);
            this.Controls.Add(this.txtGunner);
            this.Controls.Add(this.lblGunner);
            this.Controls.Add(this.txtPatrol);
            this.Controls.Add(this.lblPatrol);
            this.Controls.Add(this.BtnDef);
            this.Controls.Add(this.lblProductionFabricator);
            this.Controls.Add(this.lblProductionSolar);
            this.Controls.Add(this.lblProductionFarm);
            this.Controls.Add(this.lblProductionHabitat);
            this.Controls.Add(this.lblProductionWell);
            this.Controls.Add(this.lblProductionMine);
            this.Controls.Add(this.lblProduction);
            this.Controls.Add(this.lblCostFabricator);
            this.Controls.Add(this.lblCostSolarPlant);
            this.Controls.Add(this.lblCostFarm);
            this.Controls.Add(this.LblCostHabitabt);
            this.Controls.Add(this.lblCostWell);
            this.Controls.Add(this.LblCostMine);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.cmdBuild);
            this.Controls.Add(this.lblBuild);
            this.Controls.Add(this.lblBuildFabricator);
            this.Controls.Add(this.LblBuildSolarPlant);
            this.Controls.Add(this.lblBuildFarm);
            this.Controls.Add(this.lblBuildHabitat);
            this.Controls.Add(this.lblBuildWell);
            this.Controls.Add(this.lblBuildMine);
            this.Controls.Add(this.label666);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblEmpty);
            this.Controls.Add(this.lblFuture);
            this.Controls.Add(this.lblExtant);
            this.Controls.Add(this.txtFabricator);
            this.Controls.Add(this.lblfabricator);
            this.Controls.Add(this.txtSolarPlant);
            this.Controls.Add(this.LblSolarPlant);
            this.Controls.Add(this.txtFarm);
            this.Controls.Add(this.LblFarm);
            this.Controls.Add(this.txtHabitat);
            this.Controls.Add(this.lblHabitat);
            this.Controls.Add(this.txtWell);
            this.Controls.Add(this.lblWell);
            this.Controls.Add(this.txtMine);
            this.Controls.Add(this.lblMine);
            this.Controls.Add(this.BtnBuild);
            this.Controls.Add(this.LblWater);
            this.Controls.Add(this.LblFood);
            this.Controls.Add(this.LblPopulation);
            this.Controls.Add(this.LblEnergy);
            this.Controls.Add(this.LblMetal);
            this.Controls.Add(this.LblSidePanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MapCanvas);
            this.Name = "Map";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MapCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
               

        #endregion

        private Button button1;
        private PictureBox MapCanvas;
        private Button button2;
        private Label LblSidePanel;
        private Label LblMetal;
        private Label LblEnergy;
        private Label LblPopulation;
        private Label LblFood;
        private Label LblWater;
        private Button BtnBuild;
        private Label lblMine;
        private TextBox txtMine;
        private TextBox txtWell;
        private Label lblWell;
        private TextBox txtHabitat;
        private Label lblHabitat;
        private TextBox txtFarm;
        private Label LblFarm;
        private TextBox txtSolarPlant;
        private Label LblSolarPlant;
        private TextBox txtFabricator;
        private Label lblfabricator;
        private Label lblExtant;
        private Label lblFuture;
        private Label lblEmpty;
        private Label label666;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label lblBuildFabricator;
        private Label LblBuildSolarPlant;
        private Label lblBuildFarm;
        private Label lblBuildHabitat;
        private Label lblBuildWell;
        private Label lblBuildMine;
        private Label lblBuild;
        private Button cmdBuild;
        private Label lblCostFabricator;
        private Label lblCostSolarPlant;
        private Label lblCostFarm;
        private Label LblCostHabitabt;
        private Label lblCostWell;
        private Label LblCostMine;
        private Label lblCost;
        private Label lblProductionFabricator;
        private Label lblProductionSolar;
        private Label lblProductionFarm;
        private Label lblProductionHabitat;
        private Label lblProductionWell;
        private Label lblProductionMine;
        private Label lblProduction;
        private Button BtnDef;
        private Label lblDefenceDroneBase;
        private Label lblDefenceArtillery;
        private Label lblDefenceTurret;
        private Label lblDefenceGunner;
        private Label lblDefencePatrol;
        private Label lblDefPoints;
        private Label lblCostDroneBase;
        private Label lblCostArtillery;
        private Label lblCostTurret;
        private Label lblCostGunner;
        private Label lblCostPatrol;
        private Label lblDefCost;
        private Button btnBuildDefence;
        private Label lblDefBuild;
        private Label lblDroneBaseBuild;
        private Label lblArtilleryBuild;
        private Label lblTurretBuild;
        private Label lblGunnerBuild;
        private Label lblPatrolBuild;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label lblDefFuture;
        private Label lblDefExtant;
        private TextBox txtDroneBase;
        private Label lblDroneBase;
        private TextBox txtArtillery;
        private Label lblArtillery;
        private TextBox txtTurret;
        private Label lblTurret;
        private TextBox txtGunner;
        private Label lblGunner;
        private TextBox txtPatrol;
        private Label lblPatrol;
        private Label lblCostDestroyer;
        private Label lblCostFrigate;
        private Label lblCostBomber;
        private Label lblCostGunship;
        private Label lblCostScout;
        private Label lblOffCost;
        private Label lblOffBuild;
        private Label lblDestroyerBuild;
        private Label lblFrigateBuild;
        private Label lblBomberBuild;
        private Label lblGunshipBuild;
        private Label lblScoutBuild;
        private Label lblDestroyer;
        private Label lblFrigate;
        private Label lblBomber;
        private Label lblGunship;
        private Label lblScout;
        private Label lblOffFuture;
        private Label lblOffExtant;
        private TextBox txtDestroyer;
        private Label label37;
        private TextBox txtFrigate;
        private Label label38;
        private TextBox txtBomber;
        private Label label39;
        private TextBox txtGunship;
        private Label label40;
        private TextBox txtScout;
        private Label label41;
        private Label lblDestoyerAttack;
        private Label lblFrigateAttack;
        private Label lblBomberAttack;
        private Label lblGunshipAttack;
        private Label lblScoutAttack;
        private Label lblOffenceAttack;
        private Label lblCostBattleship;
        private Label lblCostCarrier;
        private Label lblBattleshipBuild;
        private Label lblCarrierBuild;
        private Label lblBattleship;
        private Label lblCarrier;
        private TextBox txtBattleship;
        private Label label56;
        private TextBox txtCarrier;
        private Label label57;
        private Label lblBattleshipAttack;
        private Label lblCarrierAttack;
        private Button BtnOffence;
        private Button btnOffenceBuild;
        private Label LblSelectedBase;
        private Button BtnAttack;
        private Label lblAttackBattleship;
        private Label lblAttackCarrier;
        private Label lblAttackDestroyer;
        private Label lblAttaackFrigate;
        private Label lblAttackBomber;
        private Label lblAttackGunship;
        private Label lblAttackScout;
        private TextBox txtAttackBattleship;
        private TextBox txtAttackCarrier;
        private TextBox txtAttackDestroyer;
        private TextBox txtAttackFrigate;
        private TextBox txtAttackBomber;
        private TextBox txtAttackGunship;
        private TextBox txtAttackScout;
        private Button btnSendAttack;
        private Button BtnMessages;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button cmdReinforce;
        private TextBox txtReinforceBattleship;
        private TextBox txtReinforceCarrier;
        private TextBox txtReinforceDestroyer;
        private TextBox txtReinforceFrigate;
        private TextBox txtReinforceBomber;
        private TextBox txtReinforceGunship;
        private TextBox txtReinforceScout;
        private Label lblReinforceBattleShip;
        private Label lblReinforceCarrier;
        private Label lblReinforceDestroyer;
        private Label lblReinforceFrigate;
        private Label lblReinforceBomber;
        private Label lblReinforceGunship;
        private Label lblReinforceScout;
        private Label lblReinforceDroneBase;
        private Label lblReinforceArtillery;
        private Label lblReinforceTurret;
        private Label lblReinforceGunner;
        private Label lblReinforcePatrol;
        private TextBox txtReinforceDroneBase;
        private TextBox txtReinforceArtillery;
        private TextBox txtReinforceTurret;
        private TextBox txtReinforceGunner;
        private TextBox txtReinforcePartrol;
        private Button button7;
        private ListBox LstBuildingsBuildQueue;
        private Button btnRemoveBuildings;
        private Button btnRemoveOffenceList;
        private ListBox LstRemoveOffenceList;
        private Button btnRemoveDefenceList;
        private ListBox LstRemoveDefenceList;
        private Button BtnMoveOutpost;
    }
}

