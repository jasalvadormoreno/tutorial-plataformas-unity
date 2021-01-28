using UnityEngine;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private AnyStateAnimator animator;
    [SerializeField]
    private Collider2D collider;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private SpriteRenderer[] spriteRenderers;
    public Rigidbody2D Rigidbody => rigidbody;
    public AnyStateAnimator Animator => animator;
    public Collider2D Collider => collider;
    public LayerMask GroundLayer => groundLayer;
    public SpriteRenderer[] SpriteRenderers => spriteRenderers;
}
