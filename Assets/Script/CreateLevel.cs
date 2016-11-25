using UnityEngine;

public class CreateLevel : MonoBehaviour {

	public GameObject[] Levels;
	public static int currentLevel = 0;

	// Use this for initialization
	void Start () {
		GameObject obj = Instantiate(Levels[currentLevel-1]) as GameObject;
		//PlayerPrefs.SetInt ("Level ",1);
		//currentLevel=PlayerPrefs.GetInt ("Level ");
		//obj.transform.SetParent(transform,false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
