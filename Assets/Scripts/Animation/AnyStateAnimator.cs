using System.Collections.Generic;
using UnityEngine;

public class AnyStateAnimator : MonoBehaviour
{
    private Animator _animator;
    private Dictionary<string, AnyStateAnimation> _animations = new Dictionary<string, AnyStateAnimation>();
    private string _currentAnimationLegs = string.Empty;
    private string _currentAnimationBody = string.Empty;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AddAnimations(params AnyStateAnimation[] animations)
    {
        foreach (var animationRig in animations)
        {
            _animations.Add(animationRig.Name, animationRig);
        }
    }
}
