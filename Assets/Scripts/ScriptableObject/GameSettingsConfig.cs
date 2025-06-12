using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig")]
public class GameSettingsConfig : ScriptableObject
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 1500f;
    public int gravityScale = 10;

    [Header("Dash")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.15f;

    [Header("Health")]
    public int maxHealth = 10;

    [Header("Attacks")]
    // In this prototype all attacks deal equal damage but this can easily be modified
    public int punchDamage = 1;
    public int kickDamage = 1;
    public int slashDamage = 1;

    public float punchDuration = 0.2f;
    public float kickDuration = 0.3f;
    public float slashDuration = 0.4f;

    public float horizontalKnockback = 7f;
    public float verticalKnockback = 5f;
}
