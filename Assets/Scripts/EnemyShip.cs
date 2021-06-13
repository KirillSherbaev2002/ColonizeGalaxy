using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject brokenShip;
    public GameObject explosion;

    public GameObject RocketExplotion;

    [SerializeField] private float speed;

    [SerializeField] private bool NeedsToMove;

    private void DestroyItself()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
    void OnTriggerEnter(Collider other)
    {
        //On collision with bullet or rocket
        if(other.tag == "MyBullet")
        {
            DestroyItself();
        }
        if (other.tag == "Rocket")
        {
            DestroyItself();

            if (NeedsToMove == true)
            {
                Destroy(other.gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Rocket")
        {
            DestroyItself();
            print("OnCollisionEntered");

            if (NeedsToMove == true)
            {
                Destroy(collision.gameObject);
            }
        }
    }

    private void FixedUpdate()
    {
        if (NeedsToMove == true)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
