namespace Commands
{
    public class TurnRightCommand : Command
    {
        public override void Execute() => Player.Instance.RotateRight();
    }
}