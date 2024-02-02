using Cocona;

namespace wttr.WttrService;

public class WttrCommands
{
    private readonly IWttrService _wttrService;

    public WttrCommands(IWttrService wttrService)
    {
        _wttrService = wttrService;
    }

    [Command]
    public async Task Wttr(string? city)
    {
        var wttr = await _wttrService.GetWttrForCityAsync(city);
        Console.WriteLine(wttr);
    }
}