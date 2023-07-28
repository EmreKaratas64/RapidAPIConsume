using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidAPIConsume_WEBUI.DTOs.DashboardSocialMediaDtos;

namespace RapidAPIConsume_WEBUI.ViewComponents
{
    public class DashboardSocialMedias : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/murattycedag"),
                Headers =
    {
        { "X-RapidAPI-Key", "a83746901emshc93877d882a5573p1a5f3cjsn9f1aa850f786" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InstagramResultDto>(body);
                ViewBag.InstagramFollowers = values.followers;
                ViewBag.InstagramFollowed = values.following;
            }

            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=murattyucedag"),
                Headers =
    {
        { "X-RapidAPI-Key", "a83746901emshc93877d882a5573p1a5f3cjsn9f1aa850f786" },
        { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request2))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TwitterResultDto>(body);
                ViewBag.TwitterFollowing = values.data.user_info.friends_count;
                ViewBag.TwitterFollowers = values.data.user_info.followers_count;
            }

            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Femre-karata%25C5%259F-8491b3226%2F"),
                Headers =
    {
        { "X-RapidAPI-Key", "a83746901emshc93877d882a5573p1a5f3cjsn9f1aa850f786" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request3))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<LinkednResultDto>(body);
                ViewBag.LinkednFollowing = values.data.connections_count;
                ViewBag.LinkednFollowers = values.data.followers_count;
            }
            return View();
        }
    }
}
