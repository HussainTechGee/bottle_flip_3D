using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basinscript : MonoBehaviour
{
    public GameObject _light;
    private void Start() {
        _light.SetActive(false);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){

            if(!_light.gameObject.activeInHierarchy){
          _light.SetActive(true);
            }

        }
    }
}
