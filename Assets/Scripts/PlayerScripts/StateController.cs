using Events;
using PlayerScripts.States;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
    [RequireComponent(typeof(Player))]
    public class StateController : MonoBehaviour
    {
        // References to other important components
        private State currentState;
        private Player player;
        // States are public so that one state can reference another
        [HideInInspector] public readonly State idleState = new IdleState();
        [HideInInspector] public readonly State movementState = new MovementState(); // Start is called once before the first execution of Update after the MonoBehaviour is created
        public readonly State deathState = new DeathState();

        private void Awake()
        {
            player = GetComponent<Player>();
        }

        private void Start()
        {
            ChangeState(idleState);
            GameEventManager.Instance.inputEvents.OnMovePressed += MovePressed;
        }

        // Update is called once per frame
        private void Update()
        {
            // Run the state's OnUpdate method every frame
            currentState?.OnStateUpdate();
        
            DecreaseFireDelay();
        }

        public void ChangeState(State newState)
        {
            currentState?.OnStateExit();
            currentState = newState;
            currentState.OnStateEnter(this, player);
        }

        // This method lets the idle state know when to switch to the movement state
        private void MovePressed(InputAction.CallbackContext direction)
        {
            player.MovementDirection = direction.ReadValue<Vector2>();
        }

        private void DecreaseFireDelay()
        {
            player.FireDelayBuffer -= Time.deltaTime * 10;
        }
    }
}
