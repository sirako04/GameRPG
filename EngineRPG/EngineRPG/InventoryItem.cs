﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineRPG
{
    public class InventoryItem : INotifyPropertyChanged
    {
        private Item _details;
        private int _quantity;
        public Item Details
        {
            get
            {
                return _details;
            }
            set
            {
                _details = value;
                OnPropertyChanged(nameof(Details));
            }
        }
        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
        public string Description
        {
            get
            {return Quantity > 1 ? Details.NamePlural : Details.Name;}
        }
        public InventoryItem(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

