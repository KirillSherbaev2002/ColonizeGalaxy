using System.Collections;
using UnityEngine;

public class StarConnectors : MonoBehaviour
{
    private GameObject[] OurStars;
    public LineRenderer[] lineRenderer;
    [SerializeField] private float LineWidth;
    [SerializeField] private float TimeWaitBeforeNewConnection;

    private void Awake()
    {
        OurStars = GameObject.FindGameObjectsWithTag("Ours");
        lineRenderer[0].SetPosition(Random.Range(0, OurStars.Length), OurStars[0].transform.position);
        foreach (LineRenderer line in lineRenderer)
        {
            // set the color of the line
            line.startColor = Color.blue;
            line.endColor = Color.blue;

            // set width of the renderer
            line.startWidth = LineWidth;
            line.endWidth = LineWidth;
        }
    }
    void FixedUpdate()
    {
        StartCoroutine(SetConnections());
    }

    IEnumerator SetConnections()
    {
        yield return new WaitForSeconds(TimeWaitBeforeNewConnection);
        //getting and setting V3 star from which to which
        lineRenderer[0].SetPosition(Random.Range(0, OurStars.Length), OurStars[Random.Range(0, OurStars.Length)].transform.position);
    }
}
