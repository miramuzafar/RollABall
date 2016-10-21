using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {

	public float moveSpeed = 5;
	public static bool isAlreadyClicked = false;
	//private Rigidbody2D rb;

	//private static float v;

	void Start() 
    {
		//isAlreadyClicked = false;
		//rb = GetComponent<Rigidbody2D>();
	   Reset();
		//moveSpeed = 5;
		//rb = GetComponent<Rigidbody>();
		//rb = GetComponent<Rigidbody2D>();
		//GetComponent<Rigidbody2D>().AddForce (Vector2, ForceMode2D.Impulse);
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed,0));
    }

	void Update()
	{
		if(Input.GetMouseButton(1))
		{
			
			if(!isAlreadyClicked)
			{
				//gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2, ForceMode2D.Impulse);
				GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed,0));
				//v = BallCondition.rb.velocity;
				//Debug.Log(BallCondition.rb.velocity);
				Debug.Log("clicked");
				isAlreadyClicked = true;
				//BallCondition player = GetComponent<BallCondition>();
				//StartCoroutine(player.Restart());		
			}		
		}
		
	}
	public void Reset()
	{
		isAlreadyClicked = false;
	}
}
