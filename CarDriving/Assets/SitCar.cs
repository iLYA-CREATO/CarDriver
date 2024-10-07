using NWH.WheelController3D;
using System;
using System.Collections.Generic;
using UnityEngine;


public class SitCar : MonoBehaviour
{
    public static event Action<bool> OnChangeSitCar;

    public bool IsSitCar;
    [SerializeField] private bool IsRayCar;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerContent;

    [SerializeField] private List<DataCar> dataCar;
    [SerializeField] private string nameCarBufer;


    [SerializeField] private InputGame inputGame;

    private void OnEnable()
    {
        AllRaycast.OnRaycastHitCar += RayCar;
        AllRaycast.OnRaycastHitNoCar += RayCar;
    }

    private void OnDisable()
    {
        AllRaycast.OnRaycastHitCar -= RayCar;
        AllRaycast.OnRaycastHitNoCar -= RayCar;
    }

    private void Update()
    {
        if(IsRayCar == true || IsSitCar == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _SitCar();
            }
        }
    }

    private void RayCar(RaycastHit hit, bool isRay)
    {
        nameCarBufer = hit.collider.name;
        IsRayCar = isRay;
    }
    private void RayCar(bool isRay)
    {
        IsRayCar = isRay;
        nameCarBufer = "";
    }

    public void _SitCar()
    {
        for(int i = 0; i < dataCar.Count; i++)
        {
            if(dataCar[i].NameCar == nameCarBufer)
            {
                Debug.Log("Это та тачка");
                IsSitCar = !IsSitCar;
                OnChangeSitCar?.Invoke(IsSitCar);

                if (IsSitCar == true)
                {
                    inputGame.carController = dataCar[i].carController;
                    dataCar[i].carController.enabled = true;
                    dataCar[i].CameraModul.SetActive(true);
                    player.gameObject.transform.SetParent(dataCar[i].carModel.transform);
                    player.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    player.SetActive(false);
                }
                else
                {
                    inputGame.carController = null;
                    dataCar[i].carController.enabled = false;
                    dataCar[i].CameraModul.SetActive(false);
                    player.gameObject.transform.SetParent(playerContent.transform);
                    player.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                    player.SetActive(true);
                }
            }
        } 
    }
}

[Serializable]
public class DataCar
{
    public GameObject carModel;
    public CarController carController;
    public GameObject CameraModul;
    public string NameCar;
}
