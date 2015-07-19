using UnityEngine;
using System.Collections;

public class DataScript : MonoBehaviour {

	public GameObject armyData;
	public GameObject castleData;

    void Awake() {
      
      DontDestroyOnLoad(this);
    
    }
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public Object getData(string dataName) {
	
	  if (dataName == "Army Data"){
	    return armyData.GetComponent<ArmyDataScript>(); 
	  }
	    
	  if (dataName == "Castle Data")
	    return castleData.GetComponent<CastleDataScript>();
	    
	  else
	    return null;
	    
	
	}
}
