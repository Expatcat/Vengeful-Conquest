using UnityEngine;
using System.Collections;

public class PlayerCreationGUI : MonoBehaviour {

 public Camera otherCamera;

  public Texture playerCreationScreen;
  
  private DataScript data;
  
  private bool guiState = false;
  
  //variables for the creation of the player name text field
  private Vector2 playerNameLoc, playerNameSize;
  
  private Vector2 appearanceLoc, appearanceSize;
  
  private Vector2 ability1Loc, ability1Size;
  private Vector2 ability2Loc, ability2Size;
  private Vector2 ability3Loc, ability3Size;
  private Vector2 ability4Loc, ability4Size;
  
  private Vector2 startGameLoc, startGameSize;
  
  

	// Use this for initialization
	void Start () {
	
    data = GameObject.Find("Data").GetComponent<DataScript>();
    
    playerNameLoc = new Vector2(data.guiStart.x + 146, data.guiStart.y + 106); 
    playerNameSize = new Vector2 (231, 38); 
    
    startGameLoc = new Vector2(data.guiStart.x + 508, data.guiStart.y + 427);
    startGameSize = new Vector2(162, 43);
  
	}
	
	// Update is called once per frame
	void Update () {
 
	}
  
  void OnGUI() {
  
    otherCamera.Render ();
  
    if (guiState) {
    
      GUI.DrawTexture(new Rect(data.guiStart.x, data.guiStart.y, data.guiSize.x, data.guiSize.y), playerCreationScreen);
      
      PlayerDataScript playerData = (PlayerDataScript)data.getData ("Player Data");
      
      /* GUI field to set the player name. Updates in data object */
      playerData.setPlayerName(
        GUI.TextField (new Rect(playerNameLoc.x, playerNameLoc.y, playerNameSize.x, playerNameSize.y), playerData.getPlayerName()));
        
        
      /* GUI Button to start the game */  
      if (GUI.Button (new Rect(startGameLoc.x, startGameLoc.y, startGameSize.x, startGameSize.y), "Start Game")) {
      
        Application.LoadLevel (data.worldSceneNumber); //loads open world
      
      }
      
      otherCamera.Render ();
      
    }
    
    
    

  }
  
  void OnLevelWasLoaded () {
  
    guiState = true;
  
  }
  
}
