using Godot;
using System;

public partial class Player : Entity {

    public Player(string inputtedName) {
        playerName = inputtedName;
    }
    public override void _Process(double delta)
    {
        Vector3 direction = new Vector3();
        if(Input.IsActionPressed("s")) {
            direction.Z += 1;
        }
        if(Input.IsActionPressed("w")) {
            direction.Z -= 1;
        }
        if(Input.IsActionPressed("d")) {
            direction.X += 1;
        }
        if(Input.IsActionPressed("a")) {
            direction.X -= 1;
        }
        if(Input.IsActionPressed("space")) {
            direction.Y += 1;
        }
        if(Input.IsActionPressed("shift")) {
            direction.Y -= 1;
        }

        direction = direction.Normalized();

        GlobalPosition += direction * Speed * (float)delta;
    }
}