using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class SettingsManager : MonoBehaviour {

	// Use this for initialization
	public Toggle audioEnabled;
	public GameSettings gameSettings;
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
