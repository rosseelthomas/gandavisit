using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandaVisit
{
    public class Spot : ISpot
    {
        private string id;
        private string naam;
        private string imgLink;
        private string description;
        private string summary;
        private ContactInfo contact;
        private bool isVisits;
        private double longitude;
        private double latitude;

        public Spot()
        {
            contact = new ContactInfo();
        }

        public string Naam
        {
            get
            {
                return naam;
            }
            set
            {
                naam = value;
            }
        }

        public string ImgLink
        {
            get
            {
                return imgLink;
            }
            set
            {
                imgLink = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        public ContactInfo Contact
        {
            get
            {
                return contact;
            }
            set
            {
                contact = value;
            }
        }

        public bool IsVisists
        {
            get
            {
                return isVisits;
            }
            set
            {
                isVisits = value;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
            }
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
            }
        }

        public string Summary
        {
            get
            {
                return summary;
            }
            set
            {
                summary = value ;
            }
        }
    }
}
