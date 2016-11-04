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
	}
	
	public void StartLevel()
	{
		Debug.Log("clicked");
		levelCanvas.enabled = true;
		menuCanvas.enabled = false;
		//SceneManager.LoadScene(1);
	}
	public void ExitGame()
	{
		Debug.Log("exit");
		Application.Quit ();
	}
}
