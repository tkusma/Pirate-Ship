using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnTime : MonoBehaviour
{
    [SerializeField] Slider timeSlider;
    [SerializeField] TMP_Text value;

    void Start()
    {
        timeSlider.value = PlayerPrefs.GetFloat("spawnTime", 5);
        RefreshValue();
    }

    public void RefreshValue()
    {
        value.text = timeSlider.value.ToString();
    }

    public void SaveSpawnTime()
    {
        PlayerPrefs.SetFloat("spawnTime", timeSlider.value);
    }
    
}
