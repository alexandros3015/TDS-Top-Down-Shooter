using Godot;
using System;
using tdstopdownshooter.Player;

public partial class ScopeVisuals : Node
{
    [Export] public HurtHandler HurtHandler;
    [Export] public Node2D Scope;
    [Export] public AnimationPlayer AnimationPlayer;

    private Color _targetColor;

    public override void _Ready()
    {
        // connect to signals to play animations
        HurtHandler.Shot += () => AnimationPlayer.Play("shoot");
        HurtHandler.ShotNoAmmo += () => AnimationPlayer.Play("cant_shoot");
    }

    public override void _Process(double delta)
    {
        // set the target color if you can shoot or not
        _targetColor = HurtHandler.CanShoot ? Colors.White : new Color(1, 1, 1, 0.5f);

        // LERP
        Scope.Modulate = Scope.Modulate.Lerp(_targetColor, (float)(delta * 15));
    }
}
