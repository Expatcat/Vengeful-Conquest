using UnityEngine;
using System.Collections;

public class ArmyDataScript : MonoBehaviour {

  public Object soldierObject;

  public GameObject partySoldierObject;
  public GameObject UnassignedSoldierObject;

	/* Soldier constants */
  public int partySize = 5;
  public int armySize = 50;  
  
  public Soldiers[] armyArray;
    
	/* Party Soldier Array */
	public Soldiers[] partySoldiers;
  
  private int nextFreeSoldierIndex = 0;
  private int nextFreePartyIndex = 0;
	
	void Awake() {
	
    }
	
	void Start() {
  
    partySoldiers = new Soldiers[partySize];
    armyArray = new Soldiers[armySize];
	
	}
	
	/* gets the number of active soldiers */
	public int getSoldierCount() {
	
	  int soldierCount = 0; //starts at 0
	
	  //loops through all soldiers
	  for (int i = 0; i < partySize; i++) {
	  
	    //checks if soldiers are active
	    if (partySoldiers[i].active == true) {
	     
	      //increments number of active soldiers
	      soldierCount++;
	      
	    }
	  }
	  
	  //returns active soldiers
	  return soldierCount;
	  
	}
  
  public int GetNextSoldierIndex() {
  
    return nextFreeSoldierIndex;
  
  }
  
  public Soldiers addSoldier() {
  
    GameObject newSoldier = (GameObject)Instantiate(soldierObject);
    
    newSoldier.transform.parent = UnassignedSoldierObject.transform;
  
    armyArray[nextFreeSoldierIndex] = newSoldier.GetComponent<Soldiers>();
    
    armyArray[nextFreeSoldierIndex].SetName("Unnamed");
    
    armyArray[nextFreeSoldierIndex].SetNumber (nextFreeSoldierIndex);
    
    return armyArray[nextFreeSoldierIndex++];
    
    
  }
  
  public Soldiers addSoldier(string newSoldierName) {
  
    GameObject newSoldier = (GameObject)Instantiate(soldierObject);
    
    newSoldier.transform.parent = UnassignedSoldierObject.transform;
    
    armyArray[nextFreeSoldierIndex] = newSoldier.GetComponent<Soldiers>();
    
    armyArray[nextFreeSoldierIndex].SetName (newSoldierName);
    
    armyArray[nextFreeSoldierIndex].SetNumber (nextFreeSoldierIndex);
    
    return armyArray[nextFreeSoldierIndex++];
  
  }
  
  public int GetNextPartyIndex() {
  
    return nextFreePartyIndex;
    
  }
  
  public void IncrementPartyIndex() {
  
    nextFreePartyIndex++;
  
  }
  
  public void DecrementPartyIndex() {
  
    nextFreePartyIndex--;
    
  }

}
