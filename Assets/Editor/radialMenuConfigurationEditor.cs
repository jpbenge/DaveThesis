/* Copyright (c) 2012 All Right Reserved, Marco Colombo

	Author: Marco Colombo
	Date: 06/2012
	Title: customRadialMenuConfigGui.cs
	Summary: Contains a class to create an editor window to configure a basic
			 radial menu in Unity 3D. The window contains sliders to modify
			 the value of:
			 
			 - Numeber of elements
			 - Radius of the elements
			 - Radius of the menu itself
			 
			 The window contains also a text which says what element was selected
			 the last time and a toggle which allows to pop up the menu
			 all over the screen, keeping the right mouse button pressed.
*/

using UnityEngine;
using UnityEditor;

public class radialMenuConfigurationEditor : EditorWindow {
	
		//VARIABLE DECLARATION
	
	//Values of the sliders used by the user to interacr directly in the scene on the values
	//of number of elements, element radius and menu radius
	float numElementsSliderValue;
	float elementRadiusSliderValue;
	float menuRadiusSliderValue;
	
	//A variable which represent an instance of the script used to build the menu
	static public buildMenu scriptInstance;
	
	//Declares a game object which contains the script used to build the menu
	static public GameObject radialMenuTemplate;
	
	//Contains the editor window
	static radialMenuConfigurationEditor window;
	
	//Add menu named "Configuration" to the "Radial Menu" menu
    [MenuItem ("Radial Menu/Build Menu")]
    static void ConfigurationWindow () {
		
        //Gets existing open window or if none, make a new one:
        window = (radialMenuConfigurationEditor)EditorWindow.GetWindow (typeof (radialMenuConfigurationEditor));
		window.title = "Radial Menu";
    }

		//BUILDS,SHOWS AND HANDLES THE EDITOR WINDOWS
	
    void OnGUI () {				
		//Creates the slider that changes the number of elements
		GUILayout.Label("Number of elements: " + buildMenu.numElements);
		numElementsSliderValue = GUILayout.HorizontalSlider(numElementsSliderValue, 0.0F, 50.0F);
		buildMenu.numElements = (int)numElementsSliderValue;
		
		//Creates the slider that changes the element radius
		GUILayout.Label("Element Radius: " + buildMenu.elementRadius);
		elementRadiusSliderValue = GUILayout.HorizontalSlider(elementRadiusSliderValue, 0.0F, 80.0F);
		buildMenu.elementRadius = (int)elementRadiusSliderValue;
		
		//Creates the slider that changes the menu radius
		GUILayout.Label("Menu Radius: " + buildMenu.menuRadius);
		menuRadiusSliderValue = GUILayout.HorizontalSlider(menuRadiusSliderValue, 0.0F, 200.0F);
		buildMenu.menuRadius = (int)menuRadiusSliderValue;
		
		//Creates and handles the toggle to enable/disable the menu moving with the mouse
		EditorGUILayout.BeginHorizontal();
		buildMenu.mouseEnabled = GUILayout.Toggle(buildMenu.mouseEnabled,"Enable Mouse");
		
		//Checks if the "Save" button is pressed
		if(GUILayout.Button("Save")){		
			//Declares and instantiate the main XML object
			RadialMenuXML xmlMenu = new RadialMenuXML();
			
			//Adds number of the elements, element radius and menu radius into the root of the xml file
			xmlMenu.numberOfElements = (int)numElementsSliderValue;
			xmlMenu.elementRadius = elementRadiusSliderValue;
			xmlMenu.menuRadius = menuRadiusSliderValue;
			
			//Creates the array of menu elements and puts it into the root of the xml file
			xmlMenu.Elements = new Element[(int)numElementsSliderValue];
			
			//Gets and instantiate a copy of the script that is running to build the menu
			radialMenuTemplate = GameObject.Find("RadialMenuTemplate");
			scriptInstance = radialMenuTemplate.GetComponent<buildMenu>();
			
			//For each element of the menu, gets its information (texture and postion of the rectangle)
			//from the script and writes them into the element branch of the xml file
			for(int i = 0; i < (int)numElementsSliderValue; i++){
				Element menuElement = new Element();
				
				menuElement.elementTexture = scriptInstance.getElementTexture(i);
				menuElement.elementPosition = scriptInstance.getElementPosition(i);
				
				xmlMenu.Elements[i] = menuElement;
			}

			//Writes the xml file on the disk in the specified path
			xmlMenu.Save("Assets/XmlMenu/xmlMenu.xml");
		}
		
		EditorGUILayout.EndHorizontal();
    }
}
