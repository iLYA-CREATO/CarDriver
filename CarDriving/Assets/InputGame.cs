using UnityEngine;
using YG;
using joystikController;
using NWH.WheelController3D;
public class InputGame : MonoBehaviour
{
    public FloatingJoystick joystickHor;
    public FloatingJoystick joystickVer;

    public float hor;
    public float ver;

    public GameObject playerlInpute;
    public GameObject carlInpute;
    public string Platfotrm;

    public CarController carController;

    private void Awake()
    {
        Platfotrm = YandexGame.EnvironmentData.deviceType;
        //Platfotrm = "mobile";
        if (Platfotrm == "mobile")
            playerlInpute.SetActive(true);
        else
            playerlInpute.SetActive(false);
    }
    public void Update()
    {
        if (Platfotrm == "mobile")
        {
            hor = joystickHor.Horizontal;
            ver = joystickVer.Vertical;
            carController.Car(hor, ver, false);
        }
        else
        {
            hor = Input.GetAxis("Horizontal");
            ver = Input.GetAxis("Vertical");
            carController.Car(hor, ver, true);
        }
    }

    private void OnEnable()
    {
        SitCar.OnChangeSitCar += ChangeSitCar;
    }
    private void OnDisable()
    {
        SitCar.OnChangeSitCar -= ChangeSitCar;
    }

    private void ChangeSitCar(bool sitCar)
    {
        if (sitCar)
        {
            playerlInpute.SetActive(false);
            carlInpute.SetActive(true);

        }
        else
        {
            playerlInpute.SetActive(true);
            carlInpute.SetActive(false);

        }
    }
}
