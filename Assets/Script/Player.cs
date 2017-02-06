using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	// Use this for initialization
	AudioSource bounce;
	public AudioSource win;
	public GameObject goal;
	public Canvas startCanvas;
	public Image backgroundImage;
	public ParticleSystem fireBall;
	public ParticleSystem sparks;
	public GameObject rockParticle;
	void Start () {

		goal = GameObject.FindGameObjectWithTag("Goal");
		bounce = gameObject.GetComponentInChildren<AudioSource>();
		fireBall.gameObject.SetActive(true);
		sparks.gameObject.SetActive(true);
	}
	
	public void OnCollisionEnter2D(Collision2D coll)
	{
		Debug.Log("bounce");
		
		if(coll.gameObject.tag == "Platform")
		{
			if(coll.relativeVelocity.magnitude > 1.5)
         	bounce.Play();
		}
		if(coll.gameObject.tag == "Goal")
		{
			StartCoroutine(Explode());
		}
	}
	public IEnumerator Explode()
	{
		Instantiate(rockParticle, goal.transform.position, goal.transform.rotation);
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		fireBall.gameObject.SetActive(false);
		sparks.gameObject.SetActive(false);
		goal.gameObject.transform.GetChild(0).gameObject.SetActive(false);
		goal.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		goal.gameObject.GetComponent<BoxCollider2D>().enabled = false;
		yield return new WaitForSeconds(3f);
		goal.GetComponent<AudioSource>().Play();
		Debug.Log("Level Complete");
		Time.timeScale = 0.0f;
		GameObject tempObject = GameObject.FindGameObjectWithTag("StartGame");
		startCanvas = tempObject.GetComponent<Canvas>();
		startCanvas.gameObject.GetComponent<Image>().enabled = true;
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
