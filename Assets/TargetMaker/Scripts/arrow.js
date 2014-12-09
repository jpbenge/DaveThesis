#pragma strict

// /-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\
//
// 						TargetMaker 1.0, Copyright © 2013, RipCord Development
//											     arrow.js
//										   info@ripcorddev.com
//
// \-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/

//ABOUT - This script controls the speed and life span of the target arrows.


var textureSpeed : float;		//How fast the texture will move across the object
var lifeSpan : float;			//The time in seconds it takes before the object is deleted from the scene

function Update () {

	renderer.material.mainTextureOffset.x = Mathf.Lerp(renderer.material.mainTextureOffset.x, -2, Time.deltaTime * textureSpeed);
	Destroy(gameObject, lifeSpan);
}