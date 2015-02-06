using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandaVisit
{
    public class DummySpotDAO:ISpotDAO
    {
        private static DummySpotDAO instance = new DummySpotDAO();

        //Dit is de "databank"
        private static List<ISpot> db;

        private DummySpotDAO()
        {
            //Dummy opvullen
            db = new List<ISpot>();

            ISpot belfort = new Spot();
            belfort.Naam = "Belfort";
            belfort.ImgLink = "http://upload.wikimedia.org/wikipedia/commons/thumb/f/f4/BelfortGent.jpg/210px-BelfortGent.jpg";
            belfort.Description = "Het belfort van Gent is een 95-meter hoge belforttoren in het centrum van de Belgische stad Gent. De toren is de middelste toren van de beroemde Gentse torenrij, samen met de Sint-Niklaaskerk en de Sint-Baafskathedraal. Tegen het belfort staat ook de Gentse lakenhal. Geschiedenis Men begon waarschijnlijk te bouwen aan het belfort voor 1314, het jaar waaruit de eerste rekeningen dateren. Een plan in het Bijlokemuseum is van Jan van Haelst, meestermetser. In 1323 waren reeds vier bouwlagen (van de zes geplande) klaar. Tussen 1377 en 1380 werd een voorlopige houten torenbekroning opgetrokken. Daarop werd de legendarische 'Draak van Gent' gehesen. De volgende eeuwen werd de torenspits herhaaldelijk aangepast.Na verschillende houten spitsen, kreeg het belfort in 1851 een neogotische gietijzeren spits. Een halve eeuw later was de staat van de spits echter te slecht geworden, en met de Wereldtentoonstelling van 1913 in het vooruitzicht werd een wedstrijd uitgeschreven voor een nieuwe spits. Een voorstel van Valentin Vaerwyck, gebaseerd op de middeleeuwse spits, werd goedgekeurd. Doordat de werken snel moesten gebeuren, bleken er achteraf vele gebreken te zijn, onder meer in de verbinding tussen de stenen romp en het nieuwe stenen klokkenhuis. In 1967 en 1980 werden daarom restauratiewerken uitgevoerd.";
            belfort.Contact.AdressNumber = "999";
            belfort.Contact.City = "9000 Gent";
            belfort.Contact.Street = "BelfortStreet";
            belfort.Contact.PhoneNumber = "5503403";
            belfort.Contact.Website = "http://www.bing.com";
            belfort.Contact.Fax = "9744";
            belfort.Contact.Email = "thomas_deSwag@swekmal.com";
            belfort.IsVisists = true;

            ISpot glazenStraatje = new Spot();
            glazenStraatje.Naam = "Glazen straatje";
            glazenStraatje.ImgLink = "http://www.infotalia.com/pictures/steden/250/vanderdonckt1-2.jpg";
            glazenStraatje.Description = "In 1830 waren er verspreid over Gent dertien geautoriseerde rendez-vous-huizen (bordelen). Hier werden de kamers per dag of per uur verhuurd. Een groot deel van de prostituees verkoos om in een stad te werken waarvan ze niet afkomstig waren. Velen kwamen van het platteland en kozen Gent als nieuwe woonplaats.";
            glazenStraatje.Latitude = 51.0543422;
            glazenStraatje.Longitude = 3.7174243;
            glazenStraatje.Contact.Website = "http://www.bing.com";
            glazenStraatje.IsVisists = false;
            db.Add(belfort);
            db.Add(glazenStraatje);
        }
        public List<ISpot> Visits
        {
            get
            {
                //uit db de dingen halen die in visits zitten
                List<ISpot> lijst = new List<ISpot>();
                foreach (ISpot s in db) {
                    if (s.IsVisists)
                    {
                        lijst.Add(s);
                    }
                }

                return lijst;

            }            
        }

        public List<ISpot> SearchName(string value)
        {
            //uit db de dingen halen de ingevoerde value bevatten
            List<ISpot> lijst = new List<ISpot>();
            foreach (ISpot s in db)
            {
                if (s.Naam.Contains(value))
                {
                    lijst.Add(s);
                }
            }

            return lijst;
        }

        //hier niet nodig
        public void AddDetails(ISpot spot)
        {
            
        }

        public void AddVisits(ISpot s)
        {
            s.IsVisists = true;
        }

        public void RemoveVisits(ISpot s)
        {
            s.IsVisists = false;
        }

        public static DummySpotDAO Instance
        {
            get { return instance; }
        }


        Task<List<ISpot>> ISpotDAO.SearchName(string value)
        {
            throw new NotImplementedException();
        }

        Task ISpotDAO.AddDetails(ISpot spot)
        {
            throw new NotImplementedException();
        }


        public Task LoadVisits()
        {
            throw new NotImplementedException();
        }


        public void ClearVisits()
        {
            throw new NotImplementedException();
        }
    }
}
