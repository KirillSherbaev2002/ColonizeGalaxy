using UnityEngine;

public class ShipRotator : MonoBehaviour
{
    public GameObject Ship;

    [SerializeField] private float rotZSensivity;
    [SerializeField] private float rotYSensivity;

    public void RotateZ(int Positivity)
    {
        Ship.transform.rotation = Quaternion.Euler(Ship.transform.rotation.x, Ship.transform.rotation.y, rotZSensivity * Positivity);
    }

    public void RotateY(int Positivity)
    {
        Ship.transform.rotation = Quaternion.Euler(Ship.transform.rotation.x, rotYSensivity * Positivity, Ship.transform.rotation.z);
    }
}
