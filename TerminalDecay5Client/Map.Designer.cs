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
            ((System.ComponentModel.ISupportInitialize)(this.MapCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MapCanvas
            // 
            this.MapCanvas.Image = ((System.Drawing.Image)(resources.GetObject("MapCanvas.Image")));
            this.MapCanvas.Location = new System.Drawing.Point(127, 47);
            this.MapCanvas.Name = "MapCanvas";
            this.MapCanvas.Size = new System.Drawing.Size(678, 591);
            this.MapCanvas.TabIndex = 1;
            this.MapCanvas.TabStop = false;
            this.MapCanvas.Click += new System.EventHandler(this.MapCanvas_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
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
            this.BtnBuild.Location = new System.Drawing.Point(805, 47);
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
            this.lblProductionFabricator.Location = new System.Drawing.Point(757, 499);
            this.lblProductionFabricator.Name = "lblProductionFabricator";
            this.lblProductionFabricator.Size = new System.Drawing.Size(58, 13);
            this.lblProductionFabricator.TabIndex = 54;
            this.lblProductionFabricator.Text = "Production";
            this.lblProductionFabricator.Visible = false;
            // 
            // lblProductionSolar
            // 
            this.lblProductionSolar.AutoSize = true;
            this.lblProductionSolar.Location = new System.Drawing.Point(757, 444);
            this.lblProductionSolar.Name = "lblProductionSolar";
            this.lblProductionSolar.Size = new System.Drawing.Size(58, 13);
            this.lblProductionSolar.TabIndex = 53;
            this.lblProductionSolar.Text = "Production";
            this.lblProductionSolar.Visible = false;
            // 
            // lblProductionFarm
            // 
            this.lblProductionFarm.AutoSize = true;
            this.lblProductionFarm.Location = new System.Drawing.Point(757, 398);
            this.lblProductionFarm.Name = "lblProductionFarm";
            this.lblProductionFarm.Size = new System.Drawing.Size(58, 13);
            this.lblProductionFarm.TabIndex = 52;
            this.lblProductionFarm.Text = "Production";
            this.lblProductionFarm.Visible = false;
            // 
            // lblProductionHabitat
            // 
            this.lblProductionHabitat.AutoSize = true;
            this.lblProductionHabitat.Location = new System.Drawing.Point(757, 354);
            this.lblProductionHabitat.Name = "lblProductionHabitat";
            this.lblProductionHabitat.Size = new System.Drawing.Size(58, 13);
            this.lblProductionHabitat.TabIndex = 51;
            this.lblProductionHabitat.Text = "Production";
            this.lblProductionHabitat.Visible = false;
            // 
            // lblProductionWell
            // 
            this.lblProductionWell.AutoSize = true;
            this.lblProductionWell.Location = new System.Drawing.Point(757, 308);
            this.lblProductionWell.Name = "lblProductionWell";
            this.lblProductionWell.Size = new System.Drawing.Size(58, 13);
            this.lblProductionWell.TabIndex = 50;
            this.lblProductionWell.Text = "Production";
            this.lblProductionWell.Visible = false;
            // 
            // lblProductionMine
            // 
            this.lblProductionMine.AutoSize = true;
            this.lblProductionMine.Location = new System.Drawing.Point(757, 263);
            this.lblProductionMine.Name = "lblProductionMine";
            this.lblProductionMine.Size = new System.Drawing.Size(58, 13);
            this.lblProductionMine.TabIndex = 49;
            this.lblProductionMine.Text = "Production";
            this.lblProductionMine.Visible = false;
            // 
            // lblProduction
            // 
            this.lblProduction.AutoSize = true;
            this.lblProduction.Location = new System.Drawing.Point(757, 161);
            this.lblProduction.Name = "lblProduction";
            this.lblProduction.Size = new System.Drawing.Size(61, 13);
            this.lblProduction.TabIndex = 48;
            this.lblProduction.Text = "Production:";
            this.lblProduction.Visible = false;
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 831);
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
    }
}

