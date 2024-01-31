using Cocona;
using wttr.WttrService;

namespace wttr;

public class WttrCommands
{
    private readonly IWttrService _wttrService;

    public WttrCommands(IWttrService wttrService)
    {
        _wttrService = wttrService;
    }

    [Command("city", Description = "Get weather for city")]
    public async Task Wttr(string? city = null)
    {
        var wttr = await _wttrService.GetWttrForCityAsync(city);
        Console.WriteLine(wttr);
    }
}