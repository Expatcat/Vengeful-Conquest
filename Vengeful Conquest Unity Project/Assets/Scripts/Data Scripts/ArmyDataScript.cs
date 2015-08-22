using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ArmyDataScript : MonoBehaviour {

  public UnityEngine.Object soldierObject; //prefab to create soldiers from

  public static int armyCap = 50; //number of soldiers allowed in player's army
  public static int partyCap = 5; //number of soldiers allowed in player's party

  /* Data To Save */
  private int armySize = 0; //total number of soldiers in player's army
  private int armySlots = 0; //number of open army slots
  private int lockedArmySlots = armyCap; //number of locked army slots
  
  private int partySize = 0; //total number of soldiers in player's party
  private int partySlots = 0; //total number of open party slots
  private int lockedPartySlots = partyCap; //number of locked party slots]
  private int[] partySoldiers = new int[partyCap];
  
  /* End Data To Save */
 
  /* Army Soldier Array */
  public Soldiers[] armyArray = new Soldiers[armyCap];
    
	/* Party Soldier Array */
  
	void Awake() {
	
  }
	
	void Start() {
  
	
	}
  
  public int UnlockArmySlot() {
  
    /* If there's room for another slot */
    if (armySize < armyCap) {
  
      lockedArmySlots--; //decrements locked army slots
      return armySlots++; //returns index of new slot and increments available army slots
    
    }
    
    else {
    
      return -1; //could not add slot
    
    }
  }
  
  public int UnlockPartySlot() {
  
    if (partySize < partyCap) {
    
      lockedPartySlots--;
      
      return partySlots++; //returns index of new slot and increments available party slots
    }
    
    else {
    
      return -1;
      
    }
  }
  
  /* Add a new unnamed soldier */
  public Soldiers AddSoldier() {
  
    /* Checks that there's a free army slot */
    if (armySize < armySlots) {
  
      GameObject newSoldier = (GameObject)Instantiate(soldierObject);
    
      armyArray[armySize] = newSoldier.GetComponent<Soldiers>();
      armyArray[armySize].MoveToUnassigned(); //moves the soldier to the unassigned category
      armyArray[armySize].SetName ("Unnamed");
      armyArray[armySize].SetNumber (armySize);
      armyArray[armySize].transform.parent = transform;
    
      return armyArray[armySize++]; //returns new soldier and increments the army size

    }
    
    else {
    
      return null;
      
    }
  }
  
  /* Add soldier with a given name */
  public Soldiers AddSoldier(string newSoldierName) {
  
    GameObject newSoldier = (GameObject)Instantiate(soldierObject);
    
    armyArray[armySize] = newSoldier.GetComponent<Soldiers>();
    armyArray[armySize].MoveToUnassigned(); 
    armyArray[armySize].SetName (newSoldierName);
    armyArray[armySize].SetNumber (armySize);
    
    return armyArray[armySize++];
  
  }
  
  public int GetArmySize() {
  
    return armySize;
    
  }
  
  public int GetPartySize() {
  
    return partySize;
  
  }
  
  
  public void SetPartySoldier(int soldierIndex, int partyIndex) {
  
    partySoldiers[partyIndex] = soldierIndex;
  
  }
  
  public int GetPartySoldier(int partyIndex) {
  
    return partySoldiers[partyIndex];
  
  }
  
  public int GetEmptyArmySlots() {
  
    return armySlots - armySize;
    
  }
  
  public int GetEmptyPartySlots() {
  
    return partySlots - partySize;
  
  }
  
  public void Save() {
    
    BinaryFormatter formatter = new BinaryFormatter();
    
    Directory.CreateDirectory (DataScript.armyDir);
    FileStream file = File.Create (DataScript.armyFile);
    
    ArmyData savedData = new ArmyData();
    
    /* Data to save */
    
    savedData.armySize = armySize;
    Debug.Log(armySize);
    savedData.armySlots = armySlots;
    savedData.lockedArmySlots = lockedArmySlots;
    
    savedData.partySize = partySize;
    savedData.partySlots = partySlots;
    savedData.lockedPartySlots = lockedPartySlots;
    savedData.partySoldiers = partySoldiers;
    
    for (int i = 0; i < armySize; i++) {
    
      armyArray[i].Save (i);
    
    }

    formatter.Serialize (file, savedData);
    file.Close();
    
  }
  
  public void Load() {
    
    if (File.Exists(DataScript.armyFile))
    {
      
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream file = File.Open (DataScript.armyFile, FileMode.Open);
      ArmyData savedData = (ArmyData)formatter.Deserialize (file);
      file.Close ();
      
      /* Data to load */
      armySlots = savedData.armySlots;
      lockedArmySlots = savedData.lockedArmySlots;
      
      partySize = savedData.partySize;
      partySlots = savedData.partySlots;
      lockedPartySlots = savedData.lockedPartySlots;
      partySoldiers = savedData.partySoldiers;
      
      for (int i = 0; i < savedData.armySize; i++) {
        AddSoldier ();
        armyArray[i].Load (i);
       
      
      }
    }
  }
}

[Serializable]
class ArmyData {

  public int armySize; //total number of soldiers in player's army
  public int armySlots; //number of open army slots
  public int lockedArmySlots; //number of locked army slots
  
  public int partySize; //total number of soldiers in player's party
  public int partySlots; //total number of open party slots
  public int lockedPartySlots; //number of locked party slots
  public int[] partySoldiers;
  
}
