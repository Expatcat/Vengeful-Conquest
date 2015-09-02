using UnityEngine;
using System.Collections;

public class SoldierManagerGUI : MonoBehaviour {

  public Texture soldierManagerScreen;
  private DataScript data;
  private GUIInfo guiInfo;
  
  private Soldiers currentSoldier;
  private string oldObjectName;
  
  bool showSoldierManager = false;
  Object sourceScript; //script that this window was called from

	// Use this for initialization
	void Start () {
  
    data = DataScript.data;
    guiInfo = GUIInfo.guiInfo;
    
	}
	
	// Update is called once per frame
	void Update () {

  }
  
  void OnGUI () {
  
    if (showSoldierManager == true) {
    
      GUI.DrawTexture (guiInfo.GUIWindow, guiInfo.soldierManagerScreen);
  
      currentSoldier.soldierName = (GUI.TextField(guiInfo.soldierNameField, currentSoldier.GetName()));
      
      if (GUI.Button(guiInfo.soldierCancelButton, guiInfo.soldierCancelButtonText)) {
     
        UndoChanges ();
        toggleGUI ();
      
      }
      
      if (GUI.Button (guiInfo.soldierAcceptButton, guiInfo.soldierAcceptButtonText)) {
      
        AcceptChanges ();
        toggleGUI ();
      
      }
    }
  }
  
  private void toggleGUI() {
  
    showSoldierManager = !showSoldierManager;
 
    if (showSoldierManager == false && (sourceScript.GetType() == typeof(ArmyManagerGUI))) {
      
      GetComponent<ArmyManagerGUI>().toggleArmyManager();
      
    }
  }
  
  public void toggleGUI(Soldiers soldierScript, Object sourceScript) {
 
    showSoldierManager = !showSoldierManager; 

    currentSoldier = this.gameObject.AddComponent<Soldiers>();
    currentSoldier = soldierScript.GetSoldierInfo (currentSoldier);

    this.sourceScript = sourceScript;

  }
  
  void UndoChanges() {
  
    Destroy (currentSoldier);
    
  }
  
  void AcceptChanges() {

    data.armyData.armyArray[currentSoldier.soldierNumber].SetSoldierInfo (currentSoldier);
    Destroy (currentSoldier);
  
  }
}
