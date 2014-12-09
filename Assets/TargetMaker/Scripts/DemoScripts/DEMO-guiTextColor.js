#pragma strict

// /-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\
//
// 							TargetMaker 1.0, Copyright © 2012, RipCord Development
//										   DEMO-3dTextColor.js
//										   info@ripcorddev.com
//
// \-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/

//ABOUT - This script is for demonstration purposes only and is not needed for the actual functionality of TargetMaker
//		- This script allows you to pick a colour for the attached text object.


var textColour : Color;

function OnGUI () {

	gameObject.renderer.material.color = textColour;

}