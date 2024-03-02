using ExchangeRate.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExchangeRate.Services
{
    public class ValuteService

    {
        CurrencyRates valCurs = new();
        HttpClient httpClient;

        public ValuteService()
        {
            httpClient = new HttpClient();
        }

        public void AddBaseValute(CurrencyRates currencyRates)
        {
            Valute baseValute = new Valute(
            "0",
            "810",
            "RUB",
            1,
            "Российский рубль",
            1,
            1);
            currencyRates.Valutes.Add(baseValute.CharCode, baseValute);
        }

        public async Task<CurrencyRates> GetCurrencies(DateTime date)
        {
            if (valCurs.Valutes?.Count > 0 && valCurs.Date == date)
            {
                return valCurs;
            }

            HttpResponseMessage response;
            date = date.AddDays(1);
            do
            {
                date = date.AddDays(-1);
                String dateString = date.ToString("yyyy'/'MM'/'dd");
                String apiUrl = $"https://www.cbr-xml-daily.ru/archive/{dateString}/daily_json.js";
                response = await httpClient.GetAsync(apiUrl);
            }
            while (response.IsSuccessStatusCode == false);


            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                valCurs = JsonConvert.DeserializeObject<CurrencyRates>(jsonString);
                AddBaseValute(valCurs);
                return valCurs;
            }
            return null;
        }
    }
}
