using ConsumingWebService.Data;
using ConsumingWebService.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Web;
using System.Xml.Serialization;

namespace ConsumingWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private HttpClient _httpClient;
        private readonly OpenWeatherMapOptions _options;

        public WeatherForecastController(HttpClient httpClient, IOptions<OpenWeatherMapOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        [HttpGet(Name = "GetWeatherByCityName")]
        public async Task<IActionResult> Get([FromQuery] string cityName, [FromQuery] string? mode = "json")
        {
            try
            {
                string baseUrl = _options.BaseUrl;

                var query = HttpUtility.ParseQueryString(string.Empty);
                query["q"] = cityName;
                query["appid"] = _options.ApiKey;
                
                if(mode != null)
                {
                    query["mode"] = mode;
                }

                var builder = new UriBuilder(baseUrl) { Query = query.ToString() };

                HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);

                var weather = new object();

                if (mode != null)
                {
                    if (mode.Equals("json", StringComparison.OrdinalIgnoreCase))
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };

                        weather = JsonSerializer.Deserialize<WeatherJsonResponseDTO>(json, options);
                    }
                    else if (mode.Equals("xml", StringComparison.OrdinalIgnoreCase))
                    {
                        string xml = await response.Content.ReadAsStringAsync();

                        XmlSerializer serializer = new XmlSerializer(typeof(WeatherXmlResponseDTO));

                        using (StringReader reader = new StringReader(xml))
                        {
                            weather = (WeatherXmlResponseDTO)serializer.Deserialize(reader);
                        }
                    }
                    else
                    {
                        return BadRequest("Invalid mode. Please input json or xml.");
                    }
                }

                return Ok(weather);
            }
            catch(Exception ex)
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
