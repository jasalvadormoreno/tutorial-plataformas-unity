using UnityEngine;

public class PlayerActions
{
    private Player _player;

    public PlayerActions(Player player)
    {
        _player = player;
    }

    public void Move(Transform transform)
    {
        _player.Components.Rigidbody.velocity = Vector2.right;
        // transform.position
    }
}
