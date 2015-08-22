using UnityEngine;
using System.Collections;

public class ArmyManagerGUI : MonoBehaviour {
  
  public Texture armyManagerScreen;
  
  private DataScript data;
  private ArmyDataScript armyData;
  
  private Rect armyWindow = new Rect(43, 103, 615, 207); //window where the army buttons are located
  
  /* Button Rects */
  private Rect armyManagerButton = new Rect(0, 550, 50, 50); //button to open the army manager
  private Rect addSlotButton = new Rect(15,15, 100, 50); // button to add a soldier slot 
  private Rect addSoldierButton = new Rect(585, 15, 100, 50); //button to add a soldier
  private Rect armyButton; //dynamically changing button rect, based on button dimensions
  private Rect partyButton = new Rect(145, 337, 80, 59); //info of the first party slot button

  /* Struct to hold each button rect and soldier information */
  private struct soldierButton {
    public int soldierIndex; //the soldier number in the army array
    public Rect buttonRect; //the location and dimensions of the button
  }
  
  private soldierButton[] armyButtonsArray; //array of all army buttons
  private soldierButton[] partyButtonsArray; //array of all party buttons
  
  private soldierButton storedButton; //temp button visible during dragging
  
  private soldierButton nullButton; //empty button used for null comparisons
  
  private float firstPartyButtonX;

  private float partyButtonGap;
  
  private Vector2 soldierButtonDimensions = new Vector2(5, 10);
  
  private bool showArmyManager = false;
  
  /* Variables for button drag */
  private bool buttonPressed = false;
  private int partyPressed = -1; //index of pressed party button
  private bool dragging = false;
  private Rect emptyRect;
  private Rect storedRect;
  private Soldiers storedSoldier;
  private Vector2 releasedLoc;
  
  private Vector2 mouseDelta;
  
  void Start() {
  
    armyData = ArmyDataScript.armyData;
  
    nullButton.buttonRect = new Rect(0,0,0,0);
    nullButton.soldierIndex = -1;

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
        
        /* Checks if user pressed a valid soldier button */
        if (!buttonPressed && //ensures that a button is only stored once per press
            IsNullButton(storedButton = CheckArmyPress()) == false && //stores the button and checks null
            storedButton.soldierIndex != -1) {  //makes sure there's an actual soldier there
          
          buttonPressed = true; // a button has been pressed
          
          mouseDelta.x = Event.current.mousePosition.x - storedButton.buttonRect.x;
          mouseDelta.y = Event.current.mousePosition.y - storedButton.buttonRect.y;
          
        }
        
        else if (!buttonPressed && 
                 IsNullButton(storedButton = CheckPartyPress ()) == false &&
                 storedButton.soldierIndex != ArmyDataScript.nullSoldierIndex) {
        
          buttonPressed = true; //a button has been pressed
          
          mouseDelta.x = Event.current.mousePosition.x - storedButton.buttonRect.x;
          mouseDelta.y = Event.current.mousePosition.y - storedButton.buttonRect.y;
        
        }
      }
      
      if (Event.current.type == EventType.MouseUp) {
      
        checkDragRelease(Event.current.mousePosition);
      
        buttonPressed = false; //a button is not being pressed
        partyPressed = -1; //a party button is not being pressed
      
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
        if (armyButtonsArray[i].soldierIndex != ArmyDataScript.nullSoldierIndex) {
 
          if (GUI.Button(armyButtonsArray[i].buttonRect, armyData.GetSoldierName(armyButtonsArray[i].soldierIndex))) {
          
            LoadSoldierData (armyButtonsArray[i].soldierIndex);

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
     
        if (partyButtonsArray[i].soldierIndex != ArmyDataScript.nullSoldierIndex) {
          
          /* Creates the party soldier buttons */
          if (GUI.Button (partyButtonsArray[i].buttonRect, armyData.GetSoldier (partyButtonsArray[i].soldierIndex).GetName ())) {            
            
            LoadSoldierData(partyButtonsArray[i].soldierIndex);
            
          }
        }
          
          /* If no soldier has been slotted*/
        else {
        
          GUI.Button (partyButtonsArray[i].buttonRect, "Drag Here");
          
        }
      }
      
      if (buttonPressed) {
      
        GUI.Button (storedButton.buttonRect, armyData.GetSoldier (storedButton.soldierIndex).GetName ());
      
      }  
    } // end if army manager is open
  } //end OnGUI
  
  public void toggleArmyManager() {
  
    showArmyManager = !showArmyManager;
  
  }
  
  void LoadSoldierData(int soldierIndex) {
 
    SoldierManagerGUI soldierManager = GetComponent<SoldierManagerGUI>();
    soldierManager.toggleGUI(ArmyDataScript.armyData.GetSoldier(soldierIndex), this);
    toggleArmyManager ();
  
  }
  
  void checkDragRelease(Vector2 releaseLoc) {

    if (buttonPressed) {

      for (int i = 0; i < partyButtonsArray.Length; i++) {

        if (partyButtonsArray[i].buttonRect.Contains(releaseLoc)) {
       
            armyData.GetSoldier(storedButton.soldierIndex).MoveToParty(i);
            return;
          
        }
      }
      
      /* If the button was not released in a party slot and the dragged button was a party button */
      if (partyPressed != -1) {
          
        armyData.GetSoldier (storedButton.soldierIndex).MoveToUnassigned(partyPressed);
         
      } 
    }
  }
  
  /* Creates the array of army buttons */
  void buildArmyButtonArray() {
  
    int soldierNum = 0;
  
    for (int y = 0; y < soldierButtonDimensions.y; y++) { 
      for (int x = 0; x < soldierButtonDimensions.x; x++) {
      
        
        armyButtonsArray[soldierNum].buttonRect = armyButton;
        
        if (data.armyData.IsNullSoldier(soldierNum)) {
          
          armyButtonsArray[soldierNum].soldierIndex = ArmyDataScript.nullSoldierIndex;
        }
        
        else {
        
          armyButtonsArray[soldierNum].soldierIndex = soldierNum;
        
        }
        
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
    
      partyButtonsArray[x].soldierIndex = armyData.GetPartySoldier(x);
    
      partyButtonsArray[x].buttonRect = updatedPartyButton;
      updatedPartyButton.x += partyButtonGap;
    }
  }
  
  soldierButton CheckArmyPress() {
  
    for (int i = 0; i < armyButtonsArray.Length; i++) {
    
      if (armyButtonsArray[i].buttonRect.Contains(Event.current.mousePosition)) {
      
        partyPressed = -1; //this was not a party button
        return armyButtonsArray[i];
      
      }
    }
    
    return nullButton;
  }
  
  soldierButton CheckPartyPress() {
  
    for (int i = 0; i < partyButtonsArray.Length; i++) {
    
      if (partyButtonsArray[i].buttonRect.Contains (Event.current.mousePosition)) {
      
        partyPressed = i; //stores the index of the party button
        return partyButtonsArray[i];
        
      }
      
      else {
      
        partyPressed = -1;
        
      }
    }
    
    return nullButton;
  }
  
  bool IsNullButton(soldierButton button) {
  
    if (button.buttonRect == new Rect(0,0,0,0) && button.soldierIndex == -1) {
      return true;
    
    }
  
    else {
  
      return false;
  
    }
  }
}
