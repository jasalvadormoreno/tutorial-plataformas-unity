using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _stats;

    public PlayerStats Stats => _stats;

    [SerializeField]
    private PlayerComponents _components;

    public PlayerComponents Components => _components;

    [SerializeField]
    private PlayerReferences _references;

    public PlayerReferences References => _references;
    private PlayerUtilities _utilities;
    public PlayerUtilities Utilities => _utilities;
    private PlayerActions _actions;
    public PlayerActions Actions => _actions;


    private void Start()
    {
        _actions = new PlayerActions(this);
        _utilities = new PlayerUtilities(this);

        _stats.Speed = _stats.WalkSpeed;

        var animations = new[]
        {
            new AnyStateAnimation(RIG.BODY, "Body_Idle", "Body_Attack", "Body_Hurt"),
            new AnyStateAnimation(RIG.BODY, "Body_Walk", "Body_Attack", "Body_Jump", "Body_Hurt"),
            new AnyStateAnimation(RIG.BODY, "Body_Jump", "Body_Hurt"),
            new AnyStateAnimation(RIG.BODY, "Body_Fall", "Body_Hurt"),
            new AnyStateAnimation(RIG.BODY, "Body_Attack", "Body_Hurt"),
            new AnyStateAnimation(RIG.BODY, "Body_Hurt", "Body_Die"),
            new AnyStateAnimation(RIG.BODY, "Body_Die"),

            new AnyStateAnimation(RIG.LEGS, "Legs_Idle", "Legs_Attack"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Walk", "Legs_Jump"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Jump"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Fall"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Attack", "Legs_Die"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Die"),
        };

        Components.Animator.AnimationTriggerEvent += Actions.Shoot;

        _stats.Weapons.Add(Weapon.Fists, true);
        _stats.Weapons.Add(Weapon.Sword, false);
        _stats.Weapons.Add(Weapon.Gun, false);

        UIManager.Instance.AddLife(_stats.Lives);

        _components.Animator.AddAnimations(animations);
    }

    private void Update()
    {
        if (!_stats.Alive) return;
        
        _utilities.HandleInput();
        _utilities.HandleAir();
    }

    private void FixedUpdate()
    {
        if (!_stats.Alive) return;

        _actions.Move(transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _actions.Collide(collision);
    }
}
