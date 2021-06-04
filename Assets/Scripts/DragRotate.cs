using UnityEngine;

public class DragRotate : MonoBehaviour
{
    private float rotSpeed = 3f;

    private Mover mover;

    public GameObject Ship;

    [SerializeField] float rotX;
    [SerializeField] float rotY;

    public void Awake()
    {
        mover = FindObjectOfType<Mover>();
    }

    [System.Obsolete]
    public void OnMouseDrag()
    {
        rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad; 
        #region ControllersVertical
        if (rotY > 0)
        {
            mover.SetDownBackEngines();
            mover.SetFlameToCorrectRotation();
            Ship.transform.RotateAround(-Vector3.right, rotY);
        }
        if (rotY < 0)
        {
            mover.SetUpBackEngines();
            mover.SetFlameToCorrectRotation();
            Ship.transform.RotateAround(-Vector3.right, rotY);
        }
        #endregion

        #region ControllersHorizontal
        rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        if (rotX > 0)
        {
            mover.SetToRightEngines();
            mover.SetFlameToCorrectRotation();
            Ship.transform.RotateAround(Vector3.up, rotX);
        }
        if (rotX < 0)
        {
            mover.SetToLeftEngines();
            mover.SetFlameToCorrectRotation();
            Ship.transform.RotateAround(Vector3.up, rotX);
        }
        #endregion

        OnMouseDragEnd();

        //Default position of slider engine
        mover.EnginePower.value = 0.25f;

        //Needs to be set active Main engines according to the main slider
    }
    public void OnMouseDragEnd()
    {
        if (rotX == 0 && rotY == 0)
        {
            mover.stopAllFlames();
        }
    }
}
