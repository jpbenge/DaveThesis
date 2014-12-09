    var lineLength = 400; // Maximum width in pixels before it'll wrap
     
    private var words : String[];
    private var wordsList : ArrayList;
    private var result = "";
    private var TextSize: Rect;
    private var numberOfLines = 1;
    
    private var orgWidth :float = 720;
    private var scaleF : float = 1;
    
    function Start()
    {
    	scaleF = Screen.width / 720.0f;
    	lineLength = lineLength * scaleF;
    }
    
    function cleanUp() // Easy to call from an external button
    {
        FormatString(guiText.text);
    }
     
    function FormatString( text : String ){
     
        words = text.Split(" "[0]); //Split the string into seperate words
        result = "";
     
        for( var index = 0; index < words.length; index++) {

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
    function Format( text : String ) {
        
        var curText;
        words = text.Split(" "[0]); //Split the string into seperate words
        result = "";
     
        for( var index = 0; index < words.length; index++) {
     
           var word = words[index].Trim();
           if (index == 0) {
              result = words[0];
              //curText = result;
           }
     
           if (index > 0 ) {
     
             result += " " + word;
     
              //curText = result;
            Debug.Log(result);
       }
       //result = curText;
       Debug.Log(result);
       TextSize = new Rect(0,0,200,100);
          if (TextSize.width > lineLength)
          {
              //remover
              result = result.Substring(0,result.Length-(word.Length));
           
              result += "\n" + word;
              numberOfLines += 1;
              Debug.Log("The Result is ::::: "+result);
              return result;
          }
          else
          {
            return result;
          }
        }
    }