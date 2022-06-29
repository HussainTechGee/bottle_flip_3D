using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TubScript : MonoBehaviour
{
    public Transform TubWater;
    public GameObject CylinderWater;
    bool isTrigger;
    // Start is called before the first frame update
    void Start()
    {
        isTrigger = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isTrigger)
            {
                CylinderWater.SetActive(true);
                TubWater.gameObject.SetActive(true);
                TubWater.DOScaleY(0.5f, 2f);
            }
            isTrigger = true;
        }
    } 

}
