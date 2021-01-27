using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public Vector2 Direction { get; set; }
    public float Speed { get; set; }
    [SerializeField]
    private float walkSpeed;
    public float WalkSpeed => walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float jumpForce;
    public float JumpForce => jumpForce;
    [SerializeField]
    private Weapon weapon;
    public Weapon Weapon
    {
        get => weapon;
        set => weapon = value;
    }
    [SerializeField]
    private int lives;
    public int Lives
    {
        get => lives;
        set => lives = value;
    }

    public Dictionary<Weapon, bool> Weapons { get; set; } = new Dictionary<Weapon, bool>();
}
