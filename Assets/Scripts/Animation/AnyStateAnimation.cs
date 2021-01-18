public enum RIG
{
    BODY,
    LEGS
}

public class AnyStateAnimation
{
    public RIG AnimationRig { get; private set; }
    public string Name { get; set; }
    public bool Active { get; set; }

    public AnyStateAnimation(RIG animationRig, string name)
    {
        AnimationRig = animationRig;
        Name = name;
    }
}
