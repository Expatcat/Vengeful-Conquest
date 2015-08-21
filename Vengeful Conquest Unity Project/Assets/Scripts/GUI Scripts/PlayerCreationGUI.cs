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
 
  
  private Vector2 startGameLoc, startGameSize;
  
  

	// Use this for initialization
	void Awake () {
	
    data = GameObject.Find("Data").GetComponent<DataScript>();


	}
	
	// Update is called once per frame
	void Update () {
  
    //coordinates of the player name field
    playerNameLoc = new Vector2 (
      data.guiWindow.x + (146 * data.screenOffset.x), 
      data.guiWindow.y + (106 * data.screenOffset.y)
    );
  
    //size of the player name field                             
    playerNameSize = new Vector2 (
      231 * data.screenOffset.x, 
      38 * data.screenOffset.y
    ); 
    
    //coordinates of the start game button
    startGameLoc = new Vector2(
      data.guiWindow.x + (508 * data.screenOffset.x), 
      data.guiWindow.y + (427 * data.screenOffset.y)
    );
    
    //size of the start game button
    startGameSize = new Vector2 (
      162 * data.screenOffset.x, 
      43 * data.screenOffset.y
    );
	}
  
  void OnGUI() {
  
    if (guiState) {
    
      GUI.DrawTexture(data.guiWindow, playerCreationScreen);
      
      PlayerDataScript playerData = data.playerData.GetComponent<PlayerDataScript>();
      
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
