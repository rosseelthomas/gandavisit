using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandaVisit
{
    public class Spot:ISpot
    {
        private string naam;
        private string imgLink;
        private string description;
        private string contact;


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

        public string Contact
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
    }
}
