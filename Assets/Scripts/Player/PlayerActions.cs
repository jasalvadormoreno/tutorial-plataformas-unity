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
        _player.Components.Rigidbody.velocity = new Vector2(_player.Stats.Direction.x * _player.Stats.Speed * Time.deltaTime, _player.Stats.Direction.y);
        // transform.position
    }
}
