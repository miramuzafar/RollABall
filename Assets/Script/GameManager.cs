using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	
	public void StartLevel()
	{
		Debug.Log("clicked");
		SceneManager.LoadScene(1);
	}
	public void ExitGame()
	{
		Debug.Log("exit");
		Application.Quit ();
	}
}
