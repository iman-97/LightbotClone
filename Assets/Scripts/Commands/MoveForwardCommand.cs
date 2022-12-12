namespace Commands
{
    public class MoveForwardCommand : Command
    {
        public override void Execute() => Player.Instance.MoveForward();
    }
}
