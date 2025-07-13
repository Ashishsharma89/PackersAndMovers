using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using packers.Infrastructure.Config;

namespace packers.Infrastructure.Services.Communication
{
    public class FcmService
    {
        private readonly string _serverKey;
        private readonly HttpClient _httpClient;

        public FcmService(IOptions<FcmConfig> config)
        {
            _serverKey = config.Value.ServerKey;
            _httpClient = new HttpClient();
        }

        public async Task<bool> SendPushNotificationAsync(string deviceToken, string title, string body)
        {
            var message = new
            {
                to = deviceToken,
                notification = new
                {
                    title = title,
                    body = body
                }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send")
            {
                Headers =
                {
                    { "Authorization", $"key={_serverKey}" },
                    { "Sender", _serverKey }
                },
                Content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
} 