namespace Commands
{
    public class MoveForwardCommand : Command
    {
        public override void Execute()
        {
            //playerBridge.Player.MoveForward();
            Player.Instance.MoveForward();
        }
    }
}
