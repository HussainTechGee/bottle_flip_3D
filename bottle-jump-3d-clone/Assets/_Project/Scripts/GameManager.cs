using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public bool inGame;
    // public GameObject wall,floorbase,edge1,edge2;
    // public Color[] color1,color2;
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
