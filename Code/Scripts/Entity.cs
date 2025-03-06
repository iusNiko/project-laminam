using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class Entity : CharacterBody3D
{
    public static Entity[] Entities = [];
    public MeshInstance3D MeshInstance = new MeshInstance3D();
    public CollisionShape3D CollisionShape = new();
    public string playerName;
    [Export] public float Speed = 10f;
    [Export] public float Health = 100f;

    public Entity() {
        Entities = [.. Entities, this];
    }

    ~Entity() {
        Entities = Entities.Where(entity => entity != this).ToArray();
    }

    public override void _Ready()
    {
        AddChild(MeshInstance);
        AddChild(CollisionShape);
    }

    public override void _Process(double delta)
    {
        
    }

    public void Damage(float amount) {
        Health -= amount;
        GD.Print($"{playerName} has {Health} left!");
    }
}
