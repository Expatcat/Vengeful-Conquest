using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
  
  private DataScript data;
  private GUIInfo guiInfo;

  void Start() {
  
    data = DataScript.data;
    guiInfo = GUIInfo.guiInfo;
  
  }

	//Main Menu GUI
	void OnGUI() {

		//Displays the background with "Vengeful Conquest" text on it.
		GUI.DrawTexture (guiInfo.GUIWindow, guiInfo.mainMenuScreen);

		//displays the "New Game" button
		if (GUI.Button (guiInfo.newGameButton, guiInfo.newGameButtonText)) {
    
		  Application.LoadLevel (data.openingSceneNumber);
		
		}
		
		if (GUI.Button (guiInfo.loadGameButton, guiInfo.loadGameButtonText)) {
    
      data.LoadData ();
			
		}
	}

}
