namespace Commands
{
    public class JumpCommand : Command
    {
        public override void Execute() => Player.Instance.Jump();
    }
}