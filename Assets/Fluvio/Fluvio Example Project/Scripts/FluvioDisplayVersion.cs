// 
// DisplayVersion.cs
//  
// Author:
//       Josh Montoute <josh@thinksquirrel.com>
// 
// Copyright (c) 2011-2012, Thinksquirrel Software, LLC
// All rights reserved.
//
using UnityEngine;
using System.Collections;
using ThinksquirrelSoftware.Fluvio;

[RequireComponent(typeof(GUIText))]
[AddComponentMenu("Fluvio Example Project/Version Display")]
public class FluvioDisplayVersion : MonoBehaviour {

	void Awake()
	{
		guiText.text = "Fluvio v. " + VersionInfo.version;
	}
}
