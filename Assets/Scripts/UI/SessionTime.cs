using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SessionTime : MonoBehaviour
{
    [SerializeField] Slider timeSlider;
    [SerializeField] TMP_Text value;


    // Start is called before the first frame update
    void Start()
    {
        timeSlider.value = (PlayerPrefs.GetFloat("timeGame", 120)-60)/30;
        RefreshValue();
    }

    public void RefreshValue()
    {
        int min = 1 + (int)(timeSlider.value / 2);
        int sec = (int)timeSlider.value % 2 * 30;
        value.text = min.ToString("0") + ":" + sec.ToString("00");
    }

    public void SaveTime()
    {
        float gameTime = 60 + 30 * timeSlider.value;
        PlayerPrefs.SetFloat("timeGame", gameTime);
    }

}
