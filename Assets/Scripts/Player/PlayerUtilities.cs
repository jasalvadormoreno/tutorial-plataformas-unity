using UnityEngine;

public class PlayerUtilities
{
    private Player _player;

    public PlayerUtilities(Player player)
    {
        _player = player;
    }

    public void HandleInput()
    {
        _player.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), _player.Components.Rigidbody.velocity.y);
    }
}
