using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
    void Update()
    {

        // Face the camera directly.
        transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward, Camera.main.transform.up);

        // Rotate so the visible side faces the camera.
        transform.Rotate(90, 0, 0);

    }
}
