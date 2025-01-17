﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using EngineRPG;
using System.IO;

namespace GameRPG
{
    public partial class AdventureRPG : Form
    {
        private Player _player;
        private const string PLAYER_DATA_FILE_NAME = "PlayerData.xml";

        public AdventureRPG()
        {
            InitializeComponent();

            _player = PlayerDataMapper.CreateFromDatabase();
            if (_player == null)
            {
                if (File.Exists(PLAYER_DATA_FILE_NAME))
                {
                    _player = Player.CreatePlayerFromXmlString(File.ReadAllText(PLAYER_DATA_FILE_NAME));
                }
                else
                {
                    _player = Player.CreateDefaultPlayer();
                }
            }
            BindingPlayerDataToUI();
        }

        private void BindingPlayerDataToUI()
        {
            lblHitPoints.DataBindings.Add(nameof(Text), _player, nameof(_player.CurrentHitPoints));
            lblGold.DataBindings.Add(nameof(Text), _player, nameof(_player.Gold));
            lblExperience.DataBindings.Add(nameof(Text), _player, nameof(_player.ExperiencePoints));
            lblLevel.DataBindings.Add(nameof(Text), _player, nameof(_player.Level));

            cboWeapons.DataSource = _player.Weapons;
            cboWeapons.DisplayMember = "Name";
            cboWeapons.ValueMember = "Id";
            if (_player.CurrentWeapon != null)
            {
                cboWeapons.SelectedItem = _player.CurrentWeapon;
            }
            cboWeapons.SelectedIndexChanged += cboWeapons_SelectedIndexChanged;
            cboPotions.DataSource = _player.Potions;
            cboPotions.DisplayMember = "Name";
            cboPotions.ValueMember = "Id";
            _player.PropertyChanged += PlayerOnPropertyChanged;
            _player.OnMessage += DisplayMessage;

            _player.MoveTo(_player.CurrentLocation);

            // UI changes automatically due to DataBinding
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.AutoGenerateColumns = false;
            dgvInventory.DataSource = _player.Inventory;
            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 197,
                DataPropertyName = "Description"
            });
            dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantity",
                DataPropertyName = "Quantity"
            });
            dgvQuests.RowHeadersVisible = false;
            dgvQuests.AutoGenerateColumns = false;
            dgvQuests.DataSource = _player.Quests;
            dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Name",
                Width = 197,
                DataPropertyName = "Name"
            });
            dgvQuests.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Done?",
                DataPropertyName = "IsCompleted"
            });
        }

        private void btnNorth_Click(object sender, EventArgs e)
        {
            _player.MoveNorth();
        }
        private void btnEast_Click(object sender, EventArgs e)
        {
            _player.MoveEast();
        }
        private void btnSouth_Click(object sender, EventArgs e)
        {
            _player.MoveSouth();
        }
        private void btnWest_Click(object sender, EventArgs e)
        {
            _player.MoveWest();
        }
        private void btnTrade_Click(object sender, EventArgs e) 
        {
            TradingScreen tradingScreen = new TradingScreen(_player);
            tradingScreen.StartPosition = FormStartPosition.CenterParent;
            tradingScreen.ShowDialog(this);

        }
        private void btnUseWeapon_Click(object sender, EventArgs e)
        {
            // Get the currently selected weapon from the cboWeapons ComboBox
            Weapon currentWeapon = (Weapon)cboWeapons.SelectedItem;
            _player.UseWeapon(currentWeapon);
        }
        private void btnUsePotion_Click(object sender, EventArgs e)
        {
            // Get the currently selected potion from the combobox
            HealingPotion potion = (HealingPotion)cboPotions.SelectedItem;
            _player.UsePotion(potion);
        }
    
        private void PlayerOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        
        {
            if (propertyChangedEventArgs.PropertyName == "Weapons") 
            {
                cboWeapons.DataSource = _player.Weapons;
                if (!_player.Weapons.Any()) 
                {
                    btnUseWeapon.Visible = false;
                    cboWeapons.Visible = false;
                }
            }

            if (propertyChangedEventArgs.PropertyName == "Potions")
            {
                cboPotions.DataSource = _player.Potions;
                if (!_player.Potions.Any())
                {
                    btnUsePotion.Visible = false;
                    cboPotions.Visible = false;
                }
            }
                if (propertyChangedEventArgs.PropertyName == "CurrentLocation")
                {
                    // Show/hide available movement buttons
                    btnNorth.Visible = (_player.CurrentLocation.LocationToNorth != null);
                    btnEast.Visible = (_player.CurrentLocation.LocationToEast != null);
                    btnSouth.Visible = (_player.CurrentLocation.LocationToSouth != null);
                    btnWest.Visible = (_player.CurrentLocation.LocationToWest != null);
                    btnTrade.Visible = (_player.CurrentLocation.VendorWorkingHere != null);
                // Display current location name and description
                rtbLocation.Text = _player.CurrentLocation.Name + Environment.NewLine;
                    rtbLocation.Text += _player.CurrentLocation.Description + Environment.NewLine;
                    if (!_player.CurrentLocation.HasAMonster)
                    {
                        cboWeapons.Visible = false;
                        cboPotions.Visible = false;
                        btnUseWeapon.Visible = false;
                        btnUsePotion.Visible = false;
                    }
                    else
                    {
                        cboWeapons.Visible = _player.Weapons.Any();
                        cboPotions.Visible = _player.Potions.Any();
                        btnUseWeapon.Visible = _player.Weapons.Any();
                        btnUsePotion.Visible = _player.Potions.Any();
                    }
                }
            
        }
        private void DisplayMessage(object sender, MessageEventArgs messageEventArgs)
        {
            rtbMessages.Text += messageEventArgs.Message + Environment.NewLine;

            if (messageEventArgs.AddExtraNewLine)
            {
                rtbMessages.Text += Environment.NewLine;
            }

            rtbMessages.SelectionStart = rtbMessages.Text.Length;
            rtbMessages.ScrollToCaret();
        }

        private void cboWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            _player.CurrentWeapon = (Weapon)cboWeapons.SelectedItem;
        }

        private void AdventureRPG_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(PLAYER_DATA_FILE_NAME, _player.ToXmlString());

            PlayerDataMapper.SavetoDataBase(_player);
        }
    }
    
}
