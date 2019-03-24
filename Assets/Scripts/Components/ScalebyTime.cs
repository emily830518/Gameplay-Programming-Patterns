using UnityEngine;

public class ScalebyTime : MonoBehaviour
{
    public float scalestep = 0.1f;
    int change = 1;
    Vector3 originalscale;

    private void Start()
    {
        originalscale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        originalscale.x += change * scalestep;
        originalscale.y += change * scalestep;
        originalscale.z += change * scalestep;

        if (originalscale.x >= 1.5f && originalscale.x <=8.0f && originalscale.y >= 1.5f && originalscale.y <= 8.0f && originalscale.z >= 1.5f && originalscale.z <= 8.0f)
        {
            this.transform.localScale = originalscale;
        }
        else
        {
            change = (-1) * change;
        }
    }
}
