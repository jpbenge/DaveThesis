using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class ProfileSaver : MonoBehaviour {

	Profile prof;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnApplicationQuit()
	{
		SaveProfile();
	}

	public void SaveProfile()
	{
		prof = new Profile();
		prof.playerName = PlayerPrefs.GetString("playerName");
		prof.totalTime = PlayerPrefs.GetFloat("Total Time");
		prof.pTim = PlayerPrefs.GetInt("pTim");
		prof.pFin = PlayerPrefs.GetInt("pFin");
		prof.pEth = PlayerPrefs.GetInt("pEth");
		prof.pEnv = PlayerPrefs.GetInt("pEnv");
		prof.pCom = PlayerPrefs.GetInt("pCom");
		prof.pPol = PlayerPrefs.GetInt("pPol");
		prof.pPub = PlayerPrefs.GetInt("pPub");
		prof.completedScenarios = PlayerPrefsX.GetStringArray("Completed_Scenarios");
		prof.loggedInfo = PlayerPrefsX.GetStringArray("Logged_Information");
		prof.loggedInfo = PlayerPrefsX.GetStringArray("Logged_Information");
		prof.achievements = PlayerPrefsX.GetStringArray("Achievements");

		Stream stream = File.Open(Application.dataPath+"/Resources/Profile/profile.ncarb", FileMode.Create);
		BinaryFormatter bformatter = new BinaryFormatter();
		Debug.Log("Creating Player Profile");
		bformatter.Serialize(stream, prof);
		stream.Close();

	}
}
