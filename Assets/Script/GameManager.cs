using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public Canvas levelCanvas;
	public Canvas menuCanvas;
	public GameSettings gameSettings;

	void Start()
	{
		if(GameSettings.index>0)
		{
			StartLevel();
		}
		else
		{
			levelCanvas.enabled = false;
			menuCanvas.enabled = true;
			menuCanvas.gameObject.transform.GetChild(4).gameObject.SetActive(false);
		}
	}
	
	public void StartLevel()
	{
		GetComponent<AudioSource>().Play();
		Debug.Log("clicked");
		levelCanvas.enabled = true;
		menuCanvas.enabled = false;
		//SceneManager.LoadScene(1);
	}
	public void BackButton()
	{
		GetComponent<AudioSource>().Play();
		Debug.Log("clicked");
		levelCanvas.enabled = false;
		menuCanvas.enabled = true;
		menuCanvas.gameObject.transform.GetChild(4).gameObject.SetActive(false);
		//SceneManager.LoadScene(1);
	}
	public void ExitGame()
	{
		GetComponent<AudioSource>().Play();
		Debug.Log("exit");
		Application.Quit ();
	}
	public void Settings()
	{
		GetComponent<AudioSource>().Play();
		menuCanvas.gameObject.transform.GetChild(4).gameObject.SetActive(true);
	}
}
