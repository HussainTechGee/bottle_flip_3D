using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObjectMove : MonoBehaviour
{
    public GameObject targetObject;
    Rigidbody rb;
    public float duration;
    bool moved;
    public bool isreverse,infinite;
    public Vector3 targetValueAdd;
    Vector3 startpositon;
    // Start is called before the first frame update
    void Start()
    {
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
                 StartCoroutine(movetotarget());
              
            }
            moved = true;
           
        }
    }
 private IEnumerator movetotarget(){
     targetObject.transform.DOLocalMove(/*targetObject.transform.position +*/ targetValueAdd, duration);
     yield return new WaitForSeconds(duration);
      
    StartCoroutine(reverse());

    
    
 }
    private IEnumerator reverse(){

        
        if(isreverse){
       yield return new WaitForSeconds(duration);
        targetObject.GetComponent<BoxCollider>().isTrigger=true;
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
