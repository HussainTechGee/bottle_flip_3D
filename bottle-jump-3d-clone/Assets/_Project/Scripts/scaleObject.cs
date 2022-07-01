using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scaleObject : MonoBehaviour
{
   public float sacleTo,duration;
   public GameObject targetobject;
   float orignalscale;

private void Start() {
     orignalscale = targetobject.transform.localScale.y;
     Debug.Log(orignalscale);
}
private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
          StartCoroutine(bounce());
          PlayerController.PlayerControllerInstance.isJump=false;
          PlayerController.PlayerControllerInstance. rb.velocity = (new Vector3(2f,4f,0) * Time.fixedDeltaTime * PlayerController.PlayerControllerInstance.force);
          PlayerController.PlayerControllerInstance.FlipObject();
        }
        
    }

    private IEnumerator bounce(){

      targetobject.transform.DOScaleY(sacleTo,duration);
      yield return new WaitForSeconds(duration);
      targetobject.transform.DOScaleY(orignalscale,duration);

    }

}
