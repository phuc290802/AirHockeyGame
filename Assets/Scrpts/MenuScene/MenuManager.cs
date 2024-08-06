using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour    
{
    public Toggle MultiplayerToggle;
	public GameObject levelToggles;
	private void Start()
	{
		MultiplayerToggle.onValueChanged
		   .AddListener(isMultiplayerOn => levelToggles.SetActive(!isMultiplayerOn));
		MultiplayerToggle.isOn = GameValues.IsMultiplayer;
		MultiplayerToggle.isOn = GameValues.IsMultiplayer;
		levelToggles.transform.GetChild((int)GameValues.Difficulty).GetComponent<Toggle>().isOn = true;
	}
	public void PlayGame()
    {
        SceneManager.LoadScene("main");
    }
    public void SetMultiplayer(bool isOn)
    {
        GameValues.IsMultiplayer = isOn;
    }
	#region Difficulty
	public void SetEasyDifficulty(bool isOn)
	{
		if (isOn)
			GameValues.Difficulty = GameValues.Difficulties.Easy;
	}

	public void SetMediumDifficulty(bool isOn)
	{
		if (isOn)
			GameValues.Difficulty = GameValues.Difficulties.Medium;
	}

	public void SetHardDifficulty(bool isOn)
	{
		if (isOn)
			GameValues.Difficulty = GameValues.Difficulties.Hard;
	}
	#endregion
}
