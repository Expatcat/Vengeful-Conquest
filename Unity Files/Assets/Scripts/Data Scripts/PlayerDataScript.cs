using UnityEngine;
using System.Collections;

public class PlayerDataScript : MonoBehaviour {

	public GameObject player;
	
	void Start() {
	
	}

	// Use this for initialization
	void OnLevelWasLoaded () {
	
	  if (Application.loadedLevelName == "MainMenu") {
	    hidePlayer ();
	  }
	  
	  else {
	  
	    showPlayer ();
	  }
	
	  
	
	}
	
	// Update is called once per frame
	void Update () {
	
	  Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, Camera.main.transform.position.z );
	
	}
	
	void hidePlayer() {
	
      player.GetComponent<Renderer>().enabled = false;
	
	}
	
	void showPlayer() {
	
	  player.GetComponent<Renderer>().enabled = true;
	
	}
}
