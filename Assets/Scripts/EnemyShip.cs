using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float hp;
    public GameObject brokenShip;
    public GameObject explosion;

    private void DestroyItself()
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        Instantiate(explosion, transform.position, transform.rotation);
        print("DestroyItself");
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MyBullet")
        {
            DestroyItself();
        }
    }
}
