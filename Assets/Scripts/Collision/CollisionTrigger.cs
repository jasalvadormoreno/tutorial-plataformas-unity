using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private ICollisionHandler _handler;

    private void Start()
    {
        _handler = GetComponentInParent<ICollisionHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _handler.CollisionEnter(name, collision.gameObject);
    }
}
