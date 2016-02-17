using UnityEngine;
using System.Collections;

public class TestAbility : MonoBehaviour {


	// Use this for initialization
	void Start () {
  
  
  
	}
	
	// Update is called once per frame
	void Update () {
 
    GetComponent<CircleCollider2D>().radius += 0.1f;
	
	}
  
  void OnTriggerEnter2D(Collider2D enemy) {

    if (enemy.GetComponent<Soldiers>() != null) {  

      enemy.GetComponent<Soldiers>().Damage(10);
    
    }
  
  }
}
