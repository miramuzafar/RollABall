using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour {

	// Use this for initialization
	public Toggle audioEnabled;
	public Button applyButton;
	public GameSettings gameSettings;

	void OnEnable()
	{
		gameSettings = new GameSettings();
		audioEnabled.onValueChanged.AddListener(delegate{AudioDisabledToggle();});
		Debug.Log(GameSettings.index);
		LoadSettings();
	}
	public void AudioDisabledToggle()
	{
		Debug.Log(gameSettings.audioEnabled);
		gameSettings = new GameSettings();
		gameSettings.audioEnabled = AudioListener.pause = !audioEnabled.isOn;
	}
	public void OnApplyButtonClick(Animator anim)
	{
		SaveSettings();
		foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Settings"))
		{
			GetComponent<AudioSource>().Play();
			anim.SetBool("IsDisplayed", false);
		}
	}
	public void SaveSettings()
	{
		string jsonData = JsonUtility.ToJson(gameSettings, true);
		File.WriteAllText(Application.persistentDataPath + "/Gamesettings.json", jsonData);
		Debug.Log("Saved");
	}
	public void LoadSettings()
	{
		File.ReadAllText(Application.persistentDataPath + "/Gamesettings.json");
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/Gamesettings.json"));
		Debug.Log("Loaded");
		audioEnabled.isOn = !gameSettings.audioEnabled;
	}
}
