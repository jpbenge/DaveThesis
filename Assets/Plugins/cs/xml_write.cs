using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;
using System;

public class xml_write : MonoBehaviour {

	private float baseWidth = 1280f;
	private float baseHeight = 720f;
	//gui skin to use
	public GUISkin gSkin;

	//scene local state / not the same as Globals.state
	float state = 0f;
	//is the user inputing a result?
	bool results = false;

	//weird C# things for writing xml files
	StringWriter str;
	XmlTextWriter xml;

	private string filePath = "";
	private string nameStr = "";
	private string textString = "";

		private string sceneType ="person";

	private string tTim = "0";
	private string tFin = "0";
	private string tEth = "0";
	private string tEnv = "0";
	private string tPol = "0";
	private string tCom = "0";
	private string tPub = "0";

	
	// Use this for initialization
	void Start () {
		state = 0;
		results = false;
		//set the default file path
		filePath = Application.dataPath+"/Resources/scenarios";
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI () {
		Vector3 scale = Vector3.zero;
	 	scale.x = Screen.width / baseWidth;
	 	scale.y = Screen.height / baseHeight;
	 	scale.z = 1f;

	 	GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
	 	GUI.skin = gSkin;
		
		if (state == 0)
		{
			
			GUI.Label (new Rect (400,300,400, 40), "Enter Directory to Save to: ");
			filePath = GUI.TextField(new Rect (660, 300,500,30), filePath);
			GUI.Label (new Rect (400, 360, 400, 30), "Enter Scenario Name:");
			nameStr = GUI.TextField (new Rect (660, 360, 200, 30), nameStr, 40);

			if (GUI.Button(new Rect(600, 400, 100, 40), "Enter"))
			{
				if (nameStr != "")
				{
					str = new StringWriter();
					xml = new XmlTextWriter(str);
					xml.WriteStartDocument();
					xml.WriteWhitespace("\n");
	    			xml.WriteStartElement("scenario");
	    			xml.WriteAttributeString("name", nameStr);
	    			state = 0.5f;
	    		}
            }
            if (GUI.Button(new Rect(800,400,100, 40), "Back"))
            {
            	Application.LoadLevel("Main_Menu");
            }
		}
		if (state == 0.5f)
		{
			GUI.Label (new Rect (540, 470, 360, 30), "Scene Failure Values:");
			GUI.Label (new Rect (200, 500, 360, 30), "Time:");
			tTim = GUI.TextField (new Rect (270, 500, 40, 30), tTim, 2);
			GUI.Label (new Rect (340, 500, 360, 30), "Finances:");
			tFin = GUI.TextField (new Rect (450, 500, 40, 30), tFin, 2);
			GUI.Label (new Rect (520, 500, 360, 30), "Ethics:");
			tEth = GUI.TextField (new Rect (600, 500, 40, 30), tEth, 2);
			GUI.Label (new Rect (670, 500, 360, 30), "Environmental:");
			tEnv = GUI.TextField (new Rect (850, 500, 40, 30), tEnv, 2);
			GUI.Label (new Rect (200, 540, 360, 30), "Communication:");
			tCom = GUI.TextField (new Rect (380, 540, 40, 30), tCom, 2);
			GUI.Label (new Rect (500, 540, 360, 30), "Political:");
			tPol = GUI.TextField (new Rect (610, 540, 40, 30), tPol, 2);
			GUI.Label (new Rect (690, 540, 360, 30), "Public Relations:");
			tPub = GUI.TextField (new Rect (880, 540, 40, 30), tPub, 2);
			if (GUI.Button(new Rect(300, 670, 100, 40), "Enter the first scene"))
			{
				xml.WriteAttributeString("Tim", tTim);
	    		xml.WriteAttributeString("Fin", tFin);
	    		xml.WriteAttributeString("Eth", tEth);
	    		xml.WriteAttributeString("Env", tEnv);
	    		xml.WriteAttributeString("Com", tCom);
	    		xml.WriteAttributeString("Pol", tPol);	
	    		xml.WriteAttributeString("Pub", tPub);
	    		state = 1f;
			}
		}
		//print ("current state = "+100*state+". state mod 10 = "+state*100 % 10);
		if (!results && (state == 1 || (state > 1 && (state*100f % 10 < 0.8f || state*100f % 10 > 9.8f))))
		{
			GUI.Label (new Rect (540, 20, 360, 30), "Enter Scene " + state + " Dialogue:");
			textString = GUI.TextArea (new Rect (80, 60, 1120, 300), textString, 2000);
			GUI.Label (new Rect (540, 400, 360, 30), "Enter Scene Type: ");
			sceneType = GUI.TextField (new Rect (730, 400, 100, 30), sceneType, 10);
			GUI.Label (new Rect (540, 470, 360, 30), "Scene Target Values:");
			GUI.Label (new Rect (200, 500, 360, 30), "Time:");
			tTim = GUI.TextField (new Rect (270, 500, 40, 30), tTim, 2);
			GUI.Label (new Rect (340, 500, 360, 30), "Finances:");
			tFin = GUI.TextField (new Rect (450, 500, 40, 30), tFin, 2);
			GUI.Label (new Rect (520, 500, 360, 30), "Ethics:");
			tEth = GUI.TextField (new Rect (600, 500, 40, 30), tEth, 2);
			GUI.Label (new Rect (670, 500, 360, 30), "Environmental:");
			tEnv = GUI.TextField (new Rect (850, 500, 40, 30), tEnv, 2);
			GUI.Label (new Rect (200, 540, 360, 30), "Communication:");
			tCom = GUI.TextField (new Rect (380, 540, 40, 30), tCom, 2);
			GUI.Label (new Rect (500, 540, 360, 30), "Political:");
			tPol = GUI.TextField (new Rect (610, 540, 40, 30), tPol, 2);
			GUI.Label (new Rect (690, 540, 360, 30), "Public Relations:");
			tPub = GUI.TextField (new Rect (880, 540, 40, 30), tPub, 2);
			if (GUI.Button(new Rect(300, 670, 100, 40), "Add Choices"))
			{
				xml.WriteWhitespace("\n");
	    		xml.WriteStartElement("scene"+(float)Math.Round(state,2));
	    		xml.WriteStartElement("setup");
	    		xml.WriteAttributeString("sceneType", sceneType);
	    		xml.WriteAttributeString("Tim", tTim);
	    		xml.WriteAttributeString("Fin", tFin);
	    		xml.WriteAttributeString("Eth", tEth);
	    		xml.WriteAttributeString("Env", tEnv);
	    		xml.WriteAttributeString("Com", tCom);
	    		xml.WriteAttributeString("Pol", tPol);	
	    		xml.WriteAttributeString("Pub", tPub);
	    		xml.WriteWhitespace("\n");
	    		xml.WriteWhitespace("\n");
	    		xml.WriteStartElement("introText");
	    		xml.WriteValue(textString);
	    		xml.WriteEndElement();
	    		xml.WriteEndElement();
	    		state += 0.01f;
	    		state = (float)Math.Round(state,2);
	    		xml.WriteWhitespace("\n");
	    		xml.WriteStartElement("choice"+state.ToString().Substring(state.ToString().Length-1, 1));
	    		ResetValues();
	    	}
	    	
		}
		else if (!results && (state > 1f && state % 0.1f > 0f))
		{
			GUI.Label (new Rect (540, 20, 360, 30), "Enter Choice "+state +" Dialogue:");
			textString = GUI.TextArea (new Rect (80, 60, 1120, 400), textString, 2000);
			GUI.Label (new Rect (200, 500, 360, 30), "Time:");
			tTim = GUI.TextField (new Rect (270, 500, 40, 30), tTim, 2);
			GUI.Label (new Rect (340, 500, 360, 30), "Finances:");
			tFin = GUI.TextField (new Rect (450, 500, 40, 30), tFin, 2);
			GUI.Label (new Rect (520, 500, 360, 30), "Ethics:");
			tEth = GUI.TextField (new Rect (600, 500, 40, 30), tEth, 2);
			GUI.Label (new Rect (670, 500, 360, 30), "Environmental:");
			tEnv = GUI.TextField (new Rect (850, 500, 40, 30), tEnv, 2);
			GUI.Label (new Rect (200, 540, 360, 30), "Communication:");
			tCom = GUI.TextField (new Rect (380, 540, 40, 30), tCom, 2);
			GUI.Label (new Rect (500, 540, 360, 30), "Political:");
			tPol = GUI.TextField (new Rect (610, 540, 40, 30), tPol, 2);
			GUI.Label (new Rect (690, 540, 360, 30), "Public Relations:");
			tPub = GUI.TextField (new Rect (880, 540, 40, 30), tPub, 2);
			if (state.ToString().Substring(state.ToString().Length-1, 1) != "3")
			{
				if (GUI.Button(new Rect(300, 670, 100, 40), "Add Choice"))
				{
	    			xml.WriteAttributeString("Tim", tTim);
	    			xml.WriteAttributeString("Fin", tFin);
	    			xml.WriteAttributeString("Eth", tEth);
	    			xml.WriteAttributeString("Env", tEnv);
	    			xml.WriteAttributeString("Com", tCom);
	    			xml.WriteAttributeString("Pol", tPol);	
	    			xml.WriteAttributeString("Pub", tPub);
	    			xml.WriteValue(textString);
	    			state += 0.01f;
	    			state = (float)Math.Round(state,2);
	    			xml.WriteEndElement();
	    			xml.WriteWhitespace("\n");
	    			xml.WriteStartElement("choice"+state.ToString().Substring(state.ToString().Length-1, 1));
	    			ResetValues();
	    		}
	    	}
	    	else if (!results && (state % 0.1f > 0.025))
	    	{
	    		if (GUI.Button(new Rect(300, 670, 100, 40), "Add Another Scene"))
				{
					xml.WriteAttributeString("Tim", tTim);
	    			xml.WriteAttributeString("Fin", tFin);
	    			xml.WriteAttributeString("Eth", tEth);
	    			xml.WriteAttributeString("Env", tEnv);
	    			xml.WriteAttributeString("Com", tCom);
	    			xml.WriteAttributeString("Pol", tPol);	
	    			xml.WriteAttributeString("Pub", tPub);
	    			xml.WriteValue(textString);
	    			if (state >= 2 && state % 1 > 0.29f)
	    				state += 0.77f;
	    			else if (state < 2)
	    				state += 1.07f;
	    			else
	    				state += 0.07f;
	    			//state += 0.97f;
	    			state = (float)Math.Round(state,2);
	    			xml.WriteEndElement();
	    			xml.WriteWhitespace("\n");
	    			xml.WriteEndElement();
	    			xml.WriteWhitespace("\n");
	    			ResetValues();
				}
				if (state % 1f > 0.29)
				{
	    			if (GUI.Button(new Rect(900, 670, 100, 40), "Add Results"))
					{
						xml.WriteAttributeString("Tim", tTim);
	    				xml.WriteAttributeString("Fin", tFin);
	    				xml.WriteAttributeString("Eth", tEth);
	    				xml.WriteAttributeString("Env", tEnv);
	    				xml.WriteAttributeString("Com", tCom);
	    				xml.WriteAttributeString("Pol", tPol);
	    				xml.WriteAttributeString("Pub", tPub);
	    				xml.WriteValue(textString);
						xml.WriteEndElement();
						xml.WriteWhitespace("\n");
						xml.WriteEndElement();
						xml.WriteWhitespace("\n");
	    				state += 0.77f;
	    				results = true;
	    				state = (float)Math.Round(state,2);
	    				ResetValues();
	    			}
	    		}
	    	}
		}
		else if (results)
		{
			if (state % 1f < 0.15)
			{
				GUI.Label (new Rect (540, 20, 360, 30), "Enter Negative Scenario Outcome :");
				textString = GUI.TextArea (new Rect (80, 60, 1120, 400), textString, 2000);
				if (GUI.Button(new Rect(300, 670, 100, 40), "Add Another Scene"))
				{
					xml.WriteStartElement("result"+state.ToString());
					xml.WriteWhitespace("\n");
	    			xml.WriteValue(textString);
	    			xml.WriteWhitespace("\n");
	    			state += 0.1f;
	    			state = (float)Math.Round(state,2);
	    			xml.WriteEndElement();
	    			ResetValues();
				}
			}
			else if (state % 1f < 0.25)
			{	
				GUI.Label (new Rect (540, 20, 360, 30), "Enter Neutral Scenario Outcome :");
				textString = GUI.TextArea (new Rect (80, 60, 1120, 400), textString, 2000);
				if (GUI.Button(new Rect(300, 670, 100, 40), "Add Another Scene"))
				{
					xml.WriteStartElement("result"+state.ToString());
					xml.WriteWhitespace("\n");
	    			xml.WriteValue(textString);
	    			xml.WriteWhitespace("\n");
	    			state += 0.1f;
	    			state = (float)Math.Round(state,2);
	    			xml.WriteEndElement();
	    			ResetValues();
				}
			}
			else if (state % 1f < 0.35)
			{
				GUI.Label (new Rect (540, 20, 360, 30), "Enter Positive Scenario Outcome :");
				textString = GUI.TextArea (new Rect (80, 60, 1120, 400), textString, 2000);
				if (GUI.Button(new Rect(500, 670, 100, 40), "Finish"))
				{
					xml.WriteStartElement("result"+state.ToString());
					xml.WriteWhitespace("\n");
	    			xml.WriteValue(textString);
	    			xml.WriteWhitespace("\n");
	    			xml.WriteEndElement();
	    			xml.WriteWhitespace("\n");
	    			xml.WriteEndDocument();
	    			str.Close();
	    			FileInfo file = new System.IO.FileInfo(filePath+"\\"+nameStr+"\\"+nameStr+".xml");
	    			file.Directory.Create();
	    			File.WriteAllText(file.FullName, str.ToString());
	    			state = 0.9f;
	    			state = (float)Math.Round(state,2);
	    			ResetValues();
				}
			}
		}
		if (state == 0.9f)
		{
			if (GUI.Button(new Rect(500, 670, 100, 40), "Back to Title"))
			{
				Application.LoadLevel("Main_Menu");
			}
		}

	}
	public void ResetValues()
	{
		tTim = "0";
		tFin = "0";
		tEth = "0";
		tEnv = "0";
		tCom = "0";
		tPol = "0";
		tPub = "0";
		textString = "";
		sceneType = "person";
	}
}
