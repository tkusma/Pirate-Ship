using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    [SerializeField] GameObject player;
    [SerializeField] TMP_Text scoreView;
    [SerializeField] GameObject endGame;

    private float gameTime;
    private bool gameOver;
    private int score = 0;
   
    void Start()
    {
        if (!manager)
            manager = this;
        Time.timeScale = 1;
        gameTime = PlayerPrefs.GetFloat("timeGame", 120);
        score = 0;
        gameOver = false;
    }

    void Update()
    {
        gameTime -= Time.deltaTime;
        if (!player || gameTime<=0)
        {
            Time.timeScale = 0;
            gameOver = true;
            endGame.SetActive(true);
        }
    }

    public void RefreshScore()
    {
        score += 1;
        scoreView.text = score.ToString("000");
    }

    #region Properties

    public GameObject Player
    {
        get
        {
            return player;
        }
    }

    public float GameTime
    {
        get
        {
            return gameTime;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    public bool GameOver
    {
        get
        {
            return gameOver;
        }
    }
    #endregion
}
