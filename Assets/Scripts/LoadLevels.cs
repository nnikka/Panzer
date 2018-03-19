using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour {

	public void LoadLevel(string name) {
	     SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
	     Application.Quit();
	}
}
