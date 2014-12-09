#pragma strict
var prefabteslaGrenade:GameObject;
var shootForce:float;
var spawnpos:Transform;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire5")) {

		var instanceteslaGrenade = Instantiate(prefabteslaGrenade, spawnpos.position, Quaternion.identity);
		instanceteslaGrenade.rigidbody.AddForce( transform.forward * shootForce );
	}
}