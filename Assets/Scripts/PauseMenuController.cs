using System;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
	public GameObject PauseMenuRoot;
	public GameObject OptionCanvas;
	public bool StopTimeWhileOnPause = true;

	private bool _isPauseActive;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if(OptionCanvas.activeSelf)
				HideOptionCanvas();
			else
				TogglePause(!_isPauseActive);
		}
	}

	private void HideOptionCanvas()
	{
		OptionCanvas.SetActive(false);
		PauseMenuRoot.SetActive(true);
	}

	public void TogglePause(bool pause)
	{
		if (StopTimeWhileOnPause)
			Time.timeScale = pause ? 0f : 1f;

		PauseMenuRoot.SetActive(pause);
		_isPauseActive = pause;
	}
}
