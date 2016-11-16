using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketManager.Model.Events
{
    class Movie : Event
    {
        private int runtime;
        private int releaseYear;

        public Movie(string name, int runtime, int releaseYear, int numberOfTickets) : base(name, numberOfTickets)
        {
            this.runtime = runtime;
            this.releaseYear = releaseYear;
        } 

        public override string GetInfo()
        {
            return "Name: " + Name +", Runtime: "+ runtime.ToString() +", Release Year: "+releaseYear.ToString();
        }
    }
}
