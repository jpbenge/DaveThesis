using UnityEngine;
using System.Collections;

public class chooseScenarioLoader : MonoBehaviour {
	// the cube to make
	public GameObject prefab;
	//The Buildings
	public GameObject CivilBuilding;
	public GameObject CommercialBuilding;
	public GameObject MiscBuilding;
	public GameObject ResidentialBuilding;
	//Game object arrays so that we can turn the buildings on and off
	GameObject[] CivilBuildings = new GameObject[4];
	GameObject[] CommercialBuildings = new GameObject[4];
	GameObject[] MiscBuildings = new GameObject[4];
	GameObject[] ResidentialBuildings = new GameObject[4];
	//2d array for progress check
	int[,] progressCheck = new int[4,2] { {0,0}, {0,0}, {0,0}, {0,0} };
	// teh directory to look in
	string directoryPath = "";
	// the array of scenario types (buildings)
	string[] scenarioTypes;
	//the names of scenarios in a perticular type
	string[] scenarios;
	//the names of completed scenarios in the player's profile
	string[] completedScenarios;
	// position to place the cube in
	public Vector3 buildPos;
	// Use this for initialization
	void Start () {
		string[] whateverthehell = new string[8];
		whateverthehell[0] = "Civil 1";
		whateverthehell[1] = "Civil 3";
		whateverthehell[2] = "Commercial 1";
		whateverthehell[3] = "Commercial 2";
		whateverthehell[4] = "Commercial 3";
		whateverthehell[5] = "Commercial 5";
		whateverthehell[6] = "originalTest";
		whateverthehell[7] = "Residential 3";
		PlayerPrefsX.SetStringArray("Completed_Scenarios",whateverthehell);
		int num = 0;
		for (int q=0; q < CivilBuilding.transform.childCount; q++)
					{
						
						CivilBuilding.transform.GetChild(q).gameObject.SetActive(false);
						CivilBuildings[q] = CivilBuilding.transform.GetChild(q).gameObject;

					}
		for (int r=0; r < CommercialBuilding.transform.childCount; r++)
					{
						
						CommercialBuilding.transform.GetChild(r).gameObject.SetActive(false);
						CommercialBuildings[r] = CommercialBuilding.transform.GetChild(r).gameObject;

					}
		for (int s=0; s < MiscBuilding.transform.childCount; s++)
					{
						
						MiscBuilding.transform.GetChild(s).gameObject.SetActive(false);
						MiscBuildings[s] = MiscBuilding.transform.GetChild(s).gameObject;

					}
		for (int t=0; t < ResidentialBuilding.transform.childCount; t++)
					{
						
						ResidentialBuilding.transform.GetChild(t).gameObject.SetActive(false);
						ResidentialBuildings[t] = ResidentialBuilding.transform.GetChild(t).gameObject;

					}
		//set the directory path
		directoryPath = Application.dataPath+"/Resources/scenarios";
		// fill the completed scenarios array from PlayerPrefs
		completedScenarios = PlayerPrefsX.GetStringArray("Completed_Scenarios");
		//load the scenarios
		LoadScenarios();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadScenarios()
	{
		//reset the build location
		buildPos = Vector3.zero;
		int percentCheck = 0;
        int[] actValue = new int[4];
		// try catches the error if it occurs
		try
		{
			//read all the directoris in the path
			scenarioTypes = System.IO.Directory.GetDirectories(directoryPath);
			//loop through the directories in the parent directory
			for(int i = 0;i<scenarioTypes.Length;i++)
            {
            	// get the directory at i
            	scenarios = System.IO.Directory.GetDirectories(scenarioTypes[i]);
                for (int j = 0;j<scenarios.Length;j++)
                {
                	//make the cube
                	GameObject piece = Instantiate(prefab, buildPos, Quaternion.identity) as GameObject;
                	//trim the directory path so we can compare it to the one in PlayerPrefs
                	print(i);
                	progressCheck[i,0] = scenarios.Length;
                	scenarios[j] = scenarios[j].Substring(scenarios[j].LastIndexOf(("\\"))+1);

                	for (int k = 0; k < completedScenarios.Length;k++)
                	{
                		//search the array from PlayerPrefs to see if the current directory name matches
                		//one of the completed scenarios
                		if (completedScenarios[k] == scenarios[j])
                		{
                			
                			//turn it green
                			piece.renderer.material.color = Color.green;
                			progressCheck[i,1]++;
                		}
                		
                	
                	}
                	//move the build position up
                	buildPos = new Vector3(buildPos.x,buildPos.y+10f,buildPos.z);
                }
                // move the build position over
                buildPos = new Vector3(buildPos.x+15f, 0, buildPos.z);
                
            }
           
		}
		//catch an error reading the directory
		catch (System.Exception e) 
        {
        	//log the error
            Debug.Log(e);
        }
       
        for (int o =0; o < 4; o++)
        {
        	percentCheck = 0;
        	percentCheck = (progressCheck[o,1] / progressCheck[o,0]) * 100;
        	if (percentCheck <= 25)
        	actValue[o] = 1;
        	else if (percentCheck <= 50)
        	actValue[o] = 2;
        	else if (percentCheck <= 75)
        	actValue[o] = 3;
        	else if (percentCheck <= 100)
        	actValue[o] = 4;


        }

    	CivilBuilding.transform.GetChild(actValue[0]).gameObject.SetActive(true);
    	CommercialBuilding.transform.GetChild(actValue[1]).gameObject.SetActive(true);
    	MiscBuilding.transform.GetChild(actValue[2]).gameObject.SetActive(true);
    	ResidentialBuilding.transform.GetChild(actValue[3]).gameObject.SetActive(true);

        print("ksjdhgfjshg");
        foreach (int row in actValue)
  {
   print(row);
   }
	}
}
