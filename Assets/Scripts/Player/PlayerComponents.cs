using UnityEngine;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private AnyStateAnimator _animator;

    public Rigidbody2D Rigidbody => _rigidbody;

    public AnyStateAnimator Animator => _animator;
}
