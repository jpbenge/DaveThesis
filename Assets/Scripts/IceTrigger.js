#pragma strict
var speed: float = 6.0;
var jumpSpeed: float = 8.0;
var inTriggerZone : boolean = false;
var friction: float = 1.0; // 0 means no friction;
private var curVel = Vector3.zero;
private var velY: float = 0;
private var controller: CharacterController;
function Start () {
	controller = GameObject.Find("Player").GetComponent(CharacterController);
	inTriggerZone = false;
}

function Update () {
	if (inTriggerZone)
	{
	
	}
}
/*
// get the CharacterController only the first time:
  if (!character) character = GameObject.Find("Player").GetComponent(CharacterController);
  
  // get the direction from the controls:
  var dir = Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
  // calculate the desired velocity:
  var vel = transform.TransformDirection(dir) * speed;

  // here's where the magic happens:
  curVel = Vector3.Lerp(curVel, vel, 5 * friction * friction * Time.deltaTime);

  // apply gravity and jump after the friction!
  if (character.isGrounded){
    velY = 0;
    if (Input.GetButtonDown("Jump")){
      velY = jumpSpeed;
    }
    //velY -= gravity * Time.deltaTime;
  }
  curVel.y = velY;
  character.Move(curVel * Time.deltaTime);
  
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
*/