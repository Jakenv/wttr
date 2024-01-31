using System.Net;
using HtmlAgilityPack;

namespace wttr.WttrService;

public interface IWttrService
{
    Task<string?> GetWttrForCityAsync(string? city);
}

public class WttrService : IWttrService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WttrService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<string?> GetWttrForCityAsync(string? city)
    {
        var client = _httpClientFactory.CreateClient();

        var url = $"https://wttr.in/{city}?T";

        var wttrResponse = await client.GetAsync(url);
        if (wttrResponse.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        var htmlContent = await wttrResponse.Content.ReadAsStringAsync();

        var htmlDocument = new HtmlDocument();
        htmlDocument.LoadHtml(htmlContent);
        
        var preElement = htmlDocument.DocumentNode.SelectSingleNode("//pre");
        var decodeText = HtmlEntity.DeEntitize(preElement?.InnerText ?? string.Empty);
        return decodeText;
    }
}