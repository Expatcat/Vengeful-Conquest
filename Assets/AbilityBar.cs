using UnityEngine;
using System.Collections;

public class AbilityBar : MonoBehaviour {

  private DataScript data;
  private PlayerDataScript player;
  private GUIInfo guiInfo;

	// Use this for initialization
	void Start () {
	
    data = DataScript.data;
    player = PlayerDataScript.playerData;
    guiInfo = GUIInfo.guiInfo;
  
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  
  
  void OnGUI() {
 
    if (Application.loadedLevel == data.battlefieldSceneNumber) {
    
      GUI.DrawTexture(guiInfo.abilityBar, guiInfo.abilityBarGUI);
    
    }
  }
}
