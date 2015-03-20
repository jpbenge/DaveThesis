using UnityEngine;
using System.Collections;

public class FloorState : MonoBehaviour {

	public enum FState{Normal, Water, Ice, Oil, Scorched, Friction}
	public FState floorState;

	public Material[] floorMats;
	public PhysicMaterial[] physicsMats;
	public AudioClip[] sounds;
	// Use this for initialization
	void Start () {
		GoToState((int)floorState);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GoToState(int state) {
		floorState = (FState)state;
		renderer.material = floorMats[(int)floorState];
		collider.material = physicsMats[(int)floorState];
	}

	void Extinguish()
	{
		if (floorState == FState.Ice || floorState == FState.Oil)
		{
			return;
		}
		else
		{
			GoToWater();
		}
	}

	void GoToWater()
	{
		floorState = FState.Water;
		renderer.material = floorMats[(int)floorState];
		collider.material = physicsMats[(int)floorState];
		if (sounds[(int)floorState] != null)
		{
			AudioSource.PlayClipAtPoint(sounds[(int)floorState], transform.position);
		}
	}

	void Freeze()
	{
		if (floorState == FState.Oil)
		{
			return;
		}
		else
		{
			GoToIce();
		}
	}

	void GoToIce()
	{
		floorState = FState.Ice;
		renderer.material = floorMats[(int)floorState];
		collider.material = physicsMats[(int)floorState];
		if (sounds[(int)floorState] != null)
		{
			AudioSource.PlayClipAtPoint(sounds[(int)floorState], transform.position);
		}
	}

	void OnFire()
	{
		if (floorState == FState.Water)
		{
			GoToNormal();
		}
		else if (floorState == FState.Ice)
		{
			GoToWater();
		}
		else
		{
			GoToScorched();
		}
	}

	void GoToScorched()
	{
		floorState = FState.Scorched;
		renderer.material = floorMats[(int)floorState];
		collider.material = physicsMats[(int)floorState];
		if (sounds[(int)floorState] != null)
		{
			AudioSource.PlayClipAtPoint(sounds[(int)floorState], transform.position);
		}
	}

	void OnOil()
	{
		if (floorState == FState.Ice || floorState == FState.Water)
		{
			return;
		}
		else
		{
			GoToOil();
		}
	}

	void GoToOil()
	{
		floorState = FState.Oil;
		renderer.material = floorMats[(int)floorState];
		collider.material = physicsMats[(int)floorState];
		if (sounds[(int)floorState] != null)
		{
			AudioSource.PlayClipAtPoint(sounds[(int)floorState], transform.position);
		}
	}

	void OnFriction()
	{
		GoToFriction();
	}

	void GoToFriction()
	{
		floorState = FState.Friction;
		renderer.material = floorMats[(int)floorState];
		collider.material = physicsMats[(int)floorState];
		if (sounds[(int)floorState] != null)
		{
			AudioSource.PlayClipAtPoint(sounds[(int)floorState], transform.position);
		}
	}

	void GoToNormal()
	{
		floorState = FState.Normal;
		renderer.material = floorMats[(int)floorState];
		collider.material = physicsMats[(int)floorState];
		if (sounds[(int)floorState] != null)
		{
			AudioSource.PlayClipAtPoint(sounds[(int)floorState], transform.position);
		}
	}
}
