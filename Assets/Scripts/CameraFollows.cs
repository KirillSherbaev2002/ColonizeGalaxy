using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    [Header ("Forward or Backward")]
    private float camZPos;
    private float camYPos;
    private float camZPosSmooth;
    private float camYPosSmooth;

    [SerializeField] private float camYPosMultyWithEngineOn;

    [SerializeField] private float smallestValueZ;
    [SerializeField] private float smallestValueY;

    [SerializeField] private float biggestValueZ;
    [SerializeField] private float biggestValueY;

    [Header("From left to right")]
    private float camXPos;
    private float camXPosSmooth;

    [SerializeField] private float camXPosMultyWithEngineOn;

    [SerializeField] private float smallestValueX;

    [SerializeField] private float biggestValueX;
    [SerializeField] private float centerValueX;

    [Header("Objects")]
    private Mover moverShip;
    public GameObject CameraSpot;
    private DragRotate Rotator;

    private void Awake()
    {
        moverShip = FindObjectOfType<Mover>();
        Rotator = FindObjectOfType<DragRotate>();

        camXPosSmooth = centerValueX;
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
            camYPos = biggestValueY+(moverShip.EnginePower.value * camYPosMultyWithEngineOn) - 0.26f;
        }
        if (!(moverShip.EnginePower.value > 0.28f) && !(moverShip.EnginePower.value < 0.24f))
        {
            camZPos = smallestValueZ;
            camYPos = smallestValueY;
        }
        #endregion

        #region LeftOrRightMoveCam
        if (Rotator.rotX >= 0)
        {
            TransitionToRight();
        }

        if (Rotator.rotX <= 0)
        {
            TransitionToLeft();
        }

        if (Rotator.rotX == 0)
        {
            TransitionToCenter();
        }

        #endregion

        CamToShipAxeleration();
        CamToShipOnTurn();
    }

    #region Smooth Camera Transition Back and Forward
    private void CamToShipAxeleration()
    {
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
        transform.localPosition = new Vector3(0 + camXPosSmooth, 0 + camYPosSmooth,0 + camZPosSmooth);
    }
    #endregion

    #region Smooth Camera Transition left or right
    private void CamToShipOnTurn()
    {
        if (camXPosSmooth < camXPos - 0.1f)
        {
            camXPosSmooth += 0.3f * Time.deltaTime;
        }
        else if (camXPosSmooth > camXPos + 0.1f)
        {
            camXPosSmooth -= 0.3f * Time.deltaTime;
        }
        transform.localPosition = new Vector3(0 + camXPosSmooth, 0 + camYPosSmooth, 0 + camZPosSmooth);
    }
    #endregion

    #region Changing the value to leftest or rightest position of cam
    public void TransitionToRight()
    {
        camXPos = smallestValueX;
    }
    public void TransitionToLeft()
    {
        camXPos = biggestValueX;
    }

    public void TransitionToCenter()
    {
        camXPos = centerValueX;
    }
    #endregion
}