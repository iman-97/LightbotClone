using Commands;

namespace UI.Buttons
{
    public class TurnLeftCommandButton : CommandButton
    {
        private void Start() => command = new TurnLeftCommand();
    }
}