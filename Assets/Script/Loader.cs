using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections.Generic;


public class Loader : MonoBehaviour {

	public static int currentLevel;
	//public GameObject[] levels;
	public static Loader instance;
	public List<GameObject> myList;
	

	// Use this for initialization
	void Awake () {
		LoadLevel();
		instance = this;
	//	myList = levels.ToList();
		
	}

	void LoadLevel()
	{
	/*	for(int p = 0; p < levels.Length; p++)
		{
			levels[p] = Resources.Load("Prefabs" + p) as GameObject;
		}*/
		//Instantiate(levels[currentLevel]);
		if (PlayerPrefs.HasKey ("CurrentLevel") == false) {
			PlayerPrefs.SetInt("CurrentLevel",1);
			currentLevel=PlayerPrefs.GetInt ("CurrentLevel");
		}
		currentLevel = PlayerPrefs.GetInt ("CurrentLevel");
		//if (currentLevel < myList.Length) {
			Instantiate (myList [currentLevel]);
		//}
	}
	public void NextLevel()
	{
		currentLevel++;
		PlayerPrefs.SetInt("CurrentLevel",currentLevel);
		//if (currentLevel < myList.Length) {
			PlayerPrefs.SetInt("Level" +currentLevel,1);
		//}
		//else
		//{
			//SceneManager.LoadScene(0);
		//}
		//SceneManager.LoadScene(1);
	}
	
}
