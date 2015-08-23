using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/* This script runs on each individual soldier object */
public class Soldiers : MonoBehaviour {

  public static string partyGroup = "Party"; //soldier is in the party 
  public static string unassignedGroup = "Unassigned"; //soldier has no group
  public static string castleGroup = "Castle"; //soldier is in a castle

  private ArmyDataScript armyData; //the army data

  /* Data to save */
  public int soldierNumber; //soldier index relative to army array
	public string soldierName = "Unnamed"; //soldier name
	public int health; //solider health
  private string group = unassignedGroup;
	private string soldierClass; //soldier class - Combat, Defense, Range, Support
  
  private int[] abilities; //array of soldier ability indeces
  
  /* End Data To Save */
  
  
  /* Returns the world position of the soldier */
	public Vector2 GetPosition() {
		
		return this.transform.position;
		
	}
  
  void Start() {
  
    armyData = DataScript.data.armyData; //sets the army data
  
  }
	
	void Update() {

	}
  
  /* Moves the soldier to the player's party */
  public void MoveToParty(int partyIndex) {

    // Calls the set party method in the army data script  
    armyData.SetPartySoldier(soldierNumber, partyIndex);

    group = partyGroup; //sets the soldier group to the party group

  }
  
  /* Moves the soldier to a castle */
  void MoveToCastle(int castleIndex) {
  
  
  }
  
  /* Moves the soldier to the unassigned group */
  public void MoveToUnassigned(int groupIndex) {
    
    /* If the soldier was in the player's party */
    if (group == partyGroup) {
    
      armyData.RemovePartySoldier(groupIndex); //removes soldier from party
    
    }
    
    /* If the soldier was in a castle */
    else if (group == castleGroup) {
    
    }
    
    group = unassignedGroup; //sets the player group
    
  }
  
  /* Adds an ability to the soldier */
  public void AddAbility(int ability) {
  
  }
  
  /* Gets the soldier name */
  public string GetName() {
  
    return soldierName; //returns soldier name
  
  }
  
  /* Sets the soldier name */
  public void SetName(string newSoldierName) {
  
    /* Sets solider name and GameObject name */
    soldierName = newSoldierName;
    name = soldierName;
  
  }
  
  /* Sets the group of the soldier */
  public void SetGroup(string newGroup) {
 
    group = newGroup; //updates the group
  
  }
  
  /* Gets the soldier's group */
  public string GetGroup() {
  
    return group; //soldier group
    
  }
  
  /* Sets the soldier number */
  public void SetNumber(int number) {
  
    soldierNumber = number; //updates soldier number
    
  }
  
  /* Gets the soldier number */
  public int GetNumber() {
  
    return soldierNumber; //returns the soldier number
  
  }
  
  /* Makes a copy of the soldier */
  public object GetSoldierCopy() {
  
    return this.MemberwiseClone(); //clones each member of the script
  
  }
  
  /* Sets the info of this soldier to the passed soldier */
  public void SetSoldierInfo(Soldiers newSoldier) {
  
    soldierNumber = newSoldier.soldierNumber;
    SetName(newSoldier.soldierName);
    health = newSoldier.health;
    group = newSoldier.group;
    soldierClass = newSoldier.soldierClass;
    abilities = newSoldier.abilities;
    
  }
  
  /* Returns the info of this soldier to another soldier script */
  public Soldiers GetSoldierInfo(Soldiers newSoldier) {
  
    newSoldier.soldierNumber = soldierNumber;
    newSoldier.soldierName = GetName ();
    newSoldier.health = health;
    newSoldier.group = group;
    newSoldier.soldierClass = soldierClass;
    newSoldier.abilities = abilities;
    
    return newSoldier;
  
  }
  
  /* Saves the soldier */
  public void Save(int soldierIndex) {
    
    BinaryFormatter formatter = new BinaryFormatter();
    Directory.CreateDirectory(DataScript.soldierDir); //creates the folder
    
    //creates the file to save
    FileStream file = File.Create (DataScript.soldierFile + soldierIndex + ".dat");

    //Creates a new instance of the SoldierData class
    SoldierData savedData = new SoldierData();
    
    /* Data to save -- saves into new SoldierData instance*/
    savedData.soldierNumber = soldierNumber;
    savedData.soldierName = GetName ();
    savedData.health = health;
    savedData.group = group;
    savedData.soldierClass = soldierClass;
    savedData.abilities = abilities;

    /* End data to save */

    formatter.Serialize (file, savedData); //saves the soldier instance to file
    file.Close(); //closes the file
    
  }
  
  /* Loads soldier data, with a required soldier index for file name purposes */
  public void Load(int soldierIndex) {
    
    /* Checks that the file exists */
    if (File.Exists(DataScript.soldierFile + soldierIndex + ".dat")) {

      BinaryFormatter formatter = new BinaryFormatter(); 
      
      //loads the file
      FileStream file = File.Open (DataScript.soldierFile + soldierIndex + ".dat", FileMode.Open);
      SoldierData savedData = (SoldierData)formatter.Deserialize (file);
      file.Close ();
      
      soldierNumber = savedData.soldierNumber;
      SetName(savedData.soldierName);
      health = savedData.health;
      group = savedData.group;
      soldierClass = savedData.soldierClass;
      abilities = savedData.abilities;
    }
  }
}

/* Soldier data to load */
[Serializable]
class SoldierData {

  public int soldierNumber; //soldier index relative to army array
  public string soldierName; //soldier name
  public int health; //solider health
  public string group;
  public string soldierClass; //soldier class - Combat, Defense, Range, Support
  
  public int[] abilities; //array of ability numbers
  

}