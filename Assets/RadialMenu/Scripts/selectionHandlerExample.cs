/* Copyright (c) 2012 All Right Reserved, Marco Colombo

	Author: Marco Colombo
	Date: 06/2012
	Title: selectionHandlerExample.cs
	Summary: Contains a class to test the menu in the proper test map.
			 It catches the selection made by the user and acts differently
			 over every selection.
			 Use this file as a reference to implement a specific.
*/

using UnityEngine;
using System.Collections;

public class selectionHandlerExample : MonoBehaviour {
	
	//Represents the object that changes at any selection
	public GameObject objectToChange;
	
	//Represents the light to turn ON/OFF at selection 2
	public Light lightToggle;
	
	//Represents a list of materials to switch on selection 1 (and its index)
	Material otherMaterial;
	private int materialIndex;
	
	// Use this for initialization
	void Start () {
		materialIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Checks if RMB is released
   		if(Input.GetMouseButtonUp(1))
		{   
			//Checks what selection was made by the user 
			//
			//THE CODE OF EACH SELECTION, ONCE THE MENU IS DONE, HAS TO GO HERE
			//
			switch (showRadialMenu.getSelection()){
				//Nothing is selected
				case -1: //Do nothing
						 break;
				
				//Changes the material of the sphere
				case 1: if(materialIndex == 0){
							otherMaterial = (Material)Resources.Load("Materials/WoodMaterial", typeof(Material));
							materialIndex++;
						}
						else
							if(materialIndex == 1){
								otherMaterial = (Material)Resources.Load("Materials/MarbleMaterial", typeof(Material));
								materialIndex++;
							}
							else
								if(materialIndex == 2){
								otherMaterial = (Material)Resources.Load("Materials/AtlasMaterial", typeof(Material));
								materialIndex= 0;
							}
				
						objectToChange.renderer.material = otherMaterial;
						break;
				
				//Tunrs on/off the light around the sphere
				case 2: if(lightToggle.enabled) 
							lightToggle.enabled = false;
						else
							lightToggle.enabled = true;
						break;
				
				//Scales the sphere UP and DOWN
				case 3: objectToChange.animation.Play("Scale");
						break;
				
				//Rotates the sphere
				case 4: objectToChange.animation.Play("Rotate");
						break;
				
				//Pushes the sphere far and let it come back
				case 5: objectToChange.animation.Play("Push");
						break;
				
				default: //Do nothing
						 break;
			}	
    	}
	}
}
