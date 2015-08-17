using UnityEngine;
using System.Collections;

public class DataScript : MonoBehaviour {

	public GameObject armyData;
	public GameObject castleData;
	public GameObject playerData;

  public int openingSceneNumber;
  public int worldSceneNumber;
  public int battlefieldSceneNumber;
  
  public string armyManagerKey;
  
  [HideInInspector]
  public Vector2 guiSize = new Vector2(700, 500);
  public Vector2 guiStart;

    void Awake() {
      
      DontDestroyOnLoad(this);
    
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
  
    //sets the GUI Start values
    guiStart.x = (Screen.width / 2) - 350;
    guiStart.y = (Screen.height / 2) - 250;
	
	}
	
	public Object getData(string dataName) {
	
	  if (dataName == "Army Data"){
	    return armyData.GetComponent<ArmyDataScript>(); 
	  }
	    
	  if (dataName == "Castle Data")
	    return castleData.GetComponent<CastleDataScript>();
	  
	  if (dataName == "Player Data")
	    return playerData.GetComponent<PlayerDataScript>();
	  
	  else
	    return null;
	    
	}
  
}
