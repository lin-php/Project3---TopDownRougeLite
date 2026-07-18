using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    [SerializeField] float playerMoveSpeed = 5f;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        rb = GetComponent<Rigidbody2D>();   
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
        moveInput = inputActions.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * playerMoveSpeed;
    }

}
