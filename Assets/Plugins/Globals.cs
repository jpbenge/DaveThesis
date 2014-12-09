using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {

	//working file path directory
	public static string directory = "";
	//scenarios in the working directory
	public static string[] dirs;

	//currently active scenario
	public static string collectionName = "Misc";
	public static string scenarioName = "Fantasia Hotel";
	public static string scenarioDescription = "";
	public static int scenarioIndex = 0;

	//current state - row.scene
	public static float state = 0f;
	//main menu state 0 = normal, 1 = selecting scenario
	public static int menuState = 0;

	//player total values
	public static float totalTime = 0;
	public static int pEnv = 0;
	public static int pEth = 0;
	public static int pFin = 0;
	public static int pPol = 0;
	public static int pCom = 0;
	public static int pTim = 0;
	public static int pPub = 0;

	public static int cSat = 0;



	// current scenario values=========================================
	public static int scenarioScenes = 0;
	// scenario failure values

	public static float fTim = 0;
	public static float fEth = 0;
	public static float fEnv = 0;
	public static float fFin = 0;
	public static float fPol = 0;
	public static float fCom = 0;
	public static float fPub = 0;

	//player total values specific to this scenario

	public static int lTim = 0;
	public static int lEth = 0;
	public static int lEnv = 0;
	public static int lFin = 0;
	public static int lPol = 0;
	public static int lCom = 0;
	public static int lPub = 0;

	//current scene values============================================


	public static string sceneType = "";
	public static string[] sceneText;
	public static int sceneTextIndex = 0;
	public static int choice1Index = 0;
	public static int choice2Index = 0;
	public static int choice3Index = 0;
	//current target values
	public static float tTim = 0;
	public static float tEth = 0;
	public static float tEnv = 0;
	public static float tFin = 0;
	public static float tPol = 0;
	public static float tCom = 0;
	public static float tPub = 0;
	//current choice 1 values
	public static string[] choice1Text;
	public static float choice1Tim = 0;
	public static float choice1Eth = 0;
	public static float choice1Env = 0;
	public static float choice1Fin = 0;
	public static float choice1Pol = 0;
	public static float choice1Com = 0;
	public static float choice1Pub = 0;
	public static string choice1Response;
	//current choice 2 values
	public static string[] choice2Text;
	public static float choice2Tim = 0;
	public static float choice2Eth = 0;
	public static float choice2Env = 0;
	public static float choice2Fin = 0;
	public static float choice2Pol = 0;
	public static float choice2Com = 0;
	public static float choice2Pub = 0;
	public static string choice2Response;
	//current choice 3 values
	public static string[] choice3Text;
	public static float choice3Tim = 0;
	public static float choice3Eth = 0;
	public static float choice3Env = 0;
	public static float choice3Fin = 0;
	public static float choice3Pol = 0;
	public static float choice3Com = 0;	
	public static float choice3Pub = 0;
	public static string choice3Response;

	//the impact of the last choice, used to drive the feadback system
	public enum LastChoiceImpact {
		Tim = 0,
		Fin = 1,
		Eth = 2,
		Env = 3,
		Com = 4,
		Pol = 5,
		Pub = 6
	};

	public static bool inDiologue = false;
	
	public LastChoiceImpact lastImpact;

	//is the player in a scenario?
	public static int orgState = -1;

	
	public void Start()
	{
		if (PlayerPrefs.GetFloat("Total Time") == null)
			PlayerPrefs.SetFloat("Total Time", 0f);
		if (PlayerPrefs.GetFloat("tTim") == null)
			PlayerPrefs.SetFloat("tTim", 0f);
		if (PlayerPrefs.GetFloat("tFin") == null)
			PlayerPrefs.SetFloat("tFin", 0f);
		if (PlayerPrefs.GetFloat("tEth") == null)
			PlayerPrefs.SetFloat("tEth", 0f);
		if (PlayerPrefs.GetFloat("tEnv") == null)
			PlayerPrefs.SetFloat("tEnv", 0f);
		if (PlayerPrefs.GetFloat("tCom") == null)
			PlayerPrefs.SetFloat("tCom", 0f);
		if (PlayerPrefs.GetFloat("tPol") == null)
			PlayerPrefs.SetFloat("tPol", 0f);
		if (PlayerPrefs.GetFloat("tPub") == null)
			PlayerPrefs.SetFloat("tPub", 0f);

		pFin = PlayerPrefs.GetInt("pFin");
		pEth = PlayerPrefs.GetInt("pEth");
		pEnv = PlayerPrefs.GetInt("pEnv");
		pCom = PlayerPrefs.GetInt("pCom");
		pPol = PlayerPrefs.GetInt("pPol");
		pPub = PlayerPrefs.GetInt("pPub");
		pTim = PlayerPrefs.GetInt("pTim");
		
	}

	// Use this for initialization
	public static void Init () {
		//set hte working directory
		directory = Application.dataPath+"/Resources/scenarios";
		state = 0f;
		menuState = 0;
		cSat = 0;
		orgState = -1;
		lTim = 0;
		lEth = 0;
		lEnv = 0;
		lFin = 0;
		lPol = 0;
		lCom = 0;
		lPub = 0;

		FillDirectoryArray();
	}
	

	public static void FillDirectoryArray()
	{
		try
        {
            // get all the subdirectories in the Resources folder - add them to an array
            dirs = System.IO.Directory.GetDirectories(directory);
            //print("The number of directories is "+dirs.Length);
            for(int i = 0;i<dirs.Length;i++)
            {
                //print(dirs[i]);
				if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor)
                	dirs[i] = dirs[i].Substring(dirs[i].LastIndexOf(("/"))+1);
				else
					dirs[i] = dirs[i].Substring(dirs[i].LastIndexOf(("\\"))+1);
                //print(dirs[i]);
            }
        } 
        catch (System.Exception e) 
        {
            Debug.Log(e);
        }

	}


	// Update is called once per frame
	public void Update () {
		
	}
	public static void TimAnim(bool negative = false) 
	{
		var gObjects = GameObject.FindGameObjectsWithTag("Time");
		foreach (var gObject in gObjects)
		{
			if (gObject.animation != null)
				gObject.animation.Play();
			if (negative == true)	
				gObject.SendMessage("OnNegative",SendMessageOptions.DontRequireReceiver);
			else
				gObject.SendMessage("OnPositive",SendMessageOptions.DontRequireReceiver);
		}
	}
	public static void EthAnim(bool negative = false) {
		var gObjects = GameObject.FindGameObjectsWithTag("Ethics");
		foreach (var gObject in gObjects)
		{
			if (gObject.animation != null)
				gObject.animation.Play();
			if (negative== true)	
				gObject.SendMessage("OnNegative",SendMessageOptions.DontRequireReceiver);
			else
				gObject.SendMessage("OnPositive",SendMessageOptions.DontRequireReceiver);

		}
	}
	public static void EnvAnim(bool negative = false) {
		var gObjects = GameObject.FindGameObjectsWithTag("Environment");
		foreach (var gObject in gObjects)
		{
			if (gObject.animation != null)
				gObject.animation.Play();
			if (negative == true)	
				gObject.SendMessage("OnNegative",SendMessageOptions.DontRequireReceiver);
			else
				gObject.SendMessage("OnPositive",SendMessageOptions.DontRequireReceiver);

		}
	}
	public static void ComAnim(bool negative = false) {
		var gObjects = GameObject.FindGameObjectsWithTag("Communication");
		foreach (var gObject in gObjects)
		{
			if (gObject.animation != null)
				gObject.animation.Play();
			if (negative == true)	
				gObject.SendMessage("OnNegative",SendMessageOptions.DontRequireReceiver);
			else
				gObject.SendMessage("OnPositive",SendMessageOptions.DontRequireReceiver);
		}
	}
	public static void PolAnim(bool negative = false) {
		var gObjects = GameObject.FindGameObjectsWithTag("Politics");
		foreach (var gObject in gObjects)
		{
			if (gObject.animation != null)
				gObject.animation.Play();
			if (negative == true)	
				gObject.SendMessage("OnNegative",SendMessageOptions.DontRequireReceiver);
			else
				gObject.SendMessage("OnPositive",SendMessageOptions.DontRequireReceiver);

		}
	}
	public static void FinAnim(bool negative = false) {
		var gObjects = GameObject.FindGameObjectsWithTag("Financial");
		foreach (var gObject in gObjects)
		{
			if (gObject.animation != null)
				gObject.animation.Play();
			if (negative == true)	
				gObject.SendMessage("OnNegative",SendMessageOptions.DontRequireReceiver);
			else
				gObject.SendMessage("OnPositive",SendMessageOptions.DontRequireReceiver);
		}
	}
	public static void PubAnim(bool negative = false) {
		var gObjects = GameObject.FindGameObjectsWithTag("Public");
		foreach (var gObject in gObjects)
		{
			//if (gObject.animation != null)
				//gObject.animation.Play();
			if (negative == true)
				gObject.SendMessage("OnNegative",SendMessageOptions.DontRequireReceiver);
			else
				gObject.SendMessage("OnPositive",SendMessageOptions.DontRequireReceiver);
		}
	}

}
