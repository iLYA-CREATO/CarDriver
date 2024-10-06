using Unity.VisualScripting;
using UnityEngine;
using YG;
using joystikController;
public class MoveCharacter : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravityValue = -5;

    float moveX;
    float moveY;
    float moveZ;
    Vector3 velocity;

    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private InputGame inputGame;

    private void OnEnable()
    {
        if (inputGame.Platfotrm == "mobile")
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    
    private void Awake()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    private void Update()
    {
        if(inputGame.Platfotrm == "desktop")
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }
        else if(inputGame.Platfotrm == "mobile")
        {
            moveX = joystick.Horizontal;
            moveZ = joystick.Vertical;
        }
        
        if (transform.position.y > 1.1f)
        {
            moveY = gravityValue;
        }

        MovePlayer(moveX, moveY, moveZ);

        velocity.y += gravityValue * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void MovePlayer(float moveX, float moveY, float moveZ)
    {
       
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

       
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }
}
