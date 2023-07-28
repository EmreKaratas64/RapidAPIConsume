namespace RapidAPIConsume_WEBUI.DTOs.DashboardSocialMediaDtos
{
    public class LinkednResultDto
    {

        public Data data { get; set; }

        public class Data
        {
            public int connections_count { get; set; }
            public int followers_count { get; set; }
        }

    }
}
