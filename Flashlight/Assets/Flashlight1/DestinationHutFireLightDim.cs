using UnityEngine;
using System.Collections;

public class DestinationHutFireLightDim : MonoBehaviour {

	private Transform x;
	private Transform player;
	public Light firelight;
	private Vector3 playerDistance;

	// Use this for initialization
	void Start () {
		x = this.transform;
		player = GameObject.FindGameObjectWithTag ("GameController").transform;
	}

	// Update is called once per frame
	void Update () {
		float dist = (getDistance() - 10);
		if (dist <= 80) {
			firelight.intensity = (dist / 10);
		} else {
			firelight.intensity = 8;
		}
	}

	private float getDistance(){
		return Vector3.Distance (x.position, player.position);
	}
}
