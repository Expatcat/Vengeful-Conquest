using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string playerName;
  public int health;
	public float experience;
	public int level;
  
  private static int abilityNum = 10;
  private int[] abilities = new int[abilityNum];

	public float playerWorldLocation, playerBattleLocation;
        
	// Use this for initialization
	void Start () {
	
    
    abilities[0] = KingAbilities.testAbility;
	
	}
	
	// Update is called once per frame
	void Update () {
  
    if (Input.GetKeyDown ("l")) {
    
      Debug.Log ("PRESSED");
    
      KingAbilities.kingAbilityScript.UseAbility (abilities[0], transform.position);
    
    }
  
	}
}
