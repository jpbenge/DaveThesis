/* Copyright (c) 2012 All Right Reserved, Marco Colombo

	Author: Marco Colombo
	Date: 06/2012
	Title: buildMenu.cs
	Summary: Contains a class to build a basic radial menu in Unity 3D.
			 To test the menu, play the building scene and use the Radial Menu editor
			 window to configure it.
			 The radial menu pops up as the RMB (right mouse button)
			 is pressed (if the option in the configuration window of the GUI is checked);
			 Moving the mouse over the element and releasing RMB will make the selection.
*/

using UnityEngine;
using System.Collections;

public class buildMenu : MonoBehaviour{
	
		//VARIABLE DECLARATION
	
	//Defines the number of the elements the user wants ito have in its menu
	static public int numElements;
	
	//Defines the previous number of elements, if changes, the array should be re-created and the menu has to be redrawn
	static public int oldNumElements;
	
	//Array of textures in which will be putted the custom images of the elements of the menu
	public Texture[] textures;
	
	//Array of rectangles on which will be projected the custom images of the elements of the menu
	//These rectangles are like containers of the images
	private Rect[] radialMenuButtons;

	//Enables/Disables the display of the menu onscreen	
	private bool showMenuSelection;
	
	//Enables/Disables the display of the menu onscreen	
	static public bool mouseEnabled;

	//Enables the display of the menu just on the coordinates of the mouse click
	//and prevents to see the menu dragged around with the mouse cursor
	static private bool showedMenuSelectionOnce;
	
	//Customizable value of the radius of one element of the menu
	static public float elementRadius;
	
	//Customizable value of the radius of the menu itself
	static public float menuRadius;
	
	//Coordinates of the center of the radial menu
	static private Vector3 radialMenuPosition;
	
	//The selection made by the user, selecting an element of the menu
	static public int selection;
	
	//Represets the 3d text to show the selection made by the user
	public TextMesh selectionText;
	
		// FIRST INTIALIZATION
	
	void Start () {
		//Defines the very first selection
		selection = -1;

		//Initializes the variables that enables/disable the display of the menu
		showMenuSelection = true;
		showedMenuSelectionOnce = false;
		
		//Creates the arrays of both textures and "containers" of textures
		textures = new Texture[numElements];
		radialMenuButtons = new Rect[numElements];
		
		//Initializes (and checks) the array of textures
		for(var i = 0; i < numElements; i++){
			textures[i] = (Texture) Resources.Load("Images/MenuElement");
			if (!textures[i]) {
            	Debug.LogError("Assign a texture image in the inspector.");
            	return;
        	}	
		}
	}
	
		// THIS CODE IS LOOPED DURING EXECUTION
	
	void Update () {	
		//Checks if RMB is released
   		if(Input.GetMouseButtonUp(1) && mouseEnabled)
		{   
			//Makes the menu disappear
			showMenuSelection = false;
			showedMenuSelectionOnce = true;
    	}
		else 
			//Checks if RMB is pressed
        	if(Input.GetMouseButtonDown(1) && mouseEnabled)
			{   
				//Makes the menu appear
				showMenuSelection = true;
				showedMenuSelectionOnce = false;
    		}
		
		// SHOWING THE RADIAL MENU
		
	}
	
	//Returns the texture name (string) of the "i" element
	public string getElementTexture (int i){
		return textures[i].name;
	}
	
	//Returns the rectangle of the "i" element 
	public Rect getElementPosition (int i){
		return radialMenuButtons[i];
	}
	
		// SHOWING THE RADIAL MENU
	
	void OnGUI() {
		//Creates the arrays of both textures and "containers" of textures
		if(numElements != oldNumElements)
		{ 
			//Change the new number of elements to the actual one
			oldNumElements = numElements;
			selection = -1;
			
			textures = new Texture[numElements];
			radialMenuButtons = new Rect[numElements];
		
			//Checks and initializes the array of textures
			for(var i = 0; i < buildMenu.numElements; i++){
				textures[i] = (Texture) Resources.Load("Images/MenuElement");
				if (!textures[i]) {
            		Debug.LogError("Assign a texture image in the inspector.");
            		return;
        		}
			}
		}
		
		//If the mouse is not enabled, allow the menu to be shown anyway
		if(!mouseEnabled){   
			showMenuSelection = true;
			showedMenuSelectionOnce = false;		
    	}
		
		//Checks if it is allowed to display the menu
		if(showMenuSelection)
		{  	
			//Checks if the menu elements have to be drawn just once (in the position desired, to avoid the "dragging" effect)
			if(!showedMenuSelectionOnce){
				//Checks where to draw the menu
				if(!mouseEnabled)
					//Show the menu in the center of the screen
					radialMenuPosition = new Vector3((Screen.width/2), (Screen.height/2), 0);
				else{   
					//Take the mouse position just this time
 					radialMenuPosition = Event.current.mousePosition;
    			}
			}
			
			//Checks if the click + the offset of the custom menu goes off the screen
			//and if so, sets the position of the menu to attached to the relative edge
			if((radialMenuPosition.x + menuRadius + elementRadius) > Screen.width)
				radialMenuPosition.x = (Screen.width - menuRadius - elementRadius);
					
			if((radialMenuPosition.x - menuRadius - elementRadius) < 0)
				radialMenuPosition.x = (0 + menuRadius + elementRadius);
					
			if((radialMenuPosition.y + menuRadius + elementRadius) > Screen.height)
				radialMenuPosition.y = (Screen.height - menuRadius - elementRadius);
					
			if((radialMenuPosition.y - menuRadius - elementRadius) < 0)
				radialMenuPosition.y = (0 + menuRadius + elementRadius);
			
			//Defines the initial X position (center coordinates - offset)
			float initialX = radialMenuPosition.x-elementRadius;
			
			//Defines the initial Y position (center coordinates - offset)
			float initialY = radialMenuPosition.y-elementRadius;
			
			//Defines the angle of every element from the center of the menu
			float actualAngle = 0F;
			
			//Defines the offset that has to increase, depending on the number of the elements of the menu
			float angleOffset = 360F / numElements;
			
			//Defines a varibale that checks if something is actually selected or not
			bool selected = false;
			
			//Loop on every menu element until they are over
			for(var i = 0; i < numElements; i++)
			{  
				//Creates a new rectangle for this element and store its information in the proper array (degrees have an offset of 90° degrees to have a proper "star" alignement)
				radialMenuButtons[i] = new Rect(initialX + menuRadius * Mathf.Cos((actualAngle+90)* Mathf.Deg2Rad), initialY - menuRadius * Mathf.Sin((actualAngle+90)* Mathf.Deg2Rad), elementRadius*2, elementRadius*2);

				//Draws the menu element on screen
				GUI.DrawTexture(radialMenuButtons[i], textures[i]);
				
				//Increase the angle offset (to have the angle of the next element)
				actualAngle += angleOffset;
			}
			
			//Checks if RMB is released
			if(Input.GetMouseButtonUp(1))
			{   
				//Loop on every menu element until one element is selected or they are over
				for(var i = 0; i < numElements && !selected; i++)
					//Checks if the element menu is selected
					if (radialMenuButtons[i].Contains(Event.current.mousePosition)){
						//Saves the selection (the element number, not the index) in the proper varaible
						selection = i + 1;
						
						//Now something is selected
						selected = true;
					
						//Shows the selection on screen
						selectionText.text = "Last selection: " + buildMenu.selection.ToString();
					}
				//Checks if no element of the menu was selected
				if(!selected){
					//Saves a standard value (-1) to memorize that nothing was selected
					selection = -1;
					
					//Shows the selection on screen
					selectionText.text = "Last selection: None";
				}
    		}
			
			//Memorizes that the menu has been displayed in the proper position
			//and does not have to be shown in another position (avoiding the "dragging" effect)
			showedMenuSelectionOnce = true;
    	}
    }
}
