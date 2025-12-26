using Events;
using PlayerScripts.States;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerScripts
{
    [RequireComponent(typeof(Player))]
    public class StateController : MonoBehaviour
    {
        private State currentState;

        private Player player;
        [HideInInspector] public readonly IdleState IdleState = new IdleState();
        [HideInInspector] public readonly MovementState MovementState = new MovementState();// Start is called once before the first execution of Update after the MonoBehaviour is created

        private void Awake()
        {
            player = GetComponent<Player>();
        }

        private void Start()
        {
            ChangeState(IdleState);
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
