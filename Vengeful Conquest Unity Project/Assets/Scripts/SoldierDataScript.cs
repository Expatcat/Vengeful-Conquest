using UnityEngine;
using System.Collections;

public class SoldierDataScript : MonoBehaviour {

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

	/* Class Variables */
	private string soldierClass; //soldier class - Combat, Defense, Range, Support

	void changeClass(string newClass) {

		availableAbilityPoints = totalAbilityPoints;
	}
	
	public Vector2 getSoldierPosition() {
		
		return this.transform.position;
		
	}
	
	void Update() {
	
	  if (soldierName == null && active == true)
	    active = false;
	    
	  if (soldierName != null && active == false)
	    soldierName = null;
	}
	
}
