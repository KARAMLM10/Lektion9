
namespace ServiceApplikationnew.MVVM.Models;

public class DeviceItem
{

    public string? DeviceId { get; set; }
    public string? Devicetype { get; set; }
    public string? Placement { get; set; }
    public bool IsActive { get; set; }
    public string? Icon => SetIcon();

    private string SetIcon()
    {
        return (Devicetype?.ToLower()) switch
        {
            "lampa" => "\uf0eb",
            "fan" => "\ue004",
            _ => "\uf2db"
        };
    }
}
