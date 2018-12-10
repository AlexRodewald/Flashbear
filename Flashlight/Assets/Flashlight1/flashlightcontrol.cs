using UnityEngine;
using System.Collections;

public class flashlightcontrol : MonoBehaviour {

	public Light flashlight;
	public int baseCone = 40;
	public int targetCone = 90;
	public float baseBright = 2.0f;
	public float targetBright = 10.0f;
	public bool brightening = false;
	public bool dimming = false;
	public BearLogic2 bearCode;
	public Transform bear = null;
	public bool showIntroText = true;

	// Use this for initialization
	void Start () {
		bear = GameObject.Find("Bear").transform;
		flashlight.enabled = false;
		StartCoroutine (introText());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			if (flashlight.enabled == true) {
				flashlight.enabled = false;
			} else {
				flashlight.enabled = true;
			}
		} else if (Input.GetKeyDown (KeyCode.E)) {
			if(brightening){
				goto done;
			}
			if (flashlight.enabled) {
				brightening = true;
			}
		} done:;
		if (brightening) {
			StartCoroutine (BrightAndWide ());
		}
		if (dimming) {
			StopCoroutine (BrightAndWide ());
			StartCoroutine (DimAndNarrow ());
		}
	}

	IEnumerator introText(){
		yield return new WaitForSecondsRealtime (5);
		showIntroText = false;
		yield break;
	}

	IEnumerator BrightAndWide(){
		if (flashlight.intensity >= targetBright) {
			flashlight.intensity = targetBright;
			flashlight.spotAngle = targetCone;
			brightening = false;
			dimming = true;
			if (Vector3.Distance (bear.position, flashlight.transform.position) < 25) {
				if (!bearCode.isStunned) {
					bearCode.isStunned = true;
				}
			}
			yield break;
		}
		//for (int x = (int)baseBright; x < targetBright; x++) {
			flashlight.intensity += 1;
			flashlight.spotAngle += 0.1f;
		//}
	}

	//IEnumerator WaitForBrightLight(){
	
	//}

	IEnumerator DimAndNarrow(){
		yield return new WaitForSecondsRealtime (1);
		if (flashlight.intensity <= baseBright) {
			flashlight.intensity = baseBright;
			flashlight.spotAngle = baseCone;
			dimming = false;
			yield break;
		}
		for (int x = (int)targetBright; x >= baseBright; x--) {
			flashlight.intensity -= 1;
			flashlight.spotAngle -= 0.1f;
		}
	}

	void OnGUI(){
		//GUI.Label (new Rect (20, 0, 100, 100), bearCode.isStunned.ToString());
		if (showIntroText) {
			GUI.Label (new Rect (20, 50, 140, 150), "Press F for Flashlight, E for a Burst of Light");
		}
	}
}
