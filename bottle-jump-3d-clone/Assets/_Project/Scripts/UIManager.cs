using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public GameObject StartPanel, GameplayPanel,TotalCoinPanel, LosePanel, WinPanel,ShopPanel,VIPPanel;
    public Image ProgressFillImage;
    public Text currentlevel,nextlevel,TotalCoinText;
    public Transform lose_buttonpos,lose_textpos,win_buttonpos,win_textpos;
    public float time;
    public static UIManager instance;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CoinRefresh();
    }
    public void GameStart()
    {
        StartPanel.SetActive(false);
        TotalCoinPanel.SetActive(false);
        GameplayPanel.SetActive(true);
        currentlevel.text = (PlayerPrefs.GetInt("CurrentLevel")+1).ToString();
        nextlevel.text = ( PlayerPrefs.GetInt("CurrentLevel")+2).ToString();
    }
    public void CoinRefresh()
    {
        TotalCoinText.text = CoinManager.instance.TotalCoin.ToString();
    }
    public void ProgressUpdate(float value)
    {
        ProgressFillImage.fillAmount = value;
    }
    public void GameWin()
    {
        GameManager.LoseCount = 0;
        TotalCoinPanel.SetActive(true);
        WinPanel.SetActive(true);
         StartCoroutine(doanimation(true));
    }
    public void GameLose()
    {

        GameManager.LoseCount++;
        if (GameManager.LoseCount > 3)
        {
            VIPPanel.SetActive(true);
            GameManager.LoseCount = 0;
        }
        LosePanel.SetActive(true);
        TotalCoinPanel.SetActive(true);
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

