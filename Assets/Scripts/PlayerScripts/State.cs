namespace PlayerScripts
{
    public abstract class State
    {
        protected StateController sc;
        protected Player p;

        // Call in StateController, do not override
        public void OnStateEnter(StateController stateController, Player player)
        {
            sc = stateController;
            p = player;
            OnEnter();
        }
        // Override in new states
        protected virtual void OnEnter() { }


        // Call in StateController, do not override
        public void OnStateExit()
        {
            OnExit();
        }
        // Override in new states
        protected virtual void OnExit() { }


        // Call in StateController, do not override
        public void OnStateUpdate()
        {
            p.DecreaseInvincibilityDuration();
            OnUpdate();
        }
        // Override in new states
        protected virtual void OnUpdate() { }
    }
}
