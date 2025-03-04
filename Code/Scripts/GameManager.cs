using Godot;
using System;

public partial class GameManager : Node
{
    public override void _Ready()
    {
        Player player = new Player("Wojtek");
        Player player2 = new Player("Kacper");

        Node3D Main = GetNode<Node3D>("/root/Main");
        Main.AddChild(player);
        Main.AddChild(player2);

        player.Mesh = new BoxMesh();
        player2.Mesh = new SphereMesh();
        player.GlobalPosition = new Vector3(1, 1, 0);
        player2.GlobalPosition = new Vector3(2, 1, 0.5f);
        
        
        player.Damage(566);
        player2.Damage(20);
    }
}

