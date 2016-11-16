using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager.Model.Events
{
    public abstract class Event
    {
        #region Variables
        private Guid id;
        public int hid;
        private string name;
        private List<Person> attendingCustomers = new List<Person>();
        private int maxNumberOfCustomers;
        #endregion

        #region Properties
        public string Id
        {
            get
            {
                return id.ToString();
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }

        public int CountFreeTickets
        {
            get
            {
                return maxNumberOfCustomers - attendingCustomers.Count;
            }
        }

        public int CountBookedTickets
        {
            get
            {
                return attendingCustomers.Count;
            }
        }
        #endregion

        #region Constructor
        public Event(string name, int numberOfTickets)
        {
            this.name = name;
            this.id = Guid.NewGuid();
            this.maxNumberOfCustomers = numberOfTickets;
        }
        #endregion

        #region Boolean MakeReservation(Person person)
        public Boolean MakeReservation(Person person)
        {
            if (!attendingCustomers.Exists( p => p.Id == person.Id))
            {
                if(CountFreeTickets > 0)
                {
                    attendingCustomers.Add(person);
                    return true;
                }
            }
            return false;
        }
        #endregion

        public virtual string GetInfo()
        {
            return "Type: " + this.GetType().ToString() + " Name: " + Name;
        }

        public Boolean CustomerHasTicket(Person p)
        {
            if(attendingCustomers.Exists(c => c.Id == p.Id))
            {
                return true;
            }
            return false;
        }
    }
}
