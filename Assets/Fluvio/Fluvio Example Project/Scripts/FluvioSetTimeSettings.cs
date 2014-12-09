// 
// FluvioSetTimeSettings.cs
//  
// Author:
//       Josh Montoute <josh@thinksquirrel.com>
// 
// Copyright (c) 2011-2012, Thinksquirrel Software, LLC
// All rights reserved.
//
using UnityEngine;
using System.Collections;

[AddComponentMenu("Fluvio Example Project/Set Time Settings")]
public class FluvioSetTimeSettings : MonoBehaviour {
	
	public float deltaTime = .02f;
	public float maxDeltaTime = .0333333f;
	
	void Awake()
	{
		Time.fixedDeltaTime = deltaTime;
		Time.maximumDeltaTime = maxDeltaTime;
	}
}
