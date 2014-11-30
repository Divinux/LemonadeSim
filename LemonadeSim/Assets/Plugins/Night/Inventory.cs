using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour 
{
public GUISkin s1;

	public Texture2D vStockButton;
	public Texture2D vRecipe;
	public Texture2D vUpgrades;
	public Texture2D vNext;
	public Texture2D vBar;
	
	public Texture2D vBIce;
	public Texture2D vBSugar;
	public Texture2D vBCups;
	public Texture2D vBLemons;
	public Texture2D vBPrice;
	
	public Texture2D vBuy1;
	public Texture2D vBuyMax;
	
	public Texture2D vUp;
	public Texture2D vDn;
	//current screen0:stock,1:recipe,2upgrades
	public int vCurrent = 0;
	//day
	public int vDay = 1;
	/////stock
	public float vIce = 0;
	public float vSugar = 0;
	public int vCups = 0;
	public float vLemons = 0;
	public float vMoney = 0;
	//storage amount
	public int vStorage = 10;
	//recipe per cup amount
	public float vIcePer = 1F;
	public float vSugarPer = 1F;
	public float vLemonsPer = 1F;
	public float vPrice = 4F;
	
	public string vMoneyShort;
	
	//sounds
	public AudioClip vClick;
	public AudioClip vCash;
	
	void Awake () 
	{
	//PlayerPrefs.DeleteAll();
		int dd = PlayerPrefs.GetInt("day");
	if(dd > 1)
	{
	Load();
	}
	}
	
	
	void OnGUI()
	{
	GUI.skin = s1;
		DrawButtons();
		switch(vCurrent)
		{
			case 0:
			DrawStock();
			break;
			case 1:
			DrawRecipe();
			break;
			case 2:
			DrawUpgrades();
			break;

		}
	GUI.skin = null;	
	
	}
	
	void DrawButtons()
	{

		//
		GUI.DrawTexture(new Rect(10, 10, 200, 100), vStockButton, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(10, 10, 200, 100), " ", "label"))
		 {
		 Click();
		 vCurrent = 0;
		 }
		 //
		GUI.DrawTexture(new Rect(235, 10, 200, 100), vRecipe, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(235, 10, 200, 100), " ", "label"))
		 {
		 Click();
		 vCurrent = 1;
		 }
		 //
		GUI.DrawTexture(new Rect(460, 10, 200, 100), vUpgrades, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(460, 10, 200, 100), " ", "label"))
		 {
		 Click();
		vCurrent = 2;
		 }
		 //
		GUI.DrawTexture(new Rect(685, 10, 200, 100), vNext, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(685, 10, 200, 100), " ", "label"))
		 {
		 Click();
		 LoadGame();
		 
		 }
		 //
		GUI.DrawTexture(new Rect(10, 500, 880, 100), vBar, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(10, 500, 880, 100), " ", "label"))
		 {
		 //Debug.Log("next");
		 }
		 
		 	
		
		 MoneyShort();
		   
		   GUI.Label(new Rect(-80, 545, 200, 100), "<color=#171717>" + vIce + "</color>");
		 GUI.Label(new Rect(95, 545, 200, 100), "<color=#171717>" + vSugar + "</color>");
		  GUI.Label(new Rect( 460, 545, 200, 100), "<color=#171717>" + vCups + "</color>");
		   GUI.Label(new Rect(295, 545, 200, 100), "<color=#171717>" + vLemons + "</color>");
		   GUI.Label(new Rect(645, 545, 200, 100), "<color=#171717>" + vMoneyShort + "</color>");
		   
		   GUI.Label(new Rect(-82, 544, 200, 100), "<color=yellow>" + vIce + "</color>");
		 GUI.Label(new Rect(93, 544, 200, 100), "<color=yellow>" + vSugar + "</color>");
		  GUI.Label(new Rect( 458, 544, 200, 100), "<color=yellow>" + vCups + "</color>");
		   GUI.Label(new Rect(293, 544, 200, 100), "<color=yellow>" + vLemons + "</color>");
		   GUI.Label(new Rect(643, 544, 200, 100), "<color=yellow>" + vMoneyShort + "</color>");
		
	}
	
	void DrawStock()
	{
	//
		GUI.DrawTexture(new Rect(10, 150, 200, 100), vBIce, ScaleMode.StretchToFill, true, 0F);
		GUI.DrawTexture(new Rect(10, 260, 200, 60), vBuy1, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(10, 260, 200, 60), " ", "label"))
		 {
		 Cash();
			if(vMoney >= 1 && vIce < vStorage)
			{
				
				vMoney--;
				vIce++;
			}
		 }
		 GUI.DrawTexture(new Rect(10, 330, 200, 60), vBuyMax, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(10, 330, 200, 60), " ", "label"))
		 {
		 Cash();
		while(vMoney >= 1 && vIce < vStorage)
        {
		
            vMoney--;
				vIce++;
        }
		 }
		 //
		GUI.DrawTexture(new Rect(235, 150, 200, 100), vBSugar, ScaleMode.StretchToFill, true, 0F);
		GUI.DrawTexture(new Rect(235, 260, 200, 60), vBuy1, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(235, 260, 200, 60), " ", "label"))
		 {
		 Cash();
		 if(vMoney >= 1 && vSugar < vStorage)
			{
			
				vMoney--;
				vSugar++;
			}
		 }
		 GUI.DrawTexture(new Rect(235, 330, 200, 60), vBuyMax, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(235, 330, 200, 60), " ", "label"))
		 {
		 Cash();
		 while(vMoney >= 1 && vSugar < vStorage)
        {
            vMoney--;
				vSugar++;
        }
		 }
		 //
		GUI.DrawTexture(new Rect(685, 150, 200, 100), vBCups, ScaleMode.StretchToFill, true, 0F);
		GUI.DrawTexture(new Rect(685, 260, 200, 60), vBuy1, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(685, 260, 200, 60), " ", "label"))
		 {
		 Cash();
		 if(vMoney >= 1 && vCups < vStorage)
			{
			
				vMoney--;
				vCups++;
			}
		 }
		 GUI.DrawTexture(new Rect(685, 330, 200, 60), vBuyMax, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(685, 330, 200, 60), " ", "label"))
		 {
		 Cash();
		while(vMoney >= 1 && vCups < vStorage)
        {
            vMoney--;
				vCups++;
        }
		 }
		 //
		GUI.DrawTexture(new Rect(460, 150, 200, 100), vBLemons, ScaleMode.StretchToFill, true, 0F);
		GUI.DrawTexture(new Rect(460, 260, 200, 60), vBuy1, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(460, 260, 200, 60), " ", "label"))
		 {
		 Cash();
			 if(vMoney >= 1 && vLemons < vStorage)
			{
			
				vMoney--;
				vLemons++;
			}
		 }
		 GUI.DrawTexture(new Rect(460, 330, 200, 60), vBuyMax, ScaleMode.StretchToFill, true, 0F);
		 if (GUI.Button(new Rect(460, 330, 200, 60), " ", "label"))
		 {
		 Cash();
			while(vMoney >= 1 && vLemons < vStorage)
        {
            vMoney--;
				vLemons++;
        }
		 }
	}
	void DrawRecipe()
	{
	////
	GUI.DrawTexture(new Rect(10, 150, 200, 100), vBIce, ScaleMode.StretchToFill, true, 0F);
	GUI.DrawTexture(new Rect(10, 260, 200, 60), vUp, ScaleMode.StretchToFill, true, 0F);
	 if (GUI.Button(new Rect(10, 260, 200, 60), " ", "label"))
		 {
		 Click();
		if(vIcePer+1 <= vStorage)
		{
		 vIcePer++;
		 }
		 }
	 GUI.Label(new Rect(30, 325, 100, 100), "<color=#171717>" + vIcePer + "</color>");
	 GUI.Label(new Rect(28, 324, 100, 100), "<color=yellow>" + vIcePer + "</color>");
	 
	GUI.DrawTexture(new Rect(10, 380, 200, 60), vDn, ScaleMode.StretchToFill, true, 0F);
	if (GUI.Button(new Rect(10, 380, 200, 60), " ", "label"))
		 {
		 Click();
		 if(vIcePer >= 1)
		 {
		 vIcePer--;
		 }
		 }
	////
	GUI.DrawTexture(new Rect(235, 150, 200, 100), vBSugar, ScaleMode.StretchToFill, true, 0F);
	GUI.DrawTexture(new Rect(235, 260, 200, 60), vUp, ScaleMode.StretchToFill, true, 0F);
	 if (GUI.Button(new Rect(235, 260, 200, 60), " ", "label"))
		 {
		 Click();
		if(vSugarPer+1 <= vStorage)
		{
		 vSugarPer++;
		 }
		 }
	 GUI.Label(new Rect(255, 325, 100, 100), "<color=#171717>" + vSugarPer + "</color>");
	 GUI.Label(new Rect(253, 324, 100, 100), "<color=yellow>" + vSugarPer + "</color>");
	 
	GUI.DrawTexture(new Rect(235, 380, 200, 60), vDn, ScaleMode.StretchToFill, true, 0F);
	if (GUI.Button(new Rect(235, 380, 200, 60), " ", "label"))
		 {
		 Click();
		 if(vSugarPer >= 1)
		 {
		 vSugarPer--;
		 }
		 }
	////
	GUI.DrawTexture(new Rect(460, 150, 200, 100), vBLemons, ScaleMode.StretchToFill, true, 0F);
	GUI.DrawTexture(new Rect(460, 260, 200, 60), vUp, ScaleMode.StretchToFill, true, 0F);
	 if (GUI.Button(new Rect(460, 260, 200, 60), " ", "label"))
		 {
		 Click();
		if(vLemonsPer+1 <= vStorage)
		{
		 vLemonsPer++;
		 }
		 }
	 GUI.Label(new Rect(480, 325, 100, 100), "<color=#171717>" + vLemonsPer + "</color>");
	 GUI.Label(new Rect(478, 324, 100, 100), "<color=yellow>" + vLemonsPer + "</color>");
	 
	GUI.DrawTexture(new Rect(460, 380, 200, 60), vDn, ScaleMode.StretchToFill, true, 0F);
	if (GUI.Button(new Rect(460, 380, 200, 60), " ", "label"))
		 {
		 Click();
		 if(vLemonsPer >= 1)
		 {
		 vLemonsPer--;
		 }
		 }
		 ////
	GUI.DrawTexture(new Rect(685, 150, 200, 100), vBPrice, ScaleMode.StretchToFill, true, 0F);
	GUI.DrawTexture(new Rect(685, 260, 200, 60), vUp, ScaleMode.StretchToFill, true, 0F);
	 if (GUI.Button(new Rect(685, 260, 200, 60), " ", "label"))
		 {
		 Click();
		if(vPrice+0.1F <= 99)
		{
		 vPrice += 0.1F;
		 }
		 }
	 GUI.Label(new Rect(705, 325, 100, 100), "<color=#171717>" + vPrice.ToString("F1") + "</color>");
	 GUI.Label(new Rect(703, 324, 100, 100), "<color=yellow>" + vPrice.ToString("F1") + "</color>");
	 
	GUI.DrawTexture(new Rect(685, 380, 200, 60), vDn, ScaleMode.StretchToFill, true, 0F);
	if (GUI.Button(new Rect(685, 380, 200, 60), " ", "label"))
		 {
		 Click();
		 if(vPrice >= 0.2F)
		 {
		 vPrice -= 0.1F;
		 }
		 }
	}
	void DrawUpgrades()
	{
	
	}
	
	void MoneyShort()
	{
		if(vMoney >= 1000000)
		{
			float z1 = vMoney/1000000;
			vMoneyShort = z1.ToString("F1") + " mio";
		}
		else if(vMoney >= 1000)
		{
			float z2 = vMoney/1000;
			vMoneyShort = z2.ToString("F1") + " k";
		}
		else
		{
			vMoneyShort = vMoney.ToString("F2") + "";
		}
	}
	
	void LoadGame()
	{
	Save();
	
	PlayerPrefs.SetInt("toload",3);
	Application.LoadLevel(1);
	}
	
	void Save()
	{
	PlayerPrefs.SetInt("day", vDay);
	
	PlayerPrefs.SetFloat("price", vPrice);
	
	PlayerPrefs.SetFloat("ice", vIce);
	PlayerPrefs.SetFloat("sugar", vSugar);
	PlayerPrefs.SetInt("cups", vCups);
	PlayerPrefs.SetFloat("lemons", vLemons);
	PlayerPrefs.SetFloat("money", vMoney);
	
	PlayerPrefs.SetFloat("iceper", vIcePer);
	PlayerPrefs.SetFloat("sugarper", vSugarPer);
	PlayerPrefs.SetFloat("lemonsper", vLemonsPer);
	}
	void Load()
	{
	vPrice =  PlayerPrefs.GetFloat("price");
	vDay = PlayerPrefs.GetInt("day");
	vIce = PlayerPrefs.GetFloat("ice");
	vSugar=PlayerPrefs.GetFloat("sugar");
	vCups=PlayerPrefs.GetInt("cups");
	vLemons=PlayerPrefs.GetFloat("lemons");
	vMoney=PlayerPrefs.GetFloat("money");
	
	vIcePer=PlayerPrefs.GetFloat("iceper");
	vSugarPer=PlayerPrefs.GetFloat("sugarper");
	vLemonsPer=PlayerPrefs.GetFloat("lemonsper");
	}
	
	public void Click()
	{
	 audio.clip = vClick;
	audio.Play();
	}
	public void Cash()
	{
	 audio.clip = vCash;
	audio.Play();
	}
}
