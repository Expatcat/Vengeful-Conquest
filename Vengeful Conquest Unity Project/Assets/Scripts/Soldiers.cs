using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Soldiers : MonoBehaviour {

  public static string partyGroup = "Party";
  public static string unassignedGroup = "Unassigned";
  public static string castleGroup = "Castle";

  private ArmyDataScript armyData;

  /* Data to save */
  public int soldierNumber; //soldier index relative to army array
	public string soldierName = "Unnamed"; //soldier name
	public int health; //solider health
  private string group = unassignedGroup;
	private string soldierClass; //soldier class - Combat, Defense, Range, Support
  
  private int[] abilities;
  
  /* End Data To Save */
  
	public Vector2 GetPosition() {
		
		return this.transform.position;
		
	}
  
  void Start() {
  
    armyData = DataScript.data.armyData;
  
  }
	
	void Update() {

	}
  
  public void MoveToParty(int partyIndex) {
  
    armyData.SetPartySoldier(soldierNumber, partyIndex);
    group = partyGroup;

  }
  
  void MoveToCastle(int castleIndex) {
  
  
  }
  
  public void MoveToUnassigned() {
    
    if (group == partyGroup) {
    
      /* Do stuff with the party */
    
    }
    
    group = unassignedGroup;
    
  }
  
  public void AddAbility(int ability) {
  
  }
  
  public string GetName() {
  
    return soldierName;
  
  }
  
  public void SetName(string newSoldierName) {
  
    soldierName = newSoldierName;
    name = soldierName;
  
  }
  
  public void SetGroup(string newGroup) {
 
    group = newGroup;
  
  }
  
  public string GetGroup() {
  
    return group;
  
  }
  
  public void SetNumber(int number) {
  
    soldierNumber = number;
    
  }
  
  public int GetNumber() {
  
    return soldierNumber;
  
  }
  
  public object GetSoldierCopy() {
  
    return this.MemberwiseClone();
  
  }
  
  public void SetSoldierInfo(Soldiers newSoldier) {
  
    soldierNumber = newSoldier.soldierNumber;
    SetName(newSoldier.soldierName);
    health = newSoldier.health;
    group = newSoldier.group;
    soldierClass = newSoldier.soldierClass;
    abilities = newSoldier.abilities;
    
  }
  
  public Soldiers GetSoldierInfo(Soldiers newSoldier) {
  
    newSoldier.soldierNumber = soldierNumber;
    newSoldier.soldierName = GetName ();
    newSoldier.health = health;
    newSoldier.group = group;
    newSoldier.soldierClass = soldierClass;
    newSoldier.abilities = abilities;
    
    return newSoldier;
  
  }
  
  public void Save(int soldierIndex) {
    
    BinaryFormatter formatter = new BinaryFormatter();
    Directory.CreateDirectory(DataScript.soldierDir);
    FileStream file = File.Create (DataScript.soldierFile + soldierIndex + ".dat");

    SoldierData savedData = new SoldierData();
    
    savedData.soldierNumber = soldierNumber;
    savedData.soldierName = GetName ();
    savedData.health = health;
    savedData.group = group;
    savedData.soldierClass = soldierClass;
    savedData.abilities = abilities;

    formatter.Serialize (file, savedData);
    file.Close();
    
  }
  
  public void Load(int soldierIndex) {
    
    if (File.Exists(DataScript.soldierFile + soldierIndex + ".dat"))
    {

      BinaryFormatter formatter = new BinaryFormatter();
      
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

[Serializable]
class SoldierData {

  public int soldierNumber; //soldier index relative to army array
  public string soldierName; //soldier name
  public int health; //solider health
  public string group;
  public string soldierClass; //soldier class - Combat, Defense, Range, Support
  
  public int[] abilities; //array of ability numbers
  

}