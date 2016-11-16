using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class GameController : MonoBehaviour {

	float moveSpeed = 40;
	//int score = 1;
	private int levelAmount = 12;
	private int currentLevel;
	public GameSettings gameSettings;
	//public int index;
	public Canvas startCanvas;
	public Button pauseButton;
	public GameObject ball;
	public GameObject goal;
	public bool isAlreadyClicked = false;
	public bool active = false;
	public Rigidbody2D rb;
	public AudioSource bounce;
	public AudioSource win;
	//AudioSource buttonSound;


	void Start() 
    {
		Debug.Log("restart");
		//PlayerPrefs.SetInt("Level 2", 1);
		//PlayerPrefs.SetInt("Level_1_score", score);
		CheckCurrentLevel();
		startCanvas.enabled = true;
		ball = GameObject.FindGameObjectWithTag("Ball");
		win = goal.gameObject.GetComponentInChildren<AudioSource>();
		rb = ball.gameObject.GetComponentInChildren<Rigidbody2D>();
		bounce = ball.gameObject.GetComponentInChildren<AudioSource>();
		startCanvas.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = true;
		pauseButton.gameObject.SetActive(false);
		startCanvas.gameObject.transform.GetChild(2).gameObject.SetActive(false);
		startCanvas.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = false;
		foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Platform"))
		{
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
		Time.timeScale = 0.0f;
    }
	void CheckCurrentLevel()
	{
		for(int i = 1; i < levelAmount; i++)
		{
			if((SceneManager.GetActiveScene().name == "Level "+i))
			{
				currentLevel = i;
				SaveMyGame();
			}
		}
	}
	void SaveMyGame()
	{
		int nextLevel = currentLevel + 1;
		if(nextLevel < levelAmount + 1)
		{
			PlayerPrefs.SetInt("Level "+nextLevel.ToString(),1); //unlock next level
			//PlayerPrefs.SetInt("Level "+currentLevel.ToString()+"_score",score);
		}
	//	else
	//	{
			//PlayerPrefs.SetInt("Level "+currentLevel.ToString()+"_score",score);
	//	}
	}
	public void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Platform")
		{
			if (coll.relativeVelocity.magnitude > 0.2)
            bounce.Play();
		}
		if(coll.gameObject.tag == "Goal")
		{
			win.Play();
			Debug.Log("Level Complete");
			Time.timeScale = 0.0f;
			GameObject tempObject = GameObject.Find("StartGame");
			startCanvas = tempObject.GetComponent<Canvas>();
			startCanvas.gameObject.transform.GetChild(1).gameObject.SetActive(false);
			startCanvas.gameObject.transform.GetChild(0).gameObject.SetActive(true);
		    startCanvas.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = false;
			startCanvas.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = true;
			foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Platform"))
			{
				gameObject.GetComponent<BoxCollider2D>().enabled = false;
			}
		}
	}
	public void NextLevel()
	{
		GetComponent<AudioSource>().Play();
		if(startCanvas.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().enabled == true)
		{
			GameSettings.index=+1;
			SceneManager.LoadScene(0);
		}
	}
	public void OnMouse()
	{
		GetComponent<AudioSource>().Play();
		if(!isAlreadyClicked)
		{
			//rb.AddForce(new Vector2(moveSpeed,10));
			rb.AddRelativeForce(new Vector2(moveSpeed,-150));
			isAlreadyClicked = true;
			Debug.Log("mousedown");
			startCanvas.gameObject.transform.GetChild(0).gameObject.SetActive(false);
			pauseButton.gameObject.SetActive(true);
			Time.timeScale = 1.0f;
			foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Platform"))
			{
				gameObject.GetComponent<BoxCollider2D>().enabled = true;
			}
			StartCoroutine(Restart());		
		}
	}
	public IEnumerator Restart() 
	{
		while (true)
		{
        	Debug.Log("stopped");
        	//limit the check by 1 per second
        	yield return new WaitForSeconds(1f);
        	if (rb.IsSleeping())
        	{
            	yield return new WaitForSeconds(2);
            	Debug.Log("lose");
            	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				Debug.Log("reset");	
        	}
    	}
	}
	public void PauseGame()
	{
		GetComponent<AudioSource>().Play();
		pauseButton.gameObject.SetActive(false);
		startCanvas.gameObject.transform.GetChild(2).gameObject.SetActive(true);
		startCanvas.gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(false);
		Time.timeScale =  0.0f;
		foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Platform"))
		{
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
		Debug.Log("pause");
	}
	public void ResumeGame()
	{
		GetComponent<AudioSource>().Play();
		pauseButton.gameObject.SetActive(true);
		startCanvas.gameObject.transform.GetChild(2).gameObject.SetActive(false);
		Time.timeScale = 1.0f;
		foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Platform"))
		{
			gameObject.GetComponent<BoxCollider2D>().enabled = true;
		}
		Debug.Log("resumed");
	}
	public void Home()
	{
		GetComponent<AudioSource>().Play();
		GameSettings.index=0;
		SceneManager.LoadScene(0);
	}

	public void Settings()
	{
		GetComponent<AudioSource>().Play();
		startCanvas.gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(true);
	}
}
