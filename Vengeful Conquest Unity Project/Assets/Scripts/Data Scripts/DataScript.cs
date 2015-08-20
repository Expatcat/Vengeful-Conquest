using UnityEngine;
using System.Collections;

public class DataScript : MonoBehaviour {

	public GameObject armyData;
	public GameObject castleData;
	public GameObject playerData;

  public int openingSceneNumber;
  public int worldSceneNumber;
  public int battlefieldSceneNumber;
  
  [HideInInspector]
  public Vector2 screenOffset;
  private float screenWidth = 800;
  private float screenHeight = 600;
  
  public string armyManagerKey;
  
  [HideInInspector]
 // public Vector2 guiSize = new Vector2(700, 500);
  public Vector2 guiSize;
  public Vector2 guiStart;

    void Awake() {
      
      DontDestroyOnLoad(this);
    
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
  
    screenWidth = Screen.width;
    screenHeight = Screen.height;
    
    screenOffset.x = (screenWidth / 800);
    screenOffset.y = (screenHeight / 600);
  
    //sets the GUI Start values
    guiStart.x = 50 * screenOffset.x;
    guiStart.y = 50 * screenOffset.y;
    
    guiSize.x = 700 * screenOffset.x;
    guiSize.y = 500 * screenOffset.y;
	
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
