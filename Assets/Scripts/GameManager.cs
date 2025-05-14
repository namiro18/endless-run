using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float score = 0f;
    public bool isGameOver = false;

    public TextMeshProUGUI scoreText;

    public GameObject gameOverPanel;


    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime;
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void GameOver()
{
    isGameOver = true;
    Debug.Log("Game Over! Final Score: " + Mathf.FloorToInt(score));

    Time.timeScale = 0f; 

    gameOverPanel.SetActive(true);

}

    public void RestartGame()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}


}
