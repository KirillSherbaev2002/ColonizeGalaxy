﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Mover : MonoBehaviour
{
    public Slider EnginePower;

    public GameObject[] Stoppers;
    public GameObject[] MainFire;

    public GameObject[] DownBack;
    public GameObject[] UpBack;

    public GameObject[] ToLeft;
    public GameObject[] ToRight;

    public GameObject Ship;
    public GameObject Camera;

    public TMP_Text Speed;
    public Animator ShipAnim;

    [SerializeField] private float camToStarshipRotationX;

    public void Start()
    {
        OnSliderValueChanged();
        EnginePower.value = 0.25f;
    }

    public void OnSliderValueChanged()
    {
        stopAllFlames();
        SetEnginesStoppers();
        SetMainEngines();
    }

    private void Update()
    {

        Speed.text = (Ship.GetComponent<Rigidbody>().velocity.magnitude * 100).ToString("F0") + "KM/H";

        ShipAnim.speed = (EnginePower.value-0.24f) * 3f;
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
        SetFlameToCorrectRotation();
    }
    #endregion
    #endregion

    public IEnumerator SetFlameToCorrectRotation()
    {
        foreach (GameObject fire in ToRight)
        {
            fire.SetActive(true);
            fire.transform.rotation = Quaternion.Euler(-55f, -90f, 90f);
        }
        foreach (GameObject fire in ToLeft)
        {
            fire.SetActive(true);
            fire.transform.rotation = Quaternion.Euler(-55f, 90f, 90f);
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
        print("Done");
        yield return new WaitForSeconds(10);
        print("Done2");
        stopAllFlames();
    }
}