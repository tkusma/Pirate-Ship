using UnityEngine;
using UnityEngine.EventSystems;


public class FirstButtonSelected : MonoBehaviour
{
    [SerializeField] EventSystem eventSystem;
    [SerializeField] GameObject firstSelected;

    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(firstSelected);
    }
}
