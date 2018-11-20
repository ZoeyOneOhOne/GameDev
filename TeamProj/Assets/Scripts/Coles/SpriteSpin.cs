using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpin : MonoBehaviour {

    float startXScale;
    float currentXScale;

    // Use this for initialization
    void Start () {

        startXScale = transform.localScale.x;
        currentXScale = startXScale;
	}
	
	// Update is called once per frame
	void Update () {

        currentXScale += startXScale + Mathf.Sin(Time.time);
        transform.localScale = new Vector3(currentXScale, transform.localScale.y, transform.localScale.z);
		
	}
}
