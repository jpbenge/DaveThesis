using UnityEngine;
using System.Collections;

public class scenario_loader_old : MonoBehaviour {
	//The Buildings
	public GameObject CivilBuilding;
	public GameObject CommercialBuilding;
	public GameObject MiscBuilding;
	public GameObject ResidentialBuilding;
	//Game object arrays so that we can turn the buildings on and off
	//Change the array size to match the number of layers
	GameObject[] CivilBuildings = new GameObject[5];
	GameObject[] CommercialBuildings = new GameObject[5];
	GameObject[] MiscBuildings = new GameObject[5];
	GameObject[] ResidentialBuildings = new GameObject[5];
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
		//changes the scenes that are registered complete for testing purposes, this iwll need to go away
		//when the final version is done
		string[] whateverthehell = new string[8];
		whateverthehell[0] = "Civil 1";
		whateverthehell[1] = "Civil 2";
		whateverthehell[2] = "Civil 3";
		whateverthehell[3] = "Civil 4";
		whateverthehell[4] = "Commercial 3";
		whateverthehell[5] = "Commercial 5";
		whateverthehell[6] = "originalTest";
		whateverthehell[7] = "Residential 3";
		//compares completed scenarios, will need to be changed back to the real one in final version
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
		//value for comparison
		float percentCheck = 0;
		//array for turning building stages on
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
                	
                	//sets the total number of scenes in a scenario
                	progressCheck[i,0] = scenarios.Length;
                	//trim the directory path so we can compare it to the one in PlayerPrefs
                	scenarios[j] = scenarios[j].Substring(scenarios[j].LastIndexOf(("\\"))+1);

                	for (int k = 0; k < completedScenarios.Length;k++)
                	{
                		//search the array from PlayerPrefs to see if the current directory name matches
                		//one of the completed scenarios
                		if (completedScenarios[k] == scenarios[j])
                		{
                			
                			//adds 1 to number of completed scenes
                			progressCheck[i,1]++;
                		}
                		
                	
                	}
                	//move the build position up
                	//buildPos = new Vector3(buildPos.x,buildPos.y+10f,buildPos.z);
                }
                // move the build position over
                //buildPos = new Vector3(buildPos.x+15f, 0, buildPos.z);
                
            }
           
		}
		//catch an error reading the directory
		catch (System.Exception e) 
        {
        	//log the error
            Debug.Log(e);
        }
       //for loop that compares the number of completed scenes in a scenario to total number of scenes
        for (int o =0; o < 4; o++)
        {
        	percentCheck = 0;
        	percentCheck = (float)(progressCheck[o,1] / (float)progressCheck[o,0]) * 100f;
        	// the percent values of completion shifted so that 40% or higher is required to make anythign show
			// up at all. Change the values to suit your needs
        	if (percentCheck <= 40)
        		actValue[o] = 1;
        	else if (percentCheck <= 60)
        		actValue[o] = 2;
        	else if (percentCheck <= 80)
        		actValue[o] = 3;
        	else if (percentCheck < 100)
        		actValue[o] = 4;
    		else if (percentCheck == 100)
        		actValue[o] = 5;
    		
        }
        //for loops that thurn the building stages on
		for (int q=0; q < actValue[0]; q++)
					{
						CivilBuilding.transform.GetChild(q).gameObject.SetActive(true);
					}
		for (int r=0; r < actValue[1]; r++)
					{
						CommercialBuilding.transform.GetChild(r).gameObject.SetActive(true);
					}
		for (int s=0; s < actValue[2]; s++)
					{
						MiscBuilding.transform.GetChild(s).gameObject.SetActive(true);
					}
		for (int t=0; t < actValue[3]; t++)
					{
						ResidentialBuilding.transform.GetChild(t).gameObject.SetActive(true);
					}
	}
}
