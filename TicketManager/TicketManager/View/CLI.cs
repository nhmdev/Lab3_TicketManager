using System;
using System.Collections.Generic;
using System.Linq;
using TicketManager.Model;
using TicketManager.Model.Events;

namespace TicketManager.View
{
    class CLI 
    {
        #region public static int StartMenu()
        public static int StartMenu()
        {
            #region Make a list with menu options
            List<String> menuOptions = new List<String>();
            menuOptions.Add("1. Add new person");
            menuOptions.Add("2. Show all persons");
            menuOptions.Add("3. Add new event");
            menuOptions.Add("4. Show booked events");
            menuOptions.Add("5. Create new ticket");
            menuOptions.Add("6. Show all tickets");
            menuOptions.Add("0. Quit");
            #endregion

            // Define how long the longest menuoption string is.
            int longestMenuOptionString = menuOptions.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur).Length;

            #region Print the main menu
            Console.Write("*****");
            for(int i=0;i<longestMenuOptionString;i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            foreach (string menuOption in menuOptions)
            {
                Console.Write("* " + menuOption);
                for(int i=menuOption.Length;i<=longestMenuOptionString;i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(" *");
            }
            Console.Write("*****");
            for (int i = 0; i < longestMenuOptionString; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.Write("Choose: ");
            #endregion

            #region Get user choice and validate
            string userinput = Console.ReadLine();
            
            // Validate user choice and if incorrect let user know and try again.
            while (!validateUserInputInt(userinput,0,6))
            {
                Console.Write("Incorrect choice. Try again: ");
                userinput = Console.ReadLine();
            }
            #endregion

            // Return the user choice
            return int.Parse(userinput);
        }
        #endregion

        #region public static Boolean validateUserInputInt(string input, int minValue, int maxValue)
        public static Boolean validateUserInputInt(string input, int minValue, int maxValue)
        {
            int inputAsInt;
            if(int.TryParse(input, out inputAsInt))
            {
                if(inputAsInt >= minValue && inputAsInt <= maxValue)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region public static Boolean validateUserInputString(string input)
        public static Boolean validateUserInputString(string input)
        {  
            if (input.Length > 0)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region public static int ChooseEventType()
        public static int ChooseEventType()
        {
            Console.WriteLine("********** Choose event type **********");
            Console.WriteLine("1. Concert");
            Console.WriteLine("2. Festival");
            Console.WriteLine("3. Movie");
            Console.Write("Choose an event type (1 - 3): ");
            string userinput = Console.ReadLine();
            while (!validateUserInputInt(userinput, 1, 3))
            {
                Console.Write("Incorrect choice. Try again: ");
                userinput = Console.ReadLine();
            }
            
            return int.Parse(userinput);

        }

        #endregion

        #region public static Concert AddNewConcert(int hid)
        public static Concert AddNewConcert(int hid)
        {
            Console.Write("Concert name: ");
            string concertName = Console.ReadLine();
            while(!validateUserInputString(concertName))
            {
                Console.Write("Try again: ");
                concertName = Console.ReadLine();
            }

            Console.Write("City name: ");
            string cityName = Console.ReadLine();
            while(!validateUserInputString(cityName))
            {
                Console.Write("Try again: ");
                cityName = Console.ReadLine();
            }

            Console.Write("Number of tickets: ");
            string numberOfTickets = Console.ReadLine();
            while(!validateUserInputInt(numberOfTickets, 1,1000))
            {
                Console.Write("Try again (1 - 1000): ");
                numberOfTickets = Console.ReadLine();
            }

            Console.Clear();
            Concert c = new Concert(concertName, cityName, int.Parse(numberOfTickets));
            c.hid = hid;
            return c;
        }
        #endregion

        #region public static Festival AddNewFestival(int hid)
        public static Festival AddNewFestival(int hid)
        {
            Console.Write("Festival name: ");
            string festivalName = Console.ReadLine();
            while (!validateUserInputString(festivalName))
            {
                Console.Write("Try again: ");
                festivalName = Console.ReadLine();
            }

            Console.Write("Number of tickets: ");
            string numberOfTickets = Console.ReadLine();
            while (!validateUserInputInt(numberOfTickets, 1, 1000))
            {
                Console.Write("Try again (1 - 1000): ");
                numberOfTickets = Console.ReadLine();
            }

            Console.Clear();
            Festival f = new Festival(festivalName, int.Parse(numberOfTickets));
            f.hid = hid;
            return f;
        }
        #endregion

        #region public static Movie AddNewMovie(int hid)
        public static Movie AddNewMovie(int hid)
        {
            Console.Write("Movie name: ");
            string movieName = Console.ReadLine();
            while (!validateUserInputString(movieName))
            {
                Console.Write("Try again: ");
                movieName = Console.ReadLine();
            }

            Console.Write("Runtime (minutes): ");
            string runtime = Console.ReadLine();
            while(!validateUserInputInt(runtime, 1,300))
            {
                Console.Write("Wrong value. Try again (Between 1 and 300): ");
                runtime = Console.ReadLine();
            }

            Console.Write("Release year: ");
            string releaseYear = Console.ReadLine();
            while(!validateUserInputInt(releaseYear,1900,2016))
            {
                Console.Write("Wrong value. Try again (Between 1900 and 2016): ");
                releaseYear = Console.ReadLine();
            }

            Console.Write("Number of tickets: ");
            string numberOfTickets = Console.ReadLine();
            while (!validateUserInputInt(numberOfTickets, 1, 1000))
            {
                Console.Write("Try again (1 - 1000): ");
                numberOfTickets = Console.ReadLine();
            }

            Console.Clear();
            Movie m = new Movie(movieName,int.Parse(runtime),int.Parse(releaseYear), int.Parse(numberOfTickets));
            m.hid = hid;
            return m;
        }
        #endregion

        #region public static void ShowEvents(List<Event> events)
        public static void ShowEvents(List<Event> events)
        {
            Console.WriteLine("********** All Events ({0}) **********", events.Count().ToString());

            int numberOfConcerts = events.OfType<Concert>().Count<Concert>();
            int numberOfFestivals = events.OfType<Festival>().Count<Festival>();
            int numberOfMovies = events.OfType<Movie>().Count<Movie>();

            if(numberOfConcerts > 0)
            {
                Console.WriteLine("===== All Concerts ({0}) =====", numberOfConcerts.ToString());
                foreach (Concert c in events.OfType<Concert>())
                {
                    Console.WriteLine(c.GetInfo() + Environment.NewLine);
                }

            }

            if (numberOfFestivals > 0)
            {
                Console.WriteLine("===== All Festivals ({0}) =====", numberOfFestivals.ToString());
                foreach (Festival f in events.OfType<Festival>())
                {
                    Console.WriteLine(f.GetInfo() + Environment.NewLine);
                }

            }

            if (numberOfMovies > 0)
            {
                Console.WriteLine("===== All Movies ({0}) =====", numberOfMovies.ToString());
                foreach (Movie m in events.OfType<Movie>())
                {
                    Console.WriteLine(m.GetInfo() + Environment.NewLine);
                }

            }


        }
        #endregion

        #region public static void ShowCustomers(List<Person> customers)
        public static void ShowCustomers(List<Person> customers)
        {
            Console.WriteLine("********** Customers ({0}) **********",customers.Count().ToString());
            foreach (Person p in customers)
            {
                Console.WriteLine(p.GetInfo() + Environment.NewLine);
            }
            
        }
        #endregion

        #region public static Person AddNewCustomer(int hid)
        public static Person AddNewCustomer(int hid)
        {
            Console.Write("Firstname: ");
            string firstName = Console.ReadLine();
            while (!validateUserInputString(firstName))
            {
                Console.Write("Try again: ");
                firstName = Console.ReadLine();
            }

            Console.Write("Lastname: ");
            string lastName = Console.ReadLine();
            while(!validateUserInputString(lastName))
            {
                Console.Write("Try again: ");
                lastName = Console.ReadLine();
            }

            Person p = new Person(firstName, lastName);
            p.hid = hid;
            return p;
        }
        #endregion

        #region public static Person ChooseCustomer(List<Person> CustomerList)
        public static Person ChooseCustomer(List<Person> customerList)
        {
            Console.WriteLine("Customer List");
            Console.WriteLine("-------------");
            foreach(Person customer in customerList)
            {
                Console.WriteLine(customer.hid + ". " + customer.Name);
            }
            Console.Write("Choose customer: ");
            string userInput = Console.ReadLine();
            while(!validateUserInputInt(userInput,1,customerList.Count))
            {
                Console.WriteLine("Try again: ");
                userInput = Console.ReadLine();
            }
            return customerList.Find(p => p.hid == int.Parse(userInput));
        }
        #endregion

        #region public static Event ChooseEvent(List<Event> eventList)
        public static Event ChooseEvent(List<Event> eventList)
        {
            Console.WriteLine("Event List");
            Console.WriteLine("----------");
            foreach (Event e in eventList)
            {
                Console.WriteLine(e.hid + ". " + e.Name);
            }
            Console.Write("Choose event: ");
            string userInput = Console.ReadLine();
            while (!validateUserInputInt(userInput, 1, eventList.Count))
            {
                Console.WriteLine("Try again: ");
                userInput = Console.ReadLine();
            }
            return eventList.Find(ev => ev.hid == int.Parse(userInput));
        }
        #endregion

        public static void ShowBookedEvents(Person customer, List<Event> eventList)
        {
            Console.WriteLine("The customer {0} has tickets to following events:",customer.Name);

            foreach (Event e in eventList.FindAll(e => e.CustomerHasTicket(customer)))
            {
                 Console.WriteLine(e.GetInfo());
            }
        }
    }
}
