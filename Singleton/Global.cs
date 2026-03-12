 using Godot;
 using System.Numerics;

public partial class Global : Node
{
    private static Global Instance { get; set; }
    public static int Difficulty;
    public static BigInteger Money;
    public static int Health = 1000;
    public static int Cooldown = 0;
    public static int Damage = 0;
    public static int Radius = 0;

    // Info:
    public static readonly (string path, float weight)[] Enemies =
    [
        ("res://Enemy/EnemyBasic/EnemyBasic.tscn", .5f),
        ("res://Enemy/EnemySpeedy/EnemySpeedy.tscn", .25f), 
        ("res://Enemy/EnemyBig/EnemyBig.tscn", .20f),
        ("res://Enemy/EnemyShadow/EnemyShadow.tscn", .05f),
    ];

public override void _Ready()
    {
        if (Instance == null)
            Instance = this;
        else
            GD.PushError("Global instance already exists.");
    }

    public static void Save()
    {
        using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Write);

        saveFile.StoreVar(Difficulty);
        saveFile.StoreVar(Money);
        saveFile.StoreVar(Health);
        saveFile.StoreVar(Cooldown);
        saveFile.StoreVar(Damage);
        saveFile.StoreVar(Radius);
        saveFile.Close();
    }

    public static void Load()
    {
        if (!FileAccess.FileExists("user://savegame.save"))
            return;
        
        using var saveFile = FileAccess.Open("user://savegame.save", FileAccess.ModeFlags.Read);

        if (saveFile == null)
            return;

        Difficulty = (int)saveFile.GetVar();
        Money = (long)saveFile.GetVar();
        Health = (int)saveFile.GetVar();
        Cooldown = (int)saveFile.GetVar();
        Damage = (int)saveFile.GetVar();
        Radius = (int)saveFile.GetVar();
    }
}
