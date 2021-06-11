using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [Header ("Rocket parameters")]
    [SerializeField] private Transform StackedPos;
    public GameObject RocketLaunched;
    public void FireRocket()
    {
        //RocketLaunch and destroying of the stacked v
        Instantiate(RocketLaunched, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
