using UnityEngine;
using System.Collections;

public class PlayerDataScript : MonoBehaviour {

	public GameObject player;
  
  public DataScript data;
  
  public bool userControl = false;
	
	void Start() {
  
    data = GameObject.Find ("Data").GetComponent<DataScript>();
	
    SetPlayerState(false); //disables the player by default 
  
	}

	// Use this for initialization
	void OnLevelWasLoaded () {
	
	  if (Application.loadedLevel == data.worldSceneNumber) {
      SetPlayerState (true);
      SetUserControl (true);
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
	void SetPlayerState(bool playerState) {
  
    player.SetActive (playerState);
  
  }
  
  /* Grants or removes control of the player */
  void SetUserControl(bool newUserControl) {
  
    userControl = newUserControl;
  
  }
  
  /* Returns the name of the player */
  public string getPlayerName() {
  
    return player.GetComponent<PlayerData>().playerName;
    
  }
  
  /* Sets the name of the player */
  public void setPlayerName(string playerName) {
  
    player.GetComponent<PlayerData>().playerName = playerName;
  
  }
  
  
}
