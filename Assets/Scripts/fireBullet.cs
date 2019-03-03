using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour {
    Rigidbody bulletRigidbody;
    Vector3 shootDir = new Vector3(0, 0, 1.0f);
    void Start()
    {
        bulletRigidbody = Resources.Load<Rigidbody>("playerBullet");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && !GetComponent<Defense>().isOn)
        {
            Rigidbody bulletClone = (Rigidbody)Instantiate(bulletRigidbody, transform.position + shootDir, transform.rotation);
            bulletClone.AddForce(shootDir * 500.0f);
        }
    }
}
