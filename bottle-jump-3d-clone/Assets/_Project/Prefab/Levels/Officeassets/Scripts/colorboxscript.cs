using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorboxscript : MonoBehaviour
{
    public GameObject[] targetobjects;
    public float duration;
   public bool isdestroy;
  private void OnCollisionEnter(Collision other) {
    if(other.gameObject.tag=="Player"){
        
         StartCoroutine(rigidbodyobjects());
    
    }
  }

  private IEnumerator rigidbodyobjects(){
    
    for(int i = 0;i<targetobjects.Length;i++){
    targetobjects[i].GetComponent<Rigidbody>().isKinematic=false;
    yield return new WaitForSeconds(duration);
    if(isdestroy){
    Destroy(targetobjects[i],2f);
   }
    }
   

  }
}
