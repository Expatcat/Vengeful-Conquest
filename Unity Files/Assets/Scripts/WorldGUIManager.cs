using UnityEngine;
using System.Collections;

public class WorldGUIManager : MonoBehaviour {
  
  //GUI textures
  public Texture ArmyManagerFull, ArmyManagerBlank; //two different states of army manager GUI
  private Texture ArmyManager; //active state
  
  private GUIStyle guiStyle = new GUIStyle();
  
  //Data Information
  private DataScript data; private ArmyDataScript armyData; private CastleDataScript castleData;
  
  //Soldier Variables
  private Soldiers soldier1, soldier2, soldier3, soldier4, soldier5;
  
  //Castle Variables
  private Castles selectedCastle, castle1, castle2, castle3, castle4, castle5, castle6, castle7,
    castle8, castle9, castle10, castle11, castle12, castle13, castle14, castle15, castle16,
    castle17, castle18, castle19, castle20;
  
  //GUI display booleans
  private bool displayArmyManager = false;
  
  //GUI constants
  private static float guiXStart, guiYStart, guiWidth = 700, guiHeight = 500;
  
  //ArmyManager button info
  private static float soldierButtonWidth = 74, soldierButtonHeight = 64, button1X, button1Y, button2X, 
   button2Y, button3X, button3Y, button4X, button4Y, button5X, button5Y, button6X, button6Y, 
   button7X, button7Y, button8X, button8Y, button9X, button9Y, button10X, button10Y;
   
  //Castle button info (For ArmyManager)
  private static float castleButtonWidth, castleButtonHeight, castleBackWidth, castleBackHeight,
    castleSelectedWidth, castleSelectedHeight, castleBackX, castleBackY, castleSelectedX, castleSelectedY, 
    castle1X, castle1Y, castle2X, castle2Y, castle3X, castle3Y, castle4X, castle4Y, castle5X, castle5Y,
    castle6X, castle6Y, castle7X, castle7Y, castle8X, castle8Y, castle9X, castle9Y, castle10X, castle10Y,
	castle11X, castle11Y, castle12X, castle12Y, castle13X, castle13Y, castle14X, castle14Y, castle15X, castle15Y,
	castle16X, castle16Y, castle17X, castle17Y, castle18X, castle18Y, castle19X, castle19Y, castle20X, castle20Y;
    
  
  
  /* runs at the beginning */
  void Start() {
  
    //calls the load data method
    loadData();
  
    //sets the GUI size relative to screen size
    guiXStart = (Screen.width / 2) - 350;
    guiYStart = (Screen.height / 2) - 250;
    
    //sets up the GUI variables
    initializeArmyManager(); //army manager variables initalized      
    
  }

  /* runs every frame */		
  void Update() {
 
    //checks for the Army Manager keypress 
    if (Input.GetKeyDown("t"))
      displayArmyManager = toggleGUI (displayArmyManager); //calls toggleGUI with boolean
  }		

  /* displays screen GUI's */
  void OnGUI() {
  
     GUI.skin.button.wordWrap = true;

     //Army Manager GUI
     if (displayArmyManager) {
       GUI.DrawTexture(new Rect(guiXStart, guiYStart, guiWidth, guiHeight), ArmyManager);
       
       //shows party soldier names
       for (int i = 0; i < armyData.partySoldiers.Length; i++) {
       
         //checks if the soldier is active
         if (armyData.partySoldiers[i].GetComponent<Soldiers>().active == false)
            armyData.partySoldiers[i].GetComponent<Soldiers>().soldierName = "Add Soldier";
       
       }
       
       for (int i = 0; i < castleData.castlesArray.Length; i++) {
       
         if(castleData.castlesArray[i].GetComponent<Castles>().claimed == false)
           castleData.castlesArray[i].GetComponent<Castles>().castleName = "Unclaimed";
           
       }
       
       if (GUI.Button(new Rect(button1X, button1Y, soldierButtonWidth, soldierButtonHeight), 
         soldier1.soldierName)) {
        
       }
       
       if (GUI.Button(new Rect(button2X, button2Y, soldierButtonWidth, soldierButtonHeight), 
         soldier2.soldierName)) {
        
	   }
			
	   if (GUI.Button(new Rect(button3X, button3Y, soldierButtonWidth, soldierButtonHeight), 
	     soldier3.soldierName)) {
				
	   }
	   
		if (GUI.Button(new Rect(button4X, button4Y, soldierButtonWidth, soldierButtonHeight), 
          soldier4.soldierName)) {
				
	   }
	   
	   if (GUI.Button(new Rect(button5X, button5Y, soldierButtonWidth, soldierButtonHeight), 
	     soldier5.soldierName)) {
				
	   }
       
       
       //Displays castles to check troops
       if (ArmyManager == ArmyManagerBlank) { //checks if a castle button has already been pressed  
         if (GUI.Button (new Rect(castle1X, castle1Y, castleButtonWidth, castleButtonHeight), castle1.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle1; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle2X, castle2Y, castleButtonWidth, castleButtonHeight), castle2.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle2; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle3X, castle3Y, castleButtonWidth, castleButtonHeight), castle3.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle3; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle4X, castle4Y, castleButtonWidth, castleButtonHeight), castle4.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle4; //keeps track of the pressed castle
         } 
         
         if (GUI.Button (new Rect(castle5X, castle5Y, castleButtonWidth, castleButtonHeight), castle5.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle5; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle6X, castle6Y, castleButtonWidth, castleButtonHeight), castle6.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle6; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle7X, castle7Y, castleButtonWidth, castleButtonHeight), castle7.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle7; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle8X, castle8Y, castleButtonWidth, castleButtonHeight), castle8.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle8; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle9X, castle9Y, castleButtonWidth, castleButtonHeight), castle9.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle9; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle10X, castle10Y, castleButtonWidth, castleButtonHeight), castle10.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle10; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle11X, castle11Y, castleButtonWidth, castleButtonHeight), castle11.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle11; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle12X, castle12Y, castleButtonWidth, castleButtonHeight), castle12.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle12; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle13X, castle13Y, castleButtonWidth, castleButtonHeight), castle13.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle13; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle14X, castle14Y, castleButtonWidth, castleButtonHeight), castle14.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle14; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle15X, castle15Y, castleButtonWidth, castleButtonHeight), castle15.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle15; //keeps track of the pressed castle
         } 
         
         if (GUI.Button (new Rect(castle16X, castle16Y, castleButtonWidth, castleButtonHeight), castle16.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle16; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle17X, castle17Y, castleButtonWidth, castleButtonHeight), castle17.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle17; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle18X, castle18Y, castleButtonWidth, castleButtonHeight), castle18.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle18; //keeps track of the pressed castle
         }
         
         if (GUI.Button (new Rect(castle19X, castle19Y, castleButtonWidth, castleButtonHeight), castle19.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle19; //keeps track of the pressed castle
         }   
         
         if (GUI.Button (new Rect(castle20X, castle20Y, castleButtonWidth, castleButtonHeight), castle20.castleName)) {
           ArmyManager = ArmyManagerFull; //shows troops in the castle
           selectedCastle = castle20; //keeps track of the pressed castle
         }         
                           
       }
       
       //user clicked on a castle to check troops
       else {
       
         //Chosen castle info
         guiStyle.fontSize = 11;
         GUI.Label(new Rect(castleSelectedX, castleSelectedY, castleSelectedWidth, castleSelectedHeight), 
           "Selected Castle: " + selectedCastle.castleName, guiStyle);
       
         //back button from castle choice
         if (GUI.Button (new Rect(castleBackX, castleBackY, castleBackWidth, castleBackHeight), "Back")) {
         
           ArmyManager = ArmyManagerBlank; //goes back to initial army manager GUI
           selectedCastle = null; //sets the selected castle to null
         
         }
       
       }
     }
  }
  
  /* toggles the passed boolean GUI on and off */
  bool toggleGUI(bool guiName) {
    return !guiName;
  }
  
  /* initalizes all the button values for the army manager */
  void initializeArmyManager() {
  
    int castleXGap = 112;
    int castleYGap = 22;
    int buttonGap = 104;
  
    //initial army manager window 
    ArmyManager = ArmyManagerBlank;
  
    //army button offsets
    button1X = guiXStart + 98; //1st button X offset
    button1Y = guiYStart + 208;  //1st button Y offset
    button2X = button1X + buttonGap;
    button2Y = button1Y;
    button3X = button2X + buttonGap;
    button3Y = button2Y;
    button4X = button3X + buttonGap;
    button4Y = button3Y;
    button5X = button4X + buttonGap;
    button5Y = button4Y;
    
    /* castle button sizes and offsets */
    castleButtonWidth = 112; castleButtonHeight = 20; //castle button size
    castleBackWidth = 50; castleBackHeight = 20; castleBackX = guiXStart + 50;  castleBackY = guiXStart + 303; //castle back button
	castleSelectedWidth = 140; castleSelectedHeight = 30; castleSelectedX = guiXStart + 460; castleSelectedY = guiYStart + 310;
	
    castle1X = guiXStart + 65; castle1Y = guiYStart + 343; //1st castle button offset
    castle2X = castle1X + castleXGap; castle2Y = castle1Y;
    castle3X = castle2X + castleXGap; castle3Y = castle1Y;
    castle4X = castle3X + castleXGap; castle4Y = castle1Y;
	castle5X = castle4X + castleXGap; castle5Y = castle1Y;
	
	castle6X = castle1X; castle6Y = castle1Y + castleYGap;
	castle7X = castle2X; castle7Y = castle6Y;
	castle8X = castle3X; castle8Y = castle6Y;
	castle9X = castle4X; castle9Y = castle6Y;
	castle10X = castle5X; castle10Y = castle6Y;
	
	castle11X = castle1X; castle11Y = castle6Y + castleYGap;
	castle12X = castle2X; castle12Y = castle11Y;
	castle13X = castle3X; castle13Y = castle11Y;
	castle14X = castle4X; castle14Y = castle11Y;
	castle15X = castle5X; castle15Y = castle11Y;
	
	castle16X = castle1X; castle16Y = castle11Y + castleYGap;
	castle17X = castle2X; castle17Y = castle16Y;
	castle18X = castle3X; castle18Y = castle16Y;
	castle19X = castle4X; castle19Y = castle16Y;
	castle20X = castle5X; castle20Y = castle16Y;
    
    
  }
  
  /* Loads data from the data object */
  void loadData() {
  
    //loads data object
    data = GameObject.Find ("Data").GetComponent<DataScript>();
    
    //load the data by calling getData with String name
	armyData = (ArmyDataScript)data.getData ("Army Data");
	castleData = (CastleDataScript)data.getData("Castle Data");
    
    //loads the soldiers array
	soldier1 = armyData.partySoldiers[0].GetComponent<Soldiers>();
	soldier2 = armyData.partySoldiers[1].GetComponent<Soldiers>();
	soldier3 = armyData.partySoldiers[2].GetComponent<Soldiers>();
	soldier4 = armyData.partySoldiers[3].GetComponent<Soldiers>();
	soldier5 = armyData.partySoldiers[4].GetComponent<Soldiers>();
	
	//loads the castles array
	castle1 = castleData.castlesArray[0].GetComponent<Castles>();
	castle2 = castleData.castlesArray[1].GetComponent<Castles>();
	castle3 = castleData.castlesArray[2].GetComponent<Castles>();
	castle4 = castleData.castlesArray[3].GetComponent<Castles>();
	castle5 = castleData.castlesArray[4].GetComponent<Castles>();
	castle6 = castleData.castlesArray[5].GetComponent<Castles>();
	castle7 = castleData.castlesArray[6].GetComponent<Castles>();
	castle8 = castleData.castlesArray[7].GetComponent<Castles>();
	castle9 = castleData.castlesArray[8].GetComponent<Castles>();
	castle10 = castleData.castlesArray[9].GetComponent<Castles>();
	castle11 = castleData.castlesArray[10].GetComponent<Castles>();
	castle12 = castleData.castlesArray[11].GetComponent<Castles>();
	castle13 = castleData.castlesArray[12].GetComponent<Castles>();
	castle14 = castleData.castlesArray[13].GetComponent<Castles>();
	castle15 = castleData.castlesArray[14].GetComponent<Castles>();
	castle16 = castleData.castlesArray[15].GetComponent<Castles>();
	castle17 = castleData.castlesArray[16].GetComponent<Castles>();
	castle18 = castleData.castlesArray[17].GetComponent<Castles>();
	castle19= castleData.castlesArray[18].GetComponent<Castles>();
	castle20 = castleData.castlesArray[19].GetComponent<Castles>();

	
  }
   
}
