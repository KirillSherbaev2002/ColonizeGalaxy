using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Mover : MonoBehaviour
{
    public Slider EnginePower;
    public GameObject[] Stoppers;
    public GameObject[] MainFire;

    public GameObject Ship;
    public GameObject Camera;
    [SerializeField] float camZPos;
    [SerializeField] float camYPos;
    [SerializeField] float camZPosSmooth;
    [SerializeField] float camYPosSmooth;

    public TMP_Text Speed;
    public Animator ShipAnim;

    public void Start()
    {
        OnSliderValueChanged();
        EnginePower.value = 0.25f;
        camZPosSmooth = 7f;
        camYPosSmooth = 4.01f;
    }

    public void OnSliderValueChanged()
    {
        stopAllFlames();
        SetEnginesStoppers();
        SetMainEngines();
    }

    private void stopAllFlames()
    {
        GameObject[] Flames = GameObject.FindGameObjectsWithTag("StarshipFlame");
        foreach (GameObject flame in Flames)
        {
            flame.SetActive(false);
        }
    }

    private void Update()
    {
        #region AddForceAndCamPositionsControllers
        if (EnginePower.value <= 0.24f)
        {
            Ship.GetComponent<Rigidbody>().AddForce(transform.forward * (-(EnginePower.value * 1.56f) - 0.26f) * 10);
            camZPos = 5.5f;
            camYPos = 4.01f;
        }
        if (EnginePower.value > 0.28f)
        {
            Ship.GetComponent<Rigidbody>().AddForce(transform.forward * ((EnginePower.value * 1.56f) - 0.26f) * 1);
            camZPos = 7.01f;
            camYPos = 4.01f - (EnginePower.value * 1.56f) - 0.26f;
        }
        if (!(EnginePower.value > 0.28f) && !(EnginePower.value < 0.24f))
        {
            camZPos = 6f;
            camYPos = 3.01f;
        }
        #endregion

        CamToShip();

        if(Ship.GetComponent<Rigidbody>().velocity.z < 0)
        {
            Speed.text = ("-" + (Ship.GetComponent<Rigidbody>().velocity.magnitude * 100).ToString("F0") + "KM/H");
        }
        else
        {
            Speed.text = (Ship.GetComponent<Rigidbody>().velocity.magnitude * 100).ToString("F0") + "KM/H";
        }

        ShipAnim.speed = (EnginePower.value-0.24f) * 3f;


    }

    private void CamToShip()
    {
        #region SmoothCameraTransitionValues
        if (camYPosSmooth < camYPos - 0.1f)
        {
            camYPosSmooth += 0.3f * Time.deltaTime;
        }
        else if (camYPosSmooth > camYPos + 0.1f)
        {
            camYPosSmooth -= 0.3f * Time.deltaTime;
        }
        if (camZPosSmooth < camZPos - 0.1f)
        {
            camZPosSmooth += 0.3f * Time.deltaTime;
        }
        else if (camZPosSmooth > camZPos + 0.1f)
        {
            camZPosSmooth -= 0.3f * Time.deltaTime;
        }
        #endregion
        Camera.transform.position = new Vector3(Ship.transform.position.x, Ship.transform.position.y + camYPosSmooth, Ship.transform.position.z - camZPosSmooth);
    }

    #region EngineControllers
    private void SetEnginesStoppers()
    {
        if (EnginePower.value <= 0.24f)
        {
            //= 0.265f - EnginePower.value;
            foreach (GameObject stop in Stoppers)
            {
                stop.GetComponent<ParticleSystem>().startLifetime = 5 * (0.26f - EnginePower.value);
                stop.SetActive(true);
            }
        }
    }

    private void SetMainEngines()
    {
        if (EnginePower.value > 0.28f)
        {
            foreach (GameObject fire in MainFire)
            {
                fire.GetComponent<ParticleSystem>().startLifetime = (EnginePower.value * 1.56f) - 0.26f;
                fire.SetActive(true);
            }
            Ship.GetComponent<Rigidbody>().AddForce(transform.forward * ((EnginePower.value * 1.56f) - 0.26f) * 100);
        }
    }
    #endregion
}
