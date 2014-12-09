// 
// FluvioSlowMotion.cs
//  
// Author:
//       Josh Montoute <josh@thinksquirrel.com>
// 
// Copyright (c) 2011-2012, Thinksquirrel Software, LLC
// All rights reserved.
//
using UnityEngine;
using System.Collections;

[AddComponentMenu("Fluvio Example Project/Slow Motion")]
public class FluvioSlowMotion : MonoBehaviour {
	
	public KeyCode slowMotionKey = KeyCode.Space;
	public float slowMotionSpeed = .25f;
	public float normalSpeed = 1f;
	public static bool sleep = false;
	
	void FixedUpdate()
	{
		if (sleep)
		{
			sleep = false;
			return;
		}
		if (Input.GetKey(slowMotionKey))
		{
			Time.timeScale = slowMotionSpeed;
		}
		else
		{
			Time.timeScale = normalSpeed;
		}
	}
}
