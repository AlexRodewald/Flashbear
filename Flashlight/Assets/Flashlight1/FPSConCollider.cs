/*
 * Detect collisions for FPS Controller
 * with relevant GameObjects
 * and handle such collisions
 */

using UnityEngine;
using System.Collections;

public class FPSConCollider : MonoBehaviour {

	public bool winner = false;
	public bool loser = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		if (other.name == "SuccessSpot") {
			winner = true;
			StartCoroutine (endTheGame ());
		}
		if (other.name == "Bear") {
			loser = true;
			StartCoroutine (endTheGame ());
		}
	}
		
	/*void OnCollisionEnter (Collision col){
		Debug.Log ("HerE");
		if (col.gameObject.name == "Bear") {
			Destroy (col.gameObject);
			//winner = true;
			//StartCoroutine (endTheGame ());
		}
	}*/

	IEnumerator endTheGame(){
		yield return new WaitForSecondsRealtime (2);
		Application.Quit();
		//UnityEditor.EditorApplication.isPlaying = false;
	}

	void OnGUI(){
		if (winner == true) {
			GUI.Label (new Rect (20, 20, 100, 100), "A Winner Is You!");
		}
		if (loser) {
			GUI.Label (new Rect (20, 20, 100, 100), "You got mauled by a bear!");
		}
	}
			
}
