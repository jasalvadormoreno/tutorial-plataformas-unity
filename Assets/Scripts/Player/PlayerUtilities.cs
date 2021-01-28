using System.Collections.Generic;
using CommandPattern;
using UnityEngine;

public class PlayerUtilities
{
    private Player _player;
    private List<Command> _commands = new List<Command>();

    public PlayerUtilities(Player player)
    {
        _player = player;
        _commands.Add(new JumpCommand(_player, KeyCode.Space));
        _commands.Add(new AttackCommand(_player, KeyCode.LeftShift));
        _commands.Add(new WeaponSwapCommand(_player, Weapon.Fists, KeyCode.Alpha1));
        _commands.Add(new WeaponSwapCommand(_player, Weapon.Sword, KeyCode.Alpha2));
        _commands.Add(new WeaponSwapCommand(_player, Weapon.Gun, KeyCode.Alpha3));
    }

    public void HandleInput()
    {
        _player.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), _player.Components.Rigidbody.velocity.y);
        Debug.Log(Input.GetAxisRaw("Horizontal"));

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

        // TODO: Remove this
        if (Input.GetKeyDown(KeyCode.P))
        {
            UIManager.Instance.RemoveLife();
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
