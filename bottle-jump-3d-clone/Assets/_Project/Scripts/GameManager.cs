using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool inGame;
    public Text currentlevel,nextlevel;
    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void nextLevel(){
         Replay();
    }
    public void clearTesting()
    {
        PlayerPrefs.DeleteAll();
        Replay();
    }
}
