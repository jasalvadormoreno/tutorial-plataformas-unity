using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private string targetTag;
    private Vector2 _direction;

    private void Update()
    {
        transform.Translate(_direction * (speed * Time.deltaTime));
    }

    public void Setup(Vector2 direction)
    {
        _direction = direction;
    }
}
