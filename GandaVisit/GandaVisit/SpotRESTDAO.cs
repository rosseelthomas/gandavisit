using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace GandaVisit
{
    public class SpotRESTDAO : ISpotDAO
    {

        private HttpClient httpClient = new HttpClient();

        public List<ISpot> Visits
        {
            get { return new List<ISpot>(); }
        }

        public async Task<List<ISpot>> SearchName(string value)
        {

            var response = await httpClient.GetAsync(new Uri(string.Format(Constants.zoek, value)));

            string json = await response.Content.ReadAsStringAsync();

            return parseIdNaam(json);

        }

        public async Task AddDetails(ISpot spot)
        {
            var response = await httpClient.GetAsync(new Uri(string.Format(Constants.details, spot.Id)));

            string json = await response.Content.ReadAsStringAsync();

            parseDetails(json, spot);
        }



        public void AddVisits(ISpot s)
        {
          
        }

        public void RemoveVisits(ISpot s)
        {
            
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
                    spot.Id = (Int32)(jobject.GetArray().GetObjectAt(i).GetNamedNumber("id"));
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

              
                spot.Contact.AdressNumber = (Int32)jobject.GetArray().GetObjectAt(0).GetNamedNumber("number");
                spot.Contact.City = jobject.GetArray().GetObjectAt(0).GetNamedString("city");
                spot.Contact.Street = jobject.GetArray().GetObjectAt(0).GetNamedString("street");

                spot.Contact.PhoneNumber = jobject.GetArray().GetObjectAt(0).GetNamedString("tel");
                spot.Contact.Email = jobject.GetArray().GetObjectAt(0).GetNamedString("email");
                spot.Contact.Fax = jobject.GetArray().GetObjectAt(0).GetNamedString("fax");
                spot.Contact.Website = jobject.GetArray().GetObjectAt(0).GetNamedString("website");
               
            }
            catch (Exception ex)
            {

            }
        }


    }
}
