using UnityEngine;

public class CreateLevel : MonoBehaviour {

	public GameObject[] Levels;
	public static int currentLevel = 0;

	// Use this for initialization
	void Start () {
		GameObject obj = Instantiate(Levels[currentLevel-1]) as GameObject;
	}
}
