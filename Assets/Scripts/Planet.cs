using UnityEngine;

public class Planet : MonoBehaviour
{
    [Header("On Any Collision")]
    public GameObject Smoke;

    [Header("On Collision with Spaceship")]
    public GameObject Explosion;
    public GameObject Cam;

    public Vector3 RotationalCenterPlayerLastView;

    [SerializeField] private float distanceOfCamFromTheSerface;

    private void OnCollisionEnter(Collision collision)
    {
        //On collision with any object instantiate smoke
        Instantiate(Smoke, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

        if (collision.gameObject.CompareTag("Player"))
        {
            //After a collision of spaceship with planed the explosion and camera needs to be instantiated
            Instantiate(Explosion, collision.gameObject.transform.position, collision.gameObject.transform.rotation);

            //Instantiate camera and rotate it 180 degrees from the center of mass of the spaceship collided with planet
            Instantiate(Cam, collision.gameObject.transform.position,
                Quaternion.EulerAngles(
                    collision.gameObject.transform.rotation.x,
                    collision.gameObject.transform.rotation.y,
                    collision.gameObject.transform.rotation.z)
            );

            RotationalCenterPlayerLastView = new Vector3(collision.gameObject.transform.rotation.x, collision.gameObject.transform.rotation.y, collision.gameObject.transform.rotation.z);

            //And the ship needs to be destroyed
            Destroy(collision.gameObject);
        }
    }
}
