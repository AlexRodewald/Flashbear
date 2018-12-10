using UnityEngine;
using System.Collections;

public class BearLogic : MonoBehaviour {

	public Transform player;
	public float speed = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveToPlayer ();
	}

	public void MoveToPlayer(){
		transform.LookAt (player.position);
		transform.Rotate (new Vector3(0, -90, 0));
		transform.Translate (new Vector3 ((speed * Time.deltaTime), 0, 0));
	}
}
