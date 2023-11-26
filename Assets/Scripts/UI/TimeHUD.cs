using UnityEngine;
using TMPro;

public class TimeHUD : MonoBehaviour
{
    private TMP_Text clock;
    
    void Start()
    {
        clock = GetComponent<TMP_Text>();
    }

    void Update()
    {
        int min = (int)(GameManager.manager.GameTime / 60);
        int sec = (int)GameManager.manager.GameTime - min * 60;
        clock.text = min.ToString("00") + (":") + sec.ToString("00");
    }
}
