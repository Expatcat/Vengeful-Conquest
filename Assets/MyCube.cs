using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class MyCube : MonoBehaviour
{
	private string saveDirectory;
	private string saveName;


	// Use this for initialization
	void Start ()
	{
	
		saveDirectory = Application.persistentDataPath + "/Saved Data/MyCube/";
		saveName = saveDirectory + "cube.dat";

		Load ();

	}
	
	// Update is called once per frame
	void Update ()
	{
	
		Save ();

	}

	void Save ()
	{
		BinaryFormatter formatter = new BinaryFormatter ();

		if (!Directory.Exists (saveDirectory)) {

			Directory.CreateDirectory (saveDirectory);

		}

		FileStream file = File.Create (saveName);

		PersistentCube cubeToSave = new PersistentCube ();

		Color cubeColor = this.GetComponent<MeshRenderer> ().material.color;
		cubeToSave.SetCubeColor (new Vector3 (cubeColor.r, cubeColor.g, cubeColor.b));

		Vector3 cubePosition = this.transform.position;
		cubeToSave.SetCubePosition (cubePosition);

		formatter.Serialize (file, cubeToSave);
		file.Close ();
	}

	void Load ()
	{

		if (File.Exists (saveName)) {

			BinaryFormatter formatter = new BinaryFormatter ();
			FileStream file = File.Open (saveName, FileMode.Open);
			PersistentCube loadedCube = (PersistentCube)formatter.Deserialize (file);
			file.Close ();

			this.transform.position = loadedCube.GetCubePosition ();

			Vector3 loadedColorVals = loadedCube.GetCubeColor ();
			Color loadedColor = new Color (loadedColorVals.x, loadedColorVals.y, loadedColorVals.z);
			this.GetComponent<MeshRenderer> ().material.SetColor ("_Color", loadedColor);


		}
	}
}


[Serializable]
class PersistentCube
{

	float[] cubePosition = new float[3];
	float[] cubeColor = new float[3];

	public void SetCubeColor (Vector3 color)
	{

		cubeColor [0] = color.x;
		cubeColor [1] = color.y;
		cubeColor [2] = color.z;

	}

	public void SetCubePosition (Vector3 position)
	{
		cubePosition [0] = position.x;
		cubePosition [1] = position.y;
		cubePosition [2] = position.z;

	}

	public Vector3 GetCubePosition ()
	{

		return new Vector3 (cubePosition [0], cubePosition [1], cubePosition [2]);

	}

	public Vector3 GetCubeColor ()
	{

		return new Vector3 (cubeColor [0], cubeColor [1], cubeColor [2]);

	}


}
