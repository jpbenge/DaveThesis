#pragma strict

// /-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\
//
// 							TargetMaker 1.0, Copyright © 2012, RipCord Development
//										  DEMO-cursorSwapper.js
//										   info@ripcorddev.com
//
// \-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/

//ABOUT - This script is for demonstration purposes only and is not needed for the actual functionality of TargetMaker
//		- This script will cycle backwards or forwards through the various example cursors contained in the demo.


var cursors : GameObject[];
var cursorManagers : GameObject[];

private var y : int;


function Update () {

	if (Input.GetKeyDown("space")) {
		var oldCursors : GameObject[] = GameObject.FindGameObjectsWithTag("Cursor");
		
		for (var x = 0; x < oldCursors.Length; x++) {
			Destroy(oldCursors[x]);
		}
		
		var newCursor = Instantiate(cursors[y], Vector3(transform.position.x, 0.001, transform.position.z), transform.rotation);
		var newCursorManager = Instantiate(cursorManagers[y], transform.position, transform.rotation);
		
		if (y < (cursors.Length - 1)) {
			y++;
			Debug.Log(y);
		}
		else {
			y = 0;
		}
	}
}