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
}
