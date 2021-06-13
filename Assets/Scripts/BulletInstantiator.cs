using System.Collections;
using UnityEngine;

public class BulletInstantiator : MonoBehaviour
{
    [Header ("Properties for instantiating bullets")]
    private GameObject[] Enemies;
    public GameObject ParticleShooting;
    public GameObject InstantiatorSpot;
    public GameObject Bullet;

    public Animator GunMover;

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
            //search for the object tagged "enemy"
            var distance = transform.position - enemy.transform.position;
            if (distance.magnitude < 100)
            {
                numberOfEnemies++;
            }
        }
        if(numberOfEnemies > 0)
        {
            //if enemies are closer enough gun starts shooting

            yield return new WaitForSeconds(2f);
            ParticleShooting.SetActive(true);
            ShootingBullets();
            GunMover.enabled = true;
        }
        if (numberOfEnemies <= 0)
        {
            //if there is no enemies gun dont shot
            ParticleShooting.SetActive(false);
            GunMover.enabled = false;
        }
    }

    private void ShootingBullets()
    {
        Instantiate(Bullet, InstantiatorSpot.transform.position, InstantiatorSpot.transform.rotation);
    }
}
