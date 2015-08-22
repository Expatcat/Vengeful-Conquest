using UnityEngine;
using System.Collections;

public class SoldierManagerGUI : MonoBehaviour {

  public Texture soldierManagerScreen;
  private DataScript data;
  
  private Soldiers currentSoldier;
  private string oldObjectName;
  
  bool showSoldierManager = false;
  Object sourceScript; //script that this window was called from
  
  private Rect nameField = new Rect(137, 110, 231, 38);
  private Rect cancelButton = new Rect(30, 427, 162, 42);
  private Rect acceptButton = new Rect(508, 427, 162, 43);

	// Use this for initialization
	void Start () {
  
    data = GameObject.Find ("Data").GetComponent<DataScript>();
    
    nameField.x += data.guiWindow.x;
    nameField.y += data.guiWindow.y;
    
    cancelButton.x += data.guiWindow.x;
    cancelButton.y += data.guiWindow.y;
    
    acceptButton.x += data.guiWindow.x;
    acceptButton.y += data.guiWindow.y;

	
	}
	
	// Update is called once per frame
	void Update () {
  
    nameField = data.UpdateRect(nameField);
    cancelButton = data.UpdateRect (cancelButton);
    acceptButton = data.UpdateRect (acceptButton);

  }
  
  void OnGUI () {
  
    if (showSoldierManager == true) {
    
      GUI.DrawTexture (data.guiWindow, soldierManagerScreen);
  
      currentSoldier.soldierName = (GUI.TextField(nameField, currentSoldier.GetName()));
      
      if (GUI.Button(cancelButton, "Cancel")) {
     
        UndoChanges ();
        toggleGUI ();
      
      }
      
      if (GUI.Button (acceptButton, "Accept")) {
      
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
