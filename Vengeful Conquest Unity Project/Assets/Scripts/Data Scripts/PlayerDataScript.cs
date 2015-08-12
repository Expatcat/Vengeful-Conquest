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
	
	  //camera follow
	  Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, Camera.main.transform.position.z);
	
	}
	
	/* Returns the actual player game object */
	public GameObject getPlayerObject() { 
	
	  return this.player;
	
	}
	
	/* Returns the transform position of the player */
	public Vector2 getPlayerPosition() {
	  return this.transform.position;
	  
	}
	
	/* Stop showing the player */
	void hidePlayer() {
	
      player.GetComponent<Renderer>().enabled = false;
	
	}
	
	/* Show the player */
	void showPlayer() {
	
	  player.GetComponent<Renderer>().enabled = true;
	
	}
}
