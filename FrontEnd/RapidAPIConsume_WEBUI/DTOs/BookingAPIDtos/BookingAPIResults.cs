namespace RapidAPIConsume_WEBUI.DTOs.BookingAPIDtos
{
    public class BookingAPIResults
    {
        public Result[] results { get; set; }

        public class Result
        {
            public int id { get; set; }
            public string name { get; set; }
            public string photoMainUrl { get; set; }
            public string countryCode { get; set; }
            public float latitude { get; set; }
            public float longitude { get; set; }
            public string currency { get; set; }
            public string checkoutDate { get; set; }
            public string checkinDate { get; set; }
            public float reviewScore { get; set; }
            public string reviewScoreWord { get; set; }
            public int reviewCount { get; set; }
            public int qualityClass { get; set; }
            public int ufi { get; set; }
            public string wishlistName { get; set; }
        }
    }
}
