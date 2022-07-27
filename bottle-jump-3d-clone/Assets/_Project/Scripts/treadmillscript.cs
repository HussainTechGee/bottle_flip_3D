using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treadmillscript : MonoBehaviour
{
    public GameObject Texture;
    public float scrollspeed = 0.5f;
    float offset;
    Renderer rend;
    bool move;
    // Start is called before the first frame update
    void Start()
    {
        rend = Texture.GetComponent<Renderer>();
        
    }
private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){

            move =true;

        }
    }
   
    void Update()
    {
        if(move){
          offset += Time.deltaTime*scrollspeed;
         rend.material.mainTextureOffset = new Vector2 (0,offset);
        }
    }
}
