namespace Commands
{
    public class JumpCommand : Command
    {
        public override void Execute()
        {
            //playerBridge.Player.Jump();
            Player.Instance.Jump();
        }
    }
}