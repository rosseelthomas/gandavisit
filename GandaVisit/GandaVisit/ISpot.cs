using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace GandaVisit
{
    public interface ISpot
    {
        string Naam { get; set; }
        string ImgLink { get; set; }
        string Description { get; set; }
        ContactInfo Contact { get; set; }
        //Om te weten of het in de visitslijst zit of niet
        bool IsVisists { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}
