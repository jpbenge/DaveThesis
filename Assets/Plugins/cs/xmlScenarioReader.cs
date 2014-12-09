using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System;

public class xmlScenarioReader : MonoBehaviour {

    public bool isSetup = false;
    public bool endState = false;
    public bool showingResults = false;
    public int playerChoice = 0;
    public string collectionName;
	public string scenarioName;
	public Scene[] scenesArray;
    public Scene activeScene;
	public Result[] resultsArray;
    public Result activeResult;
	public int failTim;
	public int failCom;
	public int failEth;
	public int failEnv;
	public int failFin;
	public int failPub;
	public int failPol;

	public StreamReader textFile;
	public WWW www;
	TextAsset diologue;
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
    public GameObject responsePanel;
    public GameObject gui_text;
    public GameObject responseText;
    public GameObject iconPanel;

    
    
    // Use this for initialization
	void Start ()
	{
        showingResults = false;
        playerChoice = 0;
        endState = false;
        isSetup = false;
		CountXML();
        FillArrays();

        resultsPanel.SetActive(false);
        totalsUpdated = false;
        //the position of the selection pointer
        pointerPos = 1;

        Globals.Init();

        //-------This is for if the scenario has already been picked outside of the scene-----
        //set state to temporary 0.1 state  this is changed immediately in update
        Globals.state = 0.1f;
	}
	
	// Update is called once per frame
	void Update () 
	{
        UpdateInputs();
        if (Globals.state == 0.1f)
        {
            Globals.orgState = 0;
            
            Globals.state = 1f;
            startTime = Time.time;
            //read the first scene The number isn't used
            if (isSetup)
            {
                activeScene = scenesArray[0];
                //print(activeScene.ID);
                Globals.sceneType = activeScene.sceneType;
                UpdateGlobals();
                //iconPanel.SendMessage("UpdateOpacity");
            }
        }
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
            if (!endState)
            {

            }
            else
            {
                interactionPanl.SetActive(false);
                gui_text.SetActive(false);
                
                GUI.Box(new Rect (128,71, 1024,578),"","resultsPanel");
                GUI.Label(new Rect(660, 260, 480,600),activeResult.resultText);
                //GUI.Label(new Rect(158, 189, 1160,900),"Final Client Satisfaction: "+Globals.cSat,"resultsCS");
                GUI.Label(new Rect(160, 278, 1160,900),"Final Player Ethics: "+Globals.lEth,"resultsAttribute");
                GUI.Label(new Rect(160, 332, 1160,900),"Final Player Time: "+Globals.lTim,"resultsAttribute");
                GUI.Label(new Rect(160, 386, 1160,900),"Final Player Communication: "+Globals.lCom,"resultsAttribute");
                GUI.Label(new Rect(160, 440, 1160,900),"Final Player Financial: "+Globals.lFin,"resultsAttribute");
                GUI.Label(new Rect(160, 494, 1160,900),"Final Player Environmental: "+Globals.lEnv,"resultsAttribute");
                GUI.Label(new Rect(160, 548, 1160,900),"Final Player Politics: "+Globals.lPol,"resultsAttribute");
                GUI.Label(new Rect(160, 602, 1160,900),"Final Player Public Relations: "+Globals.lPub,"resultsAttribute");
                if (GUI.Button(new Rect(907, 583, 245,65),"Continue Playing","playAgainButton"))
                {
                    textFile.Close();
                    UpdateCompleted();
                    gameObject.GetComponent<ProfileSaver>().SaveProfile();
                    Application.LoadLevel("Main_Menu");
                }
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
                    gameObject.GetComponent<ProfileSaver>().SaveProfile();
                    Application.LoadLevel("Play_Scenario");
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
        GameObject.FindWithTag("phone").SendMessage("SetInactive");
        GameObject.FindWithTag("emailVideo").SendMessage("SetInactive");
        GameObject.FindWithTag("person").SendMessage("SetInactive");
        
        playerChoice = selection;
        CalculateScore(selection);
        ShowResponse(selection);
        //AdvanceScene(selection);
        //FailureCheck();
    }
    public void ShowResponse(int selection)
    {
        showingResults = true;
        if (selection == 1)
        {
            responseText.GetComponent<GUIText>().text = activeScene.choice1Reaction;
        }
        else if (selection == 2)
        {
            responseText.GetComponent<GUIText>().text = activeScene.choice2Reaction;
        }
        else if (selection == 3)
        {
            responseText.GetComponent<GUIText>().text = activeScene.choice3Reaction;
        }
        responseText.GetComponent<guiFormatter>().cleanUp();
        responsePanel.SetActive(true);
    }

    public void Continue()
    {
        Globals.sceneType = null;
        AdvanceScene(playerChoice);
        FailureCheck();
        //iconPanel.SendMessage("UpdateOpacity");
        responsePanel.SetActive(false);
        showingResults = false;
    }

    public void AdvanceScene(int selection)
    {
        int targetNum = 0;
        if (selection == 1)
        {
            if (activeScene.c1Target.Substring(0,1) != "R")
            {
                targetNum = Convert.ToInt32(activeScene.c1Target);
            }
            else if (activeScene.c1Target.Substring(0,1) == "R")
            {
                endState = true;
                targetNum = Convert.ToInt32(activeScene.c1Target.Substring(1));
            }
        }
        else if (selection == 2)
        {
            if (activeScene.c2Target.Substring(0,1) != "R")
            {
                targetNum = Convert.ToInt32(activeScene.c2Target);
            }
            else if (activeScene.c2Target.Substring(0,1) == "R")
            {
                endState = true;
                targetNum = Convert.ToInt32(activeScene.c2Target.Substring(1));
            }
        }
        else if (selection == 3)
        {
            if (activeScene.c3Target.Substring(0,1) != "R")
            {
                targetNum = Convert.ToInt32(activeScene.c3Target);
            }
            else if (activeScene.c3Target.Substring(0,1) == "R")
            {
                endState = true;
                targetNum = Convert.ToInt32(activeScene.c3Target.Substring(1));
            }
        }
        if (!endState)
        {
            activeScene = scenesArray[targetNum];
            Globals.sceneType = scenesArray[targetNum].sceneType;
            UpdateGlobals();
        }
        else
        {
            activeResult = resultsArray[targetNum];
        }
        //readxml uses globals.state instead of the value passed to it
        //should work without the paramiter
        //ReadXML(Globals.state);
    }

    public void UpdateGlobals()
    {
        Globals.sceneType = activeScene.sceneType;
        AlertFlash();

        int maxCharacters = 250;
        int charNumber = maxCharacters;
        int numSubstrings = (activeScene.introText.Length/maxCharacters) +1;
        //Globals.sceneText = introTexxt;
        Globals.sceneText = new string[numSubstrings];

        for (int i = 0; i< numSubstrings;i++)
        {
            if (activeScene.introText.Length > maxCharacters-1)
            {
                //print(introText[charNumber]);
                while (charNumber < activeScene.introText.Length && activeScene.introText[charNumber] != ' ')
                {
                    charNumber++;
                }
                Globals.sceneText[i] = activeScene.introText.Substring(0,charNumber);
                //print("Substring ::::::::::"+Globals.sceneText[i]);
                if (activeScene.introText.Length > charNumber)
                    activeScene.introText = activeScene.introText.Substring(charNumber+1);
            }
            else
            {
                Globals.sceneText[i] = activeScene.introText;
            }
            charNumber = maxCharacters;
        }
        int maxChoiceCharacters = 350;
        charNumber = maxChoiceCharacters;
        numSubstrings = (activeScene.choice1Text.Length/maxChoiceCharacters) +1;
        Globals.choice1Text = new string[numSubstrings];
        for (int i = 0; i< numSubstrings;i++)
        {
            if (activeScene.choice1Text.Length > maxChoiceCharacters-1)
            {
                //print(introText[charNumber]);
                while (charNumber < activeScene.choice1Text.Length && activeScene.choice1Text[charNumber] != ' ')
                {
                    charNumber++;
                }
                Globals.choice1Text[i] = activeScene.choice1Text.Substring(0,charNumber);
                if (activeScene.choice1Text.Length > charNumber)
                    activeScene.choice1Text = activeScene.choice1Text.Substring(charNumber+1);
            }
            else
            {
                Globals.choice1Text[i] = activeScene.choice1Text;
            }
            charNumber = maxChoiceCharacters;
        }

        numSubstrings = (activeScene.choice2Text.Length/maxChoiceCharacters) +1;
        Globals.choice2Text = new string[numSubstrings];
        for (int i = 0; i< numSubstrings;i++)
        {
            if (activeScene.choice2Text.Length > maxChoiceCharacters-1)
            {
                //print(introText[charNumber]);
                while (charNumber < activeScene.choice2Text.Length && activeScene.choice2Text[charNumber] != ' ')
                {
                    charNumber++;
                }
                Globals.choice2Text[i] = activeScene.choice2Text.Substring(0,charNumber);
                if (activeScene.choice2Text.Length > charNumber)
                    activeScene.choice2Text = activeScene.choice2Text.Substring(charNumber+1);
            }
            else
            {
                Globals.choice2Text[i] = activeScene.choice2Text;
            }
            charNumber = maxChoiceCharacters;
        }

        numSubstrings = (activeScene.choice3Text.Length/maxChoiceCharacters) +1;
        Globals.choice3Text = new string[numSubstrings];
        for (int i = 0; i< numSubstrings;i++)
        {
            if (activeScene.choice3Text.Length > maxChoiceCharacters-1)
            {
                //print(introText[charNumber]);
                while (charNumber < activeScene.choice3Text.Length && activeScene.choice3Text[charNumber] != ' ')
                {
                    charNumber++;
                }
                Globals.choice3Text[i] = activeScene.choice3Text.Substring(0,charNumber);
                if (activeScene.choice3Text.Length > charNumber)
                    activeScene.choice3Text = activeScene.choice3Text.Substring(charNumber+1);
            }
            else
            {
                Globals.choice3Text[i] = activeScene.choice3Text;
            }
            charNumber = maxChoiceCharacters;
        }
        Globals.choice1Tim = activeScene.c1Tim;
        Globals.choice1Fin = activeScene.c1Fin;
        Globals.choice1Eth = activeScene.c1Eth;
        Globals.choice1Env = activeScene.c1Env;
        Globals.choice1Com = activeScene.c1Com;
        Globals.choice1Pol = activeScene.c1Pol;
        Globals.choice1Pub = activeScene.c1Pub;
        Globals.choice1Response = activeScene.choice1Reaction;
        //Globals.choice1Text = choice1;
        Globals.choice2Tim = activeScene.c2Tim;
        Globals.choice2Fin = activeScene.c2Fin;
        Globals.choice2Eth = activeScene.c2Eth;
        Globals.choice2Env = activeScene.c2Env;
        Globals.choice2Com = activeScene.c2Com;
        Globals.choice2Pol = activeScene.c2Pol;
        Globals.choice2Pub = activeScene.c2Pub;
        Globals.choice2Response = activeScene.choice2Reaction;
        //Globals.choice2Text = choice2;
        Globals.choice3Tim = activeScene.c3Tim;
        Globals.choice3Fin = activeScene.c3Fin;
        Globals.choice3Eth = activeScene.c3Eth;
        Globals.choice3Env = activeScene.c3Env;
        Globals.choice3Com = activeScene.c3Com;
        Globals.choice3Pol = activeScene.c3Pol;
        Globals.choice3Pub = activeScene.c3Pub;
        Globals.choice3Response = activeScene.choice3Reaction;
        //Globals.choice3Text = choice3;
    }

    public void FailureCheck()
    {
        if (Globals.lTim < Globals.fTim)
            Globals.state = -1f;
        if (Globals.lFin < Globals.fFin)
            Globals.state = -2f;
        if (Globals.lEth < Globals.fEth)
            Globals.state = -3f;
        if (Globals.lEnv < Globals.fEnv)
            Globals.state = -4f;
        if (Globals.lPol < Globals.fPol)
            Globals.state = -5f;
        if (Globals.lCom < Globals.fCom)
            Globals.state = -6f;
        if (Globals.lPub < Globals.fPub)
            Globals.state = -7f;
    }

    //add our values to the globals ones
    public void CalculateScore(int choice)
    {

        if (choice == 1)
        {
            Globals.lTim += activeScene.c1Tim;
            Globals.lEth += activeScene.c1Eth;
            Globals.lEnv += activeScene.c1Env;
            Globals.lFin += activeScene.c1Fin;
            Globals.lCom += activeScene.c1Com;
            Globals.lPub += activeScene.c1Pub;


            UpdateLastImpact(1);
        }
        else if (choice == 2)
        {
            Globals.lTim += activeScene.c2Tim;
            Globals.lEth += activeScene.c2Eth;
            Globals.lEnv += activeScene.c2Env;
            Globals.lFin += activeScene.c2Fin;
            Globals.lCom += activeScene.c2Com;
            Globals.lPub += activeScene.c2Pub;

            UpdateLastImpact(2);
        }
        else if (choice == 3)
        {
            Globals.lTim += activeScene.c3Tim;
            Globals.lEth += activeScene.c3Eth;
            Globals.lEnv += activeScene.c3Env;
            Globals.lFin += activeScene.c3Fin;
            Globals.lCom += activeScene.c3Com;
            Globals.lPub += activeScene.c3Pub;

            UpdateLastImpact(3);
        }
        print("Total Client Satisfaction "+Globals.cSat);

    }

    public void UpdateLastImpact(int choice)
    {
        if (choice == 1)
        {
            if (activeScene.c1Tim > 0)
            {
                Globals.TimAnim();
            }
            if (activeScene.c1Tim < 0)
            {
                Globals.TimAnim(true);
            }
            if (activeScene.c1Fin > 0)
            {
                Globals.FinAnim();
            }
            if (activeScene.c1Fin < 0)
            {
                Globals.FinAnim(true);
            }
            if (activeScene.c1Env > 0)
            {
                Globals.EnvAnim();
            }
            if (activeScene.c1Env < 0)
            {
                Globals.EnvAnim(true);
            }
            if (activeScene.c1Eth > 0)
            {
                Globals.EthAnim();
            }
            if (activeScene.c1Eth < 0)
            {
                Globals.EthAnim(true);
            }
            if (activeScene.c1Com > 0)
            {
                Globals.ComAnim();
            }
            if (activeScene.c1Com < 0)
            {
                Globals.ComAnim(true);
            }
            if (activeScene.c1Pub > 0)
            {
                Globals.PubAnim();
            }
            if (activeScene.c1Pub < 0)
            {
                Globals.PubAnim(true);
            }
        }
        if (choice == 2)
        {
            if (activeScene.c2Tim > 0)
            {
                Globals.TimAnim();
            }
            if (activeScene.c2Tim < 0)
            {
                Globals.TimAnim(true);
            }
            if (activeScene.c2Fin > 0)
            {
                Globals.FinAnim();
            }
            if (activeScene.c2Fin < 0)
            {
                Globals.FinAnim(true);
            }
            if (activeScene.c2Env > 0)
            {
                Globals.EnvAnim();
            }
            if (activeScene.c2Env < 0)
            {
                Globals.EnvAnim(true);
            }
            if (activeScene.c2Eth > 0)
            {
                Globals.EthAnim();
            }
            if (activeScene.c2Eth < 0)
            {
                Globals.EthAnim(true);
            }
            if (activeScene.c2Com > 0)
            {
                Globals.ComAnim();
            }
            if (activeScene.c2Com < 0)
            {
                Globals.ComAnim(true);
            }
            if (activeScene.c2Pub > 0)
            {
                Globals.PubAnim();
            }
            if (activeScene.c2Pub < 0)
            {
                Globals.PubAnim(true);
            }
        }
        if (choice == 3)
        {
            if (activeScene.c3Tim > 0)
            {
                Globals.TimAnim();
            }
            if (activeScene.c3Tim < 0)
            {
                Globals.TimAnim(true);
            }
            if (activeScene.c3Fin > 0)
            {
                Globals.FinAnim();
            }
            if (activeScene.c3Fin < 0)
            {
                Globals.FinAnim(true);
            }
            if (activeScene.c3Env > 0)
            {
                Globals.EnvAnim();
            }
            if (activeScene.c3Env < 0)
            {
                Globals.EnvAnim(true);
            }
            if (activeScene.c3Eth > 0)
            {
                Globals.EthAnim();
            }
            if (activeScene.c3Eth < 0)
            {
                Globals.EthAnim(true);
            }
            if (activeScene.c3Com > 0)
            {
                Globals.ComAnim();
            }
            if (activeScene.c3Com < 0)
            {
                Globals.ComAnim(true);
            }
            if (activeScene.c3Pub > 0)
            {
                Globals.PubAnim();
            }
            if (activeScene.c3Pub < 0)
            {
                Globals.PubAnim(true);
            }
        }
    }

	void CountXML()
	{
		int numScenes = 0;
		int numResults = 0;
        if (Globals.directory != "")
		    textFile = new StreamReader(Globals.directory+"/"+Globals.collectionName+"/"+Globals.scenarioName+"/"+Globals.scenarioName+".xml");
		else
            textFile = new StreamReader(Application.dataPath+"/Resources/scenarios/misc/Fantasia Hotel/Fantasia Hotel.xml");
        if (textFile != null)
		{
			counter = new XmlTextReader(new StringReader(textFile.ReadToEnd()));
		}
		if (counter != null)
		{
			counter.MoveToContent();
			XmlReader thisScene = counter.ReadSubtree();
			while (thisScene.Read())
   			{
        		if (thisScene.NodeType == XmlNodeType.Element && 
            		thisScene.Name == "scene")
        		{
        			numScenes++;

        		}
        		else if (thisScene.NodeType == XmlNodeType.Element && 
            		thisScene.Name == "result")
        		{
        			numResults++;
        		}
        	}
            thisScene.Close();
        	//print(numScenes);
        	//print(numResults);
        	scenesArray = new Scene[numScenes];
        	resultsArray = new Result[numResults];
        }
        counter.Close();
        textFile.Close();
	}
	void FillArrays()
	{
		int indexScenes = 0;
		int indexResults = 0;
		if (Globals.directory != "")
            textFile = new StreamReader(Globals.directory+"/"+Globals.collectionName+"/"+Globals.scenarioName+"/"+Globals.scenarioName+".xml");
        else
            textFile = new StreamReader(Application.dataPath+"/Resources/scenarios/misc/Fantasia Hotel/Fantasia Hotel.xml");

		if (textFile != null)
		{
			reader = new XmlTextReader(new StringReader(textFile.ReadToEnd()));
		}
		if (reader != null)
		{
			reader.MoveToContent();  
			scenarioName = reader.GetAttribute("name");
			int.TryParse(reader.GetAttribute("Tim"), out failTim);
    		int.TryParse(reader.GetAttribute("Fin"), out failFin);
    		int.TryParse(reader.GetAttribute("Com"), out failCom);
    		int.TryParse(reader.GetAttribute("Env"), out failEnv);
    		int.TryParse(reader.GetAttribute("Eth"), out failEth);
    		int.TryParse(reader.GetAttribute("Pol"), out failPol);
    		int.TryParse(reader.GetAttribute("Pub"), out failPub);

            Globals.fTim = failTim;
            Globals.fFin = failFin;
            Globals.fCom = failCom;
            Globals.fEnv = failEnv;
            Globals.fEth = failEth;
            Globals.fPol = failPol;
            Globals.fPub = failPub;
            XmlReader thisScene = reader.ReadSubtree();
			while (thisScene.Read())
   			{
                //print("fuuuuk "+thisScene.Name);
   				if (thisScene.NodeType == XmlNodeType.Element && 
            		thisScene.Name == "scene")
        		{
                    Scene tempScene = new Scene();
                    //scenesArray[indexScenes] = new Scene();
        			int.TryParse(reader.GetAttribute("ID"), out tempScene.ID);
        			tempScene.sceneType = reader.GetAttribute("sceneType");
                    //print(reader.GetAttribute("sceneType"));
                    //print(indexScenes);
                    XmlReader innerScene = thisScene.ReadSubtree();
                    while (innerScene.Read())
                    {
                        if (innerScene.NodeType == XmlNodeType.Element && 
                            innerScene.Name == "introText")
                        {
                            tempScene.introText = innerScene.ReadInnerXml();
                        }
                        else if (innerScene.NodeType == XmlNodeType.Element && 
                            innerScene.Name == "choice1")
                        {
                            tempScene.c1Target = innerScene.GetAttribute("Target");
                            int.TryParse(innerScene.GetAttribute("Tim"), out tempScene.c1Tim);
                            int.TryParse(innerScene.GetAttribute("Fin"), out tempScene.c1Fin);
                            int.TryParse(innerScene.GetAttribute("Eth"), out tempScene.c1Eth);
                            int.TryParse(innerScene.GetAttribute("Env"), out tempScene.c1Env);
                            int.TryParse(innerScene.GetAttribute("Com"), out tempScene.c1Com);
                            int.TryParse(innerScene.GetAttribute("Pub"), out tempScene.c1Pub);
                            int.TryParse(innerScene.GetAttribute("Pol"), out tempScene.c1Pol);
                            tempScene.choice1Text = innerScene.ReadInnerXml();
                        }
                        else if (innerScene.NodeType == XmlNodeType.Element && 
                            innerScene.Name == "response1")
                        {
                            tempScene.choice1Reaction = innerScene.ReadInnerXml();
                        }
                        else if (innerScene.NodeType == XmlNodeType.Element && 
                            innerScene.Name == "choice2")
                        {
                            tempScene.c2Target = innerScene.GetAttribute("Target");
                            int.TryParse(innerScene.GetAttribute("Tim"), out tempScene.c2Tim);
                            int.TryParse(innerScene.GetAttribute("Fin"), out tempScene.c2Fin);
                            int.TryParse(innerScene.GetAttribute("Eth"), out tempScene.c2Eth);
                            int.TryParse(innerScene.GetAttribute("Env"), out tempScene.c2Env);
                            int.TryParse(innerScene.GetAttribute("Com"), out tempScene.c2Com);
                            int.TryParse(innerScene.GetAttribute("Pub"), out tempScene.c2Pub);
                            int.TryParse(innerScene.GetAttribute("Pol"), out tempScene.c2Pol);
                            tempScene.choice2Text = innerScene.ReadInnerXml();
                        }
                        else if (innerScene.NodeType == XmlNodeType.Element && 
                            innerScene.Name == "response2")
                        {
                            tempScene.choice2Reaction = innerScene.ReadInnerXml();
                        }
                        else if (innerScene.NodeType == XmlNodeType.Element && 
                            innerScene.Name == "choice3")
                        {
                            tempScene.c3Target = innerScene.GetAttribute("Target");
                            int.TryParse(innerScene.GetAttribute("Tim"), out tempScene.c3Tim);
                            int.TryParse(innerScene.GetAttribute("Fin"), out tempScene.c3Fin);
                            int.TryParse(innerScene.GetAttribute("Eth"), out tempScene.c3Eth);
                            int.TryParse(innerScene.GetAttribute("Env"), out tempScene.c3Env);
                            int.TryParse(innerScene.GetAttribute("Com"), out tempScene.c3Com);
                            int.TryParse(innerScene.GetAttribute("Pub"), out tempScene.c3Pub);
                            int.TryParse(innerScene.GetAttribute("Pol"), out tempScene.c3Pol);
                            tempScene.choice3Text = innerScene.ReadInnerXml();
                        }
                        else if (innerScene.NodeType == XmlNodeType.Element && 
                            innerScene.Name == "response3")
                        {
                            tempScene.choice3Reaction = innerScene.ReadInnerXml();
                        }
                    }
                    //print(tempScene.sceneType);
                    scenesArray[indexScenes] = tempScene;
        			indexScenes++;
                    innerScene.Close();
        		}
        		else if (thisScene.NodeType == XmlNodeType.Element && 
            		thisScene.Name == "result")
        		{
                    resultsArray[indexResults] = new Result();
        			int.TryParse(reader.GetAttribute("ID"), out resultsArray[indexResults].ID);
        			resultsArray[indexResults].resultText = thisScene.ReadInnerXml();
        			//print(resultsArray[indexResults]);
                    indexResults++;
        		}
   			}
            thisScene.Close();
   		}
        reader.Close();
        textFile.Close();
        //print(scenesArray.Length);
        //print(scenesArray[3].c2Target);
        isSetup = true;
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
            print(completedScenarios.Length);
            foreach (string scenar in completedScenarios)
            {
                print(scenar);
            }

            string[] newlyCompleted = new string[completedScenarios.Length+1];
            print(newlyCompleted.Length);
            for (int i = 0; i < completedScenarios.Length;i++)
            {
                if (completedScenarios[i] == Globals.scenarioName)
                    newScenario = false;
                newlyCompleted[i] = completedScenarios[i];
            }
            if (newScenario == true)
            {
                newlyCompleted[completedScenarios.Length] = Globals.scenarioName;
                PlayerPrefsX.SetStringArray("Completed_Scenarios",newlyCompleted);

            }
        }
        Globals.pFin += Globals.lFin;
        PlayerPrefs.SetInt("pFin", Globals.pFin);
        Globals.pCom += Globals.lCom;
        PlayerPrefs.SetInt("pCom", Globals.pCom);
        Globals.pEth += Globals.lEth;
        PlayerPrefs.SetInt("pEth", Globals.pEth);
        Globals.pEnv += Globals.lEnv;
        PlayerPrefs.SetInt("pEnv", Globals.pEnv);
        Globals.pPub += Globals.lPub;
        PlayerPrefs.SetInt("pPub", Globals.pPub);
        Globals.pTim += Globals.lTim;
        PlayerPrefs.SetInt("pTim", Globals.pTim);
        Globals.pPol += Globals.lPol;
        PlayerPrefs.SetInt("pPol", Globals.pPol);
        PlayerPrefs.Save();
    }

    void AlertFlash()
    {
        if (activeScene.sceneType == "phone")
        {
            GameObject.FindWithTag("phone").SendMessage("SetActive",SendMessageOptions.DontRequireReceiver);
            GameObject.FindWithTag("phone").collider.enabled = true;
            GameObject.FindWithTag("emailVideo").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
            GameObject.FindWithTag("person").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
        }
        else if (activeScene.sceneType == "video" || activeScene.sceneType == "email")
        {
            GameObject.FindWithTag("emailVideo").SendMessage("SetActive",SendMessageOptions.DontRequireReceiver);
            GameObject.FindWithTag("phone").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
            GameObject.FindWithTag("person").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
        }
        else if (activeScene.sceneType == "person")
        {
            GameObject.FindWithTag("person").SendMessage("SetActive",SendMessageOptions.DontRequireReceiver);
            GameObject.FindWithTag("emailVideo").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
            GameObject.FindWithTag("phone").SendMessage("SetInactive",SendMessageOptions.DontRequireReceiver);
        }
        Globals.sceneTextIndex = 0;
    }
}
