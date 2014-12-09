#pragma strict
var prefabH20mine:GameObject;
var shootForce:float;
var spawnpos:Transform;

function Start () {
}

function Update () 
{
	if (Input.GetButtonDown("Fire4")) {

		var instanceH20mine = Instantiate(prefabH20mine, spawnpos.position, Quaternion.identity);
		instanceH20mine.rigidbody.AddForce( transform.forward * shootForce );
	}
}