using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void HideGameObject()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(EndGameObject());
    }

   IEnumerator EndGameObject()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
