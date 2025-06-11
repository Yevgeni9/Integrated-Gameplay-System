using UnityEngine;

public class Player
{
    public Rigidbody2D rb;
    public MovementStateManager movementStateManager;
    private AttackStateManager attackStateManager;
    private InputManager inputManager;

    public Transform transform;
    public GameObject punchHitbox;
    public GameObject kickHitbox;

    public Player(InputConfig inputConfig, Rigidbody2D rb, Transform transform, GameObject punch, GameObject kick, MonoBehaviour coroutineStarter)
    {
        this.rb = rb;
        this.transform = transform;
        this.punchHitbox = punch;
        this.kickHitbox = kick;

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
    }

    public void SetGrounded(bool grounded)
    {
        movementStateManager.SetGrounded(grounded);
    }
}
