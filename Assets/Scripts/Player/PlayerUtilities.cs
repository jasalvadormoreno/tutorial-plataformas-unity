using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities
{
    private Player _player;
    private List<Command> _commands = new List<Command>();

    public PlayerUtilities(Player player)
    {
        _player = player;
        _commands.Add(new JumpCommand(_player, KeyCode.Space));
    }

    public void HandleInput()
    {
        _player.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), _player.Components.Rigidbody.velocity.y);

        foreach (var command in _commands)
        {
            if (Input.GetKeyDown(command.Key))
            {
                command.GetKeyDown();
            }

            if (Input.GetKeyUp(command.Key))
            {
                command.GetKeyUp();
            }

            if (Input.GetKey(command.Key))
            {
                command.GetKey();
            }
        }
    }

    public bool IsGrounded()
    {
        var hit = Physics2D.BoxCast(
            _player.Components.Collider.bounds.center,
            _player.Components.Collider.bounds.size,
            0, Vector2.down,
            0.1f,
            _player.Components.GroundLayer
        );

        return hit.collider != null;
    }

    public void HandleAir()
    {
        if (IsFalling())
        {
            _player.Components.Animator.TryPlayAnimation("Body_Fall");
            _player.Components.Animator.TryPlayAnimation("Legs_Fall");
        }
    }

    private bool IsFalling()
    {
        return _player.Components.Rigidbody.velocity.y < 0;
    }
}
