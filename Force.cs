using UnityEngine;
using System.Collections;

public class Force : MonoBehaviour {

	public float moveSpeed = 5;
	bool isAlreadyClicked = false;

	/*void Start() 
    {
        //rb = GetComponent<Rigidbody>();
		//GetComponent<Rigidbody2D>().AddForce (Vector2, ForceMode2D.Impulse);
		//GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed,0));
    }*/

	void Update()
	{
		if(Input.GetMouseButton(0))
		{
			if(!isAlreadyClicked)
			{
				//gameObject.GetComponent<Rigidbody2D>().AddForce (Vector2, ForceMode2D.Impulse);
				GetComponent<Rigidbody2D>().AddForce(new Vector2(moveSpeed,0));
			}
			isAlreadyClicked = true;	
		}
	}
}
