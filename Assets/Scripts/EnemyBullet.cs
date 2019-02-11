using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float existTime = 1.5f;

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, existTime);
    }
}
