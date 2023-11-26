using UnityEngine;
using TMPro;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject gameOverTitle;
    [SerializeField] GameObject endTitle;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text maxScore;

    void OnEnable()
    {
        score.text = GameManager.manager.Score.ToString("000");
        if (GameManager.manager.Score > PlayerPrefs.GetInt("maxScore", 0))
            PlayerPrefs.SetInt("maxScore", GameManager.manager.Score);
        maxScore.text = PlayerPrefs.GetInt("maxScore", 0).ToString("000");
        gameOverTitle.SetActive(GameManager.manager.GameOver);
        endTitle.SetActive(!gameOverTitle.activeSelf);
    }

}
