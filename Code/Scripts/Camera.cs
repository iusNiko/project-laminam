using Godot;
using System;

public partial class Camera : Camera3D
{
    [Export] public float Speed = 10f;
    [Export] public float ScrollSpeed = 100f;
    [Export] public float RotationSpeed = 3f;
    private float TotalPitch = 0;
    public Vector2 MousePosLastFrame;
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

        Translate(direction * Speed * (float)delta);

        direction = ProjectRayNormal(new Vector2(GetWindow().Size.X / 2, GetWindow().Size.Y / 2));
        float Zoom = 0;

        if(Input.IsActionJustPressed("scroll_up")) {
            Zoom += 1;
        }
        if(Input.IsActionJustPressed("scroll_down")) {
            Zoom -= 1;
        }

        GlobalPosition += direction * ScrollSpeed * Zoom * (float)delta;

        if(Input.IsActionPressed("scroll")) {
            Vector2 mouseDirection = MousePosLastFrame.DirectionTo(GetViewport().GetMousePosition());

            float yaw = mouseDirection.X;
            float pitch = mouseDirection.Y;
            pitch = Mathf.Clamp(pitch, -90 - TotalPitch, 90 - TotalPitch);
            TotalPitch += pitch;
            RotateY(Mathf.DegToRad(-yaw));
            RotateObjectLocal(new Vector3(1.0f, 0.0f, 0.0f), Mathf.DegToRad(-pitch));
        }


        MousePosLastFrame = GetViewport().GetMousePosition();
    }
}
