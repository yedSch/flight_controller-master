using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using FlightSimulator.Models;

namespace FlightSimulator.Models
{
    class ManualModel
    {
        public void SendCommand(string singleCommand)
        { 

            //opening threads for sending instance commands. 
            new Thread(delegate ()
                {
                    Commands.Instance.SendCommands(singleCommand);
                }).Start();
        }
    }
}
