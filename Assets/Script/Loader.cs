using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Loader : MonoBehaviour {

	public static Loader instance; //Instance
	public int currentLevel;
	public GameObject[] levels;
	

	// Use this for initialization
	void Awake () {

		instance = this;
		LoadLevel();
	}

	void LoadLevel()
	{
		if (currentLevel < levels.Length) {
			Instantiate (levels [currentLevel]);
		}
	}
}
