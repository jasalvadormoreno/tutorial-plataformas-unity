using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public Vector2 Direction { get; set; }
    public float Speed { get; set; }
    
    [SerializeField]
    private float _walkSpeed;
    public float WalkSpeed => _walkSpeed;
    [SerializeField]
    private float _runSpeed;
}
