using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    [SerializeField] private float camZPos;
    [SerializeField] private float camYPos;
    [SerializeField] private float camZPosSmooth;
    [SerializeField] private float camYPosSmooth;

    private Mover moverShip;
    private GameObject Camera;
    public GameObject CameraSpot;

    private void Awake()
    {
        moverShip = FindObjectOfType<Mover>();

        camZPosSmooth = 7f;
        camYPosSmooth = 4.01f;
    }

    private void Update()
    {
        #region AddForceAndCamPositionsControllers
        if(moverShip.EnginePower.value <= 0.24f)
        {
            moverShip.GetComponent<Rigidbody>().AddForce(-transform.up * (-(moverShip.EnginePower.value * 1.56f) - 0.26f) * 30);
            camZPos = 5.5f;
            camYPos = 4.01f;
        }
        if (moverShip.EnginePower.value > 0.28f)
        {
            moverShip.GetComponent<Rigidbody>().AddForce(-transform.up * ((moverShip.EnginePower.value * 1.56f) - 0.26f) * 10);
            camZPos = 7.01f;
            camYPos = 4.01f - (moverShip.EnginePower.value * 1.56f) - 0.26f;
        }
        if (!(moverShip.EnginePower.value > 0.28f) && !(moverShip.EnginePower.value < 0.24f))
        {
            camZPos = 6f;
            camYPos = 3.01f;
        }
        #endregion
        CamToShip();
    }
    private void CamToShip()
    {
        #region SmoothCameraTransitionValues
        if (camYPosSmooth < camYPos - 0.1f)
        {
            camYPosSmooth += 0.3f * Time.deltaTime;
        }
        else if (camYPosSmooth > camYPos + 0.1f)
        {
            camYPosSmooth -= 0.3f * Time.deltaTime;
        }
        if (camZPosSmooth < camZPos - 0.1f)
        {
            camZPosSmooth += 0.3f * Time.deltaTime;
        }
        else if (camZPosSmooth > camZPos + 0.1f)
        {
            camZPosSmooth -= 0.3f * Time.deltaTime;
        }
        #endregion
        transform.position = new Vector3(CameraSpot.transform.position.x, CameraSpot.transform.position.y + camYPosSmooth, CameraSpot.transform.position.z - camZPosSmooth);
        transform.rotation = Quaternion.Euler(CameraSpot.transform.rotation.x, CameraSpot.transform.rotation.y, CameraSpot.transform.rotation.z);
    }

}
