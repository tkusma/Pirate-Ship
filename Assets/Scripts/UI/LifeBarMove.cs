using UnityEngine;

public class LifeBarMove : MonoBehaviour
{
    [SerializeField] Transform ship;
    void Update()
    {
        transform.position = ship.transform.position;
    }
}
