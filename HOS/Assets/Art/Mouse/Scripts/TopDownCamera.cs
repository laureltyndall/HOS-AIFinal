using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

public class TopDownCamera : MonoBehaviour
{
    #region Variables
    public Transform m_target;      //my target for camera
    [SerializeField]
    private float m_Height = 3f;    //my height for camera
    [SerializeField]
    private float m_Distance = 0f;  //my distance for camera
    [SerializeField]
    private float m_Angle = 1f;     //my angle for camera
    [SerializeField]
    private float m_Smoothspeed = 0.5f;     //Smoothing the camera speed
    [SerializeField]
    private float boundX = 2.0f;
    [SerializeField]
    private float boundY = 1.5f;

    private Vector3 refVelocity;
    #endregion

    #region Default Constructors
    // Use this for initialization
    void Start ()
    {
        HandleCamera();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        HandleCamera();
		
	}
    #endregion

    protected virtual void HandleCamera()
    {
        if (!m_target)
        {
            return;
        }

        //World Position Vector
        Vector3 worldPosition = (Vector3.forward * -m_Distance) + (Vector3.up * m_Height);
        Debug.DrawLine(m_target.position, worldPosition, Color.red);

        //Build Rotation Vector
        Vector3 rotatedVector = Quaternion.AngleAxis(m_Angle, Vector3.up) * worldPosition;
        Debug.DrawLine(m_target.position, rotatedVector, Color.green);

        //Move Camera Position
        Vector3 flatTargetPosition = m_target.position;
        flatTargetPosition.y = 0f;
        Vector3 finalPosition = flatTargetPosition + rotatedVector;
        Debug.DrawLine(m_target.position, finalPosition, Color.blue);

        //transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_Smoothspeed);
        transform.position = finalPosition;
        transform.LookAt(m_target.position);
    }
}
