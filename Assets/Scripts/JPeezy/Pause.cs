using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	BlurEffect blurScript;
	bool paused;
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
		if (paused)
		{
			GUI.Label(new Rect((Screen.width/2)-30,(Screen.height/2)-10,60,20),"Paused");
		}
	}
}
