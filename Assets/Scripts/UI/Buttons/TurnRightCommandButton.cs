using Commands;

namespace UI.Buttons
{
    public class TurnRightCommandButton : CommandButton
    {
        private void Start() => command = new TurnRightCommand();
    }
}