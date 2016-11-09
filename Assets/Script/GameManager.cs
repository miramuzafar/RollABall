using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public Canvas levelCanvas;
	public Canvas menuCanvas;

	void Start()
	{
		levelCanvas.enabled = false;
		menuCanvas.enabled = true;
		menuCanvas.gameObject.transform.GetChild(4).gameObject.SetActive(false);
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
