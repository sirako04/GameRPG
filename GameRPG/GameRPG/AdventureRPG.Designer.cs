using System;

namespace GameRPG
{
    partial class AdventureRPG
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.HP = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Gold = new System.Windows.Forms.Label();
            this.EXP = new System.Windows.Forms.Label();
            this.Lvl = new System.Windows.Forms.Label();
            this.lblHitPoints = new System.Windows.Forms.Label();
            this.lblGold = new System.Windows.Forms.Label();
            this.lblExperience = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.btnAction = new System.Windows.Forms.Label();
            this.cboWeapons = new System.Windows.Forms.ComboBox();
            this.cboPotions = new System.Windows.Forms.ComboBox();
            this.btnUseWeapon = new System.Windows.Forms.Button();
            this.btnUsePotion = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.rtbLocation = new System.Windows.Forms.RichTextBox();
            this.rtbMessages = new System.Windows.Forms.RichTextBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.dgvQuests = new System.Windows.Forms.DataGridView();
            this.btnTrade = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).BeginInit();
            this.SuspendLayout();
            // 
            // HP
            // 
            this.HP.AutoSize = true;
            this.HP.Location = new System.Drawing.Point(21, 19);
            this.HP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(61, 13);
            this.HP.TabIndex = 0;
            this.HP.Text = "Hit Points";
            // 
            // Gold
            // 
            this.Gold.AutoSize = true;
            this.Gold.Location = new System.Drawing.Point(21, 46);
            this.Gold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Gold.Name = "Gold";
            this.Gold.Size = new System.Drawing.Size(41, 13);
            this.Gold.TabIndex = 1;
            this.Gold.Text = "Gold : ";
            // 
            // EXP
            // 
            this.EXP.AutoSize = true;
            this.EXP.Location = new System.Drawing.Point(21, 74);
            this.EXP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EXP.Name = "EXP";
            this.EXP.Size = new System.Drawing.Size(30, 13);
            this.EXP.TabIndex = 2;
            this.EXP.Text = "EXP:";
            // 
            // Lvl
            // 
            this.Lvl.AutoSize = true;
            this.Lvl.Location = new System.Drawing.Point(21, 100);
            this.Lvl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lvl.Name = "Lvl";
            this.Lvl.Size = new System.Drawing.Size(43, 13);
            this.Lvl.TabIndex = 3;
            this.Lvl.Text = "Level :";
            // 
            // lblHitPoints
            // 
            this.lblHitPoints.AutoSize = true;
            this.lblHitPoints.Location = new System.Drawing.Point(84, 19);
            this.lblHitPoints.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHitPoints.Name = "lblHitPoints";
            this.lblHitPoints.Size = new System.Drawing.Size(0, 13);
            this.lblHitPoints.TabIndex = 4;
            // 
            // lblGold
            // 
            this.lblGold.AutoSize = true;
            this.lblGold.Location = new System.Drawing.Point(84, 45);
            this.lblGold.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGold.Name = "lblGold";
            this.lblGold.Size = new System.Drawing.Size(0, 13);
            this.lblGold.TabIndex = 5;
            // 
            // lblExperience
            // 
            this.lblExperience.AutoSize = true;
            this.lblExperience.Location = new System.Drawing.Point(84, 74);
            this.lblExperience.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExperience.Name = "lblExperience";
            this.lblExperience.Size = new System.Drawing.Size(0, 13);
            this.lblExperience.TabIndex = 6;
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Location = new System.Drawing.Point(84, 100);
            this.lblLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(0, 13);
            this.lblLevel.TabIndex = 7;
            // 
            // btnAction
            // 
            this.btnAction.AutoSize = true;
            this.btnAction.Location = new System.Drawing.Point(720, 531);
            this.btnAction.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(83, 13);
            this.btnAction.TabIndex = 8;
            this.btnAction.Text = "Select  action";
            // 
            // cboWeapons
            // 
            this.cboWeapons.BackColor = System.Drawing.Color.IndianRed;
            this.cboWeapons.FormattingEnabled = true;
            this.cboWeapons.Location = new System.Drawing.Point(430, 559);
            this.cboWeapons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboWeapons.Name = "cboWeapons";
            this.cboWeapons.Size = new System.Drawing.Size(140, 21);
            this.cboWeapons.TabIndex = 9;
            // 
            // cboPotions
            // 
            this.cboPotions.BackColor = System.Drawing.Color.Olive;
            this.cboPotions.FormattingEnabled = true;
            this.cboPotions.Location = new System.Drawing.Point(430, 593);
            this.cboPotions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cboPotions.Name = "cboPotions";
            this.cboPotions.Size = new System.Drawing.Size(140, 21);
            this.cboPotions.TabIndex = 10;
            // 
            // btnUseWeapon
            // 
            this.btnUseWeapon.BackColor = System.Drawing.Color.IndianRed;
            this.btnUseWeapon.Location = new System.Drawing.Point(723, 559);
            this.btnUseWeapon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUseWeapon.Name = "btnUseWeapon";
            this.btnUseWeapon.Size = new System.Drawing.Size(88, 23);
            this.btnUseWeapon.TabIndex = 11;
            this.btnUseWeapon.Text = "Attack";
            this.btnUseWeapon.UseVisualStyleBackColor = false;
            this.btnUseWeapon.Click += new System.EventHandler(this.btnUseWeapon_Click);
            // 
            // btnUsePotion
            // 
            this.btnUsePotion.BackColor = System.Drawing.Color.Olive;
            this.btnUsePotion.Location = new System.Drawing.Point(723, 593);
            this.btnUsePotion.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUsePotion.Name = "btnUsePotion";
            this.btnUsePotion.Size = new System.Drawing.Size(88, 23);
            this.btnUsePotion.TabIndex = 12;
            this.btnUsePotion.Text = "Consume";
            this.btnUsePotion.UseVisualStyleBackColor = false;
            this.btnUsePotion.Click += new System.EventHandler(this.btnUsePotion_Click);
            // 
            // btnNorth
            // 
            this.btnNorth.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnNorth.Location = new System.Drawing.Point(575, 433);
            this.btnNorth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(88, 23);
            this.btnNorth.TabIndex = 13;
            this.btnNorth.Text = "North";
            this.btnNorth.UseVisualStyleBackColor = false;
            this.btnNorth.Click += new System.EventHandler(this.btnNorth_Click);
            // 
            // btnEast
            // 
            this.btnEast.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnEast.Location = new System.Drawing.Point(668, 457);
            this.btnEast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(88, 23);
            this.btnEast.TabIndex = 14;
            this.btnEast.Text = "East";
            this.btnEast.UseVisualStyleBackColor = false;
            this.btnEast.Click += new System.EventHandler(this.btnEast_Click);
            // 
            // btnSouth
            // 
            this.btnSouth.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnSouth.Location = new System.Drawing.Point(575, 487);
            this.btnSouth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(88, 23);
            this.btnSouth.TabIndex = 15;
            this.btnSouth.Text = "South";
            this.btnSouth.UseVisualStyleBackColor = false;
            this.btnSouth.Click += new System.EventHandler(this.btnSouth_Click);
            // 
            // btnWest
            // 
            this.btnWest.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnWest.Location = new System.Drawing.Point(481, 457);
            this.btnWest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(88, 23);
            this.btnWest.TabIndex = 16;
            this.btnWest.Text = "West";
            this.btnWest.UseVisualStyleBackColor = false;
            this.btnWest.Click += new System.EventHandler(this.btnWest_Click);
            // 
            // rtbLocation
            // 
            this.rtbLocation.BackColor = System.Drawing.SystemColors.Info;
            this.rtbLocation.Location = new System.Drawing.Point(405, 19);
            this.rtbLocation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbLocation.Name = "rtbLocation";
            this.rtbLocation.ReadOnly = true;
            this.rtbLocation.Size = new System.Drawing.Size(419, 105);
            this.rtbLocation.TabIndex = 17;
            this.rtbLocation.Text = "";
            // 
            // rtbMessages
            // 
            this.rtbMessages.BackColor = System.Drawing.SystemColors.Info;
            this.rtbMessages.Location = new System.Drawing.Point(405, 130);
            this.rtbMessages.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbMessages.Name = "rtbMessages";
            this.rtbMessages.ReadOnly = true;
            this.rtbMessages.Size = new System.Drawing.Size(419, 286);
            this.rtbMessages.TabIndex = 18;
            this.rtbMessages.Text = "";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.AllowUserToResizeRows = false;
            this.dgvInventory.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventory.Enabled = false;
            this.dgvInventory.Location = new System.Drawing.Point(19, 130);
            this.dgvInventory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvInventory.MultiSelect = false;
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersVisible = false;
            this.dgvInventory.Size = new System.Drawing.Size(364, 309);
            this.dgvInventory.TabIndex = 19;
            // 
            // dgvQuests
            // 
            this.dgvQuests.AllowUserToAddRows = false;
            this.dgvQuests.AllowUserToDeleteRows = false;
            this.dgvQuests.AllowUserToResizeColumns = false;
            this.dgvQuests.AllowUserToResizeRows = false;
            this.dgvQuests.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvQuests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuests.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvQuests.Enabled = false;
            this.dgvQuests.Location = new System.Drawing.Point(19, 446);
            this.dgvQuests.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvQuests.MultiSelect = false;
            this.dgvQuests.Name = "dgvQuests";
            this.dgvQuests.ReadOnly = true;
            this.dgvQuests.RowHeadersVisible = false;
            this.dgvQuests.Size = new System.Drawing.Size(364, 189);
            this.dgvQuests.TabIndex = 20;
            // 
            // btnTrade
            // 
            this.btnTrade.BackColor = System.Drawing.Color.Gold;
            this.btnTrade.Location = new System.Drawing.Point(575, 612);
            this.btnTrade.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnTrade.Name = "btnTrade";
            this.btnTrade.Size = new System.Drawing.Size(88, 23);
            this.btnTrade.TabIndex = 21;
            this.btnTrade.Text = "Trade";
            this.btnTrade.UseVisualStyleBackColor = false;
            this.btnTrade.Click += new System.EventHandler(this.btnTrade_Click);
            // 
            // AdventureRPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(839, 651);
            this.Controls.Add(this.dgvQuests);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.rtbMessages);
            this.Controls.Add(this.rtbLocation);
            this.Controls.Add(this.btnTrade);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.btnUsePotion);
            this.Controls.Add(this.btnUseWeapon);
            this.Controls.Add(this.cboPotions);
            this.Controls.Add(this.cboWeapons);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblExperience);
            this.Controls.Add(this.lblGold);
            this.Controls.Add(this.lblHitPoints);
            this.Controls.Add(this.Lvl);
            this.Controls.Add(this.EXP);
            this.Controls.Add(this.Gold);
            this.Controls.Add(this.HP);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AdventureRPG";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.Text = "RPG Adventure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdventureRPG_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HP;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label Gold;
        private System.Windows.Forms.Label EXP;
        private System.Windows.Forms.Label Lvl;
        private System.Windows.Forms.Label lblHitPoints;
        private System.Windows.Forms.Label lblGold;
        private System.Windows.Forms.Label lblExperience;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label btnAction;
        private System.Windows.Forms.ComboBox cboWeapons;
        private System.Windows.Forms.ComboBox cboPotions;
        private System.Windows.Forms.Button btnUseWeapon;
        private System.Windows.Forms.Button btnUsePotion;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.Button btnTrade;
        private System.Windows.Forms.RichTextBox rtbLocation;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridView dgvQuests;
        private System.Windows.Forms.RichTextBox rtbMessages;
    }
}

