using UnityEngine;
using System.Collections;

public class CastleManagerGUI : MonoBehaviour {

  private DataScript data;
  private GUIInfo guiInfo;
  private KingdomDataScript kingdomData;
  
  private int castleNumber;

  private bool claimed;

  private bool guiState = false;

	// Use this for initialization
	void Start () {
    
    guiInfo = GUIInfo.guiInfo;
    data = DataScript.data;
    kingdomData = KingdomDataScript.kingdomData;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
  void OnGUI() {
  
    if (guiState) {
    
      if (claimed) {
      
        GUI.DrawTexture (guiInfo.GUIWindow, guiInfo.claimedCastleManagerScreen);
       
      
      }
      
      else {
      
        GUI.DrawTexture (guiInfo.GUIWindow, guiInfo.unclaimedCastleManagerScreen);
        
        GUI.Label (guiInfo.castleNameField, kingdomData.castlesArray[castleNumber].GetName ());
      
      }
    }
  }
  
  public void toggleGUI() {
  
    guiState = !guiState;
  
  
  }
  
  /* Method that turns on the GUI - is called from a castle trigger */
  public void toggleGUI(int loadedCastleNumber) {
  
    castleNumber = loadedCastleNumber;
    
    guiState = !guiState;
    
    if (kingdomData.castlesArray[castleNumber].GetComponent<Castles>().claimed == true) {
    
      claimed = true;
    
    }
    
    else {
    
      claimed = false;
      
    }
  }
}
