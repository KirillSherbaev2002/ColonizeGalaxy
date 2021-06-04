using UnityEngine;

public class ExplotionCam : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
   {
       if(collision.collider.CompareTag("Planet"))
       {
            Destroy(gameObject);
       }
   }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Planet"))
        {
            Destroy(gameObject);
        }
    }
}
