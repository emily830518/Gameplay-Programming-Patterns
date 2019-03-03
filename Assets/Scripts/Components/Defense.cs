using UnityEngine;

public class Defense : MonoBehaviour
{
    Rigidbody shield;
    public bool isOn = false;
    Rigidbody shieldclone;
    // Start is called before the first frame update
    void Start()
    {
        shield = Resources.Load<Rigidbody>("Shield");
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.X))
        {
            shieldclone=(Rigidbody)Instantiate(shield, transform.position, transform.rotation);
            isOn = true;
            shieldclone.transform.position = Utility.GetCharpos();
        }
        if (isOn)
        {
            shieldclone.transform.position = Utility.GetCharpos();
            if (Input.GetKeyUp(KeyCode.X))
            {
                isOn = false;
                Destroy(shieldclone.gameObject);
            }
        }
    }
}
