using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] AllLevelsList;
    public GameObject FinishParticles;
    public int currentLevelIndex;
    public Transform StartText,FinishText;
    float totalDist,coverDist;
    float startPos;
    Transform Player;
    public static LevelManager instance;
    void Awake()
    {
        
        instance = this;
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel");
        GameObject LevelObj=Instantiate(AllLevelsList[currentLevelIndex], transform);
        startPos = LevelObj.transform.GetChild(0).position.x;
        totalDist = Mathf.Abs(LevelObj.transform.GetChild(1).position.x-startPos);
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        StartText.position = new Vector3(startPos+1f, LevelObj.transform.GetChild(0).position.y + 10.3f,StartText.position.z);
        FinishText.position = new Vector3(LevelObj.transform.GetChild(1).position.x+1.5f, LevelObj.transform.GetChild(1).position.y + 10.3f, FinishText.position.z);
    }
    public void LevelEnd()
    {
        if (currentLevelIndex < AllLevelsList.Length-1)
        {
            currentLevelIndex++;
            PlayerPrefs.SetInt("CurrentLevel", currentLevelIndex);
        }
        UIManager.instance.GameWin();
    }
    public void PlayConfittee(Vector3 pos)
    {
        Transform Particle = Instantiate(FinishParticles).GetComponent<Transform>();
        Particle.position = pos;
        Particle.parent = transform;
        Particle.GetComponent<ParticleSystem>().Play();
        Debug.Log("Particles");
    }
    void Update()
    {
        if(Player!=null)
        {
            if (coverDist != Mathf.Abs(Player.position.x-startPos))
            {
                coverDist = Mathf.Abs(Player.position.x - startPos);
                UIManager.instance.ProgressUpdate(coverDist/totalDist);
            }
            

        }
    }
}
