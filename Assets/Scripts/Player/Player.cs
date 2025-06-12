using UnityEngine;

public class Player
{
    public Rigidbody2D rb;
    public MovementStateManager movementStateManager;
    private AttackStateManager attackStateManager;
    public InputManager inputManager; // Public because DashState Needs it
    public Collider2D bodyCollider;

    public Transform transform;
    public GameObject punchHitbox;
    public GameObject kickHitbox;
    public GameObject slashHitbox;

    public Player enemy; // The opposing player

    public HealthSystem healthSystem;

    public float hitCooldown = 0.2f;
    public float hitTimer = 0f;

    public float kickCooldown = 0.2f;
    public float kickTimer = 0f;

    public float slashCooldown = 0.2f;
    public float slashTimer = 0f;

    public Player(InputConfig inputConfig, Rigidbody2D rb, Transform transform, GameObject punch, GameObject kick, GameObject slash, HealthSystem healthSystem, MonoBehaviour coroutineStarter)
    {
        this.rb = rb;
        this.transform = transform;
        this.punchHitbox = punch;
        this.kickHitbox = kick;
        this.slashHitbox = slash;
        this.healthSystem = healthSystem;

        movementStateManager = new MovementStateManager(transform, 5f, 1500f, this);
        attackStateManager = new AttackStateManager(this, coroutineStarter);
        inputManager = new InputManager(inputConfig);
    }

    public void Update()
    {
        movementStateManager.Update();
        attackStateManager.Update();
        inputManager.ManageMovementInputs(movementStateManager);
        inputManager.ManageAttackInputs(attackStateManager);
        FaceTarget(enemy);
        hitTimer += Time.deltaTime;
        kickTimer += Time.deltaTime;
        slashTimer += Time.deltaTime;
    }

    public void FaceTarget(Player otherPlayer)
    {
        if (movementStateManager.isGrounded && attackStateManager.currentState == attackStateManager.noAttackState)
        {
            float direction = otherPlayer.transform.position.x - this.transform.position.x;

            Vector3 localScale = transform.localScale;
            localScale.x = direction >= 0 ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
            transform.localScale = localScale;
        }
    }

    public void SetGrounded(bool grounded)
    {
        movementStateManager.SetGrounded(grounded);
    }

    public void TakeDamage(int amount)
    {
        healthSystem.TakeDamage(amount);
    }
}
