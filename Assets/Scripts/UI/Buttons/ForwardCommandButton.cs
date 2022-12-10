using Commands;

namespace UI.Buttons
{
    public class ForwardCommandButton : CommandButton
    {
        private void Start() => command = new MoveForwardCommand();
    }
}