using Godot;
using System;
using System.Numerics;

namespace tdstopdownshooter.Shop;

public partial class Upgrades : VBoxContainer
{
    [Export] public Button DamageButton;
    [Export] public Button CooldownButton;
    [Export] public Button RadiusButton;
    [Export] public Label MoneyLabel;

    private BigInteger _damageCost = 5;
    private BigInteger _cooldownCost = 5;
    private BigInteger _radiusCost = 5;

    private static BigInteger Function(int timesBought)
    {
        return (BigInteger)Math.Round(5.0 * Math.Pow(5.0, 0.22 * timesBought), MidpointRounding.AwayFromZero);
    }

    private void UpdateData()
    {
        _damageCost = Function(Global.Damage);
        _cooldownCost = Function(Global.Cooldown);
        _radiusCost = Function(Global.Radius) * 2;
        
        DamageButton.Text = $"Damage ({Global.Damage}): ${_damageCost}";
        CooldownButton.Text = $"Cooldown ({Global.Cooldown}): ${_cooldownCost}";
        RadiusButton.Text = $"Radius ({Global.Radius}): ${_radiusCost}";

        MoneyLabel.Text = $"Money: ${Global.Money}";
        
        Global.Save();
    }

    public override void _Ready()
    {
        UpdateData();
        DamageButton.Pressed += DamageButtonOnPressed;
        CooldownButton.Pressed += CooldownButtonOnPressed;
        RadiusButton.Pressed += RadiusButtonOnPressed;
    }
    
    private void DamageButtonOnPressed()
    {
        if (Global.Money < _damageCost)
            return;
        
        Global.Money -= _damageCost;
        Global.Damage++;
        UpdateData();
    }
    
    private void CooldownButtonOnPressed()
    {
        if (Global.Money < _cooldownCost)
            return;
        
        Global.Money -= _cooldownCost;
        Global.Cooldown++;
        UpdateData();
    }
    
    private void RadiusButtonOnPressed()
    {
        if (Global.Money < _radiusCost)
            return;
        
        Global.Money -= _radiusCost;
        Global.Radius++;
        UpdateData();
    }
}
