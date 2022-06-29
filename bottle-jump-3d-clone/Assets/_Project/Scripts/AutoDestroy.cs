using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float life;
    void Start()
    {
        Invoke("DestroyObject", life);
    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }
    
}
