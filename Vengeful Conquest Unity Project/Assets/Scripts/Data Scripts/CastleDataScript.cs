using UnityEngine;
using System.Collections;

public class CastleDataScript : MonoBehaviour {

  private DataScript data;

  private static int castleCount = 20;

  public GameObject castlesParent;
	public GameObject[] castlesArray = new GameObject[castleCount];

	// Use this for initialization
	void Start () {
  
    data = GameObject.Find ("Data").GetComponent<DataScript>();
    
    SetCastleState (false);
  
    for (int i = 0; i < castleCount; i++) {
    
      castlesArray[i].GetComponent<Castles>().castleNumber = i+1;
      
    }
	}
  
  void OnLevelWasLoaded() {
  
    if (Application.loadedLevel == data.worldSceneNumber) {
    
      SetCastleState (true);
    
    }
  
  }
	
	// Update is called once per frame
	void Update () {
	
	}
  
  public void SetCastleState(bool castleState) {
  
    castlesParent.SetActive (castleState);
  }
}
