public enum RIG
{
    BODY,
    LEGS
}

public class AnyStateAnimation
{
    public RIG AnimationRig { get; private set; }
    public string[] HigherPriority { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }

    public AnyStateAnimation(RIG animationRig, string name, params string[] higherPriority)
    {
        AnimationRig = animationRig;
        Name = name;
        HigherPriority = higherPriority;
    }
}
