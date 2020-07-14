using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {


	public TMPro.TMP_InputField name;

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}


	public void StartEasy()
	{
		SceneManager.LoadScene(2);
	}


	public void StartNormal()
	{
		SceneManager.LoadScene(1);
	}
	public void StartHard()
	{
		SceneManager.LoadScene(3);
	}

	void Start()
	{
		if(PlayerPrefs.GetString("nome").Equals(""))
		PlayerPrefs.SetString("nome", "default");

		AudioManager.current.PlayBackGround();
	}


	public void saveName()
	{
		PlayerPrefs.SetString("nome", name.text);
		
	}
}
