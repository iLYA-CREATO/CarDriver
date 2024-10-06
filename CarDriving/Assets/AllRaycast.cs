using System;
using Unity.VisualScripting;
using UnityEngine;

public class AllRaycast : MonoBehaviour
{
    public static event Action<RaycastHit, bool> OnRaycastHitCar;
    public static event Action<bool> OnRaycastHitNoCar;

    public GameObject ImageAction;// Картинка с действием
    public Camera cameraMain;

    public bool sitCar;

    private void OnEnable()
    {
        SitCar.OnChangeSitCar += ChanchSitCar;
    }

    private void OnDisable()
    {
        SitCar.OnChangeSitCar -= ChanchSitCar;
    }

    private void ChanchSitCar(bool sitCar)
    {
        this.sitCar = sitCar;
    }
    private void Update()
    {
        if (sitCar == true)
        {
            ImageAction.SetActive(false);
        }
        else if(sitCar == false)
        {
            Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Выполняем raycast
            if (Physics.Raycast(ray, out hit, 2))
            {
                if (hit.collider.tag == "Vehicle")
                {
                    ImageAction.SetActive(true);
                    OnRaycastHitCar?.Invoke(hit, true);
                }
            }
            else
            {
                ImageAction.SetActive(false);
                OnRaycastHitNoCar?.Invoke(false);
            }
        }
        //DrawRaycast();
        // Создаем луч из камеры в направлении взгляда
       
    }

/*    void DrawRaycast()
    {
        Vector3 origin = cameraMain.transform.position;
        Vector3 direction = cameraMain.transform.forward;

        float distance = 10f;

        Debug.DrawRay(origin, direction * distance, Color.red);
    }*/
}
