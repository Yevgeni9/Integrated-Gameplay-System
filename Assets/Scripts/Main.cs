using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private HealthSystem player1Health;
    private HealthBar player1HealthBar;

    [Header("Player 2")]
    public Rigidbody2D player2Rb;
    public Collider2D player2Collider;
    public Transform player2Transform;
    public GameObject player2PunchHitbox;
    public GameObject player2KickHitbox;
    public GameObject player2SlashHitbox;
    public InputConfig player2InputConfig;
    private HealthSystem player2Health;
    private HealthBar player2HealthBar;

    [Header("Healthbar")]
    public GameObject healthbarBlock;
    public Transform player1HealthContainer;
    public Transform player2HealthContainer;
    
    

    [Header("Settings")]
    public int maxHealth = 10;
    public LayerMask groundLayer;

    private Player player1;
    private Player player2;

    void Start()
    {
        // Create players
        player1 = new Player(player1InputConfig, player1Rb, player1Transform, player1PunchHitbox, player1KickHitbox, player1SlashHitbox, this);
        player2 = new Player(player2InputConfig, player2Rb, player2Transform, player2PunchHitbox, player2KickHitbox, player2SlashHitbox, this);

        // For direction flipping
        player1.enemy = player2;
        player2.enemy = player1;

        // Health
        player1Health = new HealthSystem(maxHealth);
        player2Health = new HealthSystem(maxHealth);
        player1HealthBar = new HealthBar(player1HealthContainer, healthbarBlock, maxHealth);
        player2HealthBar = new HealthBar(player2HealthContainer, healthbarBlock, maxHealth);
    }

    void Update()
    {
        player1.Update();
        player2.Update();

        UpdateGrounded(player1, player1Collider);
        UpdateGrounded(player2, player2Collider);
    }

    private void UpdateGrounded(Player player, Collider2D collider)
    {
        bool isGrounded = collider.IsTouchingLayers(groundLayer);
        player.movementStateManager.SetGrounded(isGrounded);
    }
}
