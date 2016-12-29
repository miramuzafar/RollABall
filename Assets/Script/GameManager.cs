using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public Canvas levelCanvas;
	public Canvas menuCanvas;
	public Image backgroundCanvas;
	private Transform cameraTransform;
	private Transform cameraDesiredLookAt;
	public float speed = 0.01f;

	void Start()
	{
		cameraTransform = Camera.main.transform;
		backgroundCanvas = menuCanvas.gameObject.GetComponent<Image>();
		backgroundCanvas.enabled = false;
		Time.timeScale = 1.0f;
		if(GameSettings.index == true)
		{
			StartLevel(levelCanvas.transform);
		}
		else
		{
			StartLevel(menuCanvas.transform);
		}
	}
	void Update()
	{
		if(cameraDesiredLookAt !=null)
		{
			cameraTransform.position = Vector2.Lerp(cameraTransform.position, cameraDesiredLookAt.position,(Mathf.Sin(speed * Time.deltaTime) + 1.0f)/2.0f);
		}
	}
	public void StartLevel(Transform menuTransform)
	{
		GetComponent<AudioSource>().Play();
		cameraDesiredLookAt = menuTransform;
		Debug.Log("clicked");
	}
	public void ExitGame()
	{
		GetComponent<AudioSource>().Play();
		Debug.Log("exit");
		Application.Quit ();
	}
	public void Settings(Animator anim)
	{
		GetComponent<AudioSource>().Play();
		//backgroundCanvas.enabled = true;
		anim.SetBool("IsDisplayed", true);
	}
}
