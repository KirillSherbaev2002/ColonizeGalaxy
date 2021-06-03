using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header ("Controllers of bullets")]

    private Mover mover;
    public float Speed;
    private float timeSumm;

    void Start()
    {
        mover = FindObjectOfType<Mover>();
        GetComponent<Rigidbody>().velocity = transform.forward* (Speed + mover.GetComponent<Rigidbody>().velocity.magnitude);
    }

    private void Update()
    {
        DeathAfter();
    }

    private void DeathAfter()
    {
        if(timeSumm <= 100)
        {
            timeSumm++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
