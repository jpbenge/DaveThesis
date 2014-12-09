using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour
{
	public Vector3 force = new Vector3(0, 10, 0);
	public bool relative = false;
	
	Vector3 _overwrite = Vector3.zero;
	
	void OnTriggerEnter(Collider other)
	{
		if (other.isTrigger || !other.rigidbody)
			return;
		
		_overwrite = -other.rigidbody.velocity;
		if (force.x < Mathf.Epsilon)
			_overwrite.x = 0F;
		if (force.y < Mathf.Epsilon)
			_overwrite.y = 0F;
		if (force.z < Mathf.Epsilon)
			_overwrite.z = 0F;
		
		if (relative)
			other.rigidbody.AddRelativeForce(force-other.rigidbody.velocity, ForceMode.VelocityChange);
		else
			other.rigidbody.AddForce(force-other.rigidbody.velocity, ForceMode.VelocityChange);
	}
}
