using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _stats;

    [SerializeField]
    private PlayerComponents _components;

    private PlayerReferences _references;
    private PlayerUtilities _utilities;
    private PlayerActions _actions;

    public PlayerComponents Components => _components;
    public PlayerStats Stats => _stats;
    public PlayerActions Actions => _actions;
    public PlayerUtilities Utilities => _utilities;

    private void Start()
    {
        _actions = new PlayerActions(this);
        _utilities = new PlayerUtilities(this);

        _stats.Speed = _stats.WalkSpeed;

        var animations = new[]
        {
            new AnyStateAnimation(RIG.BODY, "Body_Idle", "Body_Attack"),
            new AnyStateAnimation(RIG.BODY, "Body_Walk", "Body_Attack", "Body_Jump"),
            new AnyStateAnimation(RIG.BODY, "Body_Jump"),
            new AnyStateAnimation(RIG.BODY, "Body_Fall"),
            new AnyStateAnimation(RIG.BODY, "Body_Attack"),

            new AnyStateAnimation(RIG.LEGS, "Legs_Idle", "Legs_Attack"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Walk", "Legs_Jump"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Jump"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Fall"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Attack"),
        };

        _components.Animator.AddAnimations(animations);
    }

    private void Update()
    {
        _utilities.HandleInput();
        _utilities.HandleAir();
    }

    private void FixedUpdate()
    {
        _actions.Move(transform);
    }
}
