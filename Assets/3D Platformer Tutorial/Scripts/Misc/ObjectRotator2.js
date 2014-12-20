
// objectRotater: Rotates the object to which it is attached.
// Useful for collectable items, etc.
	enum Axis {X,Y,Z}
	public var axis : Axis = Axis.X;

function Update () 
{
	if (axis == Axis.X)
	{
		transform.Rotate (-90 * Time.deltaTime,0 , 0);
	}
	else if (axis == Axis.Y)
	{
		transform.Rotate (0, -90 * Time.deltaTime, 0);
	}
	else
	{
		transform.Rotate (0, 0, -90 * Time.deltaTime);
	}
}

function OnBecameVisible()
{
	enabled = true;	
}

function OnBecameInvisible()
{
	enabled = false;	
}