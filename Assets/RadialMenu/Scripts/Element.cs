/* Copyright (c) 2012 All Right Reserved, Marco Colombo

	Author: Marco Colombo
	Date: 06/2012
	Title: Element.cs
	Summary: Contains a class to define how a menu element is
			 represented inside an xml configuration file which 
			 is used to show the menu, once it has been built.
*/

using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public class Element

{

    [XmlAttribute("Element")]
	public string name;
	
    public string elementTexture;
	
	public Rect elementPosition;

}