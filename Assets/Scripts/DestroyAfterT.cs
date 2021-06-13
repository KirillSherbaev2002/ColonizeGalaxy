using System.Collections;
using UnityEngine;

public class DestroyAfterT : MonoBehaviour
{
    [SerializeField] private float TimeBeforeDestroy;
    private void Start()
    {
        StartCoroutine(CollisionDestroy());
    }
    IEnumerator CollisionDestroy()
    {
        yield return new WaitForSeconds(TimeBeforeDestroy);
        Destroy(gameObject);
    }
}

