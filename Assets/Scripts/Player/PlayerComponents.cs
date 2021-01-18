using UnityEngine;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    public Rigidbody2D Rigidbody => _rigidbody;
}
