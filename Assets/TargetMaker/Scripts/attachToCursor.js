#pragma strict

// /-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\
//
// 						TargetMaker 1.0, Copyright © 2013, RipCord Development
//											attachToCursor.js
//										   info@ripcorddev.com
//
// \-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/

//ABOUT - This script makes the attached object follow the cursor.
//TROUBLESHOOTING - If your target seems to only be moving on one axis, try changing the axisPair
//				  - AxisPair suggestions:
//				  -- XY - Vertical movement such as a puzzle game or sidescroller
//				  -- YZ - Similar to XY, but probably won't be used
//				  -- XZ - Horizontal movement such as a top down RTS game or anything moving along a ground plane


private var target : Vector3;

enum AxisPair { XY, YZ, XZ };		//The axes that the target will move along
var axisPair : AxisPair;


function Update() {

	var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
	var hit : RaycastHit;

	//If the raycast hits a collider, start updating the hit.point and update the gameObject's position accordingly
	if (Physics.Raycast (ray, hit)) { 	
 	
		 switch(axisPair){
			case AxisPair.XY:
					//Muve target along X and Y axes
	 				transform.position.x = hit.point.x;
					transform.position.y = hit.point.y;
	
				break;
			
			case AxisPair.YZ:
					//Muve target along Y and Z axes
	 				transform.position.y = hit.point.y;
					transform.position.z = hit.point.z;
	
				break;
				
			case AxisPair.XZ:
					//Muve target along X and Z axes
	 				transform.position.x = hit.point.x;
					transform.position.z = hit.point.z;
	
				break;
		}
	}

}