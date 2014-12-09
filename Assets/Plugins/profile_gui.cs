using UnityEngine;
using System.Collections;

public class profile_gui : MonoBehaviour {
	//variables
	public Texture2D statsTex;
	public GUISkin gskin;
	public float leftVal = -600;
	public float topVal = 1500;
	public string playerName;
	public string newName;
	public Texture2D achievementBox;
	public Texture2D profileBar;
	public Texture2D questionNoteTex;
	public Texture2D questionIconTex;
	public Texture2D backButton;
	public Texture2D achievementsButton;
	public Texture2D statsButton;
	public Texture2D iconTexEnv1;//Textures for Environmental achievements
	public Texture2D iconTexEnv2;
	public Texture2D iconTexEnv3;
	public Texture2D noteTexEnv1;
	public Texture2D noteTexEnv2;
	public Texture2D noteTexEnv3;
	public Texture2D iconTexPub1;//Textures for Public Relations achievements
	public Texture2D iconTexPub2;
	public Texture2D iconTexPub3;
	public Texture2D noteTexPub1;
	public Texture2D noteTexPub2;
	public Texture2D noteTexPub3;
	public Texture2D iconTexTim1;//Textures for Time achievements
	public Texture2D iconTexTim2;
	public Texture2D iconTexTim3;
	public Texture2D noteTexTim1;
	public Texture2D noteTexTim2;
	public Texture2D noteTexTim3;
	public Texture2D iconTexEco1;//Textures for economic achievements
	public Texture2D iconTexEco2;
	public Texture2D iconTexEco3;
	public Texture2D noteTexEco1;
	public Texture2D noteTexEco2;
	public Texture2D noteTexEco3;
	public Texture2D iconTexPol1;//Textures for Politics achievements
	public Texture2D iconTexPol2;
	public Texture2D iconTexPol3;
	public Texture2D noteTexPol1;
	public Texture2D noteTexPol2;
	public Texture2D noteTexPol3;
	public Texture2D iconTexComm1;//Textures for Communications achievements
	public Texture2D iconTexComm2;
	public Texture2D iconTexComm3;
	public Texture2D noteTexComm1;
	public Texture2D noteTexComm2;
	public Texture2D noteTexComm3;
	public Texture2D iconTexEth1;//Textures for Ethics achievements
	public Texture2D iconTexEth2;
	public Texture2D iconTexEth3;
	public Texture2D noteTexEth1;
	public Texture2D noteTexEth2;
	public Texture2D noteTexEth3;
	public Texture2D iconTexGen1;//Textures for General achievements
	public Texture2D iconTexGen2;
	public Texture2D iconTexGen3;
	public Texture2D iconTexGen4;
	public Texture2D iconTexGen5;
	public Texture2D iconTexGen6;
	public Texture2D iconTexGen7;
	public Texture2D iconTexGen8;
	public Texture2D iconTexGen9;
	public Texture2D noteTexGen1;
	public Texture2D noteTexGen2;
	public Texture2D noteTexGen3;
	public Texture2D noteTexGen4;
	public Texture2D noteTexGen5;
	public Texture2D noteTexGen6;
	public Texture2D noteTexGen7;
	public Texture2D noteTexGen8;
	public Texture2D noteTexGen9;
	Texture2D noteTex;
	string rank;
	Vector2 scrollPosition = Vector2.zero;
	Texture2D questionMark;
	float delayTime;
	float moveTop = 0;
	float originalLeft;
	bool check = true;
	Rect labelRect;
	private float baseWidth = 1280f;
	private float baseHeight = 720f;
	public int alwaysON = 0;    //for the UI stuff that stays on all the time
	public int noteState = 0;	//used to determine what the notification is doing
	// Use this for initialization
	void achievementButton(int x, int y, Texture2D iconTex, Texture2D newNoteTex, bool conditions){//Function for achievement buttons. x and y are position on grid
										//iconTex = achievement icon. noteTex = notification picture. conditions = conditions to achieve (this variable is temporary until achievements are implemented)
		if (conditions == false)
			if (GUI.Button(new Rect(x*60+575,y*60+290,60,60),questionIconTex))//Places a ? button instead of the achievement
				{
				noteState = 1;//Sweeps in the ??? notification
				noteTex = questionNoteTex;
				}
		if (conditions == true)
			if (GUI.Button(new Rect(x*60+575,y*60+290, 60,60),iconTex))//Achievement button icon is used
		{
			noteState = 1;//Sweeps in the achievement notification
			noteTex = newNoteTex;
		}
	
	}
	void Start () {
		originalLeft = leftVal;
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
		GUI.skin = gskin;
		GUI.Box(new Rect(550,topVal,650,800),"","BackgroundBox");
		GUI.Label(new Rect(530,topVal+20,740,120),profileBar);
		newName = GUI.TextField(new Rect(665,topVal+154,260,38),PlayerPrefs.GetString("playerName"),"darkBox");
		PlayerPrefs.SetString("playerName", newName);
		GUI.Label(new Rect(665,topVal+194,240,38),"Rank: "+rank,"darkBox");
		GUI.Box(new Rect(575,topVal+150,84,84),"","cooksonBox");
		labelRect = new Rect(leftVal,600,373,100);
		GUI.Label(labelRect,noteTex);
		topVal = iTween.FloatUpdate(topVal,moveTop,4F);//This tween controls vertical movement of profile menu elements
		if (check == false)//Checks if this statement has run
		{
		if(delayTime <= Time.time)//Waits after "go back" button is pressed
		{
			moveTop = 0;
			topVal = 1500;
			check = true;
			this.enabled = false;//Closes program after it sweeps down
		}
		}
		if (alwaysON == 0)
		{

			if (GUI.Button(new Rect(1050,topVal+670,150,55),backButton,"Buttons"))//Goes back to main menu button
				{
					//Application.LoadLevel("Scene_Main");
					delayTime = Time.time+1;
					check = false;
					PlayerPrefs.Save();
					menuGlobals.profileState = 0;
				
					noteState = 99;//Sweeps the achievement notifications out of view
					moveTop = 700;//Moves profile menu back down
					
				}
			if (GUI.Button(new Rect(575,topVal+250,100,30),statsButton,"Buttons"))//Displays the Stats Tab
				{
					menuGlobals.profileState = 1;
					noteState = 99;
				}
			if (GUI.Button(new Rect(677,topVal+250,100,30),achievementsButton,"Buttons"))//Displays the General Achievements Tab
				{
					menuGlobals.profileState = 2;
					noteState = 99;
				}
		
		}
		if (menuGlobals.profileState == 1)//Stats tab
			{
				GUI.Label(new Rect(575,290,583,285),"Time played:\n" +
					"Scenarios Completed:\n" +
					"Best Category:\n" +
					"Worst Category:\n");
			}
		else if (menuGlobals.profileState == 2)//General Achievement Tab
		{
			GUI.Label(new Rect(575,290,630,700),achievementBox);
			achievementButton (0,0,iconTexGen1,noteTexGen1,true);
			achievementButton (0,1,iconTexGen2,noteTexGen2,true);
			achievementButton (0,2,iconTexGen3,noteTexGen3,false);
			achievementButton (1,0,iconTexGen4,noteTexGen4,true);
			achievementButton (1,1,iconTexGen5,noteTexGen5,false);
			achievementButton (1,2,iconTexGen6,noteTexGen6,false);
			achievementButton (2,0,iconTexGen7,noteTexGen7,true);
			achievementButton (2,1,iconTexGen8,noteTexGen8,true);
			achievementButton (2,2,iconTexGen9,noteTexGen9,false);
			achievementButton (3,0,iconTexComm1,noteTexComm1,true);
			achievementButton (3,1,iconTexComm2,noteTexComm2,true);
			achievementButton (3,2,iconTexComm3,noteTexComm3,true);
			achievementButton (4,0,iconTexEth1,noteTexEth1,false);
			achievementButton (4,1,iconTexEth2,noteTexEth2,false);
			achievementButton (4,2,iconTexEth3,noteTexEth3,false);
			achievementButton (5,0,iconTexEnv1,noteTexEnv1,true);
			achievementButton (5,1,iconTexEnv2,noteTexEnv2,true);
			achievementButton (5,2,iconTexEnv3,noteTexEnv3,true);
			achievementButton (6,0,iconTexPol1,noteTexPol1,true);
			achievementButton (6,1,iconTexPol2,noteTexPol2,true);
			achievementButton (6,2,iconTexPol3,noteTexPol3,false);
			achievementButton (7,0,iconTexPub1,noteTexPub1,true);
			achievementButton (7,1,iconTexPub2,noteTexPub2,true);
			achievementButton (7,2,iconTexPub3,noteTexPub3,true);
			achievementButton (8,0,iconTexTim1,noteTexTim1,false);
			achievementButton (8,1,iconTexTim2,noteTexTim2,false);
			achievementButton (8,2,iconTexTim3,noteTexTim3,false);
			achievementButton (9,0,iconTexEco1,noteTexEco1,true);
			achievementButton (9,1,iconTexEco2,noteTexEco2,false);
			achievementButton (9,2,iconTexEco3,noteTexEco3,false);
		}
		if (noteState == 1)
		{
			leftVal = iTween.FloatUpdate(leftVal,200,2);
		}
		if (noteState == 99)//Makes the notification fly back off screen
		{
			leftVal = iTween.FloatUpdate(leftVal,originalLeft,2);
		}
			
	}
}
