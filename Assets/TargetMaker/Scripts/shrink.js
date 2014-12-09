#pragma strict

// /-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\
//
// 						TargetMaker 1.0, Copyright © 2013, RipCord Development
//												shrink.js
//										   info@ripcorddev.com
//
// \-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/

//ABOUT - This script controls the shrinking of objects based on values in the CursorManager.  When an object is small enough, it is removed from the scene.


var initialScale : float;						//This stores the scale of the object as it is brought into the scene
private var shrinkObject : boolean = false;		//This flag determines whether or not the object is able to shrink
private var shrinkScale : float;				//This number will be used as the scale value for all 3 axes.  This allows the object to be scaled uniformly
private var cursor : cursorManager;				//This stores the _CursorManager object in the scene
private var scaleTolerance : float = 0.01;		//If the scale of the object dtops below this number, the object will be deleted.  Useful for quickly removing an object that is being lerped.

function Awake () {

	shrinkScale = initialScale;					//Store the initial scale of the object so that it can be used throughout the rest of the script
	
	//Locate the _CursorManager object in the scene and access the cursorManager script on it
	cursor = gameObject.Find("_CursorManager").GetComponent("cursorManager");
	
	shrinkObject = true;						//Sets shrinkObject true so that the newRing can start shrinking

}

function Update () {


	if (shrinkObject == true) {
		shrinkScale = Mathf.Lerp(shrinkScale, 0.0, Time.deltaTime * cursor.shrinkRate);
		if(shrinkScale > scaleTolerance) {
			//Uniformly scale the object on all 3 axes
			gameObject.transform.localScale.x = shrinkScale;
			gameObject.transform.localScale.y = shrinkScale;
			gameObject.transform.localScale.z = shrinkScale;
		}
		
		//If the scale of the object is less than the scaleTolerance, delete the object
		else {
			shrinkObject = false;				//Stop shrinking the object
			Destroy(gameObject);			
		}
	}
	
}