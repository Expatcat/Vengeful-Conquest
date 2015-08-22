using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	//textures
	public Texture backgroundTexture; //main menu background texture
  
  private DataScript data;

  void Start() {
  
    data = DataScript.data;
  
  }

	//Main Menu GUI
	void OnGUI() {

		//button texts
		string playButtonText = "New Game"; //play button text

		//play button values
		float playButtonX = Screen.width * .25f; //x value of upper left corner
	    float playButtonY = Screen.height * .5f; //y value of upper left corner
		float playButtonWidth = Screen.width * .5f; //width of play button
		float playButtonHeight = Screen.height * .1f; //height of play button

		//Displays the background with "Vengeful Conquest" text on it.
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);

		//displays the "New Game" button
		if (GUI.Button (new Rect (playButtonX, playButtonY, playButtonWidth, playButtonHeight), playButtonText)) {
    
		  Application.LoadLevel (data.openingSceneNumber);
		
		}
		
		if (GUI.Button (new Rect (playButtonX, playButtonY + 60, playButtonWidth, playButtonHeight), "Load Game")) {
    
      data.LoadData ();
			
		}
	}

}
