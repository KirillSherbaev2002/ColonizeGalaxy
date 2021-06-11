using UnityEngine;

public class MissileLanuched : MonoBehaviour
{
    [Header("Controllers of missile")]

    private Mover mover;
    public float Speed;

    void Start()
    {
        mover = FindObjectOfType<Mover>();
        GetComponent<Rigidbody>().velocity = transform.forward * (Speed + mover.GetComponent<Rigidbody>().velocity.magnitude);
    }
}
