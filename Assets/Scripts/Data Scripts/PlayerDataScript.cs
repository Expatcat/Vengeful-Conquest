using UnityEngine;
using System.Collections;

public class PlayerDataScript : MonoBehaviour {

	public Player player;
  public static PlayerDataScript playerData;
  
  public DataScript data;
  
  private bool userControl = false;
	
	void Start() {
  
    playerData = this;
  
    data = DataScript.data;
	
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
	
	  return player.gameObject;
	
	}
	
	/* Returns the transform position of the player */
	public Vector2 getPlayerPosition() {
	  return this.transform.position;
	  
	}
	
	/* Stop showing the player */
	public void SetPlayerState(bool playerState) {
  
    player.gameObject.SetActive (playerState);

  
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
