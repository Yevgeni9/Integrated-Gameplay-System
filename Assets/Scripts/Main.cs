using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    [Header("Player 1")]
    public Rigidbody2D player1Rb;
    public Collider2D player1Collider;
    public Transform player1Transform;
    public GameObject player1PunchHitbox;
    public GameObject player1KickHitbox;
    public GameObject player1SlashHitbox;
    public InputConfig player1InputConfig;
    
    [Header("Player 2")]
    public Rigidbody2D player2Rb;
    public Collider2D player2Collider;
    public Transform player2Transform;
    public GameObject player2PunchHitbox;
    public GameObject player2KickHitbox;
    public GameObject player2SlashHitbox;
    public InputConfig player2InputConfig;
    
    [Header("Healthbar")]
    private HealthSystem player1Health;
    private HealthBar player1HealthBar;
    private HealthSystem player2Health;
    private HealthBar player2HealthBar;
    [SerializeField] private GameObject p1HealthbarBlock;
    [SerializeField] private GameObject p2HealthbarBlock;
    [SerializeField] private Transform player1HealthContainer;
    [SerializeField] private Transform player2HealthContainer;

    [Header("Settings")]
    [SerializeField] private GameSettingsConfig gameConfig;
    [SerializeField] private LayerMask groundLayer;
    
    [Header("Game Flow")]
    private GameManager gameManager;
    [SerializeField] private GameObject startScreenPanel;
    [SerializeField] private GameObject startScreenText;
    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private TextMeshProUGUI resetText;

    private Player player1;
    private Player player2;

    void Start()
    {
        Time.timeScale = 0f;
        gameManager = new GameManager(winnerText, resetText, startScreenPanel, startScreenText);
        startScreenPanel.SetActive(true);

        // Health
        player1HealthBar = new HealthBar(player1HealthContainer, p1HealthbarBlock, gameConfig.maxHealth);
        player2HealthBar = new HealthBar(player2HealthContainer, p2HealthbarBlock, gameConfig.maxHealth);
        player1Health = new HealthSystem(gameConfig.maxHealth, player1HealthBar);
        player2Health = new HealthSystem(gameConfig.maxHealth, player2HealthBar);

        // Create players
        player1 = new Player(player1InputConfig, player1Rb, player1Transform, player1PunchHitbox, player1KickHitbox, player1SlashHitbox, player1Health, gameConfig, "player 1", this);
        player2 = new Player(player2InputConfig, player2Rb, player2Transform, player2PunchHitbox, player2KickHitbox, player2SlashHitbox, player2Health, gameConfig, "player 2", this);

        // For direction flipping
        player1.enemy = player2;
        player2.enemy = player1;

        // For collision detection
        player1.bodyCollider = player1Collider;
        player2.bodyCollider = player2Collider;

        player1Health.OnGameEnd += () => EndGame(player2);
        player2Health.OnGameEnd += () => EndGame(player1);
    }

    void Update()
    {
        player1.Update();
        player2.Update();

        player1.CheckIfGrounded(groundLayer);
        player2.CheckIfGrounded(groundLayer);

        if (!gameManager.GameStarted && Input.anyKeyDown)
        {
            gameManager.StartGame();
        }
            
        if (gameManager.GameEnded && Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.ResetGame();
        }
    }

    private void FixedUpdate()
    {
        CheckHit(player1, player2);
        CheckHit(player2, player1);
    }

    private void CheckHit(Player attacker, Player defender)
    {
        if (attacker.punchHitbox.activeSelf && attacker.punchHitbox.GetComponent<Collider2D>().IsTouching(defender.bodyCollider))
        {
            defender.TakeDamage(1);
            attacker.punchHitbox.SetActive(false);
        }

        if (attacker.kickHitbox.activeSelf && attacker.kickHitbox.GetComponent<Collider2D>().IsTouching(defender.bodyCollider))
        {
            defender.TakeDamage(1);
            attacker.kickHitbox.SetActive(false);
        }

        if (attacker.slashHitbox.activeSelf && attacker.slashHitbox.GetComponent<Collider2D>().IsTouching(defender.bodyCollider))
        {
            defender.TakeDamage(1);
            attacker.slashHitbox.SetActive(false);
        }
    }

    private void EndGame(Player winner)
    {
        gameManager.EndGame(winner);
    }
}
