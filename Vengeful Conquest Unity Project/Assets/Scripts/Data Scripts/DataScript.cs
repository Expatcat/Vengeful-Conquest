using UnityEngine;
using System.Collections;

public class DataScript : MonoBehaviour {

	public ArmyDataScript armyData;
	public CastleDataScript castleData;
	public PlayerDataScript playerData;

  public int openingSceneNumber;
  public int worldSceneNumber;
  public int battlefieldSceneNumber;
  
  [HideInInspector]
  public Vector2 screenOffset;
  public bool screenChange;
  private float screenWidth = 800;
  private float screenHeight = 600;
  
  public string armyManagerKey;
  
  [HideInInspector]
 // public Vector2 guiSize = new Vector2(700, 500);
  private Rect standardGuiWindow;
  public Rect guiWindow;

    void Awake() {
      
      DontDestroyOnLoad(this);
    
    }
    
	// Use this for initialization
	void Start () {
  
    standardGuiWindow = new Rect(50, 50, 700, 500);
	
	}
	
	// Update is called once per frame
	void Update () {

    screenWidth = Screen.width;
    screenHeight = Screen.height;
    
    screenOffset.x = (screenWidth / 800);
    screenOffset.y = (screenHeight / 600);
    
  
      guiWindow.x = standardGuiWindow.x * screenOffset.x;
      guiWindow.y = standardGuiWindow.y * screenOffset.y;
      guiWindow.width = standardGuiWindow.width * screenOffset.x;
      guiWindow.height = standardGuiWindow.height * screenOffset.y;
      

	}
  
  public Vector2 UpdateVector(Vector2 vector) {
  
    vector.x *= screenOffset.x;
    vector.y *= screenOffset.y;
    
    return vector;
    
  }
  
  public Rect UpdateRect(Rect rect) {
  
    rect.x *= screenOffset.x;
    rect.y *= screenOffset.y;
    rect.width *= screenOffset.x;
    rect.height *= screenOffset.y;
    
    return rect;
    
  }
}
