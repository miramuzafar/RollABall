using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour {

	// Use this for initialization
	public Toggle audioEnabled;
	public GameSettings gameSettings;
	public Canvas settingsCanvas;
	public Button applyButton;
	void OnEnable()
	{
		gameSettings = new GameSettings();
		audioEnabled.onValueChanged.AddListener(delegate{AudioDisabledToggle();});
		applyButton.onClick.AddListener(delegate{OnApplyButtonClick();});
		LoadSettings();
	}
	public void AudioDisabledToggle()
	{
		gameSettings.audioEnabled = AudioListener.pause = !audioEnabled.isOn;
	}
	public void OnApplyButtonClick()
	{
		SaveSettings();
		foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Settings"))
		{
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
		audioEnabled.isOn = !gameSettings.audioEnabled;
		Debug.Log("Loaded");
	}
}
