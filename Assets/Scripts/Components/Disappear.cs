using System.Collections;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public float duration = 1;
    public bool readyToBeDestroyed = false;

    private IEnumerator Shrink()
    {
        while (duration >= 0)
        {
            duration -= Time.deltaTime;
            transform.localScale = transform.localScale * 0.9f;
            yield return null;
        }
        readyToBeDestroyed = true;
        //Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shrink());
    }
}
