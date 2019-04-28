using System;
using FlightSimulator.Models;

namespace FlightSimulator.ViewModels.Windows
{
    class ManualViewModel
    { 
        //
        private ManualModel model;
        private string ailPath;
        private string rudPath;
        private string throtPath;
		private string elevaPath;

		public ManualViewModel()
		{
            //all options in Manual control. 
			this.model = new ManualModel();
			this.rudPath = " /controls/flight/rudder ";
			this.ailPath = " /controls/flight/aileron ";
            this.elevaPath = " /controls/flight/elevator ";
            this.throtPath = " /controls/engines/current-engine/throttle ";
        }
		
        public double Rudder
        {
            set => this.model.SendCommand("set" + this.rudPath + Convert.ToString(value));
        }
		
		public double Aileron
        {
            set => this.model.SendCommand("set" + this.ailPath + Convert.ToString(value));
        }
		
		public double Throttle
        {
            set => this.model.SendCommand("set" + this.throtPath + Convert.ToString(value));
        }
		
        public double Elevator
        {
            set => this.model.SendCommand("set" + this.elevaPath + Convert.ToString(value));
        }
    }
}
