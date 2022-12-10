using Commands;

namespace UI.Buttons
{
    public class JumpCommandButton : CommandButton
    {
        private void Start() => command = new JumpCommand();
    }
}