using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Player))]
public class StateController : MonoBehaviour
{
    private State currentState;

    private Player player;
    [HideInInspector] public IdleState idleState = new IdleState();
    [HideInInspector] public MovementState movementState = new MovementState();// Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void Start()
    {
        ChangeState(idleState);
        GameEventManager.instance.inputEvents.OnMovePressed += MovePressed;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null) currentState.OnStateUpdate();
    }

    public void ChangeState(State newState)
    {
        if (currentState != null) currentState.OnStateExit();
        currentState = newState;
        currentState.OnStateEnter(this, player);
    }

    public void MovePressed(Vector2 direction)
    {
        player.MovementDirection = direction;
    }
}
