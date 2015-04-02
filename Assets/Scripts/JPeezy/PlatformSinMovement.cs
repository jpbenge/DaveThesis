using UnityEngine;
using System.Collections;

public class PlatformSinMovement : MonoBehaviour {
	public bool moving = true;
	public enum Axis{X, Y, Z};
	public Axis axis;
	public float startOffset = 0f;
	public float moveSpeed = 1f;
	public float moveDistance = 10f;
	private float sinVal = 0f;
	private float initialVal = 0f;
	// Use this for initialization
	void Start () {
		sinVal += startOffset;
		if (axis == Axis.X)
			initialVal = transform.localPosition.x;
		else if (axis == Axis.Y)
			initialVal = transform.localPosition.y;
		else
			initialVal = transform.localPosition.z;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (moving)
		{
			if (axis == Axis.X)
			{
				transform.localPosition = new Vector3(initialVal+(moveDistance*Mathf.Sin(sinVal)), transform.localPosition.y, transform.localPosition.z);
			}
			else if (axis == Axis.Y)
			{
				transform.localPosition = new Vector3(transform.localPosition.x, initialVal+(moveDistance*Mathf.Sin(sinVal)), transform.localPosition.z);
			}
			else 
				transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, initialVal+(moveDistance*Mathf.Sin(sinVal)));
			sinVal += (0.01f*moveSpeed);
		}
	}

	void OnTerminalActivate()
	{
		moving = true;
	}
	void OnTerminalDeactivate()
	{
		print("platform stop");
		moving = false;
	}
}
