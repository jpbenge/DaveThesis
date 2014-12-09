#pragma strict
var prefabIcegrenade:GameObject;
var shootForce:float;
var spawnpos:Transform;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Punch")) {

		var instanceIcegrenade = Instantiate(prefabIcegrenade, spawnpos.position, Quaternion.identity);
		instanceIcegrenade.rigidbody.AddForce( transform.forward * shootForce );
	}
}