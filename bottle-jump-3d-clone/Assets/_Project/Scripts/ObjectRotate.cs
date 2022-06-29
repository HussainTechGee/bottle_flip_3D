using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObjectRotate : MonoBehaviour
{
    public Transform targetTran;
    public Vector3 rotateValue;
    public bool infinity;
    bool isRotate;
    // Start is called before the first frame update
    void Start()
    {
        isRotate = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!isRotate)
            {
                Debug.Log("Rotate .....");
                if (infinity)
                {
                    targetTran.gameObject.SetActive(true);
                    targetTran.DOLocalRotate(rotateValue, 2f, RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
                }
                else
                {
                    targetTran.DOLocalRotate(rotateValue, 1);
                }
                
            }
            isRotate = true;
        }
    }
}
