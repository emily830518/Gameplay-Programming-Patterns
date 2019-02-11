using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent(typeof(ControlledByKeyboard));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
