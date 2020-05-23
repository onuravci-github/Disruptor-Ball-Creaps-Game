using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public static GameObject[] button = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {

        if (this.tag == "Play Button")
        {
            button[0] = this.gameObject;
            button[0].SetActive(false);
        }
        else if (this.tag == "Replay Button")
        {
            button[1] = GameObject.FindGameObjectWithTag("Replay Button");
            button[1].GetComponentInChildren<Transform>().gameObject.SetActive(false);
            button[1].SetActive(false);
        }
        else if (this.tag == "Pause Button")
        {
            button[2] = this.gameObject;
            button[2].SetActive(true);
        }
        else if (this.tag == "Home Button")
        {
            button[3] = this.gameObject;
            button[3].SetActive(false);
        }


    }

 
    public void PlayButton(){
        button[0].SetActive(false);
        button[1].SetActive(false);
        button[1].GetComponentInChildren<Transform>().gameObject.SetActive(false);
        button[2].SetActive(true);
        button[3].SetActive(false);
	    AdManager.Hide_Banner_Bot();
        Time.timeScale = 1f;
    }

    public void ReplayButton(){
        Time.timeScale = 1f;
        if(PlayerSettings.getActiveLevel() < PlayerSettings.getLevel()){
            LevelControl.levelGold = 0;
        }
        else{
            if(LevelControl.levelGold == 0){
                LevelControl.levelGold = 10;
            }
        }

        if(AdManager.interstitialControl > 0){
            AdManager.interstitialControl--;
        }
        else{
            AdManager.interstitialControl = 0;
        }
        if(AdManager.rewardVideoControl > 0){
            AdManager.rewardVideoControl--;
        }
        else{
            AdManager.rewardVideoControl = 0;
        }
	AdManager.Hide_Banner_Bot();
        SceneManager.LoadScene(1); 
    }
    

    public void PauseButton(){
        Time.timeScale = 0f;
        button[2].SetActive(false);
        button[0].SetActive(true);
        button[1].SetActive(true);
        button[3].SetActive(true);
    }

    public void HomeButton(){
        Time.timeScale = 1f;

        if(AdManager.interstitialControl > 0){
            AdManager.interstitialControl--;
        }
        else{
            AdManager.interstitialControl = 0;
        }
        if(AdManager.rewardVideoControl > 0){
            AdManager.rewardVideoControl--;
        }
        else{
            AdManager.rewardVideoControl = 0;
        }
	AdManager.Show_Banner_Bot();

        SceneManager.LoadScene(0); 
    }


    public void StartButton(){
        
        Time.timeScale = 1f;
	    AdManager.Hide_Banner_Bot();
	if(PlayerSettings.getIsGameOpen() == 1){
            SceneManager.LoadScene(1); 
	}
	else
	    SceneManager.LoadScene(4); 
        
    }
    public void BallStoreButton(){
        Time.timeScale = 1f;

        if(AdManager.interstitialControl > 0){
            AdManager.interstitialControl--;
        }
        else{
            AdManager.interstitialControl = 0;
        }
        if(AdManager.rewardVideoControl > 0){
            AdManager.rewardVideoControl--;
        }
        else{
            AdManager.rewardVideoControl = 0;
        }
	    AdManager.Show_Banner_Bot();
        SceneManager.LoadScene(2); 
    }
    public void SettingsButton(){
        Time.timeScale = 1f;
        if(AdManager.interstitialControl > 0){
            AdManager.interstitialControl--;
        }
        else{
            AdManager.interstitialControl = 0;
        }
        if(AdManager.rewardVideoControl > 0){
            AdManager.rewardVideoControl--;
        }
        else{
            AdManager.rewardVideoControl = 0;
        }
	    AdManager.Show_Banner_Bot();
        SceneManager.LoadScene(3); 
    }
    public void AboutButton(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(4); 
    }




    public void ShowBanner(){
        AdManager.Show_Banner_Bot();
    }
    public void ShowInterstitial(){
        if(AdManager.interstitialControl <= 3){
            AdManager.Show_Interstitial();
            AdManager.interstitialControl++;
            AdManager.interstitialGoldActive = 1;
        }
    }
    public void ShowRewardVideo(){
        if(AdManager.rewardVideoControl <= 5){
            AdManager.Show_Rewarted_Video();
            AdManager.rewardVideoControl++;
        }
    }



   public void Worldea(){
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.CreapsGame.Worldea");
   }
}
