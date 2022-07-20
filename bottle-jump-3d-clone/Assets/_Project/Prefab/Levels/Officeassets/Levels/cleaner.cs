using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cleaner : MonoBehaviour
{
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
         _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter(Collision other) {
         if (other.gameObject.CompareTag("Player"))
        {
            
         _player.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            
         _player.transform.SetParent(gameObject.transform);
        }
    }
    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Player"))
        {
            
         _player.transform.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
