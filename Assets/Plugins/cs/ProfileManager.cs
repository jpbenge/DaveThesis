using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;


public class ProfileManager : MonoBehaviour {

	public GUISkin gskin;
	public GameObject profileCreate;
	public GameObject mainUi;
	string nameString = "New User";
	float baseWidth = 1280;
	float baseHeight = 720;
	public bool noProfile = false;
	public Profile prof;
	// Use this for initialization

	void Awake () {
		if (IsFileValid(Application.dataPath+"/Resources/Profile/profile.ncarb"))
		{
			LoadProfile();
			UpdatePlayerPrefs();
		}
		else
		{	
			NoValidProfile();
		}
	}

	void Start () {

	}

	void NoValidProfile()
	{
		noProfile = true;
		mainUi.SetActive(false);
		profileCreate.SetActive(true);

		//CreateProfile();
	}
	
	// Update is called once per frame
	void OnGUI()
	{
		if (noProfile)
		{
			Vector3 scale = Vector3.zero;
	 		scale.x = Screen.width / baseWidth;
	 		scale.y = Screen.height / baseHeight;
	 		scale.z = 1f;
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
			GUI.skin = gskin;
			nameString = GUI.TextField(new Rect(600,375,240,50),nameString, 40, "darkBox");
		}	
	}
	void OnApplicationQuit()
	{
		if (!noProfile)
			SaveProfile();
	}

	void SaveProfile()
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

	void LoadProfile()
	{
		prof = new Profile();
		//Open the file written above and read values from it.
		Stream stream = File.Open(Application.dataPath+"/Resources/Profile/profile.ncarb", FileMode.Open);
		BinaryFormatter bformatter = new BinaryFormatter();
        
		Debug.Log("Reading Player Profile");
		prof = (Profile)bformatter.Deserialize(stream);
		stream.Close();
            
		Debug.Log("Player Name: "+ prof.playerName);
		
	}

	void UpdatePlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetString("playerName", prof.playerName);
		PlayerPrefs.SetFloat("Total Time", prof.totalTime);
		PlayerPrefs.SetInt("pTim", prof.pTim);
		PlayerPrefs.SetInt("pFin", prof.pFin);
		PlayerPrefs.SetInt("pEth", prof.pEth);
		PlayerPrefs.SetInt("pEnv", prof.pEnv);
		PlayerPrefs.SetInt("pCom", prof.pCom);
		PlayerPrefs.SetInt("pPol", prof.pPol);
		PlayerPrefs.SetInt("pPub", prof.pPub);
		if (prof.completedScenarios.Length > 0)
			PlayerPrefsX.SetStringArray("Completed_Scenarios",prof.completedScenarios);
		if (prof.loggedInfo.Length > 0)
			PlayerPrefsX.SetStringArray("Logged_Information",prof.loggedInfo);
		if (prof.achievements.Length > 0)
			PlayerPrefsX.SetStringArray("Achievements", prof.achievements);

	}

	void CreateProfile(string profName = "No Name")
	{
		prof = new Profile();
		prof.playerName = profName;
		prof.totalTime = 0f;
		prof.pEth = 0;
		prof.pEnv = 0;
		prof.pFin = 0;
		prof.pCom = 0;
		prof.pPol = 0;
		prof.pPub = 0;
		prof.pTim = 0;

		prof.completedScenarios = new string[0];
		prof.loggedInfo = new string[0];
		prof.achievements = new string[0];
		// Open a file and serialize the object into it in binary format.
		// EmployeeInfo.osl is the file that we are creating. 
		// Note:- you can give any extension you want for your file
		// If you use custom extensions, then the user will know
		// that the file is associated with your program.
		Stream stream = File.Open(Application.dataPath+"/Resources/Profile/profile.ncarb", FileMode.Create);
		BinaryFormatter bformatter = new BinaryFormatter();
		Debug.Log("Creating Player Profile");
		bformatter.Serialize(stream, prof);
		stream.Close();

	}


	private bool IsFileValid(string filePath)
    {
        bool IsValid = true;

        if (!File.Exists(filePath))
        {
            IsValid = false;
        }
        else if (Path.GetExtension(filePath).ToLower() != ".ncarb")
        {
            IsValid = false;
        }
        return IsValid;
    }

    public void OnCreateClicked()
    {
    	CreateProfile(nameString);
		UpdatePlayerPrefs();
		mainUi.SetActive(true);
		profileCreate.SetActive(false);
		noProfile = false;
    }
}
