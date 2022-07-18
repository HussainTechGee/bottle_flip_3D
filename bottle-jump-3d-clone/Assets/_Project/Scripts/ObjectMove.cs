using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObjectMove : MonoBehaviour
{
    public GameObject targetObject;
    GameObject _player;
    Rigidbody rb;
    public float duration;
    bool moved;
    public bool isreverse,infinite,follow;
    public Vector3 targetValueAdd;
    Vector3 startpositon;
    // Start is called before the first frame update
    void Start()
    {
    
         _player = GameObject.FindGameObjectWithTag("Player");
        moved = false;
        startpositon = targetObject.transform.position;
        if(isreverse){
         rb = targetObject.GetComponent<Rigidbody>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!moved)
            {
                if(follow)
                _player.transform.SetParent(targetObject.transform);
                 StartCoroutine(movetotarget());
              
            }
            moved = true;
           
        }
    }
    private void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            if(follow)
         _player.transform.SetParent(targetObject.transform);
        }
    }
    private void OnCollisionExit(Collision other) {
         if (other.gameObject.CompareTag("Player")){
        if(follow)
              _player.transform.SetParent(null);
         }
    }
 private IEnumerator movetotarget(){
  
    yield return new WaitForSeconds(.02f);
     targetObject.transform.DOLocalMove(/*targetObject.transform.position +*/ targetValueAdd, duration);
     yield return new WaitForSeconds(duration);
      
    StartCoroutine(reverse());

    
    
 }

 
    private IEnumerator reverse(){

        
        if(isreverse){
       yield return new WaitForSeconds(0);
        // targetObject.GetComponent<BoxCollider>().isTrigger=true;
        rb.isKinematic=false;
        }else
        if(infinite)
        {
            targetObject.transform.DOLocalMove(/*targetObject.transform.position +*/ startpositon, duration);
            yield return new WaitForSeconds(duration);
            StartCoroutine(movetotarget());
        }

    }
}
