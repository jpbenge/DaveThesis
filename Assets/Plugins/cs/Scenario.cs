using UnityEngine;
using System.Collections;

public class Scenario : Object {

	public int scenarioIndex = 0;
	public string scenarioName = "";
	public int collectionIndex = 0;
	public string collectionType = "";
	public string description = "";
	public Texture2D scenarioImg;

	// Use this for initialization
	public Scenario(int tIndex, string tName, int sIndex, string sName)
	{
		scenarioIndex = sIndex;
		scenarioName = sName;
		collectionIndex = tIndex;
		collectionType = tName;
	}
	
}
