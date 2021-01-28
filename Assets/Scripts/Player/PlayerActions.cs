using System.Collections;
using System.Linq;
using UnityEngine;

public class PlayerActions
{
    private readonly Player _player;

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
            _player.Components.Animator.TryPlayAnimation("Body_Jump");
            _player.Components.Animator.TryPlayAnimation("Legs_Jump");
        }
    }

    public void Attack()
    {
        _player.Components.Animator.TryPlayAnimation("Body_Attack");
        _player.Components.Animator.TryPlayAnimation("Legs_Attack");
    }

    public void TrySwapWeapon(Weapon weapon)
    {
        if (!_player.Stats.Weapons[weapon]) return;

        _player.Stats.Weapon = weapon;
        _player.Components.Animator.SetWeapon((int) _player.Stats.Weapon);
        SwapWeapon();
    }

    public void SwapWeapon()
    {
        foreach (var weaponObject in _player.References.WeaponObjects.Skip(1))
            weaponObject.SetActive(false);

        if (_player.Stats.Weapon > 0)
            _player.References.WeaponObjects[(int) _player.Stats.Weapon].SetActive(true);
    }

    public void Shoot(string animation)
    {
        if (animation == "Shoot")
        {
            var go = GameObject.Instantiate(_player.References.ProjectilePrefab, _player.References.GunBarrel.position, Quaternion.identity);
            var direction = new Vector3(_player.transform.localScale.x, 0);
            go.GetComponent<Projectile>().Setup(direction);
        }
    }

    public void TakeHit()
    {
        if (_player.Stats.IsImmortal) return;

        if (_player.Stats.Lives > 0)
        {
            UIManager.Instance.RemoveLife();
            _player.Stats.Lives--;
            _player.Components.Animator.TryPlayAnimation("Body_Hurt");
        }

        if (_player.Stats.Alive)
        {
            _player.StartCoroutine(Immortality());
        }

        if (!_player.Stats.Alive)
        {
            _player.Components.Animator.TryPlayAnimation("Body_Die");
            _player.Components.Animator.TryPlayAnimation("Legs_Die");
        }
    }

    private IEnumerator Blink()
    {
        while (_player.Stats.IsImmortal)
        {
            foreach (var spriteRenderer in _player.Components.SpriteRenderers)
            {
                spriteRenderer.enabled = false;
            }

            yield return new WaitForSeconds(.15f);

            foreach (var spriteRenderer in _player.Components.SpriteRenderers)
            {
                spriteRenderer.enabled = true;
            }

            yield return new WaitForSeconds(.15f);
        }
    }

    private IEnumerator Immortality()
    {
        _player.Stats.IsImmortal = true;
        _player.StartCoroutine(Blink());
        yield return new WaitForSeconds(_player.Stats.ImmortalityTime);
        _player.Stats.IsImmortal = false;
    }

    public void Collide(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            collision.GetComponent<ICollectable>().Collect();
        }
    }

    public void PickUpWeapon(Weapon weapon)
    {
        _player.Stats.Weapons[weapon] = true;
    }
}
