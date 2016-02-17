using UnityEngine;
using System.Collections;

public class KingAbilities : MonoBehaviour {

  public static int abilityNum = 40;
  public static KingAbilities kingAbilityScript;
  
  public GameObject[] kingAbilities = new GameObject[abilityNum];
  private int[] abilityLevels = new int[abilityNum];
  
  /* Ability Indexes */
  public static int testAbility = 0;
  
  
  
  /* End Ability Indexes */

  /*
  public GameObject[] combatAbilities = new GameObject[abilityNum];
  public GameObject[] survivalAbilities = new GameObject[abilityNum];
  public GameObject[] strategyAbilities = new GameObject[abilityNum];
  public GameObject[] heroismAbilities = new GameObject[abilityNum];
  */
  
  // Use this for initialization
	void Start () {
      
      kingAbilityScript = this;
   
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
  public void UseAbility(int abilityIndex, Vector3 kingLocation) {

    if (abilityLevels[abilityIndex] == 0) {
        
     GameObject.Instantiate(kingAbilities[abilityIndex], kingLocation, new Quaternion(0,0,0,0) );
        
    }
        
    else if (abilityLevels[abilityIndex] == 2) {
        
        
    }
  }
}
