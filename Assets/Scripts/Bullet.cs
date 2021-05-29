using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    private float timeSumm;
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward* Speed);
        Shoot();

    }

    void Shoot()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
    }

    private void DeathAfter()
    {
        if(timeSumm <= 200)
        {
            timeSumm++;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
