using UnityEngine;

public interface ICollisionHandler
{
    void CollisionEnter(string colliderName, GameObject other);
}
