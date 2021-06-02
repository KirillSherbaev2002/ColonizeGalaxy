using UnityEngine;

public class SpaceShipBehavior : MonoBehaviour
{
    public GameObject ShipNeededToRotate;

    [SerializeField] private float RotationSpeed; 
    private void Awake()
    {
        SetRotationToNeededStarShip();
    }

    private void SetRotationToNeededStarShip()
    {
        ShipNeededToRotate = GameObject.FindGameObjectWithTag("SpaceShip");
    }

    void FixedUpdate()
    {
        ShipNeededToRotate.transform.Rotate(Vector3.up, RotationSpeed);
    }
}
