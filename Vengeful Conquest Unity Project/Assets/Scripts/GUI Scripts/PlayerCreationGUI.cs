using UnityEngine;
using System.Collections;

public class PlayerCreationGUI : MonoBehaviour {

  public Texture playerCreationScreen;
  
  private DataScript data;
  
  private bool guiState = false;
  
  //variables for the creation of the player name text field
  private Vector2 playerNameLoc = new Vector2(130 + 50, 90 + 50);
  private Vector2 playerNameSize = new Vector2 (240, 40);
  
  

	// Use this for initialization
	void Start () {
	
    data = GameObject.Find("Data").GetComponent<DataScript>();
  
	}
	
	// Update is called once per frame
	void Update () {
 
	}
  
  void OnGUI() {
  
    if (guiState) {
    
      GUI.DrawTexture(new Rect(data.guiStart.x, data.guiStart.y, data.guiSize.x, data.guiSize.y), playerCreationScreen);
      
      PlayerDataScript playerData = (PlayerDataScript)data.getData ("Player Data");
      
      playerData.setPlayerName(
        GUI.TextField (new Rect(playerNameLoc.x, playerNameLoc.y, playerNameSize.x, playerNameSize.y), playerData.getPlayerName()));
      
    }
    
    
    

  }
  
  void OnLevelWasLoaded () {
  
    guiState = true;
  
  }
  
}
