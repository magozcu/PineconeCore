using PineconeGames.Core.Patterns;
using System;

namespace PineconeGames.Core.Threads
{
    #region Event Handlers

    public delegate void ExecuteOnMainThreadEventHandler(Action action);

    #endregion

    public class PineconeThreadManager : Singleton<PineconeThreadManager>
    {
        #region Events

        protected ExecuteOnMainThreadEventHandler _onExecuteOnMainThread;

        #endregion

        #region Public Functions

        public void BindOnEvents(ExecuteOnMainThreadEventHandler onExecuteOnMainThread)
        {
            _onExecuteOnMainThread += onExecuteOnMainThread;
        }

        public void UnbindFromEvents(ExecuteOnMainThreadEventHandler onExecuteOnMainThread)
        {
            _onExecuteOnMainThread -= onExecuteOnMainThread;
        }

        public void ExecuteOnMainThread(Action action)
        {
            _onExecuteOnMainThread?.Invoke(action);
        }

        #endregion
    }
}