using UnityEngine;
using System.Collections;

public class BearLogic2 : MonoBehaviour {

	public Transform target;					// Player, the position that the bear navigates to, constantly updated
	public UnityEngine.AI.NavMeshAgent agent;	// Assignment to Unity's pathfinding
	public bool isStunned = false;				// flag for whether the bear has been stunned by the flashlight
	public int waitingPeriod = 5;				// how long the bear remains stunned
	public Transform bears;

	// Use this for initialization
	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = target.position;
		//createMoreBears ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isStunned) {
			StopCoroutine (Stunned ());
			agent.destination = target.position;
		} else if (isStunned) {
			// Took a few tries to get this to work. Simply dropping the speed did nothing for some reason. Disabling the agent made the bear-cube disappear, and Unity got upset when the NavMesh was disabled. Setting the target to itself seems to work pretty well.
			// Debug.Log("Starting stunned coroutine");
			StartCoroutine (Stunned());
		}
	}

	void createMoreBears(){
		for (int y = 0; y < 2 ;y++) {
			Instantiate (bears, new Vector3 (Random.Range (15, 112), 1.5f, Random.Range (15, 112)), Quaternion.identity);
		}
	}

	IEnumerator Stunned(){
		isStunned = false;
		agent.destination = agent.transform.position;
		agent.speed = 0;
		Debug.Log ("Waiting" + System.DateTime.Now.ToString());
		yield return new WaitForSeconds (5);
		Debug.Log ("DONE" + System.DateTime.Now.ToString());
		agent.speed = 7;
		yield break;
	}
}
