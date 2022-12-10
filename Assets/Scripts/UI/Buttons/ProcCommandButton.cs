using Commands;

namespace UI.Buttons
{
    public class ProcCommandButton : CommandButton
    {
        private void Start() => command = new ProcedureCommand();
    }
}