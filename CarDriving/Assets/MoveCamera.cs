using UnityEngine;
using YG;
using joystikController;

public class MoveCamera : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody; 

    private float xRotation = 0f;
    [SerializeField] private string Platfotrm;

    [SerializeField] private FloatingJoystick joystick;
    void Start()
    {
        Platfotrm = YandexGame.EnvironmentData.deviceType;
        //Platfotrm = "mobile";
    }

    
    void Update()
    {
        float mouseX = 0f;
        float mouseY = 0f;
        if (Platfotrm == "desktop")
        {
             mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
             mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        }
        else if(Platfotrm == "mobile")
        {
             mouseX = joystick.Horizontal * mouseSensitivity * Time.deltaTime;
             mouseY = joystick.Vertical * mouseSensitivity * Time.deltaTime;
        }
        _MoveCamera(mouseX, mouseY);
    }

    public void _MoveCamera(float _mouseX, float _mouseY)
    {
       
        xRotation -= _mouseY; 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
       
        playerBody.Rotate(Vector3.up * _mouseX);
    }
}
