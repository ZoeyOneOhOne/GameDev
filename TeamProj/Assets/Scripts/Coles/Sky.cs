using UnityEngine;

public class Sky : MonoBehaviour
{
    public GameObject followObject;

    void Start()
    {
        if (followObject)
        {
            transform.position = new Vector3(transform.position.x,
                followObject.transform.position.y - 2, transform.position.z);
        }
    }

    void Update()
    {
        if (followObject)
        {
            transform.position = new Vector3(transform.position.x,
                followObject.transform.position.y - 2, transform.position.z);
        }
    }
}