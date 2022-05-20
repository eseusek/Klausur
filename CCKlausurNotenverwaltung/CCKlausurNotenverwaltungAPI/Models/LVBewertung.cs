using Newtonsoft.Json;

namespace CCKlausurNotenverwaltungAPI.Models
{
    public class LVBewertung
    {
        public int LVBewertungId { get; set; }

        public int StudPersNummer { get; set; }
        
        public string LVBezeichnung { get; set; }
        public double PunkteTheorie { get; set; }
        public double PunktePraxis { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
