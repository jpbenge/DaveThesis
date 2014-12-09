
// objectRotater: Rotates the object to which it is attached.
// Useful for collectable items, etc.

function Update () 
{
	transform.Rotate (0, -90 * Time.deltaTime, 0);
}

function OnBecameVisible()
{
	enabled = true;	
}

function OnBecameInvisible()
{
	enabled = false;	
}