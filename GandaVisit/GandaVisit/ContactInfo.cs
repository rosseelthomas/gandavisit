using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandaVisit
{
    public class ContactInfo
    {
        private int phoneNumber;
        private string email;
        private string website;
        private int fax;

        //adres info
        private int adressNumber;
        private string street;
        private string city;

        public int PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        public int Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public int AdressNumber
        {
            get { return adressNumber; }
            set { adressNumber = value; }
        }

        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }
    }
}
