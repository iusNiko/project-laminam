using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node3D
{
    public static GameManager Instance;
    public Node3D Main;
    public RayCast3D MouseTrace;
    public Random RNG = new Random();
    public override void _Ready()
    {
        Instance = this;

        Player player = new Player("Wojtek");
        Player player2 = new Player("Kacper");

        Main = GetNode<Node3D>("/root/Main");
        Main.AddChild(player);
        Main.AddChild(player2);

        player.MeshInstance = new MeshInstance3D();
        player2.MeshInstance = new MeshInstance3D();

        player.MeshInstance.Mesh = new BoxMesh();
        player2.MeshInstance.Mesh = new SphereMesh();

        player.MeshInstance.MaterialOverride = new ShaderMaterial();
        player2.MeshInstance.MaterialOverride = new ShaderMaterial();

        player.CollisionShape.Shape = new BoxShape3D();
        player2.CollisionShape.Shape = new SphereShape3D();

        player.GlobalPosition = new Vector3(1, 1, 0);
        player2.GlobalPosition = new Vector3(2, 1, 0.5f);
        
        player.Damage(566);
        player2.Damage(20);

        MouseTrace = new RayCast3D();
        Main.AddChild(MouseTrace);
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 mousePos = GetViewport().GetMousePosition();
        Camera3D camera = GetNode<Camera3D>("/root/Main/Camera3D");
        Vector3 origin = camera.ProjectRayOrigin(mousePos);
        Vector3 end = origin + camera.ProjectRayNormal(mousePos) * 100f;
        
        MouseTrace.GlobalPosition = origin;
        MouseTrace.TargetPosition = end;

        MouseTrace.ForceRaycastUpdate();

        List<Entity> collidedEntities = [];

        if(MouseTrace.IsColliding()) {
            Object collider = MouseTrace.GetCollider();
            if(collider is Entity entity) {
                collidedEntities.Add(entity);
            }
        }

        foreach(Entity entity in GetChildrenOfType<Entity>(Main)) {
            if(collidedEntities.Contains(entity)) {
                (entity.MeshInstance.MaterialOverride as ShaderMaterial).Shader = ResourceLoader.Load<Shader>("res://Shaders/Highlight.gdshader");
            }
            else {
                (entity.MeshInstance.MaterialOverride as ShaderMaterial).Shader = null;
            }
        }
        
        

    }

    public static List<T> GetChildrenOfType<T>(Node parent) {
        List<T> children = [];
        foreach(Node child in parent.GetChildren()) {
            if(child is T childOfType) {
                children.Add(childOfType);
            }
        }
        return children;
    }
}

