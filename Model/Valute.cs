using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.Model
{
    public class CurrencyRates
    {
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("PreviousDate")]
        public DateTime PreviousDate { get; set; }

        [JsonProperty("PreviousURL")]
        public string PreviousURL { get; set; }

        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("Valute")]
        public Dictionary<string, Valute> Valutes { get; set; }
    }

    public class Valute
    {
        public Valute(string id, string numCode, string charCode, int nominal, string name, double value, double previous)
        {
            this.ID = id;
            this.NumCode = numCode;
            this.CharCode = charCode;
            this.Nominal = nominal;
            this.Name = name;
            this.Value = value;
            this.Previous = previous;
        }

        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("NumCode")]
        public string NumCode { get; set; }

        [JsonProperty("CharCode")]
        public string CharCode { get; set; }

        [JsonProperty("Nominal")]
        public int Nominal { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("Previous")]
        public double Previous { get; set; }

        public double Convert(Valute selectedValuteDest, double amountSrc)
        {
            return amountSrc * this.Value * selectedValuteDest.Nominal / selectedValuteDest.Value * this.Nominal;
        }
    }
}