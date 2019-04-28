using System;
using System.Threading;
using System.Windows.Input;
using System.ComponentModel;
using FlightSimulator.Models;
using FlightSimulator.Views.Windows;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private bool isConnected;
        private Settings settings;
        private FlightBoardModel model;

        public FlightBoardViewModel()
        {
            //connect between flightboard and changes 
            this.isConnected = false;
            this.model = new FlightBoardModel();
            this.model.PropertyChanged += M_PropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void M_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //change settings with notifyer. 
            if (e.PropertyName.Equals("Lat"))
            {
                this.NotifyPropertyChanged("Lat");
            }
            else if (e.PropertyName.Equals("Lon"))
            {
                this.NotifyPropertyChanged("Lon");
            }
        }

        public double Lon
        {
            //longtitude getter and setter. 

            get
            {
                return this.model.Lon;
            }
            set
            {
            }
        }

        public double Lat
        {
            //latitude getter and setter. 
            get
            {
                return this.model.Lat;
            }
            set
            {
            }
        }
        
        private ICommand settingsCommand;

        public ICommand SettingsCommand
        {
            //check if button is clicked. 
            get
            {
                return settingsCommand ?? (settingsCommand 
                    = new CommandHandler(() => SettingsOnClick()));
            }
        }

        public void SettingsOnClick()
        {
            this.settings = new Settings();

            this.settings.ShowDialog();     
        }
        
        private ICommand connectCommand;


        public ICommand ConnectCommand {
            get
            {
                return connectCommand ?? (connectCommand 
                    = new CommandHandler(() => ConnectOnClick()));
            }
        }

        public void ConnectOnClick()
        {
            //check if connection is single. 
            if (!this.isConnected)
            {
                this.isConnected = true;

                // port listener
                new Thread(delegate () {

                    Info.Instance.Connect(ApplicationSettingsModel.Instance.FlightInfoPort);
                    //info includes data for flight, including port. 
                    this.model.Read();
                }).Start();

                // connect plane by ip and port
                new Thread(delegate () {
                    //connect IP
                    Commands.Instance.Connect(ApplicationSettingsModel.Instance.FlightServerIP, 

                        ApplicationSettingsModel.Instance.FlightCommandPort);
                }).Start();
            }
        }
    }
}
