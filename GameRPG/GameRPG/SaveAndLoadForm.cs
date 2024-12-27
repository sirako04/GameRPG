using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineRPG;

namespace GameRPG
{
    public partial class SaveAndLoadForm : Form
    {
        private Player _player;   
        public SaveAndLoadForm()
        {
            InitializeComponent();
        }

        private void btnNewGame_Click( object sender, EventArgs e)
        {
            try
            {
                _player = Player.CreateDefaultPlayer();
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + " Source: " + ex.Source);
            }
            Close();
        }

        private void LoadPlayer_Click(object sender, EventArgs e)
        {
            try
            {
                _player = PlayerDataMapper.CreateFromDatabase();
               
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + " Source: " + ex.Source);
            }
            Close();         
        }
    }
}
