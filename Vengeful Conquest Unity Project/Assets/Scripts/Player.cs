using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string playerName;
  public int health;
	public float experience;
	public int level;
  
  private static int abilityNum = 10;
  public GameObject[] abilities = new GameObject[abilityNum];

	public float playerWorldLocation, playerBattleLocation;
        
	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
