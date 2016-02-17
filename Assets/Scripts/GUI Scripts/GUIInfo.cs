using UnityEngine;
using System.Collections;

public class GUIInfo : MonoBehaviour {

  public static GUIInfo guiInfo;
  
  private Vector2 screenSize = new Vector2(800,600);
  private Vector2 offset = new Vector2(1,1);
  
  private static Rect constGUIWindow = new Rect(50, 50, 700, 500);
  internal Rect GUIWindow;
  private static float GUIOffset = 50;
  
  public string acceptButtonText = "Accept";
  public string cancelButtonText = "Cancel";
  
  /* Main Menu Variables */
  /* ------------------------------------------------------------------------------*/
  public Texture mainMenuScreen;
  
  private static Rect constNewGameButton = new Rect(GUIOffset + 269, GUIOffset + 319, 162, 43);
  internal Rect newGameButton;
  public string newGameButtonText = "New Game";
  
  private static Rect constLoadGameButton = new Rect(GUIOffset + 269, GUIOffset + 375, 162, 43);
  internal Rect loadGameButton;
  public string loadGameButtonText = "Load Game";
  
  
  /* ------------------------------------------------------------------------------*/

  /* Army Manager Variables */
  /* ------------------------------------------------------------------------------*/
  public Texture armyManagerScreen;
  
  private static Rect constArmyManagerButton = new Rect(0,  550, 50, 50); //button to open the army manager
  internal Rect armyManagerButton;
  public string armyManagerButtonText = "Army";
  
  private static Rect constArmyWindow = new Rect(GUIOffset + 43, GUIOffset + 103, 615, 207); //window where the army buttons are located
  internal Rect armyWindow;
  
  private static Rect constAddSlotButton = new Rect(GUIOffset + 15, GUIOffset + 15, 100, 50); // button to add a soldier slot 
  internal Rect addSlotButton;
  public string addSlotButtonText = "Unlock Slot";
  
  private static Rect constAddSoldierButton = new Rect(GUIOffset + 585, GUIOffset + 15, 100, 50); //button to add a soldier
  internal Rect addSoldierButton;
  public string addSoldierButtonText = "Add Soldier";
  
  private static Rect constPartyButton = new Rect(GUIOffset + 145, GUIOffset + 337, 80, 59); //info of the first party slot button
  internal Rect partyButton;
  private float constPartyButtonGap = 91;
  internal float partyButtonGap;
  
  public static Vector2 armyButtonDimensions = new Vector2(5, 10); //army buttons in the window, row x column
  
  private Rect constArmyButton = new Rect(
    constArmyWindow.x, 
    constArmyWindow.y, 
    constArmyWindow.width / armyButtonDimensions.x,
    constArmyWindow.height / armyButtonDimensions.y
  ); //dynamically changing button rect, based on button dimensions
  internal Rect armyButton;
  
  /* ------------------------------------------------------------------------------*/
  
  /* Kingdom Manager Variables */
  /* ------------------------------------------------------------------------------*/
  public Texture kingdomManagerScreen;
  
  /* ------------------------------------------------------------------------------*/
  
  /* Castle Manager Variables */
  /* ------------------------------------------------------------------------------*/
  public Texture claimedCastleManagerScreen;                   
  public Texture unclaimedCastleManagerScreen;
  
  private static Rect constCastleNameField = new Rect(GUIOffset + 137, GUIOffset + 147, 231, 38);
  internal Rect castleNameField;
  
  private static Rect constCastleLeaderButton = new Rect(GUIOffset + 165, GUIOffset + 202, 80, 59);
  internal Rect castleLeaderButton;
  
  private static Rect constCastleSoldierButton = new Rect(GUIOffset + 178, GUIOffset + 287, 80, 59);
  internal Rect castleSoldierButton;
  private static float castleSoldierButtonGap = 91;
  
  private static Rect constCastleMiddleButton = new Rect(GUIOffset + 262, GUIOffset + 373, 162, 43);
  internal Rect castleMiddleButton;
  
  private static Rect constCastleAcceptButton = new Rect(GUIOffset + 508, GUIOffset + 427, 162, 43);
  internal Rect castleAcceptButton;
  public string castleBattleButtonText = "Battle";
  
  private static Rect constCastleCancelButton = new Rect(GUIOffset + 30, GUIOffset + 427, 162, 43);
  internal Rect castleCancelButton;
  
  /* ------------------------------------------------------------------------------*/
  
  /* Player Creation Variables */
  /* ------------------------------------------------------------------------------*/
  public Texture kingCreationScreen;
  
  private static Rect constPlayerCreationNameField = new Rect (GUIOffset + 146, GUIOffset + 106, 231, 38);
  internal Rect playerCreationNameField;
  
  private static Rect constStartingAbilityButton = new Rect (GUIOffset + 291, GUIOffset + 337, 80, 59);
  internal Rect startingAbilityButton;
  private float constStartingAbilityButtonGap = 91;
  internal float startingAbilityButtonGap;
  
  private static Rect constStartButton = new Rect(GUIOffset + 508, GUIOffset + 427, 162, 43);
  internal Rect startButton;
  public string startButtonText = "Start";
  
  /* ------------------------------------------------------------------------------*/
  
  /* Soldier Manager Variables */
  /* ------------------------------------------------------------------------------*/
  public Texture soldierManagerScreen;
  
  private static Rect constSoldierNameField = new Rect(GUIOffset + 137, GUIOffset + 110, 231, 38);
  internal Rect soldierNameField;
  
  private static Rect constSoldierCancelButton = new Rect(GUIOffset + 30, GUIOffset + 427, 162, 42);
  internal Rect soldierCancelButton;
  public string soldierCancelButtonText = "Cancel";
  
  private static Rect constSoldierAcceptButton = new Rect(GUIOffset + 508, GUIOffset + 427, 162, 43);
  internal Rect soldierAcceptButton;
  public string soldierAcceptButtonText = "Accept";
  
  /* ------------------------------------------------------------------------------*/
  
  /* Ability Bar Variables */
  /* ------------------------------------------------------------------------------*/
  public Texture abilityBarGUI;
  
  private static Rect constAbilityBar = new Rect(50, 450, 700, 100);
  internal Rect abilityBar;
  
  private static Rect constFirstAbilitySlot = new Rect(717, 115, 63, 70);
  internal Rect firstAbilitySlot;
  private float constAbilityBarButtonGap = 67;
  internal float abilityBarButtonGap;
  
  /* ------------------------------------------------------------------------------*/
  
  
  
  void Awake() {
  
    guiInfo = this;
    
    armyButton = new Rect( 
      armyWindow.x,
      armyWindow.y,
      armyWindow.width / armyButtonDimensions.x,
      armyWindow.height / armyButtonDimensions.y
    );
  }

	// Use this for initialization
	void Start () {
  
    UpdateGUIInfo();
	
	}
  
  void UpdateGUIInfo() {
  
    GUIWindow = UpdateValues (constGUIWindow);
    
    armyManagerButton = UpdateValues(constArmyManagerButton);
    armyWindow = UpdateValues(constArmyWindow);
    addSlotButton = UpdateValues (constAddSlotButton);
    addSoldierButton = UpdateValues(constAddSoldierButton);
    partyButton = UpdateValues(constPartyButton);
    armyButton = UpdateValues (constArmyButton);
    partyButtonGap = UpdateValues (constPartyButtonGap, "x");
    
    playerCreationNameField = UpdateValues (constPlayerCreationNameField);
    startingAbilityButton = UpdateValues (constStartingAbilityButton);
    startButton = UpdateValues (constStartButton);
    
    newGameButton = UpdateValues(constNewGameButton);
    loadGameButton = UpdateValues (constLoadGameButton);
    
    soldierNameField = UpdateValues (constSoldierNameField);
    soldierCancelButton = UpdateValues (constSoldierCancelButton);
    soldierAcceptButton = UpdateValues (constSoldierAcceptButton);
    
    castleNameField = UpdateValues (constCastleNameField);
    castleLeaderButton = UpdateValues (constCastleLeaderButton);
    castleSoldierButton = UpdateValues (constCastleSoldierButton);
    castleMiddleButton = UpdateValues (constCastleMiddleButton);
    castleAcceptButton = UpdateValues (constCastleAcceptButton);
    castleCancelButton = UpdateValues (constCastleCancelButton);
    
    abilityBar = UpdateValues(constAbilityBar);
    firstAbilitySlot = UpdateValues (constFirstAbilitySlot);
    abilityBarButtonGap = UpdateValues (constAbilityBarButtonGap, "x");
    
  }
	
	// Update is called once per frame
	void Update () {
  
    if (screenSize.x != Screen.width) {
    
      screenSize.x = Screen.width;
      offset.x = screenSize.x / 800;
      UpdateGUIInfo();

    
    }
    
    if (screenSize.y != Screen.height) {
    
      screenSize.y = Screen.height;
      offset.y = screenSize.y / 600;
      UpdateGUIInfo ();
    
    }
	}
  
  Rect UpdateValues(Rect constRect) {
  
    Rect newRect = new Rect(
      constRect.x * offset.x, 
      constRect.y * offset.y, 
      constRect.width * offset.x,
      constRect.height * offset.y
    );
    
    return newRect;
  
  }
  
  Vector2 UpdateValues (Vector2 constVector) {
  
    Vector2 newVector = new Vector2(
      constVector.x * offset.x,
      constVector.y * offset.y
    );
    
    return newVector;
  
  
  }
  
  float UpdateValues (float constNum, string axis) {
  
    if (axis == "x") {
      return constNum * offset.x;
    }
    
    if (axis == "y") {
      return constNum * offset.y;
    }
   
    else {
    
      return -1;
      
    }
  }
}
