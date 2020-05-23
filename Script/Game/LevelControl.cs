using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{

    public static int levelGold = 10;
    public static int gainGold;
    public static int isGameStart;
    public static int GameOver;
    public static int InfinityMode;

    public int tempLevel;

    public bool controlWin;
    public bool controlLose;

    
    // Start is called before the first frame update
    void Start()
    {
        AdManager.Hide_Banner_Bot();
        //PlayerPrefs.DeleteAll();
        /*if(PlayerSettings.getLevel() >= 60){
            PlayerSettings.setActivelevel()
        }*/

        //PlayerSettings.setlevel(60);
        isGameStart = 0 ;
        GameOver = 0 ;
        gainGold = levelGold;
        controlWin = false;
        controlLose = false;
	Mouse.gameStart = 0;

        if(levelGold == 10){
            GameObject.FindGameObjectWithTag("Level Start Anim Create").GetComponent<LevelStartAnimCreate>().Creater();
        }
        else {
            //GameObject.FindGameObjectWithTag("Level Start Animation").GetComponent<Destroy>().Destroyer();
            GameObject.FindGameObjectWithTag("Block Create").GetComponent<Create>().Creater();
            GameObject.FindGameObjectWithTag("Ball Create").GetComponent<Create>().Creater();
        }
        tempLevel = PlayerSettings.getActiveLevel();


        if(levelGold == 3){
            AdManager.Show_Rewarted_Video();
        }
        if(levelGold == 8 || levelGold == 2){
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
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Mouse.gameStart == 1 && Time.timeScale != 0){
            if(FindObjectOfType<BlockLife>() == null && isGameStart == 1 && !controlWin){
                //Debug.Log("Kazandın");

                controlWin = true;
                PlayerSettings.setMainGold(PlayerSettings.getMainGold() + gainGold );

                //GameObject.FindObjectOfType<SelectLevelMouse>().updateLevel = GameObject.FindObjectOfType<SelectLevelMouse>().updateLevel + 1;
                
                if(tempLevel != PlayerSettings.getActiveLevel()){
                    PlayerSettings.setActivelevel(tempLevel +1); 
                }
                else{
                    PlayerSettings.setActivelevel(PlayerSettings.getActiveLevel() +1); 
                }
                //PlayerSettings.setActivelevel(PlayerSettings.getActiveLevel() +1);
                
                if(PlayerSettings.getLevel() < PlayerSettings.getActiveLevel()){
                    PlayerSettings.setlevel(PlayerSettings.getActiveLevel());
                }
                levelGold = 10;
                Mouse.isBallControl = 0;
                Mouse.gameStart = 0;
                WinLose.audior[0].Play();
                StartCoroutine(NextLevel());
                
            }
            else if(GameOver == 1 && !controlLose && !controlWin) {
                //Debug.Log("Kaybettin");
                controlLose = true;

                levelGold--;
                if(levelGold < 0){
                    levelGold = 0;
                }

                


                if(tempLevel != PlayerSettings.getActiveLevel()){
                    PlayerSettings.setActivelevel(tempLevel); 
                }
                Mouse.gameStart = 0;
                Mouse.isBallControl = 0;
                WinLose.audior[1].Play();
                StartCoroutine(ReplayLevel());
            }
        }
    }


    public void Hile(){
            controlWin = true;
            PlayerSettings.setMainGold(PlayerSettings.getMainGold() + gainGold );
            
            GameObject.FindObjectOfType<SelectLevelMouse>().updateLevel = GameObject.FindObjectOfType<SelectLevelMouse>().updateLevel + 1;
            PlayerSettings.setActivelevel(GameObject.FindObjectOfType<SelectLevelMouse>().updateLevel); 

            if(PlayerSettings.getLevel() < PlayerSettings.getActiveLevel()){
                PlayerSettings.setlevel(PlayerSettings.getActiveLevel());
            }
            
            levelGold = 10;
            Mouse.isBallControl = 0;
            SceneManager.LoadScene(1);
    }
    public void Hile2(){
            controlWin = true;
            PlayerSettings.setMainGold(PlayerSettings.getMainGold() + gainGold );
            
            GameObject.FindObjectOfType<SelectLevelMouse>().updateLevel = GameObject.FindObjectOfType<SelectLevelMouse>().updateLevel + 1;
            PlayerSettings.setActivelevel(GameObject.FindObjectOfType<SelectLevelMouse>().updateLevel); 

            if(PlayerSettings.getLevel() > PlayerSettings.getActiveLevel()){
                PlayerSettings.setlevel(PlayerSettings.getActiveLevel());
            }

            PlayerSettings.setActivelevel(PlayerSettings.getActiveLevel()- 1);
            levelGold = 10;
            Mouse.isBallControl = 0;
            SceneManager.LoadScene(1);
    }


    IEnumerator NextLevel() {
        Time.timeScale = 2f;
        yield return new WaitForSeconds(4);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);

    }
    IEnumerator ReplayLevel() {
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(1);

    }
    
}
