#pragma strict
var prefabEMPgrenade:GameObject;
var shootForce:float;
var spawnpos:Transform;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire1")) {

		var instanceEMPgrenade = Instantiate(prefabEMPgrenade, spawnpos.position, Quaternion.identity);
		instanceEMPgrenade.rigidbody.AddForce( transform.forward * shootForce );
	}
}