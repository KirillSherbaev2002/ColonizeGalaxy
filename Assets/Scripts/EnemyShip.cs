using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject brokenShip;
    public GameObject explosion;

    public GameObject RocketExplotion;

    private void DestroyItself()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MyBullet")
        {
            DestroyItself();
        }
        if (other.tag == "Rocket")
        {
            DestroyItself();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rocket")
        {
            DestroyItself();
            print("OnCollisionEntered");
        }
    }
}
