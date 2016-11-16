using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketManager.Model.Events
{
    public class Concert : Event 
    {
        private string city;
        public Concert(string name, string city, int numberOfTickets) :base (name, numberOfTickets)
        {
            this.city = city;
        }

        public override string GetInfo()
        {
            return "Name: " + Name + Environment.NewLine + 
                "City: " + city;
        }
    }
}