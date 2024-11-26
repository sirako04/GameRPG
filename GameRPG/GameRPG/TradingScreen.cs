using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EngineRPG;
namespace GameRPG
{

    public partial class TradingScreen : Form
    {
        private Player _currentPlayer;

        public TradingScreen(Player player)
        {
                // ERROR player gets the valuE NULL AND IDK WHY :/
                _currentPlayer = player;
                InitializeComponent();
                // Style, to display numeric column values
                DataGridViewCellStyle rightAlignedCellStyle = new DataGridViewCellStyle();
                rightAlignedCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                // Populate the datagrid for the player's inventory
                dgvMyItems.RowHeadersVisible = false;
                dgvMyItems.AutoGenerateColumns = false;
                // Bind the player's inventory to the datagridview 
                dgvMyItems.DataSource = _currentPlayer.Inventory;
                // When the user clicks on a row, call this function
                dgvMyItems.CellClick += dgvMyItems_CellClick;

                dgvMyItems.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(InventoryItem.ItemID),
                    Visible = false
                });
                dgvMyItems.Columns.Add(new DataGridViewTextBoxColumn
                {
                HeaderText = "Name",
                Width = 100,
                DataPropertyName = nameof(InventoryItem.Description)
                });
            dgvMyItems.Columns.Add(new DataGridViewTextBoxColumn 
            {
                HeaderText= "Qty",
                Width = 30,
                DefaultCellStyle = rightAlignedCellStyle,
                DataPropertyName = nameof(InventoryItem.Quantity)    
            });
            dgvMyItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Price",
                Width = 35,
                DefaultCellStyle = rightAlignedCellStyle,
                DataPropertyName = nameof(InventoryItem.Price)
            });
            dgvMyItems.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "Sell Item",
                Text = "Sell 1",
                UseColumnTextForButtonValue = true,
                Width = 50,
                DataPropertyName = nameof(InventoryItem.ItemID)
            });

            // Populate the datagrid for the vendor's inventory
            dgvVendorItems.RowHeadersVisible = false;
                dgvVendorItems.AutoGenerateColumns = false;
                // Bind the vendor's inventory to the datagridview 
                dgvVendorItems.DataSource = _currentPlayer.CurrentLocation.VendorWorkingHere.Inventory;
                // When the user clicks on a row, call this function
                dgvVendorItems.CellClick += dgvVendorItems_CellClick;
                // This hidden column holds the item ID, so we know which item to sell
                dgvVendorItems.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = nameof(InventoryItem.ItemID),
                    Visible = false
                });
                dgvVendorItems.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Name",
                    Width = 100,
                    DataPropertyName = nameof(InventoryItem.Description)
                });
                dgvVendorItems.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Price",
                    Width = 35,
                    DefaultCellStyle = rightAlignedCellStyle,
                    DataPropertyName = nameof(InventoryItem.Price)
                });
                dgvVendorItems.Columns.Add(new DataGridViewButtonColumn
                {
                    HeaderText = "Buy Item",
                    Text = "Buy 1",
                    UseColumnTextForButtonValue = true,
                    Width = 50,
                    DataPropertyName = nameof(InventoryItem.ItemID)
                });
            
        }

        private void dgvMyItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {   // get the Sell Button  
            if (e.ColumnIndex == 4)
            {
                var ItemID = dgvMyItems.Rows[e.RowIndex].Cells[0].Value;
                Item ItemBeingSold = World.ItemByID(Convert.ToInt32(ItemID));

                if (ItemBeingSold.Price == World.UNSELLABLE_ITEM_PRICE)
                {
                    MessageBox.Show("You can NOT sell " + ItemBeingSold.Name);
                }
                else
                {
                    _currentPlayer.RemoveItemFromInventory(ItemBeingSold);
                    _currentPlayer.Gold += ItemBeingSold.Price;
                    _currentPlayer.RaiseMessage("item sold :" + ItemBeingSold.Name);
                    _currentPlayer.RaiseMessage("you obtained : " + ItemBeingSold.Price + " Gold");
                }


            }

        }

        private void dgvVendorItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {   // get the Buy 1 Button 
            if (e.ColumnIndex == 3)
            {
                var ItemID = dgvVendorItems.Rows[e.RowIndex].Cells[0].Value;
                Item itemBeingBought = World.ItemByID(Convert.ToInt32(ItemID));

                if (_currentPlayer.Gold >= itemBeingBought.Price)
                {
                    _currentPlayer.AddItemToInventory(itemBeingBought);
                    _currentPlayer.Gold -= itemBeingBought.Price;
                    _currentPlayer.RaiseMessage(" you bought :" + itemBeingBought.Name + " for : "+ itemBeingBought.Price + " Gold ");
                    
                }
                else
                {
                    MessageBox.Show("You dont have enough money to buy" + itemBeingBought.Name);
                }
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
      
    }
}
