using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public Transform myDest;

    void OnMouseDown()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = myDest.position;
        this.transform.parent = GameObject.Find("Destination").transform;
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(180f, 180, 0));
        
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
        
    }

    //private void OnTriggerEnter(Collider collider)
    //{
    //    if (collider.name == "Mouse_b")
    //    {
    //        Destroy(collider.gameObject);
    //    }
    //}
}
