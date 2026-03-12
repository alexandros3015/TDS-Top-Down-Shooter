using Godot;

namespace tdstopdownshooter.MainArea.Zone;
public partial class MoneyDisplay : Label
{
    public override void _Process(double delta)
    {
        var msg = Global.Money.ToString("N0");
        Text = $"Money: ${msg}";
    }
}
