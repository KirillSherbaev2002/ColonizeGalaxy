using System.Collections;
using System.Collections.Generic;
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
        rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
        rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

        #region ControllersVertical
        if (rotY > 0)
        {
            mover.SetDownBackEngines();
            mover.SetFlameToCorrectRotation();
        }
        if (rotY < 0)
        {
            mover.SetUpBackEngines();
            mover.SetFlameToCorrectRotation();
        }
        #endregion

        #region ControllersHorizontal
        if (rotX > 0)
        {
            mover.SetToRightEngines();
        }
        if (rotX < 0)
        {
            mover.SetToLeftEngines();
        }
        #endregion

        OnMouseDragEnd();

        mover.EnginePower.value = 0.25f;

        //Needs to be set active Main engines according to the main slider
        Ship.transform.RotateAround(Vector3.up, rotX);
        Ship.transform.RotateAround(-Vector3.right, rotY);
    }
    public void OnMouseDragEnd()
    {
        if (rotX == 0 && rotY == 0)
        {
            mover.stopAllFlames();
        }
    }
}
