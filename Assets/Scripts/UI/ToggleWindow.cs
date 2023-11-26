using UnityEngine;

public class ToggleWindow : MonoBehaviour
{
    [SerializeField] GameObject windowA;
    [SerializeField] GameObject windowB;

    public void SwitchWindow()
    {
        windowA.SetActive(!windowA.activeSelf);
        windowB.SetActive(!windowB.activeSelf);
    }
}
