using NWH.WheelController3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    public GameObject respawnPoint;

    public Vector3 point;

    public GameObject player;
    private void Start()
    {
        point = respawnPoint.transform.position;
    }
    public void RespawnPlayer()
    {
        if(player.activeSelf == true)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = point;
            player.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            player.GetComponent<CharacterController>().enabled = true;
        }
        else
        {
            
            // Получаем родительский объект
            Transform parentTransform = player.transform.parent;
            Debug.Log("Родитель объекта: " + parentTransform.name);
            parentTransform.gameObject.SetActive(false);  
            parentTransform.transform.position = point;
            parentTransform.gameObject.SetActive(true);
            parentTransform.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }

    }
}
