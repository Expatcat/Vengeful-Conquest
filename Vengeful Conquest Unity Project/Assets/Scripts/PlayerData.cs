using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	public int health;
	public float experience;
	public int level;

	public float playerWorldLocation, playerBattleLocation;
        
	// Use this for initialization
	void Start () {
	
	GetComponent<Renderer>().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
