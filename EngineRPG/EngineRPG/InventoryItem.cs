﻿using System.ComponentModel;

namespace EngineRPG
{
    public class InventoryItem : INotifyPropertyChanged
    {
        public int ItemID 
        {
          get { return Details.ID ;} 
        }

        public int Price
        { 
           get  { return Details.Price ;}        
        }
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

