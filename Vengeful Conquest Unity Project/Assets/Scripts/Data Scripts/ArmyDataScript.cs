using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ArmyDataScript : MonoBehaviour {

  public UnityEngine.Object soldierObject; //prefab to create soldiers from

  public static ArmyDataScript armyData;
  public static int armyCap = 50; //number of soldiers allowed in player's army
  public static int partyCap = 5; //number of soldiers allowed in player's party
  public static int nullSoldierIndex = -1;

  /* Data To Save */
  
  private int armySize = 0; //total number of soldiers in player's army
  private int armySlots = 0; //number of open army slots
  private int lockedArmySlots = armyCap; //number of locked army slots
  
  private int partySize = 0; //total number of soldiers in player's party
  private int partySlots = 0; //total number of open party slots
  private int lockedPartySlots = partyCap; //number of locked party slots]
  private int[] partySoldiers = new int[partyCap];
  
  /* End Data To Save */
 
  /* Army Soldier Array */
  public Soldiers[] armyArray = new Soldiers[armyCap];
    
	/* Party Soldier Array */
  
	void Awake() {
  
    /* Initialzes all elements of party soldiers to -1 */
    for (int i = 0; i < partySoldiers.Length; i++) {
    
      partySoldiers[i] = nullSoldierIndex;
    
    }
  }
	
  /* Sets the static variable armyData to this instance of the script */
	void Start() {
  
    armyData = this;
  
	
	}
  
  void Update() {
  
  
  }
  
  /* Adds an additional army slot */
  public int UnlockArmySlot() {
  
    /* If there's room for another slot */
    if (armySize < armyCap) {
  
      lockedArmySlots--; //decrements locked army slots
      return armySlots++; //returns index of new slot and increments available army slots
    
    }
    
    else {
    
      return -1; //could not add slot
    
    }
  }
  
  /* Unlock an additional party slot */
  public int UnlockPartySlot() {
  
    /* If there's room for another party soldier */
    if (partySize < partyCap) {
    
      lockedPartySlots--; //decrements locked party slots
      return partySlots++; //returns index of new slot and increments available party slots
    }
    
    /* No party slots available */
    else {
    
      return -1;
      
    }
  }
  
  /* Add a new unnamed soldier */
  public Soldiers AddSoldier() {
  
    /* Checks that there's a free army slot */
    if (armySize < armySlots) {
  
      /* Creates a new soldier object */
      GameObject newSoldier = (GameObject)Instantiate(soldierObject);
    
      armyArray[armySize] = newSoldier.GetComponent<Soldiers>(); //grabs the soldier component
      armyArray[armySize].SetName ("Unnamed"); //sets the soldier to an unnamed soldier
      armyArray[armySize].SetNumber (armySize); //sets the soldier index
      armyArray[armySize].transform.parent = transform; //places the soldier under the army data object
    
      return armyArray[armySize++]; //returns new soldier and increments the army size

    }
    
    else {
    
      return null;
      
    }
  }
  
  /* Add soldier with a given name */
  public Soldiers AddSoldier(string newSoldierName) {
  
    /* Creates a new soldier object */
    GameObject newSoldier = (GameObject)Instantiate(soldierObject);
    
    armyArray[armySize] = newSoldier.GetComponent<Soldiers>(); //grabs the new soldier component
    armyArray[armySize].SetName (newSoldierName); //Sets the soldier name to the passed soldier
    armyArray[armySize].SetNumber (armySize); //sets the soldier index
    
    return armyArray[armySize++]; //returns the new soldier and increments the army size
  
  }
  
  /* Sets a soldier's name */
  public void SetSoldierName(int soldierIndex, string name) {
  
    /* Sets the name of the soldier located at the passed index */
    armyArray[soldierIndex].SetName (name);
  
  }
  
  /* Returns a soldier name */
  public string GetSoldierName(int soldierIndex) {
  
    return armyArray[soldierIndex].GetName (); //returns the soldier name at passed index
  
  }
  
  /* Returns the soldier script at the passed index */
  public Soldiers GetSoldier(int soldierIndex) {
  
    return armyArray[soldierIndex]; //soldier script at index
  
  }

  /* Returns the size of the army */  
  public int GetArmySize() {
  
    return armySize; //size of the army
    
  }
  
  /* Returns the size of the party */
  public int GetPartySize() {
  
    return partySize; //size of the party
  
  }
  
  /* Sets a soldier index to the passed party index */
  public void SetPartySoldier(int soldierIndex, int partyIndex) {
  
    // Places the soldier army index into the party array
    partySoldiers[partyIndex] = soldierIndex;
    
    CheckPartyDuplicates(partyIndex); // Checks for duplicate soldiers in the party
  
  }
  
  /* Returns the soldier index at the passed party index  */
  public int GetPartySoldier(int partyIndex) {
  
    return partySoldiers[partyIndex]; //returns the soldier index
  
  }
  
  /* Removes a soldier from the party array */
  public void RemovePartySoldier(int partyIndex) {
  
    partySoldiers[partyIndex] = nullSoldierIndex; //sets the soldier index to -1
  
  }
  
  /* Checks for duplicates in the player's party */
  public void CheckPartyDuplicates(int newPartyIndex) {

    /* Loops through each element of the party index */  
    for (int otherIndeces = 0; otherIndeces < partySoldiers.Length; otherIndeces++) {

      /* If the soldier index is a duplicate */
      if (newPartyIndex != otherIndeces && partySoldiers[newPartyIndex] == partySoldiers[otherIndeces]) {
      
        partySoldiers[otherIndeces] = nullSoldierIndex; //sets the party element to -1
      
      }
    }
  }
  
  /* Swaps two soldiers in the party */
  public void SwapPartySoldiers(int partyIndex1, int partyIndex2) {
  
    /* Stores the army soldier indeces */
    int soldierNumber1 = partySoldiers[partyIndex1];
    int soldierNumber2 = partySoldiers[partyIndex2];  
    
    /* Moves soldier1 to the party index of the second soldier */
    armyArray[soldierNumber1].MoveToParty (partyIndex2);
    
    /* Moves soldier2 to the party index of the first soldier */
    armyArray[soldierNumber2].MoveToParty (partyIndex1);
    
  }
  
  /* Checks if a soldier exists */
  public bool IsNullSoldier(int armyIndex) { 
  
    /* checks the index in the army array */
    if (armyArray[armyIndex] == null) {
    
      return true; //there was no soldier at the index
      
    }
    
    else {
    
      return false; //there was a soldier in the array
    }
  }
  
  /* Returns the number of empty army slots */
  public int GetEmptyArmySlots() {
  
    return armySlots - armySize; //number of empty army slots
    
  }
  
  /* Returns the number of empty party slots */
  public int GetEmptyPartySlots() {
  
    return partySlots - partySize; //number of empty party slots
  
  }
  
  /* Saves the data to a file when called */
  public void Save() {
    
    BinaryFormatter formatter = new BinaryFormatter();
    
    Directory.CreateDirectory (DataScript.armyDir); //creates a new folder to save data
    FileStream file = File.Create (DataScript.armyFile); //creates a new file to save data
    
    ArmyData savedData = new ArmyData(); //creates a new instance of the army data
    
    /* Data to save -- saves current army data into new instance*/
    
    savedData.armySize = armySize;;
    savedData.armySlots = armySlots;
    savedData.lockedArmySlots = lockedArmySlots;
    
    savedData.partySize = partySize;
    savedData.partySlots = partySlots;
    savedData.lockedPartySlots = lockedPartySlots;
    savedData.partySoldiers = partySoldiers;
    
    /* Calls the save method of each individual soldier */
    for (int i = 0; i < armySize; i++) {
    
      armyArray[i].Save (i);
    
    }

    formatter.Serialize (file, savedData); //save the data
    file.Close(); //close the file
    
  }
  
  /* Loads the data from a file */
  public void Load() {
    
    if (File.Exists(DataScript.armyFile)) { //checks that the load file exists
      
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream file = File.Open (DataScript.armyFile, FileMode.Open); //opens the file
      ArmyData savedData = (ArmyData)formatter.Deserialize (file); //loads the saved ArmyData
      file.Close (); //closes the file
      
      /* Data to load -- sets the current data to the saved data*/
      armySlots = savedData.armySlots;
      lockedArmySlots = savedData.lockedArmySlots;
      
      partySize = savedData.partySize;
      partySlots = savedData.partySlots;
      lockedPartySlots = savedData.lockedPartySlots;
      partySoldiers = savedData.partySoldiers;
      
      /* Loads all saved soldiers */
      for (int i = 0; i < savedData.armySize; i++) {
        AddSoldier ();
        armyArray[i].Load (i);
       
      }
    }
  }
}

/* Class to save army data */
[Serializable]
class ArmyData {

  public int armySize; //total number of soldiers in player's army
  public int armySlots; //number of open army slots
  public int lockedArmySlots; //number of locked army slots
  
  public int partySize; //total number of soldiers in player's party
  public int partySlots; //total number of open party slots
  public int lockedPartySlots; //number of locked party slots
  public int[] partySoldiers;
  
}
