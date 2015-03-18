/* Copyright (c) 2012 All Right Reserved, Marco Colombo

	Author: Marco Colombo
	Date: 06/2012
	Title: showRadialMenu.cs
	Summary: Contains a class to show a basic radial menu in Unity 3D.
			 The radial menu pops up as the RMB (right mouse button)
			 is pressed (if the option in the configuration window of the GUI is checked);
			 Moving the mouse over the element and releasing RMB will make the selection.
*/

using UnityEngine;
using System.Collections;

public class showRadialMenu : MonoBehaviour{
	
		//VARIABLE DECLARATION
	
	//Defines the number of the elements the user wants ito have in its menu
	private int numElements;
	
	//Array of textures in which will be putted the custom images of the elements of the menu
	private Texture[] textures;
	
	//Array of rectangles on which will be projected the custom images of the elements of the menu
	//These rectangles are like containers of the images
	private Rect[] radialMenuButtons;

	//Enables/Disables the display of the menu onscreen	
	private bool showMenuSelection;

	//Enables the display of the menu just on the coordinates of the mouse click
	//and prevents to see the menu dragged around with the mouse cursor
	private bool showedMenuSelectionOnce;
	
	//Customizable value of the radius of one element of the menu
	private float elementRadius;
	
	//Customizable value of the radius of the menu itself
	private float menuRadius;
	
	//Coordinates of the center of the radial menu
	private Vector3 radialMenuPosition;
	
	//The selection made by the user, selecting an element of the menu
	static private int selection;
	
	static private int tempSelection;

	//Represent the xml file containing the menu specifications
	RadialMenuXML xmlMenu;
	
		// FIRST INTIALIZATION
	
	private Vector2 stickPos;
	public float widthMult = 5.6f;
	public float heightMult = 2.4f;
	private bool weaponButtonUp;

	void Start () {
		//Defines the very first selection
		selection = -1;
		tempSelection = -1;

		//Reads the xml file containing the menu specifications
		xmlMenu = RadialMenuXML.Load("Assets/XmlMenu/xmlMenu.xml");
		
		if(xmlMenu != null){
			//Initializes the number of the elements and both element and menu radius
			numElements = xmlMenu.numberOfElements;
			elementRadius = xmlMenu.elementRadius;
			menuRadius = xmlMenu.menuRadius;
		
			//Creates the arrays of both textures and "containers" of textures
			textures = new Texture[numElements];
			radialMenuButtons = new Rect[numElements];
		
			//Assign every texture and rectangle (read from the xml file)
			//to the proper element of the menu
			for(int i = 0; i < numElements; i++){
        		textures[i] = (Texture) Resources.Load("ElementTextures/" + xmlMenu.Elements[i].elementTexture);
				if (!textures[i]) {
            		Debug.LogError("The texture file \"" + xmlMenu.Elements[i].elementTexture + "\" is missing in the folder \"ElementTextures\"! Please, place it inside the folder.");
					xmlMenu = null;
            		return;
        		}
				radialMenuButtons[i] = xmlMenu.Elements[i].elementPosition;
			}	
			
			//Initializes the variables that enables/disable the display of the menu
			showMenuSelection = false;
			showedMenuSelectionOnce = false;
		}
		else
			//If the xml configuration file is not present in the right folder, tells the user to create and save a new menu
			Debug.LogError("There is no XML file to build the menu. Please create and save a menu from Radial Menu -> Build Menu editor window.");
	}
	
		// THIS CODE IS LOOPED DURING EXECUTION
	
	void Update () {
		
		//Checks if RMB is released
   		if(Input.GetMouseButtonUp(1) || Input.GetButtonUp("WeaponSelect"))
		{   
			//Makes the menu disappear
			//showMenuSelection = false;
			showedMenuSelectionOnce = true;
			weaponButtonUp = true;
    	} //Checks if RMB is pressed
		else if(Input.GetMouseButtonDown(1) || Input.GetButtonDown("WeaponSelect"))
		{   
			//Makes the menu appear
			showMenuSelection = true;
			showedMenuSelectionOnce = false;
    	}
	}

	//Returns the texture name (string) of the "i" element
	public string getElementTexture (int i){
		return textures[i].name;
	}
	
	//Returns the rectangle of the "i" element 
	public Rect getElementPosition (int i){
		return radialMenuButtons[i];
	}
	
	//Returns the rectangle of the "i" element 
	static public int getSelection (){
		return selection;
	}

	static public int getTempSelection (){
		return tempSelection;
	}
	
		// SHOWING THE RADIAL MENU
	
	void OnGUI() {
		float stickX = (Screen.width / 2f) + (Input.GetAxis("RightX")*(Screen.width / widthMult));
		float stickY = (Screen.height / 2f) - (Input.GetAxis("RightY")*(Screen.height / heightMult));
		stickPos = new Vector2(stickX, stickY);
		//Checks every time if the configuration file is present
		if(xmlMenu != null){
			//Checks if it is allowed to display the menu
			if(showMenuSelection)
			{  	
				//Checks if the menu elements have to be drawn just once (in the position desired, to avoid the "dragging" effect)
				if(!showedMenuSelectionOnce){
 					//radialMenuPosition = Event.current.mousePosition;
 					radialMenuPosition = new Vector2(Screen.width / 2f, Screen.height / 2f);
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
					
					GUI.DrawTexture(radialMenuButtons[i], textures[i]);	
					
					//Increase the angle offset (to have the angle of the next element)
					actualAngle += angleOffset;
				}
				for(var s = 0; s < numElements; s++)
				{
					if (radialMenuButtons[s].Contains(Event.current.mousePosition) || radialMenuButtons[s].Contains(stickPos)){
						//Saves the selection (the element number, not the index) in the proper varaible
						tempSelection = s;
						Rect bigRect = new Rect(radialMenuButtons[s].x - ((1f/3f)*radialMenuButtons[s].width)
							,radialMenuButtons[s].y - ((1f/3f)*radialMenuButtons[s].height)
							,radialMenuButtons[s].width*1.5f
							,radialMenuButtons[s].height*1.5f);
						GUI.DrawTexture(bigRect, textures[s]);
					}

				}
				//Checks if RMB is released
				if(weaponButtonUp)
				{   

					//Loop on every menu element until one element is selected or they are over
					for(var i = 0; i < numElements && !selected; i++)
					{
						//Checks if the element menu is selected
						if (radialMenuButtons[i].Contains(Event.current.mousePosition) || radialMenuButtons[i].Contains(stickPos))
						{
							//Saves the selection (the element number, not the index) in the proper varaible
							selection = i + 1;
							//Now something is selected
							selected = true;
						}
					}
					//Checks if no element of the menu was selected
					if(!selected)
					{
						//Saves a standard value (-1) to memorize that nothing was selected
						selection = -1;
					}
					weaponButtonUp = false;
					showMenuSelection = false;
    			}
			
				//Memorizes that the menu has been displayed in the proper position
				//and does not have to be shown in another position (avoiding the "dragging" effect)
				showedMenuSelectionOnce = true;
    		}
		}
    }
}
