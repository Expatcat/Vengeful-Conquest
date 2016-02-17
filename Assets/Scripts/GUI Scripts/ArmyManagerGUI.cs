using UnityEngine;
using System.Collections;

/* Class to handle the Army Manager GUI, that displays army information and allows the user to
 * drag and change party soldiers */
public class ArmyManagerGUI : MonoBehaviour {
  
  public Texture armyManagerScreen; //the actual GUI
  
  private DataScript data; //the data script
  private ArmyDataScript armyData; //the army data script


  /* Struct to hold each button rect and soldier information */
  private struct soldierButton {
    public int soldierIndex; //the soldier number in the army array
    public Rect buttonRect; //the location and dimensions of the button
  }
  
  private soldierButton[] armyButtonsArray; //array of all army buttons
  private soldierButton[] partyButtonsArray; //array of all party buttons
  
  private soldierButton storedButton; //temp button visible during dragging
  
  private soldierButton nullButton; //empty button used for null comparisons
  
  private bool showArmyManager = false; //boolean to toggle the GUI
  
  /* Variables for button drag */
  private bool buttonPressed = false; //if the user clicked on a button
  private int partyPressed = -1; //index of pressed party button
  private Vector2 mouseDelta; //the mouse location relative to the rest of the dragged button
  
  void Start() {
  
    data = DataScript.data; //sets the data variable
    armyData = ArmyDataScript.armyData; //sets the armyData variable
  
    /* Sets a null button */
    nullButton.buttonRect = new Rect(0,0,0,0); 
    nullButton.soldierIndex = -1;

    //creates an array of party buttons 
    partyButtonsArray = new soldierButton[ArmyDataScript.partyCap];
    
    //creates an array of army buttons that will be displayed
    armyButtonsArray = new soldierButton[ArmyDataScript.armyCap];
   
  }
  
  void Update() {
  
    buildArmyButtonArray(); //creates the array of army buttons that display
    buildPartyButtonArray(); //creates the array of party buttons that display

  }
  
  /* Displays on the GUI */
  void OnGUI() {
  
    GUI.skin.button.wordWrap = true; //words wrap to next lines

    //Displays an "Army" button that the user presses to open up the army window
    if (GUI.Button (GUIInfo.guiInfo.armyManagerButton, GUIInfo.guiInfo.armyManagerButtonText)) {
    
      toggleArmyManager ();
        
    }
    
    //Displays the save button
    //TODO: Remove this later
    if (GUI.Button (new Rect(750, 0, 50, 50), "Save")) {
    
      data.SaveData();
    
    }
    
    if (showArmyManager) { //displays the entire Army Manager GUI
    
      GUI.DrawTexture (GUIInfo.guiInfo.GUIWindow, armyManagerScreen); //shows the Army Manager screen
      
      if (Event.current.type == EventType.MouseDown) { //checks if the user presses down
        
        /* Checks if user pressed a valid soldier button */
        if (!buttonPressed && //ensures that a button is only stored once per press
            IsNullButton(storedButton = CheckArmyPress()) == false && //stores the button and checks null
            storedButton.soldierIndex != -1) {  //makes sure there's an actual soldier there
          
          buttonPressed = true; // a button has been pressed
          
          /* stores distance from mouse to the top left corner of the pressed button */
          mouseDelta.x = Event.current.mousePosition.x - storedButton.buttonRect.x;
          mouseDelta.y = Event.current.mousePosition.y - storedButton.buttonRect.y;
          
        }
       
        else if (!buttonPressed && //if button wasnt pressed efore
                 IsNullButton(storedButton = CheckPartyPress ()) == false && //button isnt null and is party pressed
                 storedButton.soldierIndex != ArmyDataScript.nullSoldierIndex) { //soldier is there
        
          buttonPressed = true; //a button has been pressed
          
          /* Stores distance from mouse to top left corner of pressed button */
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
      
      if (GUI.Button (GUIInfo.guiInfo.addSlotButton, GUIInfo.guiInfo.addSlotButtonText)) {
      
        data.armyData.UnlockArmySlot();
      
      }
      
      if (GUI.Button (GUIInfo.guiInfo.addSoldierButton, GUIInfo.guiInfo.addSoldierButtonText)) {
      
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
       
          if (partyPressed != -1 && partyButtonsArray[i].soldierIndex != -1) {
         
            armyData.SwapPartySoldiers(partyPressed, i);
            
         
          }
         
          else {
        
            armyData.GetSoldier(storedButton.soldierIndex).MoveToParty(i);
          }
          
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
    Rect tempArmyButton = GUIInfo.guiInfo.armyButton;
  
    for (int y = 0; y < GUIInfo.armyButtonDimensions.y; y++) { 
    
      for (int x = 0; x < GUIInfo.armyButtonDimensions.x; x++) {
      
        tempArmyButton.x = GUIInfo.guiInfo.armyButton.x + (GUIInfo.guiInfo.armyButton.width * x);
        tempArmyButton.y = GUIInfo.guiInfo.armyButton.y + (GUIInfo.guiInfo.armyButton.height * y);
        
        armyButtonsArray[soldierNum].buttonRect = tempArmyButton;
        
        if (data.armyData.IsNullSoldier(soldierNum)) {
          
          armyButtonsArray[soldierNum].soldierIndex = ArmyDataScript.nullSoldierIndex;
        }
        
        else {
        
          armyButtonsArray[soldierNum].soldierIndex = soldierNum;
        
        }
        
        soldierNum++;
        
      }
    }
    
    tempArmyButton = GUIInfo.guiInfo.armyButton;
    soldierNum = 0;

  }
  
  void buildPartyButtonArray() {
  
    Rect updatedPartyButton = GUIInfo.guiInfo.partyButton;
    
    for (int x = 0; x < ArmyDataScript.partyCap; x++) {
    
      partyButtonsArray[x].soldierIndex = armyData.GetPartySoldier(x);
    
      partyButtonsArray[x].buttonRect = updatedPartyButton;
      updatedPartyButton.x += GUIInfo.guiInfo.partyButtonGap;
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
    
      if (partyPressed == -1 && partyButtonsArray[i].buttonRect.Contains (Event.current.mousePosition)) {
      
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
