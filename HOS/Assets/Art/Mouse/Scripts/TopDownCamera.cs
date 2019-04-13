using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class TopDownCamera : MonoBehaviour
{
    #region Variables
    //public Transform m_target;      //my target for camera
    [SerializeField]
    private float m_Height = 3f;    //my height for camera
    [SerializeField]
    private float m_Distance = 0f;  //my distance for camera
    [SerializeField]
    private float m_Angle = 1f;     //my angle for camera
    [SerializeField]
    private float m_Smoothspeed = 0.5f;     //Smoothing the camera speed
    [SerializeField]
    private float panSpeed = 20f;
    [SerializeField]
    private float boundX = 2.0f;
    [SerializeField]
    private float boundY = 1.5f;
    [SerializeField]
    private float panBorderThickness = 10f;
    [SerializeField]
    private Vector2 panLimit;
    [SerializeField]
    private float scrollspeed = 20;
    [SerializeField]
    private float minY = 20f;
    [SerializeField]
    private float maxY = 120f;

    private Vector3 refVelocity;
    #endregion

    #region Default Constructors
	// Update is called once per frame
	void Update ()
    {
        //HandleCamera();
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollspeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);


        transform.position = pos;
	}
    #endregion

    //protected virtual void HandleCamera()
    //{
    //    if (!m_target)
    //    {
    //        return;
    //    }

    //    //World Position Vector
    //    Vector3 worldPosition = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
    //    Debug.DrawLine(m_target.position, worldPosition, Color.red);

    //    //Build Rotation Vector
    //    Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPosition;
    //    Debug.DrawLine(m_target.position, rotatedVector, Color.green);

    //    //Move Camera Position
    //    Vector3 flatTargetPosition = m_target.position;
    //    flatTargetPosition.y = 0f;
    //    Vector3 finalPosition = flatTargetPosition + rotatedVector;
    //    Debug.DrawLine(m_target.position, finalPosition, Color.blue);

    //    //transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_Smoothspeed);
    //    transform.position = finalPosition;
    //    transform.LookAt(m_target.position);
    //}
}
