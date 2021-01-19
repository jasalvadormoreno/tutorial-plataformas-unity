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
            new AnyStateAnimation(RIG.BODY, "Body_Idle"),
            new AnyStateAnimation(RIG.BODY, "Body_Walk"),
            
            new AnyStateAnimation(RIG.LEGS, "Legs_Idle"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Walk"),
        };
        
        _components.Animator.AddAnimations(animations);
    }

    private void Update()
    {
        _utilities.HandleInput();
    }

    private void FixedUpdate()
    {
        _actions.Move(transform);
    }
}
