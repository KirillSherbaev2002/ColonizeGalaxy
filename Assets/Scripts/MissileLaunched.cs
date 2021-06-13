using UnityEngine;
using System.Collections;

public class MissileLaunched : MonoBehaviour
{
    [Header("Controllers of missile")]

    private Mover mover;
    [SerializeField] private float Speed;
    private float multiplayer = 1;
    [SerializeField] private float AxelerationOverFrame;

    public GameObject Explosion;


    void Start()
    {
        //Set
        mover = FindObjectOfType<Mover>();
        GetComponent<Rigidbody>().velocity = -mover.transform.up
            * (Speed + mover.GetComponent<Rigidbody>().velocity.magnitude);
    }

    private void Update()
    {
        GetComponent<Rigidbody>().AddForce(-mover.transform.up * Speed * multiplayer);
        multiplayer += AxelerationOverFrame;
        gameObject.transform.Rotate(mover.transform.rotation.x, mover.transform.rotation.y, mover.transform.rotation.z, Space.Self);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(Explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z-400), 
            Quaternion.EulerAngles(mover.transform.rotation.x * transform.forward.x, mover.transform.rotation.y * transform.forward.y, mover.transform.rotation.z * transform.forward.z) );
        Destroy(gameObject);
    }
}
