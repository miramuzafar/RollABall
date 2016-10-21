using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BallCondition : MonoBehaviour {

	// Use this for initialization
	public bool isLose = false;
	float timeLeft = 2.0f;
	public Rigidbody2D rb;

	void Awake () {

		rb = GetComponent<Rigidbody2D>();	
	}
	void Update()
	{
		//Debug.Log(rb.velocity);
		if((rb.velocity.x)==0 && (rb.velocity.y) == 0 && Force.isAlreadyClicked == true)
		{
			timeLeft -=Time.deltaTime;
			if(timeLeft < 0)
			{
				StartCoroutine(Restart());
			}
		}
		else
		return;
	}
	public IEnumerator Restart() 
	 {
		if((rb.velocity.x)==0 && (rb.velocity.y) == 0)
		{
			yield return new WaitForSeconds(1);
			Debug.Log("lose");
			isLose = true;
			SceneManager.LoadScene(0);	
		}
	 }
}
