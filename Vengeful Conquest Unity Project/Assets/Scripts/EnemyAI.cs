using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public string behaviour;

    GameObject[] targetArray;
    
    DataScript data; //data script 
	ArmyDataScript targetArmy; //player's army
	SoldierDataScript soldier1, soldier2, soldier3, soldier4, soldier5;
	PlayerDataScript player; //player information

	// Use this for initialization
	void Start () {

      data = GameObject.Find ("Data").GetComponent<DataScript>(); //loads the data script
      targetArmy = (ArmyDataScript)data.getData ("Army Data"); //loads the army data
      player = (PlayerDataScript)data.getData ("Player Data"); //loads the player data
      
      int targetArmySize = targetArmy.getSoldierCount(); //number of party members in player's party
      
      targetArray = new GameObject[targetArmySize + 1]; //create an array of targets including the player
      
      //set elements of the target array to player and party
      for (int i = 0; i < targetArmySize; i++) {
      
        targetArray[i] = targetArmy.partySoldiers[i];
        
      }
      
      //set the final element to the player
      targetArray[targetArray.Length - 1] = player.getPlayerObject();
     
	}
	
	// Update is called once per frame
	void Update () {
	
	  this.GetComponent<EnemyMove>().setDirection(getComponentDistanceBetween (targetArray[getTargetByBehaviour()].transform.position));
		
	}
	
	//finds the desired target based on AI behaviour
	int getTargetByBehaviour() {
	
	  int closestIndex = 0;
	
	  if (behaviour == "closest") {
	    
	    //loops through all soldiers
	    for (int i = 0; i < targetArray.Length; i++) {
	    
	      //checks if next soldier is closer than stored soldier
	      if (getDistanceBetween (targetArray[i].transform.position) < 
	        getDistanceBetween(targetArray[closestIndex].transform.position)) {
	       
	        closestIndex = i;
	      
	      }
	    }
	  }
	  return closestIndex;
	}
	
	//stores the distance between two objects into a vector
	Vector2 getComponentDistanceBetween(Vector2 targetPosition) {
	
	  //return vector
	  Vector2 distanceVector;
	
	  //sets x and y distances
	  distanceVector.x = (targetPosition.x - this.transform.position.x);
	  distanceVector.y = (targetPosition.y - this.transform.position.y);
	  
	  //returns vectors
	  return distanceVector;
	
	}
	
	float getDistanceBetween(Vector2 targetPosition) {
	  
	  return (Vector2.Distance (this.transform.position, targetPosition));
	
	}
}
