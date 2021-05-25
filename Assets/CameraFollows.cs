using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    [SerializeField] private float camZPos;
    [SerializeField] private float camYPos;
    [SerializeField] private float camZPosSmooth;
    [SerializeField] private float camYPosSmooth;

    private Mover moverShip;
    public GameObject CameraSpot;

    private void Awake()
    {
        moverShip = FindObjectOfType<Mover>();

        camZPosSmooth = 3.33f;
        camYPosSmooth = 6f;
    }

    private void Update()
    {
        #region AddForceAndCamPositionsControllers
        if(moverShip.EnginePower.value <= 0.24f)
        {
            camZPos = 4.33f;
            camYPos = 5.95f;
        }
        if (moverShip.EnginePower.value > 0.28f)
        {
            camZPos = 3.2f;
            camYPos = 9f - (moverShip.EnginePower.value * 1.56f) - 0.26f;
        }
        if (!(moverShip.EnginePower.value > 0.28f) && !(moverShip.EnginePower.value < 0.24f))
        {
            camZPos = 3.33f;
            camYPos = 6f;
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
        transform.localPosition = new Vector3(0, 0 + camYPosSmooth, 0 + camZPosSmooth); 
    }
}
