using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    private float camZPos;
    private float camYPos;
    private float camZPosSmooth;
    private float camYPosSmooth;

    [SerializeField] private float smallestValueZ;
    [SerializeField] private float smallestValueY;

    [SerializeField] private float biggestValueZ;
    [SerializeField] private float biggestValueY;

    private Mover moverShip;
    public GameObject CameraSpot;

    private void Awake()
    {
        moverShip = FindObjectOfType<Mover>();

        camZPosSmooth = smallestValueZ;
        camYPosSmooth = smallestValueY;
    }

    private void Update()
    {
        transform.position = CameraSpot.transform.position;
        #region AddForceAndCamPositionsControllers
        if (moverShip.EnginePower.value <= 0.24f)
        {
            camZPos = smallestValueZ;
            camYPos = smallestValueY;
        }
        if (moverShip.EnginePower.value > 0.28f)
        {
            camZPos = biggestValueZ;
            camYPos = biggestValueY +2f - (moverShip.EnginePower.value * 1.56f) - 0.26f;
        }
        if (!(moverShip.EnginePower.value > 0.28f) && !(moverShip.EnginePower.value < 0.24f))
        {
            camZPos = smallestValueZ;
            camYPos = smallestValueY;
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
        transform.localPosition = new Vector3(0, 0 + camYPosSmooth,0 + camZPosSmooth);
    }
}