namespace Commands
{
    public class TurnLeftCommand : Command
    {
        public override void Execute()
        {
            //playerBridge.Player.RotateLeft();
            Player.Instance.RotateLeft();
        }
    }
}