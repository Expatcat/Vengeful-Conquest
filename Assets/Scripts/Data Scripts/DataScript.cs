using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataScript : MonoBehaviour {

  public static DataScript data;
  
	public ArmyDataScript armyData;
	public KingdomDataScript kingdomData;
	public PlayerDataScript playerData;

  public int mainMenuSceneNumber;
  public int openingSceneNumber;
  public int worldSceneNumber;
  public int battlefieldSceneNumber;
  
  private int currentScene;
  
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
  
	
	}
  
  void OnLevelWasLoaded() {
  
    currentScene = Application.loadedLevel;
    
    if (currentScene == mainMenuSceneNumber) {
    
      KingdomDataScript.kingdomData.SetCastleState(false);
      
    }
    
    if (currentScene == openingSceneNumber) {
    
      KingdomDataScript.kingdomData.SetCastleState(false);
     
    }
    
    else if (currentScene == worldSceneNumber) {
    
      KingdomDataScript.kingdomData.SetCastleState(true);
    
    }
    
    else if (currentScene == battlefieldSceneNumber) {
    
      KingdomDataScript.kingdomData.SetCastleState(false);
      
    }
    
  }
  
	
	// Update is called once per frame
	void Update () {


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




