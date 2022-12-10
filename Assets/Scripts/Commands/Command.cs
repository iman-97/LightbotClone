using UnityEngine;

namespace Commands
{
    public abstract class Command
    {
        [SerializeField]
        protected PlayerBridgeSO playerBridge;

        public abstract void Execute();

    }
}
