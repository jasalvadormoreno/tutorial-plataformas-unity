using System;
using System.Collections.Generic;
using System.Linq;
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

    private void Update()
    {
        Animate();
    }

    public void AddAnimations(params AnyStateAnimation[] animations)
    {
        foreach (var animationRig in animations)
        {
            _animations.Add(animationRig.Name, animationRig);
        }
    }

    public void TryPlayAnimation(string newAnimation)
    {
        switch (_animations[newAnimation].AnimationRig)
        {
            case RIG.BODY:
                PlayAnimation(ref _currentAnimationBody);
                break;
            case RIG.LEGS:
                PlayAnimation(ref _currentAnimationLegs);
                break;
        }

        void PlayAnimation(ref string currentAnimation)
        {
            if (string.IsNullOrEmpty(currentAnimation))
            {
                _animations[newAnimation].Active = true;
                currentAnimation = newAnimation;
            }
            else if (
                currentAnimation != newAnimation
                && !_animations[newAnimation].HigherPriority.Contains(currentAnimation)
                || !_animations[currentAnimation].Active
            )
            {
                _animations[currentAnimation].Active = false;
                _animations[newAnimation].Active = true;
                currentAnimation = newAnimation;
            }
        }
    }

    private void Animate()
    {
        foreach (var key in _animations.Keys)
        {
            _animator.SetBool(key, _animations[key].Active);
        }
    }

    public void OnAnimationDone(string animation)
    {
        _animations[animation].Active = false;
    }
}
