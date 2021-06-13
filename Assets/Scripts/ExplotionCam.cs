using UnityEngine;

public class ExplotionCam : MonoBehaviour
{
    private Planet planet;
    [SerializeField] private float camSpeedAfterCollision;

    private void Awake()
    {
        planet = FindObjectOfType<Planet>();
    }
    private void Update()
    {
        //We move cam back to the direction in which spaceship came
        transform.position += new Vector3(
            camSpeedAfterCollision * planet.RotationalCenterPlayerLastView.x,
            camSpeedAfterCollision * planet.RotationalCenterPlayerLastView.y,
            camSpeedAfterCollision * planet.RotationalCenterPlayerLastView.z
            );
    }
}
