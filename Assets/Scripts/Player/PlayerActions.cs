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
        _player.Components.Rigidbody.velocity = new Vector2(_player.Stats.Direction.x * _player.Stats.Speed * Time.deltaTime, _player.Components.Rigidbody.velocity.y);
        if (_player.Stats.Direction.x != 0)
        {
            transform.localScale = new Vector3(_player.Stats.Direction.x < 0 ? -1 : 1, 1, 1);
            _player.Components.Animator.TryPlayAnimation("Body_Walk");
            _player.Components.Animator.TryPlayAnimation("Legs_Walk");
        }
        else if (_player.Components.Rigidbody.velocity == Vector2.zero)
        {
            _player.Components.Animator.TryPlayAnimation("Body_Idle");
            _player.Components.Animator.TryPlayAnimation("Legs_Idle");
        }
    }

    public void Jump()
    {
        if (_player.Utilities.IsGrounded())
        {
            _player.Components.Rigidbody.AddForce(new Vector2(0, _player.Stats.JumpForce), ForceMode2D.Impulse);
        }
    }
}
