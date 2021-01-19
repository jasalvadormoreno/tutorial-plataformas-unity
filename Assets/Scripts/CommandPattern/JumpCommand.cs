using UnityEngine;

public class JumpCommand : Command
{
    public JumpCommand(KeyCode key) : base(key) { }

    public override void GetKeyDown()
    {
        Debug.Log("JUMP!!");
    }
}
