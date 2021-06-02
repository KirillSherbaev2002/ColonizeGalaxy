using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header ("Controllers of bullets")]

    private Mover mover;
    public float Speed;
    private float timeSumm;

    void Update()
    {
        mover = FindObjectOfType<Mover>();
        GetComponent<Rigidbody>().AddForce(transform.forward* (Speed + mover.GetComponent<Rigidbody>().velocity.magnitude));
        print(mover.GetComponent<Rigidbody>().velocity.magnitude);
        Shoot();
        DeathAfter();
    }

    void Shoot()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
    }

    private void DeathAfter()
    {
        if(timeSumm <= 100)
        {
            timeSumm++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
