using UnityEngine;
using System.Collections;

public class PlayerDataScript : MonoBehaviour {

	public Player player;
  
  public DataScript data;
  
  private bool userControl = false;
	
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
	
	  return this.player.gameObject;
	
	}
	
	/* Returns the transform position of the player */
	public Vector2 getPlayerPosition() {
	  return this.transform.position;
	  
	}
	
	/* Stop showing the player */
	public void SetPlayerState(bool playerState) {
  
    player.gameObject.SetActive (playerState);
    
    if (playerState == true) {
      Camera.main.transform.parent = this.transform;
    }
    
    else {
    
      Camera.main.transform.parent = null;
      
    }
  
  }
  
  /* Grants or removes control of the player */
  public void SetUserControl(bool newUserControl) {
  
    userControl = newUserControl;
  
  }
  
  public bool GetUserControl() {
  
    return userControl;
  
  }
  
  /* Returns the name of the player */
  public string getPlayerName() {
  
    return player.GetComponent<Player>().playerName;
    
  }
  
  /* Sets the name of the player */
  public void setPlayerName(string playerName) {
  
    player.GetComponent<Player>().playerName = playerName;
  
  }
  
  
}
