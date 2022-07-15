using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvScript : MonoBehaviour
{
    public GameObject Tvscreen;
    public float scrollspeed=0.5f;
    Renderer rend;
    private void Start() {
        rend = Tvscreen.GetComponent<Renderer>();
        // Debug.Log(rend);
        Tvscreen.SetActive(false);
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){

            if(!Tvscreen.gameObject.activeInHierarchy){
          Tvscreen.SetActive(true);
            }

        }
    }
    private void Update() {
        if(Tvscreen.activeSelf){

         float offset = Time.deltaTime*scrollspeed;
        //  Debug.Log(offset);
         rend.material.mainTextureOffset = new Vector2 (offset,offset);
        //  rend.material.SetTextureOffset("Tv , No Signal",new Vector2 (offset,0));
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(turnoffscreen());
        }
    }

    private IEnumerator turnoffscreen(){
    yield return new WaitForSeconds(5f);
    Tvscreen.SetActive(false);

    }
}
