using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {
	public void GoToScene(string sceneName) 
	{
		SceneManager.LoadScene(sceneName);
	}

}
