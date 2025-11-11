using Godot;
using System;

public partial class HpBar : ProgressBar
{
    public override void _Process(double delta)
    {
        Value = Mathf.Lerp(Value, Global.Health, 5.0 * delta);
    }
}
