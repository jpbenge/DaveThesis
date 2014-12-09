#pragma strict
var prefabsmokegrenade:GameObject;
var shootForce:float;
var spawnpos:Transform;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire3")) {

		var instancesmokegrenade = Instantiate(prefabsmokegrenade, spawnpos.position, Quaternion.identity);
		instancesmokegrenade.rigidbody.AddForce( transform.forward * shootForce );
	}
}