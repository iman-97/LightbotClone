namespace Commands
{
    public class LightCommand : Command
    {
        public override void Execute() => Player.Instance.LightOn();
    }
}