using Godot;

namespace tdstopdownshooter.Enemy.EnemyShadow;
public partial class VisionHandler : Node
{
    [Export] public Node2D ShadowSkeleton;

    private float _factor;
    public override void _Process(double delta)
    {
        _factor += 0.0001f;
        ShadowSkeleton.Modulate = new Color(1.0f, 1.0f, 1.0f, float.Min(_factor, 1.0f));
    }
}
