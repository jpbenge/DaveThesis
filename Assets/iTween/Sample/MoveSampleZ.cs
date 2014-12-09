using UnityEngine;
using System.Collections;

public class MoveSampleZ : MonoBehaviour
{	
	void Start(){
		iTween.MoveBy(gameObject, iTween.Hash("z", 3, "easeType", "easeInOutExpo", "loopType", "pingPong", "delay", .1));
	}
}

