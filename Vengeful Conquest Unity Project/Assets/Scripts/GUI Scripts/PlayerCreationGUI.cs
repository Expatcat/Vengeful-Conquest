using UnityEngine;
using System.Collections;

public class PlayerCreationGUI : MonoBehaviour {

 public Camera otherCamera;

  public Texture playerCreationScreen;
  
  private DataScript data;
  
  private bool guiState = false;
  
  public GameObject[] appearance1 = new GameObject[4];
  
  
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
    
    //coordinates of the player name field
    playerNameLoc = new Vector2 (
      (data.guiStart.x + 146) * data.screenOffset.x, 
      (data.guiStart.y + 106) * data.screenOffset.y
    );
    
    //size of the player name field                             
    playerNameSize = new Vector2 (
      231 * data.screenOffset.x, 
      38 * data.screenOffset.y
    ); 
    
    //coordinates of the start game button
    startGameLoc = new Vector2(
      (data.guiStart.x + 508) * data.screenOffset.x, 
      (data.guiStart.y + 427) * data.screenOffset.y
    );
    
    //size of the start game button
    startGameSize = new Vector2 (
      162 * data.screenOffset.x, 
      43 * data.screenOffset.y
    );
	}
	
	// Update is called once per frame
	void Update () {
 
	}
  
  void OnGUI() {
  
    if (guiState) {
    
      GUI.DrawTexture(new Rect(data.guiStart.x, data.guiStart.y, data.guiSize.x, data.guiSize.y), playerCreationScreen);
      
      PlayerDataScript playerData = data.playerData.GetComponent<PlayerDataScript>;
      
      /* GUI field to set the player name. Updates in data object */
      playerData.setPlayerName (
        GUI.TextField ( //field type is textfield
          new Rect(playerNameLoc.x, playerNameLoc.y, playerNameSize.x, playerNameSize.y), //location of field 
          playerData.getPlayerName() //players name will display and update
        )
      );
        
        
      /* GUI Button to start the game */  
      if (GUI.Button (
        new Rect(startGameLoc.x, startGameLoc.y, startGameSize.x, startGameSize.y), "Start Game")) {
      
        Application.LoadLevel (data.worldSceneNumber); //loads open world
      
      }
    }
    
    otherCamera.Render(); //renders camera that can see appearance sprites

  }
  
  void OnLevelWasLoaded () {
  
    guiState = true;
    data.playerData.GetComponent<PlayerDataScript>().SetUserControl(false);
  
  }
  
}
