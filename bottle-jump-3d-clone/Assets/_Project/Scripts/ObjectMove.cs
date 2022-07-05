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
    public bool isreverse;
    public Vector3 targetValueAdd;
    // Start is called before the first frame update
    void Start()
    {
        moved = false;
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
               targetObject.transform.DOLocalMove(/*targetObject.transform.position +*/ targetValueAdd, duration);
               if(isreverse){
                StartCoroutine(reverse());
               }
            }
            moved = true;
           
        }
    }

    private IEnumerator reverse(){

        yield return new WaitForSeconds(duration);
        targetObject.GetComponent<BoxCollider>().isTrigger=true;
        rb.isKinematic=false;
    }
}
