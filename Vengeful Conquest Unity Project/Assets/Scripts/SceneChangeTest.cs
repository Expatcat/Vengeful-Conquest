using UnityEngine;
using System.Collections;

public class SceneChangeTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	if (Input.GetKeyDown ("c"))
	  Application.LoadLevel (1);
	
	}
}
