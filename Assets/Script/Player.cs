﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	// Use this for initialization
	AudioSource bounce;
	public AudioSource win;
	public GameObject goal;
	public Canvas startCanvas;
	void Start () {

		goal = GameObject.FindGameObjectWithTag("Goal");
		bounce = gameObject.GetComponentInChildren<AudioSource>();
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
			goal.GetComponent<AudioSource>().Play();
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
}
