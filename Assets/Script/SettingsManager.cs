using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour {

	// Use this for initialization
	public Toggle audioEnabled;
	public Canvas settingsCanvas;
	public Button applyButton;
	public GameSettings gameSettings;

	void OnEnable()
	{
		gameSettings = new GameSettings();
		audioEnabled.onValueChanged.AddListener(delegate{AudioDisabledToggle();});
		Debug.Log(GameSettings.index);
		applyButton.onClick.AddListener(delegate{OnApplyButtonClick();});
		LoadSettings();
	}
	public void AudioDisabledToggle()
	{
		Debug.Log(gameSettings.audioEnabled);
		gameSettings.audioEnabled = AudioListener.pause = !audioEnabled.isOn;
	}
	public void OnApplyButtonClick()
	{
		SaveSettings();
		foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Settings"))
		{
			GetComponent<AudioSource>().Play();
			gameObject.SetActive(false);
		}
	}
	public void SaveSettings()
	{
		string jsonData = JsonUtility.ToJson(gameSettings, true);
		File.WriteAllText(Application.persistentDataPath + "/gameSettings.json", jsonData);
		Debug.Log("Saved");
	}
	public void LoadSettings()
	{
		File.ReadAllText(Application.persistentDataPath + "/gameSettings.json");
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gameSettings.json"));
		Debug.Log("Loaded");
		audioEnabled.isOn = !gameSettings.audioEnabled;
		//Debug.Log("Loaded");
	}
}
