using UnityEngine;

public class WeaponPickup : MonoBehaviour, ICollectable
{
    [SerializeField]
    private Weapon weapon;

    public Weapon Weapon
    {
        get => weapon;
        set => weapon = value;
    }

    public void Collect()
    {
        FindObjectOfType<Player>().Actions.PickUpWeapon(weapon);
        Destroy(gameObject);
    }
}
