namespace Commands
{
    public class TurnLeftCommand : Command
    {
        public override void Execute() => Player.Instance.RotateLeft();
    }
}