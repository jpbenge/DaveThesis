using UnityEngine;

public class ActivateTrigger : MonoBehaviour {
	public enum Mode {
		Trigger   = 0, // Just broadcast the action on to the target
		Replace   = 1, // replace target with source
		Activate  = 2, // Activate the target GameObject
		Enable    = 3, // Enable a component
		Animate   = 4, // Start animation on target
		Deactivate= 5, // Decativate target GameObject
		Terminal  = 6
	}

	/// The action to accomplish
	public Mode action = Mode.Terminal;

	/// The game object to affect. If none, the trigger work on this game object
	public Object target;
	public GameObject source;
	public int triggerCount = 1;///
	public bool repeatTrigger = false;
	private bool breached = false;
	
	void DoActivateTrigger () {
		triggerCount--;

		if (triggerCount == 0 || repeatTrigger) {
			Object currentTarget = target != null ? target : gameObject;
			Behaviour targetBehaviour = currentTarget as Behaviour;
			GameObject targetGameObject = currentTarget as GameObject;
			if (targetBehaviour != null)
				targetGameObject = targetBehaviour.gameObject;
		
			switch (action) {
				case Mode.Trigger:
					targetGameObject.BroadcastMessage ("DoActivateTrigger");
					break;
				case Mode.Replace:
					if (source != null) {
						Object.Instantiate (source, targetGameObject.transform.position, targetGameObject.transform.rotation);
						DestroyObject (targetGameObject);
					}
					break;
				case Mode.Activate:
					targetGameObject.active = true;
					break;
				case Mode.Enable:
					if (targetBehaviour != null)
						targetBehaviour.enabled = true;
					break;	
				case Mode.Animate:
					targetGameObject.animation.Play ();
					break;	
				case Mode.Deactivate:
					targetGameObject.active = false;
					break;
				case Mode.Terminal:
					breached = true;
					break;
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		print("eeeeee");
		DoActivateTrigger ();
	}
	void OnTriggerExit (Collider other) {
		breached = false;
	}
	void Update () {
		if (breached == true) 
		{
    	if (Input.GetButtonDown("Activate")) {
    		print("Activated");
    	}
		} 
	}
}