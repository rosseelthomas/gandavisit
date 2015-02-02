using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandaVisit
{
    interface ISpot
    {
        string Naam { get; set; }
        string ImgLink { get; set; }
        string Description { get; set; }
        string Contact { get; set; }
    }
}
