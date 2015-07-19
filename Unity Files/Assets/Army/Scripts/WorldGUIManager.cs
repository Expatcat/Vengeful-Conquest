using UnityEngine;
using System.Collections;

public class WorldGUIManager : MonoBehaviour {
  
  //GUI textures
  public Texture ArmyManager;
  
  private bool displayArmyManager = false;
  
  //GUI constants
  private static float guiXStart, guiYStart, guiWidth = 700, guiHeight = 500;
  
  //ArmyManager button offsets
  private static float button1X, button1Y, button2X, button2Y, button3X, button3Y,
    button4X, button4Y, button5X, button5Y, button6X, button6Y, button7X, button7Y,
    button8X, button8Y, button9X, button9Y, button10X, button10Y;
  
  
  //runs at the beginning
  void Start() {
  
    initializeArmyManager();
  
    guiXStart = (Screen.width / 2) - 350;
    guiYStart = (Screen.height / 2) - 250;
    
  }

  //runs every frame			
  void Update() {
 
    //checks for the Army Manager keypress 
    if (Input.GetKeyDown("s"))
      displayArmyManager = toggleGUI (displayArmyManager); //calls toggleGUI with boolean
  }		

  //displays screen GUI's
  void OnGUI() {

     if (displayArmyManager)
       GUI.DrawTexture(new Rect(guiXStart, guiYStart, guiWidth, guiHeight), ArmyManager);
       
      
  }
  
  //toggles the passed boolean GUI on and off
  bool toggleGUI(bool guiName) {
    return !guiName;
  }
}
