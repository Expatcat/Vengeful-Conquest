using UnityEngine;
using System.Collections;

public class ArmyDataScript : MonoBehaviour {

	/* Soldier constants */
    private static int partySoldierCount = 5;
    
    /* Soldier Indeces */
    private static int soldier1 = 0;
    private static int soldier2 = 1;
    private static int soldier3 = 2;
    private static int soldier4 = 3;
    private static int soldier5 = 4;
    
	/* Party Soldier Array */
	public GameObject[] partySoldiers = new GameObject[partySoldierCount];
	
	void Awake() {
	
    }
	
	void Start() {
	
	}
	
	/* gets the number of active soldiers */
	public int getSoldierCount() {
	
	  int soldierCount = 0; //starts at 0
	
	  //loops through all soldiers
	  for (int i = 0; i < partySoldierCount; i++) {
	  
	    //checks if soldiers are active
	    if (partySoldiers[i].GetComponent<SoldierDataScript>().active == true) {
	     
	      //increments number of active soldiers
	      soldierCount++;
	      
	    }
	  }
	  
	  //returns active soldiers
	  return soldierCount;
	  
	}

}
