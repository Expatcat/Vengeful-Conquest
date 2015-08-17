using UnityEngine;
using System.Collections;

public class CastleManagerGUI : MonoBehaviour {

  private DataScript data;
  private CastleDataScript castleData;

  private bool claimed;

  public Texture claimedCastleGUI;
  public Texture unclaimedCastleGUI;

  private bool guiState = false;

	// Use this for initialization
	void Start () {
    
    data = GameObject.Find("Data").GetComponent<DataScript>();
    castleData = (CastleDataScript)data.getData ("Castle Data");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
  void OnGUI() {
  
    if (guiState) {
    
      if (claimed) {
      
      }
      
      else {
      
        Debug.Log ("HE");
       
        GUI.DrawTexture (new Rect(data.guiStart.x, data.guiStart.y, data.guiSize.x, data.guiSize.y), unclaimedCastleGUI);
      
      }
    
    }
  
  }
  
  public void toggleGUI() {
  
    guiState = !guiState;
  
  
  }
  
  public void toggleGUI(int castleNumber) {
  
    guiState = !guiState;
    
    if (castleData.castlesArray[castleNumber].GetComponent<Castles>().claimed == true) {
    
      claimed = true;
      Debug.Log ("HE");
    
    }
    
    else {
    
      claimed = false;
      
    }
   
  
  }
  
}
