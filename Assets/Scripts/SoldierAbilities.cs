using UnityEngine;
using System.Collections;

public class SoldierAbilities : MonoBehaviour {

  private GameObject[] soldierAbilityArray;
  
  public const int hit = 0;
  public const int strike = 1;
  /* etc */
  
  private Vector2 soldierLocation;
  private int abilityLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
  public static void Use(Vector2 location, int level, int ability) {
  
    SoldierAbilities useAbility = new SoldierAbilities();
   
      useAbility.soldierLocation = location;
      useAbility.abilityLevel = level;
  
    switch (ability) {
    
      case hit:
        useAbility.Hit();
        break;
     
    }  
  }
  
  private void Hit() {
  
  /* Do cool ability stuff */
  
  
  }
}
