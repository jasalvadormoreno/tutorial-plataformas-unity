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

    private void Awake()
    {
        _actions = new PlayerActions(this);
        _utilities = new PlayerUtilities(this);
        
        _stats.Speed = _stats.WalkSpeed;
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
