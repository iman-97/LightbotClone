namespace Commands
{
    public class TurnRightCommand : Command
    {
        public override void Execute()
        {
            //playerBridge.Player.RotateRight();
            Player.Instance.RotateRight();
        }
    }
}