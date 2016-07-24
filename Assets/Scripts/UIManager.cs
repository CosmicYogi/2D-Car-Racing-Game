using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text buttonCaption;
	public Text scoreText;
	public Button[] buttonArray;
	private int score;
	private bool gameOver = false;
	void Start(){
		score = 0;
		InvokeRepeating ("UpdateScore", 1f, 1f);
	}

	void Update(){
		scoreText.text = "Score: " + score + " m";
	}
	void UpdateScore(){
		if (!gameOver) {
			score += 1;
		}
	}
	public void PausePlay(){
		if (Time.timeScale == 0) {
			Time.timeScale = 1;
			buttonCaption.text = "II";
		} else {
			Time.timeScale = 0;
			buttonCaption.text = "I>";
		}
	}

	public void GameIsOver(){
		gameOver = true;
		foreach (Button btn in buttonArray) {
			btn.gameObject.SetActive (true);
		}
	}
	public void LoadLevel(string level){
		UnityEngine.SceneManagement.SceneManager.LoadScene (level);
	}
	public void LoadNextLevel(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex + 1);
	}
	public void ResetLevel(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().buildIndex);
	}
	public void Exit(){
		Application.Quit();
	}
}
