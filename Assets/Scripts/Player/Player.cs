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
    public GameObject slashHitbox;

    public Player enemy;

    public Player(InputConfig inputConfig, Rigidbody2D rb, Transform transform, GameObject punch, GameObject kick, GameObject slash, MonoBehaviour coroutineStarter)
    {
        this.rb = rb;
        this.transform = transform;
        this.punchHitbox = punch;
        this.kickHitbox = kick;
        this.slashHitbox = slash;

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
}
