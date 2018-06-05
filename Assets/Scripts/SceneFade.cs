using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFade : MonoBehaviour {

    public Texture2D fadeOutTexture; // the texture that will overlay the screen. This can be black or a graphic
    public float fadeSpeed = 0.8f; //fade speed

    private int drawDepth = -1000; //the texture's order in the draw hierarchy: low number = top
    private float alpha = 1.0f; //the texture's alpha value between 0 and 1 
    private int fadeDir = -1; //the direction to fade: in = -1, out = 1

	private void OnGUI()
	{
        //fade out/in the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        //force (clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
        alpha = Mathf.Clamp01(alpha);

        //set color of GUI (texture). All colour values will remain the same & the Alpha is set to the alpha var
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha); //set the alpha value
        GUI.depth = drawDepth; //make the black texture render on top
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture); //draw the texture to fit the entire screen area
     }

    //sets fadeDir to the direction parameter making the scene fade in if -1 and out if 1
    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed); //return the fadeSpeed variable to easily time load times
    }

    //OnLevelWasLoaded is called when level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes
    private void OnLevelWasLoaded()
	{
        alpha = 1;
        BeginFade(-1);
	}
}
