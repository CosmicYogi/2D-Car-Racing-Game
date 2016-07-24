using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string INPUT_METHOD_TOUCH_SCREEN_KEY = "touch_screen_input";

	public static void SetInputMethodOnTouchScreenMobileDevice(string inputMethod){
		PlayerPrefs.SetString (INPUT_METHOD_TOUCH_SCREEN_KEY, inputMethod);
	}
	public static string GetInputMethodOnTouchScreenMobileDevice(){
		return PlayerPrefs.GetString (INPUT_METHOD_TOUCH_SCREEN_KEY);
	}
}
