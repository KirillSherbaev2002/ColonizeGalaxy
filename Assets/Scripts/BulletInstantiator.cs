using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiator : MonoBehaviour
{
    private GameObject[] Enemies;
    public GameObject ParticleShooting;
    public GameObject InstantiatorSpot;
    public GameObject Bullet;
    private void Update()
    {
        StartCoroutine(SearchForTheEnemies());
    }

    IEnumerator SearchForTheEnemies()
    {
        Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int numberOfEnemies = 0;
        foreach(GameObject enemy in Enemies)
        {
            var distance = transform.position - enemy.transform.position;
            if (distance.magnitude < 100)
            {
                numberOfEnemies++;
            }
        }
        if(numberOfEnemies > 0)
        {
            ParticleShooting.SetActive(true);

            yield return new WaitForSeconds(2f);
            ShootingBullets();
        }
        if (numberOfEnemies <= 0)
        {
            ParticleShooting.SetActive(false);
        }
    }

    private void ShootingBullets()
    {
        Instantiate(Bullet, InstantiatorSpot.transform.position, InstantiatorSpot.transform.rotation);
    }
}
