using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoade_Game : MonoBehaviour
{
	public Animator transition;
	public int transitionTime;

	void Update()
	{

	}

	public void LoadNextLevel()
	{
		StartCoroutine(LoadLevel());
	}

	IEnumerator LoadLevel()
	{
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(4);
	}
}