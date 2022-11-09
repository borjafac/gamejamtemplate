using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public void LoadLevel(int index)
	{
		SceneManager.LoadScene(index);
		Time.timeScale = 1f;
	}

	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
		Time.timeScale = 1f;
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1f;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
