#pragma strict

// /-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\
//
// 						TargetMaker 1.0, Copyright © 2013, RipCord Development
//											cursorMovement.js
//										   info@ripcorddev.com
//
// \-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/-\-/

//ABOUT - This script controls the basic movement of objects.  It can control the rotation as well as modify the scale.
//		  This script can also make the object shirnk away until it disappears.  This can be based on a timer, or as soon
//		  as the object is generated.


private var canSpin : boolean;
var spinRate : float;							//The rate at which the object rotates.  Negative values will cause the object to rotate in the opposite direction
												//If 0, the object won't spin at all

private var canScale : boolean;
var scalePulseAmount : float = 0.25;			//How far the object will scale above and below the initialScale
var scalePulseSpeed : float = 3.0;				//How fast the object will scale above and below the initialScale

private var currentScale : float;				//The single value that will control the X, Y and Z scale of the object
var initialScale : float = 1;					//The scale the object will inherit when it is initially generated


private var shrinkAway : boolean = false;		//If true the object will gradually shrink until it disappears
private var scalePulseRing : boolean = true;
private var shrinkScale : float;

var shrinkAfterTime : boolean;					//
var shrinkDelay : float = 3;					//The number of time, in seconds, the object will wait before shrinking down to nothing
												//If 0, the object will begin to shrink immediately after it is generated
var shrinkRate : float;							//The speed at which the object will shrink //Numbers above 1 will increase speed, numbers below 1 will decrease speed

function Awake () {

	shrinkScale = initialScale;
	currentScale = initialScale;
	
	//If a value has been set for the spinRate, allow the object to spin
	if (spinRate != 0) {
		canSpin = true;
	}
	
	//If values have been set for the scalePulse, allow the object to scale
	if (scalePulseAmount != 0 && scalePulseSpeed != 0) {
		canScale = true;
	}

}


function Start () {

	if (shrinkAfterTime == true) {
		yield WaitForSeconds(shrinkDelay);			//Wait for the specified number of seconds before the object starts shrinking
		shrinkAway = true;							//Set the shrinkAway flag true so that the object will start shrinking
		scalePulseRing = false;						//Set the scalePulseRing flag false so that the object stops pulsing
		shrinkScale = currentScale;					//Set shrinkScale equal to the currentScale of the object so that the object smoothly shrinks down
	}
}

function Update () {

	//If a value has been set for the spinRate, spin the object
	if (canSpin == true) {
		transform.Rotate(0, (spinRate * Time.deltaTime), 0);
	}
	
	//If values have been set for the scalePulse, scale the object
	if (canScale == true) {
		currentScale = Mathf.Sin (Time.time * scalePulseSpeed) * (scalePulseAmount) + initialScale;
	
		transform.localScale.x = currentScale;
		transform.localScale.y = currentScale;
		transform.localScale.z = currentScale;
	}
	
	//If
	if (shrinkAway == true) {
		shrinkScale = Mathf.Lerp(shrinkScale, 0.0, Time.deltaTime * shrinkRate);
		if(shrinkScale > 0.01) {
			gameObject.transform.localScale.x = shrinkScale;
			gameObject.transform.localScale.y = shrinkScale;
			gameObject.transform.localScale.z = shrinkScale;
		}
		else {
			//Once the object is below the specified threshold stop shrinking and destroy the object
			shrinkAway = false;
			Destroy(gameObject);	
			cursorManager.activeMarkers--;		
		}
	}
	
}