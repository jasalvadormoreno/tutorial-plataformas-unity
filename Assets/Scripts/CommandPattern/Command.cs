using UnityEngine;

public abstract class Command
{
    public KeyCode Key { get; private set; }

    public Command(KeyCode key)
    {
        Key = key;
    }

    public virtual void GetKeyDown()
    {
        
    }

    public virtual void GetKeyUp()
    {
        
    }

    public virtual void GetKey()
    {
        
    }
}
