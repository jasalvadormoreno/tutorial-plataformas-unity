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
}
