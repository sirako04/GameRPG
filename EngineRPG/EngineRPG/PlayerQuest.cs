using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace EngineRPG
{
   public class PlayerQuest : INotifyPropertyChanged
    {
        private Quest _details;
        private bool _isCompleted;
        public Quest Details 
        {
           get {return _details;}           
           set 
           {
             _details = value;
             OnPropertyChanged(nameof(Details));
           }
        }
        public bool IsCompleted 
        {
          get {return _isCompleted;}
          set 
          {
           _isCompleted = value;
           OnPropertyChanged(nameof(IsCompleted));
          }
        }

        public string name 
        {
            get { return Details.Name; } 
        }   
        public PlayerQuest(Quest details)
        {
            Details = details;
            IsCompleted = false;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
