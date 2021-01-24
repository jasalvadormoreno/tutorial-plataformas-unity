using UnityEngine;

public enum Weapon
{
    Fists,
    Sword,
    Gun,
}

public class WeaponSwapCommand : Command
{
    private Player _player;
    private Weapon _weapon;

    public WeaponSwapCommand(Player player, Weapon weapon, KeyCode key) : base(key)
    {
        _player = player;
        _weapon = weapon;
    }

    public override void GetKeyDown()
    {
        _player.Actions.TrySwapWeapon(_weapon);
    }
}
