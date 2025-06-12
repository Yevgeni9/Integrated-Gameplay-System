using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager
{
    private TextMeshProUGUI winnerText;
    private TextMeshProUGUI resetText;
    private GameObject startScreenPanel;
    private GameObject startScreenText;

    public bool GameStarted;
    public bool GameEnded;

    public GameManager(TextMeshProUGUI winnerText, TextMeshProUGUI resetText, GameObject startScreenPanel, GameObject startScreenText)
    {
        this.winnerText = winnerText;
        this.resetText = resetText;
        this.startScreenPanel = startScreenPanel;
        this.startScreenText = startScreenText;

        GameStarted = false;
        GameEnded = false;
    }

    public void StartGame()
    {
        GameStarted = true;
        GameEnded = false;
        startScreenPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void EndGame(Player winner)
    {
        if (GameEnded)
        {
            return;
        }

        GameEnded = true;
        winnerText.text = "Winner: " + winner.playerName;
        resetText.text = "Press Escape to reset";
        Time.timeScale = 0f;
    }

    public void ResetGame()
    {
        GameStarted = false;
        GameEnded = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
