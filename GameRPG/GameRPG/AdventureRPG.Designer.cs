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
            this.currentHP = new System.Windows.Forms.Label();
            this.currentGold = new System.Windows.Forms.Label();
            this.currentExp = new System.Windows.Forms.Label();
            this.currentLVL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HP
            // 
            this.HP.AutoSize = true;
            this.HP.Location = new System.Drawing.Point(18, 19);
            this.HP.Name = "HP";
            this.HP.Size = new System.Drawing.Size(52, 13);
            this.HP.TabIndex = 0;
            this.HP.Text = "Hit Points";
            // 
            // Gold
            // 
            this.Gold.AutoSize = true;
            this.Gold.Location = new System.Drawing.Point(18, 46);
            this.Gold.Name = "Gold";
            this.Gold.Size = new System.Drawing.Size(38, 13);
            this.Gold.TabIndex = 1;
            this.Gold.Text = "Gold : ";
            // 
            // EXP
            // 
            this.EXP.AutoSize = true;
            this.EXP.Location = new System.Drawing.Point(18, 74);
            this.EXP.Name = "EXP";
            this.EXP.Size = new System.Drawing.Size(31, 13);
            this.EXP.TabIndex = 2;
            this.EXP.Text = "EXP:";
            // 
            // Lvl
            // 
            this.Lvl.AutoSize = true;
            this.Lvl.Location = new System.Drawing.Point(18, 100);
            this.Lvl.Name = "Lvl";
            this.Lvl.Size = new System.Drawing.Size(39, 13);
            this.Lvl.TabIndex = 3;
            this.Lvl.Text = "Level :";
            // 
            // currentHP
            // 
            this.currentHP.AutoSize = true;
            this.currentHP.Location = new System.Drawing.Point(72, 19);
            this.currentHP.Name = "currentHP";
            this.currentHP.Size = new System.Drawing.Size(0, 13);
            this.currentHP.TabIndex = 4;
            // 
            // currentGold
            // 
            this.currentGold.AutoSize = true;
            this.currentGold.Location = new System.Drawing.Point(72, 45);
            this.currentGold.Name = "currentGold";
            this.currentGold.Size = new System.Drawing.Size(0, 13);
            this.currentGold.TabIndex = 5;
            // 
            // currentExp
            // 
            this.currentExp.AutoSize = true;
            this.currentExp.Location = new System.Drawing.Point(72, 74);
            this.currentExp.Name = "currentExp";
            this.currentExp.Size = new System.Drawing.Size(0, 13);
            this.currentExp.TabIndex = 6;
            // 
            // currentLVL
            // 
            this.currentLVL.AutoSize = true;
            this.currentLVL.Location = new System.Drawing.Point(72, 100);
            this.currentLVL.Name = "currentLVL";
            this.currentLVL.Size = new System.Drawing.Size(0, 13);
            this.currentLVL.TabIndex = 7;
            // 
            // AdventureRPG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 651);
            this.Controls.Add(this.currentLVL);
            this.Controls.Add(this.currentExp);
            this.Controls.Add(this.currentGold);
            this.Controls.Add(this.currentHP);
            this.Controls.Add(this.Lvl);
            this.Controls.Add(this.EXP);
            this.Controls.Add(this.Gold);
            this.Controls.Add(this.HP);
            this.Name = "AdventureRPG";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.Text = "RPG Adventure";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HP;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label Gold;
        private System.Windows.Forms.Label EXP;
        private System.Windows.Forms.Label Lvl;
        private System.Windows.Forms.Label currentHP;
        private System.Windows.Forms.Label currentGold;
        private System.Windows.Forms.Label currentExp;
        private System.Windows.Forms.Label currentLVL;
    }
}

