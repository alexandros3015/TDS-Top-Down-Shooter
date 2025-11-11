using Godot;
using tdstopdownshooter.Enemy.EnemyBasic;

namespace tdstopdownshooter.MainArea.DeathArea;

public partial class DeathArea : Node2D
{
    private Area2D _area2D;
    public override void _Ready()
    {
        _area2D = GetNode<Area2D>("Area2D");
        if (_area2D == null)
            GD.PushError("Area2D not found.");
        else
            _area2D.AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Area2D area)
    {
        GD.Print($"Detected body: {area}");
        
        if (area is not HurtBox enemyBody) return;

        var healthHandler = enemyBody.GetNodeOrNull<HealthHandler>("../HealthHandler");

        if (healthHandler == null)
            GD.PushError("HealthHandler not found.");
        else
        {
            Global.Health -= healthHandler.CurrentHealth;
            healthHandler.Die();
            
            GD.Print($"Health of base: {Global.Health}");
        }
    }
}
