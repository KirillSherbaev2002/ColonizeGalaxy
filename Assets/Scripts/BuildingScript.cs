using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    [Header("Building")]
    public GameObject RocketExplosion;
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rocket")
        {
            DestroyItself();
            print("RocketStriked");
        }
    }

    private void DestroyItself()
    {
        Destroy(gameObject);
        Instantiate(RocketExplosion, transform.position, transform.rotation);
        print("DestroyItself");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rocket")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            DestroyItself();
        }
    }
}
