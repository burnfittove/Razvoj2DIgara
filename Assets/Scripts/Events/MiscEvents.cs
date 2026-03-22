using System;

namespace Events
{
    public class MiscEvents
    {
        public event Action OnPlayerDied;
        public virtual void PlayerDied()
        {
            OnPlayerDied?.Invoke();
        }
    }
}