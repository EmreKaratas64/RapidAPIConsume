namespace RapidAPIConsume_WEBUI.DTOs.CurrencyDtos
{
    public class CurrencyResult
    {
        public Exchange_Rates[] exchange_rates { get; set; }


        public class Exchange_Rates
        {
            public string currency { get; set; }
            public string exchange_rate_buy { get; set; }
        }
    }
}
