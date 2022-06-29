using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public GameObject StartPanel, GameplayPanel, LosePanel, WinPanel;
    public Image ProgressFillImage;
    public Text currentlevel,nextlevel;
    public Transform lose_buttonpos,lose_textpos,win_buttonpos,win_textpos;
    public float time;
    public static UIManager instance;
    void Awake()
    {
        instance = this;
    }
    public void GameStart()
    {
        StartPanel.SetActive(false);
        GameplayPanel.SetActive(true);
        currentlevel.text = (PlayerPrefs.GetInt("CurrentLevel")+1).ToString();
        nextlevel.text = ( PlayerPrefs.GetInt("CurrentLevel")+2).ToString();
    }
    public void ProgressUpdate(float value)
    {
        ProgressFillImage.fillAmount = value;
    }
    public void GameWin()
    {
        WinPanel.SetActive(true);
         StartCoroutine(doanimation(true));
    }
    public void GameLose()
    {

        LosePanel.SetActive(true);
        
        LosePanel.transform.GetChild(1).GetComponent<Text>().text=(int)(ProgressFillImage.fillAmount*100)+"% COMPLETED";
        StartCoroutine(doanimation(false));
    }

    private IEnumerator doanimation(bool iswin){
      if(!iswin){
     LosePanel.transform.GetChild(1).DOMove(lose_textpos.position, time, true);
      }else{
        WinPanel.transform.GetChild(1).DOMove(lose_textpos.position, time, true);
      }

     yield return new WaitForSeconds(0.5f);
   if(!iswin){
     LosePanel.transform.GetChild(0).DOMove(lose_buttonpos.position, time, true);
   }else{
        WinPanel.transform.GetChild(0).DOMove(win_buttonpos.position, time, true);
      }

    }
}

