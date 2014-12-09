using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;

public class xml_read : MonoBehaviour {

	public string scenarioName = "scenario";
	TextAsset scenario; 
	XmlTextReader reader;
	XmlTextReader counter;

	public GUISkin gSkin;
	public Texture arrowTex;
	public Texture resultsImg;
	public float baseWidth = 1280f;
	public float baseHeight = 720f;

	public float pointerPos = 1;

	public float startTime = 0;
	public bool totalsUpdated = false;

	public GameObject resultsPanel;
	public GameObject interactionPanl;
	public GameObject gui_text;

	//-------------Scene Stuff---------------------------
	//Target Values
	public int tTim = 0;
	public int tFin = 0;
	public int tEth = 0;
	public int tPol = 0;
	public int tEnv = 0;
	public int tCom = 0;
	public int tPub = 0;

	//fail values
	public int fTim = 0;
	public int fFin = 0;
	public int fEth = 0;
	public int fPol = 0;
	public int fEnv = 0;
	public int fCom = 0;
	public int fPub = 0;

	//type of scene "phone" "person" "video" "email"
	public string sceneType = "";
	//the npc's text
	public string introText;
	//the final outcome text
	public string resultText;
	//choice 1 text
	public string choice1;
	//choice 1 values
	public int choice1Tim = 0;
	public int choice1Fin = 0;
	public int choice1Eth = 0;
	public int choice1Pol = 0;
	public int choice1Env = 0;
	public int choice1Com = 0;
	public int choice1Pub = 0;
	//choice 2 text
	public string choice2;
	//choice 2 values
	public int choice2Tim = 0;
	public int choice2Fin = 0;
	public int choice2Eth = 0;
	public int choice2Pol = 0;
	public int choice2Env = 0;
	public int choice2Com = 0;
	public int choice2Pub = 0;
	//choice 3 text
	public string choice3;
	//choice 3 values
	public int choice3Tim = 0;
	public int choice3Fin = 0;
	public int choice3Eth = 0;
	public int choice3Pol = 0;
	public int choice3Env = 0;
	public int choice3Com = 0;
	public int choice3Pub = 0;
	public int numScenes = 0;
	//---------------------------------------------------

	//stuff to get the xml file
	public StreamReader textFile;
	public WWW www;

	void Start() {
		resultsPanel.SetActive(false);
		totalsUpdated = false;
		//the position of the selection pointer
		pointerPos = 1;
		//set stuff to zero just to start
		tTim = 0;
		tFin = 0;
		tEth = 0;
		tPol = 0;
		tEnv = 0;
		tCom = 0;
		tPub = 0;
		//reset globals
		Globals.Init();

		//-------This is for if the scenario has already been picked outside of the scene-----
		//set state to temporary 0.1 state  this is changed immediately in update
		Globals.state = 0.1f;
		//-----------------------------------------------
	}
	
	//read in values from the xml file
	void ReadXML (float scene) {
		Globals.sceneTextIndex = 0;
		Globals.choice1Index = 0;
		Globals.choice2Index = 0;
		Globals.choice3Index = 0;
		//getting the file from the specified path
		textFile = new StreamReader(Globals.directory+"/"+Globals.scenarioName+"/"+Globals.scenarioName+".xml");
		
		if (Globals.state == 1f)
		{
			if (textFile != null)
			{
				counter = new XmlTextReader(new StringReader(textFile.ReadToEnd()));
			}
			//this one just counts the number of scenes
			if (counter != null)
			{
				counter.MoveToContent();
    			numScenes = CountChildNodes(counter, XmlNodeType.Element);
    			numScenes = numScenes/3;
    			Globals.scenarioScenes = numScenes;
    			textFile.Close();
    			textFile = new StreamReader(Globals.directory+"/"+Globals.scenarioName+"/"+Globals.scenarioName+".xml");
			}
		}
		if(textFile != null)
		{
    		reader = new XmlTextReader(new StringReader(textFile.ReadToEnd()));
		}
    	if (reader != null)
    	{
    		//this one actually reads stuff
    		reader.MoveToContent();
    		int.TryParse(reader.GetAttribute("Tim"), out fTim);
    		int.TryParse(reader.GetAttribute("Fin"), out fFin);
    		int.TryParse(reader.GetAttribute("Com"), out fCom);
    		int.TryParse(reader.GetAttribute("Env"), out fEnv);
    		int.TryParse(reader.GetAttribute("Eth"), out fEth);
    		int.TryParse(reader.GetAttribute("Pol"), out fPol);
    		int.TryParse(reader.GetAttribute("Pub"), out fPub);

    		//set the global failure values to the read in ones
    		Globals.fTim = fTim;
    		Globals.fFin = fFin;
    		Globals.fCom = fCom;
    		Globals.fEnv = fEnv;
    		Globals.fEth = fEth;
    		Globals.fPol = fPol;
    		Globals.fPub = fPub;

    		print("number of scenes: "+numScenes);
    		if (Globals.state < numScenes+1)
    		{
    			reader.ReadToDescendant("scene"+scene.ToString());	
    			reader.ReadToDescendant("setup");
    			sceneType = reader.GetAttribute("sceneType");
    			int.TryParse(reader.GetAttribute("Tim"), out tTim);
    			int.TryParse(reader.GetAttribute("Fin"), out tFin);
    			int.TryParse(reader.GetAttribute("Eth"), out tEth);
    			int.TryParse(reader.GetAttribute("Pol"), out tPol);
    			int.TryParse(reader.GetAttribute("Env"), out tEnv);
    			int.TryParse(reader.GetAttribute("Com"), out tCom);
    			int.TryParse(reader.GetAttribute("Pub"), out tPub);
    			
        		reader.ReadToDescendant("introText");
        		introText = reader.ReadInnerXml();
        		reader.ReadToFollowing("choice1");
        		int.TryParse(reader.GetAttribute("Tim"), out choice1Tim);
    			int.TryParse(reader.GetAttribute("Fin"), out choice1Fin);
    			int.TryParse(reader.GetAttribute("Eth"), out choice1Eth);
    			int.TryParse(reader.GetAttribute("Pol"), out choice1Pol);
    			int.TryParse(reader.GetAttribute("Env"), out choice1Env);
    			int.TryParse(reader.GetAttribute("Com"), out choice1Com);
    			int.TryParse(reader.GetAttribute("Pub"), out choice1Pub);
        		choice1 = reader.ReadInnerXml();
        		reader.ReadToNextSibling("choice2");
        		int.TryParse(reader.GetAttribute("Tim"), out choice2Tim);
    			int.TryParse(reader.GetAttribute("Fin"), out choice2Fin);
    			int.TryParse(reader.GetAttribute("Eth"), out choice2Eth);
    			int.TryParse(reader.GetAttribute("Pol"), out choice2Pol);
    			int.TryParse(reader.GetAttribute("Env"), out choice2Env);
    			int.TryParse(reader.GetAttribute("Com"), out choice2Com);
    			int.TryParse(reader.GetAttribute("Pub"), out choice2Pub);
        		choice2 = reader.ReadInnerXml();
        		reader.ReadToNextSibling("choice3");
        		int.TryParse(reader.GetAttribute("Tim"), out choice3Tim);
    			int.TryParse(reader.GetAttribute("Fin"), out choice3Fin);
    			int.TryParse(reader.GetAttribute("Eth"), out choice3Eth);
    			int.TryParse(reader.GetAttribute("Pol"), out choice3Pol);
    			int.TryParse(reader.GetAttribute("Env"), out choice3Env);
    			int.TryParse(reader.GetAttribute("Com"), out choice3Com);
    			int.TryParse(reader.GetAttribute("Pub"), out choice3Pub);
        		choice3 = reader.ReadInnerXml();
				
				UpdateGlobals();
			}
			else
			{
				reader.ReadToDescendant("result"+scene.ToString());
				resultText = reader.ReadInnerXml();
			}
			reader.Close();
      	}
	}
	void AlertFlash()
	{
		if (sceneType == "phone")
		{
			GameObject.FindWithTag("phone").SendMessage("SetActive",SendMessageOptions.DontRequireReceiver);
			GameObject.FindWithTag("emailVideo").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
			GameObject.FindWithTag("person").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
		}
		else if (sceneType == "video" || sceneType == "email")
		{
			GameObject.FindWithTag("emailVideo").SendMessage("SetActive",SendMessageOptions.DontRequireReceiver);
			GameObject.FindWithTag("phone").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
			GameObject.FindWithTag("person").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
		}
		else if (sceneType == "person")
		{
			GameObject.FindWithTag("person").SendMessage("SetActive",SendMessageOptions.DontRequireReceiver);
			GameObject.FindWithTag("emailVideo").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
			GameObject.FindWithTag("phone").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
		}
		Globals.sceneTextIndex = 0;
	}
	void UpdateGlobals()
	{
		Globals.sceneType = sceneType;

		AlertFlash();



		Globals.tTim = tTim;
		Globals.tEnv = tEnv;
		Globals.tEth = tEth;
		Globals.tCom = tCom;
		Globals.tFin = tFin;
		Globals.tPol = tPol;
		Globals.tPub = tPub;
		//Globals.sceneText = introText;
		int maxCharacters = 250;
		int charNumber = maxCharacters;
		int numSubstrings = (introText.Length/maxCharacters) +1;
		//Globals.sceneText = introTexxt;
		Globals.sceneText = new string[numSubstrings];
		
		//int spaceCount = introText.Split(' ').Length - 1;
		//String 
		for (int i = 0; i< numSubstrings;i++)
		{
			if (introText.Length > maxCharacters-1)
			{
				//print(introText[charNumber]);
				while (charNumber < introText.Length && introText[charNumber] != ' ')
				{
					charNumber++;
				}
				Globals.sceneText[i] = introText.Substring(0,charNumber);
				if (introText.Length > charNumber)
					introText = introText.Substring(charNumber+1);
			}
			else
			{
				Globals.sceneText[i] = introText;
			}
			charNumber = maxCharacters;
		}
		int maxChoiceCharacters = 350;
		charNumber = maxChoiceCharacters;

		numSubstrings = (choice1.Length/maxChoiceCharacters) +1;
		Globals.choice1Text = new string[numSubstrings];
		for (int i = 0; i< numSubstrings;i++)
		{
			if (choice1.Length > maxChoiceCharacters-1)
			{
				//print(introText[charNumber]);
				while (charNumber < choice1.Length && choice1[charNumber] != ' ')
				{
					charNumber++;
				}
				Globals.choice1Text[i] = choice1.Substring(0,charNumber);
				if (choice1.Length > charNumber)
					choice1 = choice1.Substring(charNumber+1);
			}
			else
			{
				Globals.choice1Text[i] = choice1;
			}
			charNumber = maxChoiceCharacters;
		}

		numSubstrings = (choice2.Length/maxChoiceCharacters) +1;
		Globals.choice2Text = new string[numSubstrings];
		for (int i = 0; i< numSubstrings;i++)
		{
			if (choice2.Length > maxChoiceCharacters-1)
			{
				//print(introText[charNumber]);
				while (charNumber < choice2.Length && choice2[charNumber] != ' ')
				{
					charNumber++;
				}
				Globals.choice2Text[i] = choice2.Substring(0,charNumber);
				if (choice2.Length > charNumber)
					choice2 = choice2.Substring(charNumber+1);
			}
			else
			{
				Globals.choice2Text[i] = choice2;
			}
			charNumber = maxChoiceCharacters;
		}

		numSubstrings = (choice3.Length/maxChoiceCharacters) +1;
		Globals.choice3Text = new string[numSubstrings];
		for (int i = 0; i< numSubstrings;i++)
		{
			if (choice3.Length > maxChoiceCharacters-1)
			{
				//print(introText[charNumber]);
				while (charNumber < choice3.Length && choice3[charNumber] != ' ')
				{
					charNumber++;
				}
				Globals.choice3Text[i] = choice3.Substring(0,charNumber);
				if (choice3.Length > charNumber)
					choice3 = choice3.Substring(charNumber+1);
			}
			else
			{
				Globals.choice3Text[i] = choice3;
			}
			charNumber = maxChoiceCharacters;
		}

		Globals.choice1Tim = choice1Tim;
		Globals.choice1Fin = choice1Fin;
		Globals.choice1Eth = choice1Eth;
		Globals.choice1Env = choice1Env;
		Globals.choice1Com = choice1Com;
		Globals.choice1Pol = choice1Pol;
		Globals.choice1Pub = choice1Pub;
		//Globals.choice1Text = choice1;
		Globals.choice2Tim = choice2Tim;
		Globals.choice2Fin = choice2Fin;
		Globals.choice2Eth = choice2Eth;
		Globals.choice2Env = choice2Env;
		Globals.choice2Com = choice2Com;
		Globals.choice2Pol = choice2Pol;
		Globals.choice2Pub = choice2Pub;
		//Globals.choice2Text = choice2;
		Globals.choice3Tim = choice3Tim;
		Globals.choice3Fin = choice3Fin;
		Globals.choice3Eth = choice3Eth;
		Globals.choice3Env = choice3Env;
		Globals.choice3Com = choice3Com;
		Globals.choice3Pol = choice3Pol;
		Globals.choice3Pub = choice3Pub;
		//Globals.choice3Text = choice3;
	}


	void OnGUI () {
		Vector3 scale = Vector3.zero;
	 	scale.x = Screen.width / baseWidth;
	 	scale.y = Screen.height / baseHeight;
	 	scale.z = 1f;

	 	GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
	 	GUI.skin = gSkin;
		
		
		if (Globals.orgState == 0)
		{
			//GUI.Box(new Rect (30,10,1220,700),"");
			if (Globals.state < numScenes+1)
			{
				//GUI.Label(new Rect(60, 50, 1160,900),introText);
				//GUI.Label(new Rect(80, 300, 1140,900),choice1);
				//GUI.Label(new Rect(80, 450, 1140,900),choice2);
				//GUI.Label(new Rect(80, 590, 1140,900),choice3);
			}
			else
			{
				//resultsPanel.active = true;
				interactionPanl.SetActive(false);
				gui_text.SetActive(false);
				
				


				GUI.Box(new Rect (128,71, 1024,578),"","resultsPanel");
				GUI.Label(new Rect(660, 250, 480,600),resultText);
				GUI.Label(new Rect(158, 189, 1160,900),"Final Client Satisfaction: "+Globals.cSat,"resultsCS");
				GUI.Label(new Rect(160, 278, 1160,900),"Final Player Ethics: "+Globals.pEth,"resultsAttribute");
				GUI.Label(new Rect(160, 332, 1160,900),"Final Player Time: "+Globals.pTim,"resultsAttribute");
				GUI.Label(new Rect(160, 386, 1160,900),"Final Player Communication: "+Globals.pCom,"resultsAttribute");
				GUI.Label(new Rect(160, 440, 1160,900),"Final Player Financial: "+Globals.pFin,"resultsAttribute");
				GUI.Label(new Rect(160, 494, 1160,900),"Final Player Environmental: "+Globals.pEnv,"resultsAttribute");
				GUI.Label(new Rect(160, 548, 1160,900),"Final Player Politics: "+Globals.pPol,"resultsAttribute");
				GUI.Label(new Rect(160, 602, 1160,900),"Final Player Public Relations: "+Globals.pPub,"resultsAttribute");
				if (GUI.Button(new Rect(907, 583, 245,65),"Continue Playing","playAgainButton"))
				{
					textFile.Close();
					UpdateCompleted();
					Application.LoadLevel("Main_Menu");
				}
			}
			if (Globals.state > 1f && Globals.state < numScenes+1)
				{
				//UpdatePointer();
				}
		}

		if (Globals.state < 0)
		{
			//resultsPanel.active = true;
			interactionPanl.SetActive(false);
			gui_text.SetActive(false);
			GUI.Box(new Rect (128,71, 1024,578),"","resultsPanel");
			
			GUI.Label(new Rect(158, 189, 1160,900),"Scenario Lost","resultsCS");
			if (Globals.state == -3f)
			{
				GUI.Label(new Rect(160, 278, 1160,900),"Final Player Ethics: "+Globals.pEth,"failAttribute");
				GUI.Label(new Rect(660, 250, 480,600),"\n The client has termainated the contract due to your decisions regarding Ethics.  Consider your choices and try again.");
			}
			if (Globals.state == -1f)
			{
				GUI.Label(new Rect(160, 332, 1160,900),"Final Player Time: "+Globals.pTim,"failAttribute");
				GUI.Label(new Rect(660, 250, 480,600),"\n The client has termainated the contract due to your decisions regarding Time.  Consider your choices and try again.");
			}
			if (Globals.state == -6f)
			{
				GUI.Label(new Rect(160, 386, 1160,900),"Final Player Communication: "+Globals.pCom,"failAttribute");
				GUI.Label(new Rect(660, 250, 480,600),"\n The client has termainated the contract due to your decisions regarding Communication.  Consider your choices and try again.");
			}
			if (Globals.state == -2f)
			{
				GUI.Label(new Rect(160, 440, 1160,900),"Final Player Financial: "+Globals.pFin,"failAttribute");
				GUI.Label(new Rect(660, 250, 480,600),"\n The client has termainated the contract due to your decisions regarding Finances.  Consider your choices and try again.");
			}
			if (Globals.state == -4f)
			{
				GUI.Label(new Rect(160, 494, 1160,900),"Final Player Environmental: "+Globals.pEnv,"failAttribute");
				GUI.Label(new Rect(660, 250, 480,600),"\n The client has termainated the contract due to your decisions regarding the Environment.  Consider your choices and try again.");
			}
			if (Globals.state == -5f)
			{
				GUI.Label(new Rect(160, 548, 1160,900),"Final Player Politics: "+Globals.pPol,"failAttribute");
				GUI.Label(new Rect(660, 250, 480,600),"\n The client has termainated the contract due to your decisions regarding Politics.  Consider your choices and try again.");
			}
			if (Globals.state == -7f)
			{
				GUI.Label(new Rect(160, 602, 1160,900),"Final Player Public Relations: "+Globals.pPub,"failAttribute");
				GUI.Label(new Rect(660, 250, 480,600),"\n The client has termainated the contract due to your decisions regarding Public Relations.  Consider your choices and try again.");
			}
			if (GUI.Button(new Rect(907, 583, 245,65),"Try Again","playAgainButton"))
				{
					textFile.Close();
					Application.LoadLevel("Play_Scenario");
				}
		}
	}

	public void UpdatePointer() {
		if (pointerPos == 1)
		{
			GUI.DrawTexture(new Rect(30, 300, 32,32), arrowTex);
		}
		else if (pointerPos == 2)
		{
			GUI.DrawTexture(new Rect(30, 450, 32,32), arrowTex);
		}
		else if (pointerPos == 3)
		{
			GUI.DrawTexture(new Rect(30, 590, 32,32), arrowTex);
		}
	}

	// Update is called once per frame
	void Update () {
		UpdateInputs();
		if (Globals.state == 0.1f)
		{
			Globals.orgState = 0;
			Globals.state = 1f;
			startTime = Time.time;
			//read the first scene The number isn't used
			ReadXML(1);
		}
		if (Globals.state >= numScenes+1 && !totalsUpdated)
		{
			if (PlayerPrefs.GetFloat("Total Time") == null)
				PlayerPrefs.SetFloat("Total Time", 0f);
			PlayerPrefs.SetFloat("Total Time", (PlayerPrefs.GetFloat("Total Time")+Time.time-startTime));
			Globals.totalTime = PlayerPrefs.GetFloat("Total Time");
			totalsUpdated = true;
		}
		//print(sceneType);
	}

	public void UpdateCompleted() {
		bool newScenario = true;
		if (PlayerPrefsX.GetStringArray("Completed_Scenarios").Length == 0)
			{
				string[] completedScenarios = new string[1];
				completedScenarios[0] = Globals.scenarioName;
				PlayerPrefsX.SetStringArray("Completed_Scenarios",completedScenarios);
			}
		else
		{
			print(PlayerPrefsX.GetStringArray("Completed_Scenarios").Length);
			string[] completedScenarios = PlayerPrefsX.GetStringArray("Completed_Scenarios");
			string[] newlyCompleted = new string[completedScenarios.Length+1];
			for (int i = 0; i < completedScenarios.Length;i++)
			{
				if (completedScenarios[i] == Globals.scenarioName)
					newScenario = false;
				newlyCompleted[i] = completedScenarios[i];
			}
			if (newScenario == true)
			{
				newlyCompleted[completedScenarios.Length+1] = Globals.scenarioName;
				PlayerPrefsX.SetStringArray("Completed_Scenarios",completedScenarios);
			}
		}
	}

	public void UpdateInputs() {
		if (Input.GetKeyUp("down"))
		{
			if (pointerPos < 3)
			{
				pointerPos ++;
			}
		}
		if (Input.GetKeyUp("up"))
		{
			if (pointerPos > 1)
			{
				pointerPos --;
			}
		}
	}

	public void SelectChoice(int selection)
	{
		CalculateScore(selection);
		AdvanceScene();
		FailureCheck();
	}

	//check to see if the player has lost
	public void FailureCheck()
	{
		if (Globals.pTim < Globals.fTim)
			Globals.state = -1f;
		if (Globals.pFin < Globals.fFin)
			Globals.state = -2f;
		if (Globals.pEth < Globals.fEth)
			Globals.state = -3f;
		if (Globals.pEnv < Globals.fEnv)
			Globals.state = -4f;
		if (Globals.pPol < Globals.fPol)
			Globals.state = -5f;
		if (Globals.pCom < Globals.fCom)
			Globals.state = -6f;
		if (Globals.pPub < Globals.fPub)
			Globals.state = -7f;
	}


	//add our values to the globals ones
	public void CalculateScore(int choice)
	{
		print(choice1Tim);
		print(choice2Tim);
		print(choice3Tim);

		if (choice == 1)
		{
			Globals.pTim += choice1Tim;
			Globals.pEth += choice1Eth;
			Globals.pEnv += choice1Env;
			Globals.pPol += choice1Pol;
			Globals.pFin += choice1Fin;
			Globals.pCom += choice1Com;
			Globals.pPub += choice1Pub;

			Globals.cSat += 
				tTim*choice1Tim+
				tEnv*choice1Env+
				tEth*choice1Eth+
				tPol*choice1Pol+
				tFin*choice1Fin+
				tCom*choice1Com+
				tPub*choice1Pub;

			UpdateLastImpact(1);
		}
		else if (choice == 2)
		{
			Globals.pTim += choice2Tim;
			Globals.pEth += choice2Eth;
			Globals.pEnv += choice2Env;
			Globals.pPol += choice2Pol;
			Globals.pFin += choice2Fin;
			Globals.pCom += choice2Com;
			Globals.pPub += choice2Pub;

			Globals.cSat += 
				tTim*choice2Tim+
				tEnv*choice2Env+
				tEth*choice2Eth+
				tPol*choice2Pol+
				tFin*choice2Fin+
				tCom*choice2Com+
				tPub*choice2Pub;

			UpdateLastImpact(2);
		}
		else if (choice == 3)
		{
			Globals.pTim += choice3Tim;
			Globals.pEth += choice3Eth;
			Globals.pEnv += choice3Env;
			Globals.pPol += choice3Pol;
			Globals.pFin += choice3Fin;
			Globals.pCom += choice3Com;
			Globals.pPub += choice3Pub;

			Globals.cSat +=
				tTim*choice3Tim+
				tEnv*choice3Env+
				tEth*choice3Eth+
				tPol*choice3Pol+
				tFin*choice3Fin+
				tCom*choice3Com+
				tPub*choice3Pub;

			UpdateLastImpact(3);
		}
		print("Total Client Satisfaction "+Globals.cSat);

	}
	//update the globals value for the last choice you made, used for the feedback system
	public void UpdateLastImpact(int choice)
	{
		if (choice == 1)
		{
			if (tTim*choice1Tim > 0)
			{
				Globals.TimAnim();
			}
			if (tFin*choice1Fin > 0)
			{
				Globals.FinAnim();
			}
			if (tEnv*choice1Env > 0)
			{
				Globals.EnvAnim();
			}
			if (tEth*choice1Eth > 0)
			{
				Globals.EthAnim();
			}
			if (tPol*choice1Pol > 0)
			{
				Globals.PolAnim();
			}
			if (tCom*choice1Com > 0)
			{
				Globals.ComAnim();
			}
			if (tPub*choice1Pub > 0)
			{
				Globals.PubAnim();
			}
		}
		if (choice == 2)
		{
			if (tTim*choice2Tim > 0)
			{
				Globals.TimAnim();
			}
			if (tFin*choice2Fin > 0)
			{
				Globals.FinAnim();
			}
			if (tEnv*choice2Env > 0)
			{
				Globals.EnvAnim();
			}
			if (tEth*choice2Eth > 0)
			{
				Globals.EthAnim();
			}
			if (tPol*choice2Pol > 0)
			{
				Globals.PolAnim();
			}
			if (tCom*choice2Com > 0)
			{
				Globals.ComAnim();
			}
			if (tPub*choice2Pub > 0)
			{
				Globals.PubAnim();
			}
		}
		if (choice == 3)
		{
			if (tTim*choice3Tim > 0)
			{
				Globals.TimAnim();
			}
			if (tFin*choice3Fin > 0)
			{
				Globals.FinAnim();
			}
			if (tEnv*choice3Env > 0)
			{
				Globals.EnvAnim();
			}
			if (tEth*choice3Eth > 0)
			{
				Globals.EthAnim();
			}
			if (tPol*choice3Pol > 0)
			{
				Globals.PolAnim();
			}
			if (tCom*choice3Com > 0)
			{
				Globals.ComAnim();
			}
			if (tPub*choice3Pub > 0)
			{
				Globals.PubAnim();
			}
		}
	}

	//move the scene forward
	public void AdvanceScene()
	{
		Globals.state+=1;
		string row = Globals.state.ToString().Substring(0, 1);
		if (Globals.cSat <= -6)
		{
			row += ".1";
		}
		else if (Globals.cSat > -6 && Globals.cSat < 6)
		{
			row += ".2";
		}
		else if (Globals.cSat >= 6)
		{
			row += ".3";
		}
		float.TryParse(row, out Globals.state);
		//readxml uses globals.state instead of the value passed to it
		//should work without the paramiter
		ReadXML(Globals.state);
	}
	//count the scenes in the scenario
	public static int CountChildNodes(XmlReader node, XmlNodeType nodeType)
        {
            int count = 0;
            int currentDepth = node.Depth;
            int depthToTest = currentDepth + 1;
            while (node.Read() && node.Depth != currentDepth)
            {
                if (node.NodeType == nodeType && node.Depth == depthToTest)
                {
                    count++;
                }
            }
            return count;
        }
}
