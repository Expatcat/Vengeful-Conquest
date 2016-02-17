using UnityEngine;
using System.Collections;

public class PlayerCreationGUI : MonoBehaviour {

  public Camera otherCamera;

  public Texture playerCreationScreen;
  
  private DataScript data;
  private GUIInfo guiInfo;
  
  private bool guiState = false;
  
  public GameObject[] appearance1 = new GameObject[4];
 
	// Use this for initialization
	void Awake () {

    data = DataScript.data;
    guiInfo = GUIInfo.guiInfo;

	}
	
	// Update is called once per frame
	void Update () {
  
	}
  
  void OnGUI() {
  
    if (guiState) {
    
      GUI.DrawTexture(guiInfo.GUIWindow, guiInfo.kingCreationScreen);
      
      PlayerDataScript playerData = data.playerData.GetComponent<PlayerDataScript>();
      
      /* GUI field to set the player name. Updates in data object */
      playerData.setPlayerName (
        GUI.TextField (GUIInfo.guiInfo.playerCreationNameField, playerData.getPlayerName())
      );
        
        
      /* GUI Button to start the game */  
      if (GUI.Button (GUIInfo.guiInfo.startButton, GUIInfo.guiInfo.startButtonText)) {
      
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
