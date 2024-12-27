namespace GameRPG
{
    partial class SaveAndLoadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveAndLoadForm));
            this.btnNewGame = new System.Windows.Forms.Button();
            this.LoadPlayer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewGame
            // 
            resources.ApplyResources(this.btnNewGame, "btnNewGame");
            this.btnNewGame.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewGame.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // LoadPlayer
            // 
            resources.ApplyResources(this.LoadPlayer, "LoadPlayer");
            this.LoadPlayer.BackColor = System.Drawing.Color.RoyalBlue;
            this.LoadPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoadPlayer.ForeColor = System.Drawing.Color.AliceBlue;
            this.LoadPlayer.Name = "LoadPlayer";
            this.LoadPlayer.UseVisualStyleBackColor = false;
            this.LoadPlayer.Click += new System.EventHandler(this.LoadPlayer_Click);
            // 
            // SaveAndLoadForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.YellowGreen;
            this.Controls.Add(this.LoadPlayer);
            this.Controls.Add(this.btnNewGame);
            this.Name = "SaveAndLoadForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button LoadPlayer;
    }
}