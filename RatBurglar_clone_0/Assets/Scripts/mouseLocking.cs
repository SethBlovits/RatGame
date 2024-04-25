using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLocking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
