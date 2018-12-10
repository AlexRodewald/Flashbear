using UnityEngine;
using System.Collections;

public class CreateForest : MonoBehaviour {

	public Transform trees;

	// Use this for initialization
	void Start () {
		for (int y = 0; y < 80 ;y++) {
			Instantiate (trees, new Vector3 (Random.Range (15, 112), 1.5f, Random.Range (15, 112)), Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
