using UnityEngine;

public class Enemy : MonoBehaviour, ICollisionHandler
{
    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "DamageArea" && other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Actions.TakeHit();
        }
    }
}
