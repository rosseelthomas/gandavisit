using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandaVisit
{
    public interface ISpotDAO
    {
        //Voor dataverbruik te verlagen: Alleen belangrijke info afhalen: bv alleen naam
        List<ISpot> Visits { get;}
        Task<List<ISpot>> SearchName(string value);

        //om data verbruik te verlagen: de geselecteerde spot waarvand e details getoond worden worden de details afgehaald
        Task AddDetails(ISpot spot);

        //toevoegen/verwijderen van je visits lijst
        void AddVisits(ISpot s);
        void RemoveVisits(ISpot s);

        Task LoadVisits();
    }
}
