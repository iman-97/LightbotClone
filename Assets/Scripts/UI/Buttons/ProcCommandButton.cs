using Commands;
using UnityEngine;

namespace UI.Buttons
{
    public class ProcCommandButton : CommandButton
    {
        [SerializeField]
        private byte _procNumber;

        private void Start() => command = new ProcedureCommand(_procNumber);
    }
}