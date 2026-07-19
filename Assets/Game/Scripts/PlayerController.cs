using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Vector2 mouseScreenPosition;
    private Vector2 mouseWorldPosition;
    private Vector2 aimDirection;

    [Header("AimSettings")]
    [SerializeField] private Transform attackPivot;
    [SerializeField] private Transform visual;
    [SerializeField] private float aimDeadZone = 0.25f;

    [Space(10)]

    [Header("Movement")]
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
        mouseScreenPosition = inputActions.Player.Aim.ReadValue<Vector2>(); 
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        aimDirection = mouseWorldPosition - (Vector2)transform.position; 

        if (aimDirection.sqrMagnitude > aimDeadZone * aimDeadZone)
        {
            aimDirection = aimDirection.normalized;
            attackPivot.right = aimDirection;
        }

        // AttackInput

        if (inputActions.Player.Attack.WasPressedThisFrame())
        {
            //
        }



    }

    private void FixedUpdate()
    {
        rb.linearVelocity = moveInput * playerMoveSpeed;
    }
}
