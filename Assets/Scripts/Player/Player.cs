using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStats _stats;
    [SerializeField]
    private PlayerComponents _components;
    private PlayerReferences _references;
    private PlayerUtilities _utilities;
    private PlayerActions _actions;

    public PlayerComponents Components => _components;

    private void Awake()
    {
        _actions = new PlayerActions(this);
    }

    private void FixedUpdate()
    {
        _actions.Move(transform);
    }
}
