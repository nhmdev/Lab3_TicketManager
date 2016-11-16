using System;
using System.Collections.Generic;
using System.Linq;
using TicketManager.View;
using TicketManager.Model.Events;
using TicketManager.Model;

namespace TicketManager
{
    class Runtime
    {
        private List<Event> events = new List<Event>();
        private List<Person> customers = new List<Person>();

        public void Start()
        {
            while (true)
            {
                switch (CLI.StartMenu())
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        // Add new customers
                        customers.Add(CLI.AddNewCustomer(customers.Count+1));

                        break;
                    case 2:
                        // Show all customers
                        CLI.ShowCustomers(customers);
                        break;
                    case 3:
                        // Add new event
                        AddNewEvent();
                        break;
                    case 4:
                        // Show booked events
                        CLI.ShowEvents(events);
                        break;

                    case 5:
                        // Create new Ticket
                        CreateBooking();
                        break;

                    case 6:
                        // Show all tickets
                        ShowTickets();
                        break;
                }
            }
            
        }
        #region public void AddNewEvent()
        public void AddNewEvent()
        {
            switch (CLI.ChooseEventType())
            {
                case 1:
                    // Concert
                    events.Add(CLI.AddNewConcert(events.Count + 1));
                    break;
                case 2:
                    // Festival
                    events.Add(CLI.AddNewFestival(events.Count + 1));
                    break;
                case 3:
                    // Movie
                    events.Add(CLI.AddNewMovie(events.Count + 1));
                    break;
            }
        }
        #endregion

        #region CreateBooking()
        public Boolean CreateBooking()
        {
            Person cust = CLI.ChooseCustomer(customers);
            Event e = CLI.ChooseEvent(events);
            if (e.MakeReservation(cust))
            {
                //Console.WriteLine("Booking done");
                return true;
            }
            //Console.WriteLine("Cannot make booking");
            return false;
           
        }
        #endregion

        #region ShowTickets()
        public void ShowTickets()
        {
            Person cust = CLI.ChooseCustomer(customers);
            CLI.ShowBookedEvents(cust,events);
        }
        #endregion
    }
}
