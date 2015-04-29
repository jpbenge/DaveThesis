using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	BlurEffect blurScript;
	bool paused;
	public GUISkin gskin;
	// Use this for initialization
	void Start () {
		paused = false;
		blurScript = GetComponent<BlurEffect>();
		audio.ignoreListenerPause = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Pause"))
		{
			if (!paused)
			{
				paused = true;
				blurScript.enabled = true;
				Time.timeScale = 0f;
				AudioListener.pause = true;
				audio.Play();
			}
			else
			{
				paused = false;
				blurScript.enabled = false;
				Time.timeScale = 1f;
				AudioListener.pause = false;
			}
		}
	}

	void OnGUI() {
		GUI.skin = gskin;
		if (paused)
		{
			GUI.Label(new Rect((Screen.width/2)-151,(Screen.height/2)-50,300,100),"Paused","PauseTextOutline");
			GUI.Label(new Rect((Screen.width/2)-150,(Screen.height/2)-51,300,100),"Paused","PauseTextOutline");
			GUI.Label(new Rect((Screen.width/2)-149,(Screen.height/2)-50,300,100),"Paused","PauseTextOutline");
			GUI.Label(new Rect((Screen.width/2)-150,(Screen.height/2)-49,300,100),"Paused","PauseTextOutline");
			GUI.Label(new Rect((Screen.width/2)-150,(Screen.height/2)-50,300,100),"Paused","PauseText");

		}
	}
}
