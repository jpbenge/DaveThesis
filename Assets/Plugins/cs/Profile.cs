using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


[Serializable ()]
public class Profile : ISerializable {

	public string playerName;
	public string[] completedScenarios;
	public string[] loggedInfo;
	public string[] achievements;
	public float totalTime;

	public int pEnv;
	public int pEth;
	public int pFin;
	public int pPol;
	public int pCom;
	public int pTim;
	public int pPub;

	public Profile()
	{
		playerName = "NO NAME";

		totalTime = 0f;
		pEnv = 0;
		pEth = 0;
		pFin = 0;
		pPol = 0;
		pPub = 0;
		pCom = 0;
		pTim = 0;
	}
	public Profile(SerializationInfo info, StreamingContext ctxt)
	{
   		//Get the values from info and assign them to the appropriate properties
    	playerName = (string)info.GetValue("playerName", typeof(string));

    	completedScenarios = (string[])info.GetValue("completedScenarios",typeof(string[]));
    	loggedInfo = (string[])info.GetValue("loggedInfo",typeof(string[]));
    	achievements = (string[])info.GetValue("achievements",typeof(string[]));

    	pEnv = (int)info.GetValue("pEnv", typeof(int));
    	pEth = (int)info.GetValue("pEth", typeof(int));
    	pFin = (int)info.GetValue("pFin", typeof(int));
    	pPol = (int)info.GetValue("pPol", typeof(int));
    	pPub = (int)info.GetValue("pPub", typeof(int));
    	pCom = (int)info.GetValue("pCom", typeof(int));
    	pTim = (int)info.GetValue("pTim", typeof(int));

    	totalTime = (float)info.GetValue("totalTime", typeof(float));
    		
	}
        
	//Serialization function.
	public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	{
    	//You can use any custom name for your name-value pair. But make sure you
    	// read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
    	// then you should read the same with "EmployeeId"
    	info.AddValue("playerName", playerName);

    	info.AddValue("completedScenarios", completedScenarios);
    	info.AddValue("loggedInfo", loggedInfo);
    	info.AddValue("achievements", achievements);

    	info.AddValue("pEnv", pEnv);
    	info.AddValue("pEth", pEth);
    	info.AddValue("pFin", pFin);
    	info.AddValue("pPol", pPol);
    	info.AddValue("pPub", pPub);
    	info.AddValue("pCom", pCom);
    	info.AddValue("pTim", pTim);

    	info.AddValue("totalTime", totalTime);
	}
}
