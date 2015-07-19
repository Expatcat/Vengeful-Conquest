using UnityEngine;
using System.Collections;

public class Soldiers : MonoBehaviour {

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
}
