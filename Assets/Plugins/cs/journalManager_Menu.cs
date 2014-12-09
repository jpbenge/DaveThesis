using UnityEngine;
using System.Collections;

public class journalManager_Menu : MonoBehaviour {

	public GameObject mainUi;
	float inactiveTop = 2500f;
	float topVal = 2500f;
	float activeTop = 0f;
	public GUISkin jSkin;
	public Texture2D finImg;
	public Texture2D ethImg;
	public Texture2D envImg;
	public Texture2D comImg;
	public Texture2D pubImg;
	public Texture2D timImg;
	public Texture2D polImg;
	public bool journalOpen = false;
	public int journalState = 0;
	GameObject mainCam;

	public float baseWidth = 1280f;
    public float baseHeight = 720f;
    public Vector2 scrollPosition = Vector2.zero;
    string infoString = "";

	// Use this for initialization
	void Start () {
		mainCam = GameObject.Find("Camera_Game");
		//mainCam.GetComponent<BlurEffect>().enabled = false;
		infoString = "";
		UpdateInformationString();

		//PlayerPrefsX.SetStringArray("Logged_Information",new string[1]);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnEnabled()
	{
		mainUi.SetActive(false);
		journalOpen = true;
		//mainCam.GetComponent<BlurEffect>().enabled = true;
		UpdateInformationString();
		scrollPosition = Vector2.zero;
		Hashtable hash = new Hashtable();
		hash.Add("from", inactiveTop);
		hash.Add("to", activeTop);
		hash.Add("time", 0.5f);
		hash.Add("onupdate", "UpdateTopVal");
		iTween.ValueTo(gameObject,hash);
	}

	public void OnDisabled()
	{
		mainUi.SetActive(true);
		Hashtable hash = new Hashtable();
		hash.Add("from", activeTop);
		hash.Add("to", inactiveTop);
		hash.Add("time", 0.5f);
		hash.Add("onupdate", "UpdateTopVal");
		hash.Add("oncomplete", "DisableCompleted");
		iTween.ValueTo(gameObject,hash);
		
	}

	void UpdateTopVal(float curVal)
	{
		topVal = curVal;
	}
	void DisableCompleted()
	{
		journalOpen = false;
	}

	void UpdateInformationString()
	{
		infoString = "";
		string[] infoArray = PlayerPrefsX.GetStringArray("Logged_Information");
		foreach (string info in infoArray)
		{	
			print(info);
			if (info.Length < 253)
			{
				infoString += info;
				infoString += "\n\n";
			}
			else 
			{
				if (info.Substring(253) != "%%")
				{
					infoString += info;
					infoString += "\n\n";
				}
				else
				{
					infoString += info;
					infoString = infoString.Substring(0,infoString.Length-2);
				}
			}
		}
		print(infoString);
	}

	void OnGUI()
	{
		Vector3 scale = Vector3.zero;
        scale.x = Screen.width / baseWidth;
        scale.y = Screen.height / baseHeight;
        scale.z = 1f;

        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
		GUI.skin = jSkin;
		if (journalOpen)
		{
			GUI.Box(new Rect(177,topVal+0,926,720),PlayerPrefs.GetString("playerName"));
			GUI.Box(new Rect(268,topVal+246,250,367),"","blueBox");
			if (GUI.Button(new Rect(954,topVal+50,88,55),"Close","closeButton"))
			{
				OnDisabled();
				//mainCam.GetComponent<BlurEffect>().enabled = false;
			}
			if (journalState >= 0 && journalState < 11)
			{
				if (GUI.Button(new Rect(244,topVal+130,100,68),"Information","infoButtonActive"))
				{
					journalState = 0;
				}
				else if (GUI.Button(new Rect(344,topVal+130,100,68),"Profile","profileButton"))
				{
					journalState = 11;
				}	
				else if (GUI.Button(new Rect(442,topVal+130,100,68),"Resources","resourcesButton"))
				{
					journalState = 13;
				}
				if (journalState == 0)
				{
					/*
					if (GUI.Button(new Rect(305,topVal+270,175,45),"Time","narrowButtonActive"))
					{
						journalState = 0;
					}
					if (GUI.Button(new Rect(305,topVal+340,175,45),"Finance","narrowButton"))
					{
						journalState = 1;
					}
					if (GUI.Button(new Rect(305,topVal+410,175,45),"PR","narrowButton"))
					{
						journalState = 2;
					}
					if (GUI.Button(new Rect(305,topVal+480,175,45),"Office Relations","narrowButton"))
					{
						journalState = 3;
					}
					if (GUI.Button(new Rect(305,topVal+550,175,45),"Ethics","narrowButton"))
					{
						journalState = 4;
					}
					*/
				}
				if (journalState == 1)
				{
					if (GUI.Button(new Rect(305,topVal+270,175,45),"Time","narrowButton"))
					{
						journalState = 0;
					}
					if (GUI.Button(new Rect(305,topVal+340,175,45),"Finance","narrowButtonActive"))
					{
						journalState = 1;
					}
					if (GUI.Button(new Rect(305,topVal+410,175,45),"PR","narrowButton"))
					{
						journalState = 2;
					}
					if (GUI.Button(new Rect(305,topVal+480,175,45),"Office Relations","narrowButton"))
					{
						journalState = 3;
					}
					if (GUI.Button(new Rect(305,topVal+550,175,45),"Ethics","narrowButton"))
					{
						journalState = 4;
					}
				}
				if (journalState == 2)
				{
					if (GUI.Button(new Rect(305,topVal+270,175,45),"Time","narrowButton"))
					{
						journalState = 0;
					}
					if (GUI.Button(new Rect(305,topVal+340,175,45),"Finance","narrowButton"))
					{
						journalState = 1;
					}
					if (GUI.Button(new Rect(305,topVal+410,175,45),"PR","narrowButtonActive"))
					{
						journalState = 2;
					}
					if (GUI.Button(new Rect(305,topVal+480,175,45),"Office Relations","narrowButton"))
					{
						journalState = 3;
					}
					if (GUI.Button(new Rect(305,topVal+550,175,45),"Ethics","narrowButton"))
					{
						journalState = 4;
					}
				}
				if (journalState == 3)
				{
					if (GUI.Button(new Rect(305,topVal+270,175,45),"Time","narrowButton"))
					{
						journalState = 0;
					}
					if (GUI.Button(new Rect(305,topVal+340,175,45),"Finance","narrowButton"))
					{
						journalState = 1;
					}
					if (GUI.Button(new Rect(305,topVal+410,175,45),"PR","narrowButton"))
					{
						journalState = 2;
					}
					if (GUI.Button(new Rect(305,topVal+480,175,45),"Office Relations","narrowButtonActive"))
					{
						journalState = 3;
					}
					if (GUI.Button(new Rect(305,topVal+550,175,45),"Ethics","narrowButton"))
					{
						journalState = 4;
					}
				}
				if (journalState == 4)
				{
					if (GUI.Button(new Rect(305,topVal+270,175,45),"Time","narrowButton"))
					{
						journalState = 0;
					}
					if (GUI.Button(new Rect(305,topVal+340,175,45),"Finance","narrowButton"))
					{
						journalState = 1;
					}
					if (GUI.Button(new Rect(305,topVal+410,175,45),"PR","narrowButton"))
					{
						journalState = 2;
					}
					if (GUI.Button(new Rect(305,topVal+480,175,45),"Office Relations","narrowButton"))
					{
						journalState = 3;
					}
					if (GUI.Button(new Rect(305,topVal+550,175,45),"Ethics","narrowButtonActive"))
					{
						journalState = 4;
					}
				}
				scrollPosition = GUI.BeginScrollView(new Rect(560,topVal+150,465,490), scrollPosition, new Rect(0, 0, 440, 4000),false,true);
        			GUI.Label(new Rect (6,topVal+6,440,4000),infoString);
        		GUI.EndScrollView();
			}
			else if (journalState == 11 || journalState == 12)
			{
				if (GUI.Button(new Rect(244,topVal+130,100,68),"Information","infoButton"))
				{
					journalState = 0;
				}
				else if (GUI.Button(new Rect(344,topVal+130,100,68),"Profile","profileButtonActive"))
				{
					journalState = 11;
				}	
				else if (GUI.Button(new Rect(442,topVal+130,100,68),"Resources","resourcesButton"))
				{
					journalState = 13;
				}

				if (journalState == 11)
				{
					if (GUI.Button(new Rect(305,topVal+270,175,60),"Profile","narrowButtonActive"))
					{
						journalState = 11;
					}
					if (GUI.Button(new Rect(305,topVal+370,175,60),"achievements","narrowButton"))
					{
						journalState = 12;
					}
					

					GUI.Label(new Rect(860,topVal+170,130,30),"Overall","labelCenter");
					GUI.DrawTexture(new Rect(620,topVal+220,30,30),finImg);
					GUI.Label(new Rect(670,topVal+220,130,30),"Finance");
					
					GUI.Label(new Rect(860,topVal+220,130,30),Globals.pFin.ToString(),"labelCenter");
					GUI.DrawTexture(new Rect(620,topVal+260,30,30),ethImg);
					GUI.Label(new Rect(670,topVal+260,130,30),"Ethics");
					
					GUI.Label(new Rect(860,topVal+260,130,30),Globals.pEth.ToString(),"labelCenter");
					GUI.DrawTexture(new Rect(620,topVal+300,30,30),envImg);
					GUI.Label(new Rect(670,topVal+300,130,30),"Environment");
					
					GUI.Label(new Rect(860,topVal+300,130,30),Globals.pEnv.ToString(),"labelCenter");
					GUI.DrawTexture(new Rect(620,topVal+340,30,30),comImg);
					GUI.Label(new Rect(670,topVal+340,130,30),"Communication");
					
					GUI.Label(new Rect(860,topVal+340,130,30),Globals.pCom.ToString(),"labelCenter");
					GUI.DrawTexture(new Rect(620,topVal+380,30,30),pubImg);
					GUI.Label(new Rect(670,topVal+380,130,30),"Public Relations");
					
					GUI.Label(new Rect(860,topVal+380,130,30),Globals.pPub.ToString(),"labelCenter");
					GUI.DrawTexture(new Rect(620,topVal+420,30,30),timImg);
					GUI.Label(new Rect(670,topVal+420,130,30),"Time");
					
					GUI.Label(new Rect(860,topVal+420,130,30),Globals.pTim.ToString(),"labelCenter");
					GUI.DrawTexture(new Rect(620,topVal+460,30,30),polImg);
					GUI.Label(new Rect(670,topVal+460,130,30),"Office Politics");
					
					GUI.Label(new Rect(860,topVal+460,130,30),Globals.pPol.ToString(),"labelCenter");
				}
				else if (journalState == 12)
				{
					if (GUI.Button(new Rect(305,topVal+270,175,60),"Profile","narrowButton"))
					{
						journalState = 11;
					}
					if (GUI.Button(new Rect(305,topVal+370,175,60),"achievements","narrowButtonActive"))
					{
						journalState = 12;
					}
					GUI.Box(new Rect(585,topVal+150,420,56),"Achievements Coming Soon!","achievementsBar");
				}

			}
			else if (journalState == 13)
			{
				if (GUI.Button(new Rect(244,topVal+130,100,68),"Information","infoButton"))
				{
					journalState = 0;
				}
				else if (GUI.Button(new Rect(344,topVal+130,100,68),"Profile","profileButton"))
				{
					journalState = 11;
				}	
				else if (GUI.Button(new Rect(442,topVal+130,100,68),"Resources","resourcesButtonActive"))
				{
					journalState = 13;
				}
				GUI.Label(new Rect(640,topVal+170,130,30),"NCARB");
				if (GUI.Button(new Rect(640,topVal+270,130,30),"http://www.ncarb.org/","link"))
				{
					Application.OpenURL("http://www.ncarb.org/");
				}
				GUI.Label(new Rect(640,topVal+370,130,30),"AIA");
				if (GUI.Button(new Rect(640,topVal+470,130,30),"http://www.aia.org/","link"))
				{
					Application.OpenURL("http://www.aia.org/");
				}
			}

		}
	}
}
