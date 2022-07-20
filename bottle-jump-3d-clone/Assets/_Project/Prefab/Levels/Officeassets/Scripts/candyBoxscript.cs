using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candyBoxscript : MonoBehaviour
{
    public ParticleSystem candyparticals;
   
  private void OnCollisionEnter(Collision other) {
    if(other.gameObject.tag=="Player"){
        
         candyparticals.Play();
    
    }
  }

  
}
