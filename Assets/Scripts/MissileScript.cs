using UnityEngine;
using UnityEngine.UI;

public class MissileScript : MonoBehaviour
{
    [Header ("Rocket parameters")]
    [SerializeField] private Transform StackedPos;

    public GameObject RocketLaunched;
    public GameObject RocketLaunchIcon;
    public void FireRocket()
    {
        //RocketLaunch and destroying of the stacked v
        Instantiate(RocketLaunched, transform.position, transform.rotation);
        Destroy(RocketLaunchIcon);

        Destroy(gameObject);
    }
}
