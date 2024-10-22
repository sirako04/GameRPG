using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineRPG;

namespace GameRPG
{ 
    public partial class AdventureRPG : Form
    {
        public  Player player;
        
        public AdventureRPG()
        {
            InitializeComponent();

            Location location = new Location(1, "Home", "This is your house!");


            player = new Player(15, 15, 20, 0, 1);

            currentHP.Text = player.CurrentHitPoints.ToString();
            currentGold.Text = player.Gold.ToString();
            currentExp.Text = player.ExperiencePoints.ToString();
            currentLVL.Text = player.Level.ToString();
            
        }


    }
}
