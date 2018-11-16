using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public Transform redLight;

	void Start () {
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject != God.playerObject)
        {
            return;
        }
        else
        {
            God.playerObject.GetComponent<PlayerControls>().SetRespawnPoint(transform.position);

            if (redLight)
                Instantiate(redLight, transform.GetChild(0).transform.position, transform.rotation);
            
        }
    }
}
