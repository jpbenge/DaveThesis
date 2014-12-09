#pragma strict

// /-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\
//
// 							TargetMaker 1.0, Copyright © 2012, RipCord Development
//										  DEMO-presetEmitter.js
//										   info@ripcorddev.com
//
// \-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/

//ABOUT - This script is for demonstration purposes only and is not needed for the actual functionality of TargetMaker
//	    - This script selects an element from an array and instances it into the scene.  It is meant to show some of the
//		combinations possible with TargetMaker

var presets : GameObject[];
var delay : float;

private var selectedPreset : GameObject;
private var x : int;


function Start () {

	while (true) {
		GeneratePreset();
		yield WaitForSeconds(delay);
	}
}

function GeneratePreset() {

	selectedPreset = presets[x];
	var newPreset = Instantiate(selectedPreset, transform.position, transform.rotation);
	
	if (x < presets.Length -1) {
		x++;
	}
	else {
		x = 0;
	}
}