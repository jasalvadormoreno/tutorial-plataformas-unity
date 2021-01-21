using UnityEngine;

namespace CommandPattern
{
    public class AttackCommand : Command
    {
        private readonly Player _player;

        public AttackCommand(Player player, KeyCode key) : base(key)
        {
            _player = player;
        }

        public override void GetKeyDown()
        {
            _player.Actions.Attack();
        }
    }
}
