using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float hp;
    public GameObject brokenShip;
    public GameObject explosion;

    private void DestroyItself()
    {
        gameObject.SetActive(false);
        Instantiate(brokenShip, transform.position, transform.rotation);
        Instantiate(explosion, transform.position, transform.rotation);
        print("DestroyItself");
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter");
        DestroyItself();
    }
    void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
        DestroyItself();
    }

    void OnParticleCollision(GameObject test)
    {
        print("OnParticleCollision");
        DestroyItself();
    }
}
