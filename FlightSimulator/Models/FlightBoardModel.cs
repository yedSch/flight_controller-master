using System;
using System.Threading;
using System.ComponentModel;
using System.Threading.Tasks;
using FlightSimulator.ViewModels;
using FlightSimulator.Models;

namespace FlightSimulator.Models
{
    class FlightBoardModel : BaseNotify
    {
        private double lon;
        private double lat;
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    
        public double Lon
        {
            // setting longtitude function

            get
            {
                return this.lon;
            }
            set
            {
                this.lon = value;
            }
        }

        public double Lat
        {
            // setting latitude function
            get
            {
                return this.lat;
            }
            set
            {
                this.lat = value;
            }
        }

        public void Read()
        {
            while (true)
            {
                // first arg is lon and second is lat
                double[] lonAndLat = Info.Instance.Read();
                
                this.Lon = lonAndLat[0];
                this.Lat = lonAndLat[1];

                // notify one after one to get more accurate map 
                this.NotifyPropertyChanged("Lon");
                this.NotifyPropertyChanged("Lat");
            }
        }
    }
}
