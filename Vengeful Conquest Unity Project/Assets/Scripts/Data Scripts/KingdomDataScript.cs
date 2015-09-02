using UnityEngine;
using System.Collections;

public class KingdomDataScript : MonoBehaviour {

  public static KingdomDataScript kingdomData;
 
  private DataScript data;

  private static int castleCount = 20;

  public GameObject castlesParent;
	public Castles[] castlesArray = new Castles[castleCount];

  void Awake() {
  
    kingdomData = this;
    
    data = DataScript.data;    
    SetCastleState (false);
    
    castlesArray = castlesParent.GetComponentsInChildren<Castles>(true);
    Debug.Log (castlesArray);
    
    for (int i = 0; i < castleCount; i++) {
      
      castlesArray[i].castleNumber = i+1;
      castlesArray[i].SetName ("Unnamed Castle");
      
    }
    
  
  }

	// Use this for initialization
	void Start () {
  
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
