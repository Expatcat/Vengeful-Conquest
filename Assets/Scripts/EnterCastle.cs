using UnityEngine;
using System.Collections;

public class EnterCastle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
  void OnTriggerEnter2D() {
    
  
    Camera.main.GetComponent<CastleManagerGUI>().toggleGUI (GetComponent<Castles>().castleNumber);
  
  }
  
  void OnTriggerExit2D() {
  
    Camera.main.GetComponent<CastleManagerGUI>().toggleGUI();
  
  }
  
}
