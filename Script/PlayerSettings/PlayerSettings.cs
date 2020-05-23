using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{

    const string LEVEL = "level";

	public static void setlevel (int numb){
		PlayerPrefs.SetInt(LEVEL,numb);
	}
	public static int getLevel() {
		return PlayerPrefs.GetInt(LEVEL);
	}

	const string ACTIVE_LEVEL = "active level";

	public static void setActivelevel (int numb){
		PlayerPrefs.SetInt(ACTIVE_LEVEL,numb);
	}
	public static int getActiveLevel() {
		return PlayerPrefs.GetInt(ACTIVE_LEVEL);
	}



    const string IS_GAME_OPEN = "is game open";

    public static void setIsGameOpen (int numb){
		PlayerPrefs.SetInt(IS_GAME_OPEN,numb);
	}
	public static int getIsGameOpen() {
		return PlayerPrefs.GetInt(IS_GAME_OPEN);
	}



	const string MAIN_GOLD = "main gold";

    public static void setMainGold (int numb){
		PlayerPrefs.SetInt(MAIN_GOLD,numb);
	}
	public static int getMainGold() {
		return PlayerPrefs.GetInt(MAIN_GOLD);
	}

	//0 Not Buy --- 1 : Buy ---- 2 : Eguip
	readonly static string [] BALLS= {"ball 1","ball 2","ball 3","ball 4","ball 5","ball 6","ball 7","ball 8","ball 9",
									  "ball 10","ball 11","ball 12","ball 13","ball 14","ball 15","ball 16","ball 17","ball 18",
									  "ball 19","ball 20","ball 21","ball 22","ball 23","ball 24","ball 25","ball 26","ball 27",
									  "ball 28","ball 29","ball 30","ball 31","ball 32","ball 33","ball 34","ball 35","ball 36",
									  "ball 37","ball 38","ball 39","ball 40","ball 41","ball 42","ball 43","ball 44","ball 45",
									  "ball 46","ball 47","ball 48","ball 49","ball 50","ball 51","ball 52","ball 53","ball 54",
									  "ball 55","ball 56","ball 57","ball 58","ball 59","ball 60","ball 61","ball 62","ball 63",
								 	  "ball 64","ball 65","ball 66","ball 67","ball 68","ball 69","ball 70","ball 71","ball 72",
									  "ball 73","ball 74","ball 75","ball 76","ball 77","ball 78","ball 79","ball 80","ball 81",
									  "ball 82","ball 83","ball 84","ball 85","ball 86","ball 87","ball 88","ball 89","ball 90"};
	public static void setBalls(int size,int numb){
			PlayerPrefs.SetInt(BALLS[size],numb);
	}
	public static int getBalls(int numb) {
		return PlayerPrefs.GetInt(BALLS[numb]);
	}

	const string ACTIVE_BALL = "active ball";

    public static void setActiveBall (int numb){
		PlayerPrefs.SetInt(ACTIVE_BALL,numb);
	}
	public static int getActiveBall() {
		return PlayerPrefs.GetInt(ACTIVE_BALL);
	}


	const string ACTIVE_EFFECT = "active effect";

    public static void setActiveEffect (int numb){
		PlayerPrefs.SetInt(ACTIVE_EFFECT,numb);
	}
	public static int getActiveEffect() {
		return PlayerPrefs.GetInt(ACTIVE_EFFECT);
	}






	const string EXTRA_BALL_CONTROL = "extra ball control";

	public static void setExtraBallControl (int numb){
		PlayerPrefs.SetInt(EXTRA_BALL_CONTROL,numb);
	}
	public static int getExtraBallControl() {
		return PlayerPrefs.GetInt(EXTRA_BALL_CONTROL);
	}

	// 0 : On ||| 1: Off
	const string SOUND = "sound";

	public static void setSound (int numb){
		PlayerPrefs.SetInt(SOUND,numb);
	}
	public static int getSound() {
		return PlayerPrefs.GetInt(SOUND);
	}

	const string EXTRA_FRAGMENTATION = "extra fregmantation";

	public static void setExtraFragmentaton (int numb){
		PlayerPrefs.SetInt(EXTRA_FRAGMENTATION,numb);
	}
	public static int getExtraFragmentaton() {
		return PlayerPrefs.GetInt(EXTRA_FRAGMENTATION);
	}


	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		//PlayerPrefs.DeleteAll();
		/*if(PlayerSettings.getBalls(0) != 0){
			PlayerPrefs.DeleteAll();
		}*/
		if(PlayerSettings.getBalls(0) == 0){
		   PlayerSettings.setBalls(0,2);
		}
		//PlayerPrefs.DeleteAll();
	}
}
