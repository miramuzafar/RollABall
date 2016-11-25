using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	[System.Serializable]
	public class Level
	{
		public string levelText;
		public int unlocked;
		public bool isInteractable;
	//	private int levelIndex;
	}
	public List<Level> LevelList;
	public Transform spacer;
	public GameObject levelButton;
	public AudioSource button;
	void Start () 
	{
		//DeleteAll();
		FillList();
	}
	
	void FillList()
	{
		foreach(var level in LevelList)
		{
			GameObject newButton = Instantiate(levelButton) as GameObject;
			LevelButton button = newButton.GetComponent<LevelButton>();
			button.levelText.text = level.levelText;
			//level1, level2, 
			if(PlayerPrefs.GetInt("Level " + button.levelText.text) == 1)
			{
				level.unlocked = 1;
				level.isInteractable = true;
			}
			button.unlocked = level.unlocked;
			button.GetComponent<Button>().interactable = level.isInteractable;
			//Loader.currentLevel = PlayerPrefs.GetInt("Level " + button.levelText.text, button.unlocked);
			button.GetComponent<Button>().onClick.AddListener(() => Levels(button.levelText.text));
			//button.GetComponent<Button>().onClick.AddListener(() => Levels(CreateLevel.currentLevel));
			/*if(PlayerPrefs.GetInt("Level " + button.levelText.text + "_score") > 0 )
			{
				button.star1.SetActive(true);
			}
			if(PlayerPrefs.GetInt("Level " + button.levelText.text + "_score") >= 5000 )
			{
				button.star2.SetActive(true);
			}
			if(PlayerPrefs.GetInt("Level " + button.levelText.text + "_score") >= 9999 )
			{
				button.star3.SetActive(true);
			}*/
			newButton.transform.SetParent(spacer,false);
		}
		SaveAll();
	}
	void SaveAll()
	{
		//if(PlayerPrefs.HasKey("Level 1"))
		//{
			//return;
		//}
		//else
		//{
			GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
			foreach (GameObject buttons in allButtons)
			{
				LevelButton button = buttons.GetComponent<LevelButton>();
				PlayerPrefs.SetInt("Level " + button.levelText.text, button.unlocked);
			}
		//}
	}
	public void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}
	void Levels(string value)
	{
		button.gameObject.GetComponent<AudioSource>().Play();
		CreateLevel.currentLevel = int.Parse(value)-1;
		//CreateLevel.currentLevel = 0;
		//GameObject instance = Instantiate(Resources.Load("Level1", typeof(GameObject))) as GameObject;
		SceneManager.LoadScene(value);
	}
}
