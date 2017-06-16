using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {


	public void NewGameBtn(string newGameLevel){

		SceneManager.LoadScene(newGameLevel);
	}
		
	public void ExitGameBtn(){

		Application.Quit();
	}
}
