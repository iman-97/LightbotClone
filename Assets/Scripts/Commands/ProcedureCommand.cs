using Managers;

namespace Commands
{
    public class ProcedureCommand : Command
    {
        public override void Execute() => GameManager.Instance.RunProcCommands();
    }
}