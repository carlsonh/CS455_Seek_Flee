
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
	private bool bGameHasEnded = false;
	public float gameEndRestartWait = 1f;

	public GameObject completeLevelUI;

	public void LevelComplete()
	{
		completeLevelUI.SetActive(true);
	}


	public void GameEnd ()
	{
		if(!bGameHasEnded)
		{
			bGameHasEnded = true;
			Debug.Log("Game End");
			Invoke("Restart", gameEndRestartWait);
		}
	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
