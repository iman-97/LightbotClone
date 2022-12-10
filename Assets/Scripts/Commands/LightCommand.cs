namespace Commands
{
    public class LightCommand : Command
    {
        public override void Execute()
        {
            //playerBridge.Player.LightOn();
            Player.Instance.LightOn();
        }
    }
}