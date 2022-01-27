using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : Singleton<SceneController> {

	
	public void RestartScene (){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void GoToScene(string sceneName){		
		StartCoroutine(ProceedToScene(sceneName));

	}

	IEnumerator ProceedToScene(string sceneName){
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene (sceneName);
    }

	public void QuitGame(){		
		Debug.Log("Quit Game");
		Application.Quit ();
	}
	
		
}
