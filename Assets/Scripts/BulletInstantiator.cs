using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiator : MonoBehaviour
{
    private GameObject[] Enemies;
    public GameObject Shooting;
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
            print(numberOfEnemies);
        }
        if(numberOfEnemies > 0)
        {
            Shooting.SetActive(true);
            yield return new WaitForSeconds(2f);
            ShootingBullets();
        }
        if (numberOfEnemies <= 0)
        {
            Shooting.SetActive(false);
        }
    }

    private void ShootingBullets()
    {
        Instantiate(Bullet, transform.position, transform.rotation);
    }
}
