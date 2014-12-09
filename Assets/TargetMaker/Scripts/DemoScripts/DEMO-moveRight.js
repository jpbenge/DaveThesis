#pragma strict

// /-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\
//
// 							TargetMaker 1.0, Copyright © 2012, RipCord Development
//										    DEMO-moveRight.js
//										   info@ripcorddev.com
//
// \-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/

//ABOUT - This script is for demonstration purposes only and is not needed for the actual functionality of TargetMaker
//		- This script will use the positionIncrement to move the object to the right more and more each frame.


private var positionIncrement : float = 0.005;

function Update () {

	if (gameObject.transform.position.x <= 5.0) {
		gameObject.transform.position.x += positionIncrement;
	}
	else {
		Destroy(gameObject);
	}

}