using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMouse : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private void Update()
    {
        if(Input.GetKey(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
