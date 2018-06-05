using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class VRDisable : MonoBehaviour {

	// Use this for initialization
	public void Start()
    {
        StartCoroutine(DeactivateVR("none"));
    }

    public IEnumerator DeactivateVR(string NOVR)
    {
        VRSettings.LoadDeviceByName(NOVR);
        yield return null;
		VRSettings.enabled = false;
    }

}
