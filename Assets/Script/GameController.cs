using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class GameController : MonoBehaviour {

	float moveSpeed = 40;
	public Vector3[] characterLocation;
	public Vector3[] respawnBallLocation;
	public Vector3[] respawnGoalLocation;
	public ParticleSystem ps;
	public ParticleSystem goalEffect;
	public GameObject goal;
	public GameObject respawnBall;
	public ParticleSystem explosion;
	//int score = 1;
	private int levelAmount = 12;
	private int currentLevel;
	public Canvas startCanvas;
	public Image backgroundImage;
	public Button pauseButton;
	public GameObject ball;
	public bool isAlreadyClicked = false;
	public bool active = false;
	public Rigidbody2D rb;


	void Start() 
    {
		Debug.Log("restart");
		//PlayerPrefs.SetInt("Level 2", 1);
		//PlayerPrefs.SetInt("Level_1_score", score);
		CheckCurrentLevel();
		backgroundImage = startCanvas.gameObject.GetComponent<Image>();
		backgroundImage.enabled = true;
		GameObject ballTemp = (GameObject)Instantiate(ball,characterLocation[CreateLevel.currentLevel-1],Quaternion.identity);
		ball = GameObject.FindGameObjectWithTag("Ball");
		GameObject respawnBallTemp = (GameObject)Instantiate(respawnBall,respawnBallLocation[CreateLevel.currentLevel-1],Quaternion.identity);
		respawnBall = GameObject.FindGameObjectWithTag("Particles");
		GameObject goalTemp = (GameObject)Instantiate(goal,respawnGoalLocation[CreateLevel.currentLevel-1],Quaternion.identity);
		goal = GameObject.FindGameObjectWithTag("Goal");
		ps = ballTemp.gameObject.GetComponentInChildren<ParticleSystem>();
		explosion = respawnBallTemp.gameObject.GetComponentInChildren<ParticleSystem>();
		goalEffect = goalTemp.gameObject.GetComponentInChildren<ParticleSystem>();
		startCanvas.enabled = true;
		rb = ballTemp.gameObject.GetComponentInChildren<Rigidbody2D>();
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
		Debug.Log(CreateLevel.currentLevel);
		for(int i = 1; i < levelAmount; i++)
		{
			if((CreateLevel.currentLevel.ToString() == "Level "+i))
			{
				CreateLevel.currentLevel = i;
			}
		}
	}
	public void NextLevel()
	{
		GetComponent<AudioSource>().Play();
		if(startCanvas.gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().enabled == true)
		{
			SaveMyGame();
			GameSettings.index = true;
			SceneManager.LoadScene(0);
		}
	}
	void SaveMyGame()
	{
		int nextLevel = CreateLevel.currentLevel + 1;
		if(nextLevel < levelAmount + 1)
		{
			CreateLevel.currentLevel = nextLevel;
			PlayerPrefs.SetInt("Level "+nextLevel.ToString(),1); //unlock next level
			Debug.Log(CreateLevel.currentLevel);
			//nextLevel = CreateLevel.currentLevel++;
			//PlayerPrefs.SetInt("Level "+currentLevel.ToString()+"_score",score);
		}
	//	else
	//	{
			//PlayerPrefs.SetInt("Level "+currentLevel.ToString()+"_score",score);
	//	}
	}
	public void OnMouse()
	{
		GetComponent<AudioSource>().Play();
		if(!isAlreadyClicked)
		{
			backgroundImage.enabled = false;
			rb.AddRelativeForce(new Vector2(moveSpeed,-150));
			explosion.Play();
			StartCoroutine(StopParticle());	
			ps.Play();
			goalEffect.Play();
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
	public IEnumerator StopParticle()
	{
		yield return new WaitForSeconds(1f);
		explosion.Clear();
	}
	public IEnumerator Restart() 
	{
		while (true)
		{
        	Debug.Log(rb.IsSleeping());
        	//limit the check by 1 per second
        	yield return new WaitForSeconds(1f);
        	if (rb.IsSleeping())
        	{
				Debug.Log("stopped");
            	yield return new WaitForSeconds(1);
            	Debug.Log("lose");
            	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				currentLevel = CreateLevel.currentLevel;
				Debug.Log("reset");	
        	}
    	}
	}
	public void PauseGame()
	{
		GetComponent<AudioSource>().Play();
		pauseButton.gameObject.SetActive(false);
		//backgroundImage.enabled = true;
		startCanvas.gameObject.transform.GetChild(2).gameObject.SetActive(true);
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
		//backgroundImage.enabled = false;
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
		GameSettings.index = false;
		SceneManager.LoadScene(0);
	}
	public void RestartButton()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		currentLevel = CreateLevel.currentLevel;
	}

	public void Settings(Animator anim)
	{
		GetComponent<AudioSource>().Play();
		anim.SetBool("IsDisplayed", true);
	}
}
