using UnityEngine;
using System.Collections;

public class CastleDataScript : MonoBehaviour {

    private static int castleCount = 20;

	public GameObject[] castlesArray = new GameObject[castleCount];

	// Use this for initialization
	void Start () {
  
    for (int i = 0; i < castleCount; i++) {
    
      castlesArray[i].GetComponent<Castles>().castleNumber = i+1;
      
    }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
