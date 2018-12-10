using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HutTextController : MonoBehaviour {

	public TextMesh HutText;

	// Use this for initialization
	void Start () {
		//StartCoroutine(growLetters ());
		StartCoroutine(addLetters());
	}

	IEnumerator addLetters() {
		HutText = (TextMesh)HutText.transform.GetComponent (typeof(TextMesh));
		HutText.text = "Try to make it to the cabin!";
		yield return new WaitForSecondsRealtime (3);
		HutText.text = "...But watch out for the bear!";
		yield return new WaitForSecondsRealtime (5);
		Destroy (HutText);
		yield break;
	}

	/*IEnumerator growLetters(){
		while (HutText.transform.right < new Vector3(1,0,0) {
			HutText.transform.right += new Vector3(0.05,0,0);
			HutText.transform.forward += new Vector3(0,0,0.05);
		}
		HutText.transform.right = new Vector3 (1, 0, 0);
		HutText.transform.forward = new Vector3 (0, 0, 1);
		yield break;
	}

	/*IEnumerator waitAMoment(){
	
	}

	IEnumerator shrinkLetters(){

	}*/

	// Update is called once per frame
	void Update () {
		
	}
}
