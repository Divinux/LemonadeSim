using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
//public Texture2D vBg;
public Texture2D vStartButton;
public Texture2D vResetButton;

	
	void OnGUI () 
	{
	//
		GUI.DrawTexture(new Rect(10, 10, 200, 60), vStartButton, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(10, 10, 200, 60), " ", "label"))
		 {
			PlayerPrefs.SetInt("toload",2);
			Application.LoadLevel(1);
			audio.Play();
		 }
		 //
		GUI.DrawTexture(new Rect(10, 120, 200, 60), vResetButton, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(10, 120, 200, 60), " ", "label"))
		 {
			audio.Play();
			PlayerPrefs.DeleteAll();
			PlayerPrefs.SetFloat("price", 4);
			PlayerPrefs.SetFloat("money", 1000);
			PlayerPrefs.SetInt("day", 1);
			
			PlayerPrefs.SetFloat("iceper", 1);
	PlayerPrefs.SetFloat("sugarper", 1);
	PlayerPrefs.SetFloat("lemonsper", 1);
		 }
	}
}
