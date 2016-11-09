using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public float moveSpeed = 5;
	public Canvas startCanvas;
	public Button pauseButton;
	public GameObject ball;
	public bool isAlreadyClicked = false;
	public bool active = false;
	public Rigidbody2D rb;
	public AudioSource bounce;
	//AudioSource buttonSound;


	void Start() 
    {
		Debug.Log("restart");
		startCanvas.enabled = true;
		ball = GameObject.FindGameObjectWithTag("Ball");
		//bounce.isReadyToPlay();
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
	public void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "Platform")
		{
			if (coll.relativeVelocity.magnitude > 0.2)
            bounce.Play();
		}
		if(coll.gameObject.tag == "Goal")
		{
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
			//startCanvas.gameObject.SetActive(false);
			SceneManager.LoadScene(0);
		}
	}
	public void OnMouse()
	{
		GetComponent<AudioSource>().Play();
		if(!isAlreadyClicked)
		{
			rb.AddForce(new Vector2(moveSpeed,0));
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
            	SceneManager.LoadScene(1);
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
		SceneManager.LoadScene(0);
	}

	public void Settings()
	{
		GetComponent<AudioSource>().Play();
		startCanvas.gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(true);
	}
}
