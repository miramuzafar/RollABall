using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections.Generic;


public class Loader : MonoBehaviour {

	public static int currentLevel;
	//public GameObject[] levels;
	public static Loader instance;
	public List<GameObject> myList = new List<GameObject>();
	

	// Use this for initialization
	void Awake () {
		LoadLevel();
		instance = this;
		//myList = levels.ToList();
		
	}

	void LoadLevel()
	{
	/*	for(int p = 0; p < levels.Length; p++)
		{
			levels[p] = Resources.Load("Prefabs" + p) as GameObject;
		}*/
		//Instantiate(levels[currentLevel]);
		if (PlayerPrefs.HasKey ("currentLevel") == false) {
			PlayerPrefs.SetInt("currentLevel",1);
			currentLevel=PlayerPrefs.GetInt ("currentLevel");
		}
		currentLevel = PlayerPrefs.GetInt ("currentLevel");
		//if (currentLevel < myList.Length) {
			Instantiate (myList [currentLevel]);
		//myList.Add(GameObject.Find(myList));
		//}
	}
	public void NextLevel()
	{
		currentLevel++;
		PlayerPrefs.SetInt("currentLevel",currentLevel);
		//if (currentLevel < myList.Length) {
			PlayerPrefs.SetInt("Level " +currentLevel,1);
		//}
		//else
		//{
			//SceneManager.LoadScene(0);
		//}
		//SceneManager.LoadScene(1);
	}
	
}
