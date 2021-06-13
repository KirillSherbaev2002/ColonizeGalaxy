using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Mover : MonoBehaviour
{
    public Slider EnginePower;

    [Header("Fires of engines")]

    public GameObject[] Stoppers;
    public GameObject[] MainFire;

    public GameObject[] DownBack;
    public GameObject[] UpBack;

    public GameObject[] ToLeft;
    public GameObject[] ToRight;

    [Header("Rotation controllers and setting")]

    public GameObject Ship;

    public TMP_Text Speed;

    public Animator ShipRotationPositive;

    [SerializeField] private float camToStarshipRotationX;

    public GameObject Explosion;

    public ParticleSystemRenderer SpeedMarkers;
    [SerializeField] private float speedOfOneHunderedPercent;

    [Header("Main Engines")]
    public ParticleSystem[] MainEngines;
    [SerializeField] private float startSliderValue;

    public void Start()
    {
        OnSliderValueChanged();
        EnginePower.value = startSliderValue;
    }

    public void OnSliderValueChanged()
    {
        stopAllFlames();
        SetEnginesStoppers();
        SetMainEngines();
    }

    private void Update()
    {
        #region MoveSpaceShip
        if (EnginePower.value <= 0.24f)
        {
            GetComponent<Rigidbody>().AddForce(-transform.up * (-(EnginePower.value * 1.56f) - 0.26f) * 30);
        }
        if (EnginePower.value > 0.28f)
        {
            GetComponent<Rigidbody>().AddForce(-transform.up * ((EnginePower.value * 1.56f) - 0.26f) * 10);
        }
        #endregion

        Speed.text = (Ship.GetComponent<Rigidbody>().velocity.magnitude * 100).ToString("N0") + "KM/M";

        ShipRotationPositive.speed = (EnginePower.value - 0.24f) * 3f;

        CheckSpeed();
    }

    #region EngineControllers
    private void SetEnginesStoppers()
    {
        if (EnginePower.value <= 0.24f)
        {
            foreach (GameObject stop in Stoppers)
            {
                stop.GetComponent<ParticleSystem>().startLifetime = 5 * (0.26f - EnginePower.value);
                stop.SetActive(true);
            }
        }
    }

    #region SetActivityOfEngines

    public void stopAllFlames()
    {
        GameObject[] Flames = GameObject.FindGameObjectsWithTag("StarshipFlame");
        foreach (GameObject flame in Flames)
        {
            flame.SetActive(false);
        }
    }
    public void SetMainEngines()
    {
        if (EnginePower.value > 0.28f)
        {
            foreach (GameObject fire in MainFire)
            {
                fire.GetComponent<ParticleSystem>().startLifetime = (EnginePower.value * 1.56f) - 0.26f;
                fire.SetActive(true);
            }
        }
    }
    public void SetDownBackEngines()
    {
        stopAllFlames();
        foreach (GameObject fire in DownBack)
        {
            fire.SetActive(true);
        }
    }

    public void SetUpBackEngines()
    {
        stopAllFlames();
        foreach (GameObject fire in UpBack)
        {
            fire.SetActive(true);
        }
    }

    public void SetToLeftEngines()
    {
        stopAllFlames();
        foreach (GameObject fire in ToLeft)
        {
            fire.SetActive(true);
        }
    }
    public void SetToRightEngines()
    {
        stopAllFlames();
        foreach (GameObject fire in ToRight)
        {
            fire.SetActive(true);
        }
    }

    public void SetShipToNoRotation()
    {
        Ship.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        Ship.transform.rotation = Quaternion.Euler(-90, 0, 0);
        StartCoroutine(SetFlameToCorrectRotation());
    }
    #endregion
    #endregion

    public IEnumerator SetFlameToCorrectRotation()
    {
        foreach (GameObject fire in ToRight)
        {
            fire.SetActive(true);
            fire.transform.rotation = Quaternion.identity;
            print(fire.transform.rotation);
        }
        foreach (GameObject fire in ToLeft)
        {
            fire.SetActive(true);
            fire.transform.rotation = Quaternion.identity;
            print(fire.transform.rotation);
        }
        foreach (GameObject fire in UpBack)
        {
            fire.SetActive(true);
            fire.transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        foreach (GameObject fire in DownBack)
        {
            fire.SetActive(true);
            fire.transform.rotation = Quaternion.Euler(-90, 0, 0);
        }
        yield return new WaitForSeconds(0.5f);
        stopAllFlames();
    }

    private void CheckSpeed()
    {
        SpeedMarkers.lengthScale = GetComponent<Rigidbody>().velocity.magnitude * 20 / speedOfOneHunderedPercent;

        if (SpeedMarkers.lengthScale > 20)
        {
            SpeedMarkers.lengthScale = 20;
        }
    }

    public void SetEnginesToCorrectRotation()
    {
        foreach(ParticleSystem engines in MainEngines)
        {
            engines.startRotation3D = new Vector3(transform.rotation.x-90, 0, 0);
        }
    }
}
