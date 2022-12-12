using Managers;

namespace Commands
{
    public class ProcedureCommand : Command
    {
        private byte _procNumber;

        public ProcedureCommand(byte procNumber) => _procNumber = procNumber;

        public override void Execute() => GameManager.Instance.RunProcCommands(_procNumber);
    }
}