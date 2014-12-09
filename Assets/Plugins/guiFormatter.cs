using UnityEngine;
using System.Collections;

public class guiFormatter : MonoBehaviour {

	public float lineLength = 400f; // Maximum width in pixels before it'll wrap
     
    private string[] words;
    private ArrayList wordsList;
    private string result = "";
    private Rect TextSize;
    private int numberOfLines = 1;

    private float orgWidth = 720;
    private float scaleF = 1;

	// Use this for initialization
	void Awake () {
		scaleF = Screen.width / 720.0f;
    	lineLength = lineLength * scaleF;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void cleanUp() // Easy to call from an external button
    {
        FormatString(guiText.text);
        print("cleaned");
    }

    void FormatString(string text){
     
        words = text.Split(" "[0]); //Split the string into seperate words
        result = "";
     
        for( var index = 0; index < words.Length; index++) {

           var word = words[index].Trim();
           if (index == 0) {
              result = words[0];
              guiText.text = result;
           }
     
           if (index > 0 ) {
     
             result += " " + word;
     
              guiText.text = result;
       }
     
       TextSize = guiText.GetScreenRect();
       
          if (TextSize.width > lineLength)
          {
              //remover
              result = result.Substring(0,result.Length-(word.Length));
           
              result += "\n" + word;
              numberOfLines += 1;
              guiText.text = result;
          }
        }
    }
}
