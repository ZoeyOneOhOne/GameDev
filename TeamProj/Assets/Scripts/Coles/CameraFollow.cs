using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;

    void Start ()
    {
	    	
	}	
	
    void Update ()
    {
		if(followObject)
        {
            transform.position = new Vector3(followObject.transform.position.x, 
                followObject.transform.position.y, transform.position.z);
        }
	}
}
