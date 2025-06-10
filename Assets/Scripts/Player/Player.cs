using UnityEngine;

public class Player : Main
{
    // Movement variables
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpForce;
    public bool isGrounded { get; private set; } = true;

    // Attack variables
    public GameObject punchHitbox;
    public GameObject kickHitbox;

    private MovementStateManager movementStateManager;
    private AttackStateManager attackStateManager;
    private InputManager inputManager;

    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        movementStateManager = new MovementStateManager(transform, moveSpeed, jumpForce, this);
        movementStateManager.Start();
        attackStateManager = new AttackStateManager(this);
        attackStateManager.Start();
        inputManager = new InputManager();
    }

    private void Update()
    {
        movementStateManager.Update();
        attackStateManager.Update();
        inputManager.ManageMovementInputs(movementStateManager);
        inputManager.ManageAttackInputs(attackStateManager);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            movementStateManager.SetGrounded(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            movementStateManager.SetGrounded(false);
        }
    }
}
