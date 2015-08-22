using UnityEngine;
using System.Collections;

public class ArmyManagerGUI : MonoBehaviour {
  
  public Texture armyManagerScreen;
  
  private DataScript data;
  
  private Rect armyManagerButton = new Rect(0, 550, 50, 50);
  private Rect addSlotButton = new Rect(0,0, 100, 100);
  private Rect addSoldierButton = new Rect(600, 0, 100, 100);
  
  private Rect armyButton;
  
  private Rect armyWindow = new Rect(43, 103, 615, 207);
  
  private Vector2 xButtonSize;
  private Rect xButton;
  
  private struct soldierButton {
    public Soldiers soldierScript;
    public Rect buttonRect;
  }
  private soldierButton[] armyButtonsArray;
  private soldierButton[] partyButtonsArray;
  private soldierButton storedButton;
  private soldierButton nullButton;
  
  private Rect partyButton = new Rect(145, 337, 80, 59);
  private float firstPartyButtonX;

  private float partyButtonGap;
  
  private Vector2 soldierButtonDimensions = new Vector2(5, 10);
//  private Vector2 soldierButtonGap;
  
  private int soldierNum = 0; //index to loop through entire army array
  
  private bool showArmyManager = false;
  
  /* Variables for button drag */
  private bool buttonPressed = false;
  private bool partyPressed = false;
  private bool dragging = false;
  private Rect emptyRect;
  private Rect storedRect;
  private Soldiers storedSoldier;
  private Vector2 releasedLoc;
  
  private Vector2 mouseDelta;
  
  void Start() {
  
    nullButton.buttonRect = new Rect(0,0,0,0);
    nullButton.soldierScript = null;

    data = DataScript.data;
    partyButtonsArray = new soldierButton[ArmyDataScript.partyCap];
    armyButtonsArray = new soldierButton[ArmyDataScript.armyCap];
    
    partyButton.x += DataScript.data.guiWindow.x;
    partyButton.y += data.guiWindow.y;
    
    armyWindow.x += data.guiWindow.x;
    armyWindow.y += data.guiWindow.y;
    
    addSlotButton.x += data.guiWindow.x;
    addSlotButton.y += data.guiWindow.y;
   
    addSoldierButton.x += data.guiWindow.x;
    addSoldierButton.y += data.guiWindow.y;
   
  }
  
  void Update() {
  
    buildArmyButtonArray();
    buildPartyButtonArray();
    
    armyButton = new Rect( 
      data.UpdateRect (armyWindow).x,
      data.UpdateRect (armyWindow).y,
      (data.UpdateRect (armyWindow).width / soldierButtonDimensions.x),
      (data.UpdateRect (armyWindow).height / soldierButtonDimensions.y)
    );
    
    partyButtonGap = 91 * data.screenOffset.x;
    
    firstPartyButtonX = partyButton.x;
    
  }
  
  void OnGUI() {
  
    GUI.skin.button.wordWrap = true;

    if (GUI.Button (data.UpdateRect (armyManagerButton), "Army"))  
    {
    
      toggleArmyManager ();
        
    }
    
    if (GUI.Button (new Rect(750, 0, 50, 50), "Save")) {
    
      data.SaveData();
    
    }
    
    if (showArmyManager) {
    
      GUI.DrawTexture (data.guiWindow, armyManagerScreen);
      
      if (Event.current.type == EventType.MouseDown) {
        
        if (!buttonPressed && 
            IsNullButton(storedButton = CheckArmyPress()) == false && 
            storedButton.soldierScript != null) {
          
          buttonPressed = true;
          
          mouseDelta.x = Event.current.mousePosition.x - storedButton.buttonRect.x;
          mouseDelta.y = Event.current.mousePosition.y - storedButton.buttonRect.y;
          
        }
        
        else if (!buttonPressed && 
                 IsNullButton(storedButton = CheckPartyPress ()) == false &&
                 storedButton.soldierScript != null) {
        
          buttonPressed = true;
          partyPressed = true;
          
          mouseDelta.x = Event.current.mousePosition.x - storedButton.buttonRect.x;
          mouseDelta.y = Event.current.mousePosition.y - storedButton.buttonRect.y;
        
        }
      }
      
      if (Event.current.type == EventType.MouseUp) {
      
        checkDragRelease(Event.current.mousePosition);
      
        buttonPressed = false;
        partyPressed = false;
      
      }
      
      if (Event.current.type == EventType.MouseDrag) {
      
        storedButton.buttonRect.x = Event.current.mousePosition.x - mouseDelta.x;
        storedButton.buttonRect.y = Event.current.mousePosition.y - mouseDelta.y;
      
      }
      
      if (GUI.Button (addSlotButton, "Unlock Slot")) {
      
        data.armyData.UnlockArmySlot();
      
      }
      
      if (GUI.Button (addSoldierButton, "Add Soldier")) {
      
        data.armyData.AddSoldier();
      
      }
      
      int emptySlots = data.armyData.GetEmptyArmySlots();
      for (int i = 0; i < ArmyDataScript.armyCap; i++) {
        
        //if the button is a valid soldier
        if (armyButtonsArray[i].soldierScript != null) {
 
          if (GUI.Button(armyButtonsArray[i].buttonRect, armyButtonsArray[i].soldierScript.GetName())) {
          
            loadSoldierData (armyButtonsArray[i].soldierScript);

          }
        }
          
        /* If a new soldier slot is available */
        else if (emptySlots != 0) {
        
          if (GUI.Button(armyButtonsArray[i].buttonRect, "Empty Slot")) {
            
            data.armyData.AddSoldier ();
          
          }
          
          emptySlots--;
          
        }
        
        /* If the soldier slot is locked */
        else {
        
          GUI.Button(armyButtonsArray[i].buttonRect, "Locked");
        
        }
      }
      
      /* loops through each party button */
      for (int i = 0; i < ArmyDataScript.partyCap; i++) {
     
        if (partyButtonsArray[i].soldierScript != null) {
          
          /* Creates the party soldier buttons */
          if (GUI.Button (data.UpdateRect(partyButtonsArray[i].buttonRect), 
                          partyButtonsArray[i].soldierScript.GetName ())) {            
            
            loadSoldierData(partyButtonsArray[i].soldierScript);
            
          }
        }
          
          /* If no soldier has been slotted*/
        else {
        
          GUI.Button (data.UpdateRect (partyButtonsArray[i].buttonRect), "Drag Here");
          
        }
      }
      
      if (buttonPressed) {
      
        GUI.Button (data.UpdateRect(storedButton.buttonRect), storedButton.soldierScript.GetName ());
      
      }
      
    } // end if army manager is open
  } //end OnGUI
  
  public void toggleArmyManager() {
  
    showArmyManager = !showArmyManager;
  
  }
  
  void checkDuplicates(int partyIndex) {
  
    for (int i = 0; i < partyButtonsArray.Length; i++) {
    
      if (i != partyIndex && 
          partyButtonsArray[i].soldierScript == partyButtonsArray[partyIndex].soldierScript
      ) {
      
        partyButtonsArray[i].soldierScript = null;
        
      }
    }
  }
  
  void loadSoldierData(Soldiers soldierData) {
 
    SoldierManagerGUI soldierManager = GetComponent<SoldierManagerGUI>();
    soldierManager.toggleGUI(soldierData, this);
    toggleArmyManager ();
  
  }
  
  void checkDragRelease(Vector2 releaseLoc) {

    for (int i = 0; i < partyButtonsArray.Length; i++) {
   
      if (buttonPressed) {
   
        if (partyButtonsArray[i].buttonRect.Contains(releaseLoc)) {
        
          partyButtonsArray[i].soldierScript = storedButton.soldierScript;
          partyButtonsArray[i].soldierScript.MoveToParty(i);
          checkDuplicates(i);
          
        }
        
        else if (partyPressed && (partyButtonsArray[i].soldierScript == storedButton.soldierScript)) {
        
          partyButtonsArray[i].soldierScript = null;
        
        }
      }
    }
  }
  
  /* Creates the array of army buttons */
  void buildArmyButtonArray() {
  
    for (int y = 0; y < soldierButtonDimensions.y; y++) { 
      for (int x = 0; x < soldierButtonDimensions.x; x++) {
        
        armyButtonsArray[soldierNum].buttonRect = armyButton;
        armyButtonsArray[soldierNum].soldierScript = data.armyData.armyArray[soldierNum];
        armyButton.x += armyButton.width;
        soldierNum++;
        
      }
      
      armyButton.x = armyWindow.x;
      armyButton.y += armyButton.height;
    }
    
    soldierNum = 0;

  }
  
  void buildPartyButtonArray() {
  
    Rect updatedPartyButton = partyButton;
    
    for (int x = 0; x < ArmyDataScript.partyCap; x++) {
    
      partyButtonsArray[x].buttonRect = updatedPartyButton;
      updatedPartyButton.x += partyButtonGap;
     
      if (partyButtonsArray[x].soldierScript != null) {
      
        partyButtonsArray[x].soldierScript = data.armyData.armyArray[partyButtonsArray[x].soldierScript.soldierNumber];
      
      }
    }
  }
  
  soldierButton CheckArmyPress() {
  
    for (int i = 0; i < armyButtonsArray.Length; i++) {
    
      if (armyButtonsArray[i].buttonRect.Contains(Event.current.mousePosition)) {
      
        return armyButtonsArray[i];
      
      }
    }
    
    return nullButton;
  }
  
  soldierButton CheckPartyPress() {
  
    for (int i = 0; i < partyButtonsArray.Length; i++) {
    
      if (partyButtonsArray[i].buttonRect.Contains (Event.current.mousePosition)) {
      
        return partyButtonsArray[i];
        
      }
    }
    
    return nullButton;
  }
  
  bool IsNullButton(soldierButton button) {
  
    if (button.buttonRect == new Rect(0,0,0,0) && button.soldierScript == null) {
      return true;
    
    }
  
    else {
  
      return false;
  
    }
  }
}
