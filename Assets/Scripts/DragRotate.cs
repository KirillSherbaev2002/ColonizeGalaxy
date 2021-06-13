using UnityEngine;

public class DragRotate : MonoBehaviour
{
    [SerializeField] private float Sensivity;

    private Mover mover;
    private CameraFollows camFollows;

    public GameObject Ship;

    public float rotX;
    [SerializeField] private float rotY;

    [SerializeField] private int PlusOrMinus;

    private void Awake()
    {
        mover = FindObjectOfType<Mover>();
        camFollows = FindObjectOfType<CameraFollows>();
    }

    [System.Obsolete]
    public void OnMouseDrag()
    {
        //On touch and move in vertical change Y
        rotY = PlusOrMinus * Input.GetAxis("Mouse Y") * Sensivity * Mathf.Deg2Rad;
        #region ControllersVertical
        if (rotY > 0)
        {
            mover.SetUpBackEngines();
            mover.SetFlameToCorrectRotation();
            Ship.transform.Rotate(rotY, 0.0f, 0.0f, Space.Self);
        }
        if (rotY < 0)
        {
            mover.SetDownBackEngines();
            mover.SetFlameToCorrectRotation();
            Ship.transform.Rotate(rotY, 0.0f, 0.0f, Space.Self);
        }
        #endregion

        #region ControllersHorizontal
        //On touch and move in Horizontal change X
        rotX = -PlusOrMinus * Input.GetAxis("Mouse X") * Sensivity * Mathf.Deg2Rad;
        if (rotX > 0)
        {
            mover.SetToRightEngines();
            mover.SetFlameToCorrectRotation();
            Ship.transform.Rotate(0.0f, 0.0f, rotX, Space.Self);
        }
        if (rotX < 0)
        {
            mover.SetToLeftEngines();
            mover.SetFlameToCorrectRotation();
            Ship.transform.Rotate(0.0f, 0.0f, rotX, Space.Self);
        }
        #endregion

        OnMouseDragEnd();

        //Default position of slider engine
        mover.EnginePower.value = 0.25f;

        //Needs to be set active Main engines according to the main slider

        //Main Engines engines to needed rotation
        mover.SetEnginesToCorrectRotation();
    }
    public void OnMouseDragEnd()
    {
        //Delete all starship flames 
        if (rotX == 0 && rotY == 0)
        {
            mover.stopAllFlames();
        }
    }
}
