#pragma strict
var speed : float = 6.0;
var jumpSpeed : float = 8.0;
var gravity : float = 20.0;
var upwardSpeed : float = 5.0;  
var inTriggerZone : boolean = false;
var controller : CharacterController;
var spunky : float = 20.0;
private var moveDirection : Vector3 = Vector3.zero;

function Start () {
	controller = GameObject.Find("Player").GetComponent(CharacterController);
	inTriggerZone = false;
}

function Update () {
	if (inTriggerZone)
	{
		controller.Move(Vector3.up *spunky* Time.deltaTime);
	}
	
	
}
 
function OnTriggerEnter (other : Collider) {
	Debug.Log("driz");
	inTriggerZone = true;
}

function OnTriggerExit (other : Collider) {
	Debug.Log("djiz");
	inTriggerZone = false;
}

 
function OnTriggerExit(){
inTriggerZone = false;
}