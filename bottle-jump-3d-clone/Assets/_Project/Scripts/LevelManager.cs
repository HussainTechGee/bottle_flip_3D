using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [System.Serializable] class _levelcolor{
        public Color wallColor;
        public Color edgeColor;
        public Color baseColor;
    }
    [SerializeField] List<_levelcolor> levelcolors;
    public GameObject[] AllLevelsList;
    public Material wallmat,edgemat,basemat;
    
    public GameObject FinishParticles,LevelParent;
    public int currentLevelIndex;
    public Transform StartText,FinishText;
    float totalDist,coverDist;
    float startPos;
    Transform Player;
    public InputField levelinput;
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
        changelevelcolors();
    }
    public void _customLevel(){
     int inputlevel = int.Parse(levelinput.text);
     currentLevelIndex =inputlevel;
      currentLevelIndex-=1;
     PlayerPrefs.SetInt("CurrentLevel", currentLevelIndex);
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    private void changelevelcolors(){
        
        if(  currentLevelIndex+1 <= 15 ){
            wallmat.color = levelcolors[0].wallColor;
            edgemat.color = levelcolors[0].edgeColor;
            basemat.color = levelcolors[0].baseColor;
        }else{
             wallmat.color = levelcolors[1].wallColor;
            edgemat.color = levelcolors[1].edgeColor;
            basemat.color = levelcolors[1].baseColor;
        }

    }

    public void select31level(){
        currentLevelIndex =30;
        PlayerPrefs.SetInt("CurrentLevel", currentLevelIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

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
