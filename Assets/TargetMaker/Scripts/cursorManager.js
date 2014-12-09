#pragma strict

// /-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\
//
// 						TargetMaker 1.0, Copyright © 2013, RipCord Development
//											cursorManager.js
//										   info@ripcorddev.com
//
// \-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/

//ABOUT - This script contains all the rules for the cursor.  Audio and effects related to the cursor are generated from this script.


var shrinkRate : float;						//The rate at which the object will shrink
static var targetShrinkRate : float;		//A static version of the shrinkRate.  This allows for a variable that can be modified in the inspector as well
											//as one that can be accessed by other scripts

var clickAudio : AudioClip;					//The audio that will play when the click is detected
var clickMarker : GameObject;				//The object that will be generated when the mouse is clicked
var clickEffect : GameObject;				//An additional effect that will be generated when the mouse is clicked

var clickMarkerLimit : int = 20;			//The number of click markers that can exist in the scene at any given time.  If set to 0, there will be no limit
static var activeMarkers : int;				//The current number of clickMarkers that are active in the scene
private var limitMarkers : boolean;			//A flag that states whether clickMarkers are unlimited or not

var cursorTransform : GameObject;			

var hideCursor : boolean;					//If true, hide the system cursor

function Awake () {

	targetShrinkRate = shrinkRate;
	cursorTransform = GameObject.Find("cursor");

	if (hideCursor == true) {
		Screen.showCursor = false;				//The the mouse cursor
	}
	
	//Check to see if there is a limit on clickMarkers.  If there is, limitMarkers is true
	if (clickMarkerLimit == 0) {
		limitMarkers = false;
	}
	else {
		limitMarkers = true;
	}
	
}

function Update () {

	if (limitMarkers == false) {
		if(Input.GetButtonDown("Fire1")) {
			PlayAudio();
			GenerateMarker();
			GenerateEffect();
		}
	}
	else {
	
		if (activeMarkers < clickMarkerLimit) {
			if(Input.GetButtonDown("Fire1")) {
				PlayAudio();
				GenerateMarker();
				GenerateEffect();
			}
		}
	}
}

//If there is a clickAudio object, play it
function PlayAudio() {
	if (clickAudio) {
		audio.Play();
	}
}

//If there is a clickMarker object, generate it
function GenerateMarker() {
	if (clickMarker) {
		var newMarker = Instantiate(clickMarker, cursorTransform.transform.position, cursorTransform.transform.rotation);
		activeMarkers++;
	}
}

//If there is a clickEffect object, generate it
function GenerateEffect() {
	if (clickEffect) {
		var newEffect = Instantiate(clickEffect, cursorTransform.transform.position, cursorTransform.transform.rotation);
	}
}