using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Model.Events
{
    class Festival : Event
    {
        public Festival(string name, int numberOfTickets) :base (name, numberOfTickets)
        {

        }
    }
}
