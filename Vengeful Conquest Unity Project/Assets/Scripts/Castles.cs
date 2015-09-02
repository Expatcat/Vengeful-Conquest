using UnityEngine;
using System.Collections;

public class Castles : MonoBehaviour {

	private string castleName;
  public int castleNumber;
	
	public bool claimed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
  public string GetName() {
  
    return castleName;
  
  }
  
  public void SetName(string newCastleName) {
  
    castleName = newCastleName;
    this.name = castleName;
  
  }
}
