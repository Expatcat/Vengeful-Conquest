using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataScript : MonoBehaviour {

  public static DataScript data;
  
	public ArmyDataScript armyData;
	public CastleDataScript castleData;
	public PlayerDataScript playerData;

  public int openingSceneNumber;
  public int worldSceneNumber;
  public int battlefieldSceneNumber;
  
  private int currentScene;
  
  [HideInInspector]
  public Vector2 screenOffset;
  public bool screenChange;
  private float screenWidth = 800;
  private float screenHeight = 600;
  
  /* Save Locations */
  [HideInInspector]
  public static string dataDir = Application.persistentDataPath + "/Saved Data/";
  public static string gameDir = dataDir + "Game Data/";
  public static string armyDir = dataDir + "Army Data/";
  public static string kingdomDir = dataDir + "Kingdom Data/";
  public static string soldierDir = armyDir + "Soldier Data/";
  public static string castleDir = kingdomDir + "Castle Data/";
  
  public static string gameFile = gameDir + "gameData.dat";
  public static string armyFile = armyDir + "armyData.dat";
  public static string soldierFile = soldierDir + "soldierData";
  public static string kingdomFile = kingdomDir + "kingdomData.dat";
  public static string castleFile = castleDir + "castleData";
  
  public string armyManagerKey;
  
  [HideInInspector]
 // public Vector2 guiSize = new Vector2(700, 500);
  private Rect standardGuiWindow;
  public Rect guiWindow;

   void Awake() {
      
      if (data == null) {
      
        DontDestroyOnLoad(this);
        data = this;
        
      }
      
      else if (data != this) {
      
        Destroy (gameObject);
      
      }
    }
    
	// Use this for initialization
	void Start () {
  
    standardGuiWindow = new Rect(50, 50, 700, 500);
	
	}
  
  void OnLevelWasLoaded() {
  
    currentScene = Application.loadedLevel;
    
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
  
  public void SaveData() {
  
    Save ();
    armyData.Save ();
    //castleData.Save();
    //playerData.Save();
  
  }
  
  public void LoadData() {
  
    Load ();
    armyData.Load ();
    //castleData.Load();
   // playerData.Load();
    Application.LoadLevel (currentScene);
  
  }
  
  public void Save() {
    
    BinaryFormatter formatter = new BinaryFormatter();
    
    Directory.CreateDirectory(dataDir);
    Directory.CreateDirectory (gameDir);
    
    FileStream file = File.Create (gameFile);
    
    GameData savedData = new GameData();
    savedData.currentScene = currentScene;
    
    /* Data to save goes here */
    
    formatter.Serialize (file, savedData);
    file.Close();
    
  }
  
  public void Load() {
    
    if (File.Exists(gameFile))
    {
      
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream file = File.Open (gameFile, FileMode.Open);
      GameData savedData = (GameData)formatter.Deserialize (file);
      file.Close ();
      
      currentScene = savedData.currentScene;
   
    }
  }
}

[Serializable]
class GameData {

  public int currentScene;


}




