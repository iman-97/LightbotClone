using Commands;

namespace UI.Buttons
{
    public class LightCommandButton : CommandButton
    {
        private void Start() => command = new LightCommand();
    }
}