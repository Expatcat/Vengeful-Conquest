using UnityEngine;
using System.Collections;

public class Soldiers : MonoBehaviour {

  private ArmyDataScript armyData;
  
  public int soldierNumber;

	/* Player Stats Variables */
	public string soldierName; //soldier name
	public int health; //solider health
	public bool active = false;
	
	/* Experience Related Variables */
	private float experience; //soldier experience
	private int level; //solider level

	/* Ability Related Variables */
	private int totalAbilityPoints; //ability points
	private int spentAbilityPoints; //ability points used
	private int availableAbilityPoints; //ability points not used
  
  private bool unassignedSoldier, partySoldier, castleSoldier;

	/* Class Variables */
	private string soldierClass; //soldier class - Combat, Defense, Range, Support

  void Start() {
  
    armyData = this.transform.parent.parent.GetComponent<ArmyDataScript>();
  
  }

	void changeClass(string newClass) {

		availableAbilityPoints = totalAbilityPoints;
	}
	
	public Vector2 getSoldierPosition() {
		
		return this.transform.position;
		
	}
	
	void Update() {
	
	}
  
  public void MoveToParty(int partyIndex) {
  
    this.transform.parent = armyData.partySoldierObject.transform;
    armyData.partySoldiers[partyIndex] = this;
    
    partySoldier = true;
    castleSoldier = false;
    unassignedSoldier = false;
  
  }
  
  void MoveToCastle(int castleIndex) {
  
  
  }
  
  void MoveToUnassigned() {
    
    this.transform.parent = armyData.UnassignedSoldierObject.transform;
    
    if (partySoldier) {
    
      armyData.DecrementPartyIndex();
      
    }
    
    partySoldier = false;
    castleSoldier = false;
    unassignedSoldier = true;
    
  }
  
  public string GetName() {
  
    return soldierName;
  
  }
  
  public void SetName(string newSoldierName) {
  
    soldierName = newSoldierName;
    name = newSoldierName;
  
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
  
  
	
}
