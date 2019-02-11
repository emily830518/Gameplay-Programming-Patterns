using UnityEngine;

public class ControlledByKeyboard : MonoBehaviour
{
    public float step = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = this.transform.position;
        if (Input.GetKey(KeyCode.RightArrow))
            newPos.x += step;
        if (Input.GetKey(KeyCode.LeftArrow))
            newPos.x -= step;
        if (Input.GetKey(KeyCode.UpArrow))
            newPos.z += step;
        if (Input.GetKey(KeyCode.DownArrow))
            newPos.z -= step;
        if (Mathf.Abs(newPos.x) < 10f && Mathf.Abs(newPos.z) < 10f)
            this.transform.position = newPos;
    }
}
