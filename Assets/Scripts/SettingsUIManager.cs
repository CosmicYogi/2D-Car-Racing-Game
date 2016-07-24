using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsUIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetInputMethodOnButtonDown(string inputMethod){
		
		PlayerPrefsManager.SetInputMethodOnTouchScreenMobileDevice (inputMethod);
	}
	public void BackButtonPressed(string sceneName){
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
	}
}
