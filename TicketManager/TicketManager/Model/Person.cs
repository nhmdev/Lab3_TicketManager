using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketManager.Model
{
    public class Person
    {
        #region variables
        private Guid id;
        private string firstName;
        private string lastName;
        public int hid;
        #endregion

        #region Properties
        public Guid Id
        {
            get
            {
                return id;
            }
        }
        public string Name
        {
            get
            {
                return firstName + " " + lastName;
            }
        }
        #endregion

        #region Constructor
        public Person(string firstName, string lastName)
        {
            this.id = Guid.NewGuid();
            this.firstName = firstName;
            this.lastName = lastName;
        }
        #endregion

        #region public string GetInfo()
        public string GetInfo()
        {
            return "ID: " + id + Environment.NewLine +
                "Name: " + Name;
        }

        #endregion
    }
}
