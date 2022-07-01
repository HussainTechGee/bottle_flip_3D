using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObjectRotate : MonoBehaviour
{
    public Transform targetTran;
    public Vector3 rotateValue;
    public bool infinity,reverse;
    public float duration;
    bool isRotate;
    Vector3 currentrotation ;
    // Start is called before the first frame update
    void Start()
    {
         currentrotation = targetTran.rotation.eulerAngles;
        isRotate = false;
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!isRotate)
            {
                Debug.Log("Rotate .....");
                Debug.Log(currentrotation);
                if (infinity)
                {
                    targetTran.gameObject.SetActive(true);
                    targetTran.DOLocalRotate(rotateValue, 2f, RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
                }
                else
                {
                    targetTran.DOLocalRotate(rotateValue, duration);
                    if(reverse){
                      StartCoroutine(rotateObject());
                    }
                
                }
                
            }
            isRotate = true;
        }
    }

    private IEnumerator rotateObject(){
        yield return new WaitForSeconds(duration);
        targetTran.DOLocalRotate(currentrotation, duration);

    }
}
