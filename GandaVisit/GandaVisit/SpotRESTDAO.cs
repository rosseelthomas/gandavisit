using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;

namespace GandaVisit
{
    public class SpotRESTDAO : ISpotDAO
    {

        private HttpClient httpClient = new HttpClient();
        private List<ISpot> visits = new List<ISpot>();

        public List<ISpot> Visits
        {
            get { return visits; }
        }

        public async Task<List<ISpot>> SearchName(string value)
        {

            var response = await httpClient.GetAsync(new Uri(string.Format(Constants.zoek, value)));

            string json = await response.Content.ReadAsStringAsync();

            return parseIdNaam(json);

        }

        public async Task AddDetails(ISpot spot)
        {
            //foto is altijd aanwezig, dus als de foto er niet inzit zijn de details nog niet opgehaald
            if (spot.ImgLink == null)
            {
                var response = await httpClient.GetAsync(new Uri(string.Format(Constants.details, spot.Id)));

                string json = await response.Content.ReadAsStringAsync();

                parseDetails(json, spot);
            }

        }



        public void AddVisits(ISpot s)
        {
            visits.Add(s);
            s.IsVisists = true;
            SaveVisits();
        }

        public void RemoveVisits(ISpot s)
        {
            visits.Remove(s);
            s.IsVisists = false;
            SaveVisits();
        }

        public List<ISpot> parseIdNaam(string json)
        {
            List<ISpot> geparset = new List<ISpot>();
            try
            {

                JsonArray jobject = JsonArray.Parse(json);
                for (uint i = 0; i < jobject.GetArray().Count; i++)
                {
                    ISpot spot = new Spot();
                    spot.Id = jobject.GetArray().GetObjectAt(i).GetNamedString("id");
                    spot.Naam = jobject.GetObjectAt(i).GetNamedString("title");
                    geparset.Add(spot);
                }

            }
            catch (Exception ex)
            {

            }

            return geparset;
        }

        private void parseDetails(string json, ISpot spot)
        {
            try
            {

                JsonArray jobject = JsonArray.Parse(json);
                spot.Description = jobject.GetArray().GetObjectAt(0).GetNamedString("description");
                spot.ImgLink = jobject.GetArray().GetObjectAt(0).GetNamedString("thumbnail");
                spot.Latitude = jobject.GetArray().GetObjectAt(0).GetNamedNumber("latitude");
                spot.Longitude = jobject.GetArray().GetObjectAt(0).GetNamedNumber("longitude");
                spot.Summary = jobject.GetArray().GetObjectAt(0).GetNamedString("summary");

                
                    spot.Contact.AdressNumber = jobject.GetArray().GetObjectAt(0).GetNamedObject("contact").GetNamedString("number");
               
                spot.Contact.City = jobject.GetArray().GetObjectAt(0).GetNamedObject("contact").GetNamedString("city");
                spot.Contact.Street = jobject.GetArray().GetObjectAt(0).GetNamedObject("contact").GetNamedString("street");

                spot.Contact.PhoneNumber = jobject.GetArray().GetObjectAt(0).GetNamedObject("contact").GetNamedString("tel");
                spot.Contact.Email = jobject.GetArray().GetObjectAt(0).GetNamedObject("contact").GetNamedString("email");
                spot.Contact.Fax = jobject.GetArray().GetObjectAt(0).GetNamedObject("contact").GetNamedString("fax");
                spot.Contact.Website = jobject.GetArray().GetObjectAt(0).GetNamedObject("contact").GetNamedString("website");

            }
            catch (Exception ex)
            {

            }
        }

        private void SaveVisits()
        {
            StringBuilder s = new StringBuilder();
            foreach (ISpot spot in visits)
            {
                s.Append(";");
                s.Append(spot.Id);
            }
            ApplicationData.Current.LocalSettings.Values["visits"] = s.ToString();


        }

        public async Task LoadVisits()
        {
            string s = (string)ApplicationData.Current.LocalSettings.Values["visits"];
            if (s != null)
            {
                string[] ids = s.Split(';');
                foreach (string id in ids)
                {
                    //als je split is de eerste id altijd "" omdat vooraan ook ; geplaatst wordt
                    if (id != "")
                    {                 



                    var response = await httpClient.GetAsync(new Uri(string.Format(Constants.details, id)));

                    string json = await response.Content.ReadAsStringAsync();

                    ISpot spot = new Spot();
                    spot.Id = id;
                    spot.IsVisists = true;
                    ParseNaam(json, spot);

                    visits.Add(spot);
                    }

                }
            }
        }

        public void ParseNaam(string json, ISpot spot)
        {
            JsonArray jobject = JsonArray.Parse(json);
            spot.Naam = jobject.GetObjectAt(0).GetNamedString("title");

        }


        public void ClearVisits()
        {
            visits.Clear();
            SaveVisits();
        }
    }
}
