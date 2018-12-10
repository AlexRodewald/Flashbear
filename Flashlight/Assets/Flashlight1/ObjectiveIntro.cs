using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveIntro : MonoBehaviour {

	public GameObject playerCamera = GameObject.Find("FPSController");
	public GameObject bear = GameObject.Find("Bear");
	public GameObject objective = GameObject.Find("EndingHut");

	// Use this for initialization
	void Start () {
		playerCamera.transform.LookAt (bear.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
