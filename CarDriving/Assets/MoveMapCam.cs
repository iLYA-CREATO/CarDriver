using UnityEngine;

public class MoveMapCam : MonoBehaviour
{
    public GameObject playerObject;
    void Update()
    {
        transform.position = new Vector3(playerObject.transform.position.x, 20f, playerObject.transform.position.z);
    }
}
