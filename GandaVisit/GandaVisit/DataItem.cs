using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandaVisit
{
    public class DataItem : INotifyPropertyChanged 
    {
        private string imgSource;
        private bool isLoading;

        public string ImgSource { 
            get {return imgSource;}
            set {imgSource=value;}
            

        }

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value;
            NotifyPropertyChanged("IsLoading");            
            }
        }

        public bool IsNotLoading
        {
            get { return !isLoading; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // NotifyPropertyChanged will raise the PropertyChanged event passing the
        // source property that is being updated.
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }  
    }
}
