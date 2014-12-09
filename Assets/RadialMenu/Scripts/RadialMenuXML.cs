/* Copyright (c) 2012 All Right Reserved, Marco Colombo

	Author: Marco Colombo
	Date: 06/2012
	Title: RadialMenuXML.cs
	Summary: Contains a class to define how the radial menu is
			 represented inside an xml configuration file which 
			 is used to show the menu, once it has been built.
			 This class contains also methods to access the xml
			 in both read (catching "file not found" exception)
			 and write mode.
*/

using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

 

[XmlRoot("RadialMenu")]
public class RadialMenuXML

{	
	public int numberOfElements;

	public float menuRadius;
		
	public float elementRadius;
	

    [XmlArray("Elements"),XmlArrayItem("Element")]

    public Element[] Elements;

	
	
    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(RadialMenuXML));
        using(var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public static RadialMenuXML Load(string path)
    {
        var serializer = new XmlSerializer(typeof(RadialMenuXML));
        try
		{
			using(var stream = new FileStream(path, FileMode.Open))
        	{
            	return serializer.Deserialize(stream) as RadialMenuXML;
        	}
		}			
		catch (FileNotFoundException ex)
		{
			ex.ToString();				
	    	//If the xml configuration file is not present in the right folder, tells the user to create and save a new menu
			Debug.LogError("There is no XML file to build the menu. Please create and save a menu from Radial Menu -> Build Menu editor window.");
			return null;
		}
    }
}