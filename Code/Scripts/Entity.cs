using Godot;
using System;

public partial class Entity : MeshInstance3D
{
    public string playerName;
    [Export] public float Speed = 100f;
    [Export] public float Health = 100f;

    public override void _Process(double delta)
    {
        
    }

    public void Damage(float amount) {
        Health -= amount;
        GD.Print($"{playerName} has {Health} left!");
    }
}
