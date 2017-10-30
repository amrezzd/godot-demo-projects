using Godot;
using System;

public class Paddle : Area2D
{
    [Export]
    private int ballDir = 1;

    private const int MOVE_SPEED = 100;

    public override void _Process(float delta)
    {
        String which = GetName();

        // Move up and down based on input
        if (Input.IsActionPressed(which + "_move_up") && GetPosition().y > 0)
        {
            Vector2 pos = GetPosition();
            pos.y -= MOVE_SPEED * delta;
            SetPosition(pos);
        }
        if (Input.IsActionPressed(which + "_move_down") && GetPosition().y < GetViewportRect().Size.y)
        {
            Vector2 pos = GetPosition();
            pos.y += MOVE_SPEED * delta;
            SetPosition(pos);
        }
    }

    public void OnAreaEntered(Area2D area)
    {
        if (area is Ball)
        {
            // Assign new direction
            Ball ball = (Ball)area;
            ball.SetDirection(new Vector2(ballDir, (float)new Random().NextDouble() * 2 - 1).normalized());
        }
    }
}