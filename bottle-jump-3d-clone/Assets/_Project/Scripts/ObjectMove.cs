using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObjectMove : MonoBehaviour
{
    bool moved;
    public Vector3 targetValueAdd;
    // Start is called before the first frame update
    void Start()
    {
        moved = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(!moved)
            {
                transform.DOLocalMove(transform.position + targetValueAdd, 1f);
            }
            moved = true;
           
        }
    }
}
