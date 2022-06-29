using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class testscript : MonoBehaviour
{
     Rigidbody rb;
     public float force;
     bool down,isJump, secondJump;
    // Start is called before the first frame update
    void Start()
    {
        isJump=secondJump=false;
        rb = GetComponent<Rigidbody>();
    }

   void Update()
    {
        
            if (Input.GetMouseButtonDown(0) )
            {
               
                Debug.Log("Mouse Click");
               down = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Mouse Up");
            }
        
    }


    private void FixedUpdate()
    {
        if (down)
        {
            down = false;
            //First Jump
            if (!isJump)
            {
                Debug.Log("First Jump");
                isJump = true;
             
                rb.velocity = (new Vector3(0,4f,0) * Time.fixedDeltaTime * force);
                FlipObject();
                // SecondFlip();
                //StartCoroutine(RotateGraphics(.9f));
            }
            else if (!secondJump)
            {
                Debug.Log("second Jump");
                secondJump = true;
                
                rb.velocity = (new Vector3(0,4.5f, 0) * Time.fixedDeltaTime * force);
                  FlipObject();
                // StartCoroutine(RotateGraphics(.9f));
                // SecondFlip();
            }else{
                 isJump = false;
                 secondJump = false;

            }
        }

    }

    void FlipObject(){

             if(transform.rotation.eulerAngles.z < 45 || transform.rotation.eulerAngles.z >315){
                    transform.rotation = Quaternion.identity;
                        rb.DORotate(new Vector3(0, 0, -360), 1.1f, RotateMode.LocalAxisAdd);
                    }else if(transform.rotation.eulerAngles.z<315 &&  transform.rotation.eulerAngles.z> 225){
                        //  rb.DORotate(new Vector3(0, 0, 0), 1.1f, RotateMode.Fast);
                        float remaining = transform.rotation.eulerAngles.z-360;
                        rb.DORotate(new Vector3(0, 0, remaining-transform.rotation.eulerAngles.z-360), 1.1f, RotateMode.Fast);  
                    }  
                    else if(transform.rotation.eulerAngles.z < 225 && transform.rotation.eulerAngles.z > 135){

                        float remaining = transform.rotation.eulerAngles.z-360;
                        rb.DORotate(new Vector3(0, 0, remaining-transform.rotation.eulerAngles.z-360), 1.1f, RotateMode.Fast);

                    }else if(transform.rotation.eulerAngles.z<135 && transform.rotation.eulerAngles.z>45){

                        float remaining = transform.rotation.eulerAngles.z-360;
                         rb.DORotate(new Vector3(0, 0, remaining-transform.rotation.eulerAngles.z-360), 1.1f, RotateMode.FastBeyond360);
                       
                    }
                    else{
                         float remaining = transform.rotation.eulerAngles.z-360;
                        rb.DORotate(new Vector3(0, 0, remaining-transform.rotation.eulerAngles.z-360), 1.1f, RotateMode.Fast);
                    }

                    // if(transform.rotation.eulerAngles.z < 45||transform.rotation.eulerAngles.z >315){
                    // transform.rotation = Quaternion.identity;
                    //     rb.DORotate(new Vector3(0, 0, -360), 1.1f, RotateMode.LocalAxisAdd);
                    // }else if(transform.rotation.eulerAngles.z<315 &&  transform.rotation.eulerAngles.z> 225){
                    //     //  rb.DORotate(new Vector3(0, 0, 0), 1.1f, RotateMode.Fast);
                    //     float remaining = transform.rotation.eulerAngles.z-360;
                    //     rb.DORotate(new Vector3(0, 0, remaining-transform.rotation.eulerAngles.z), 1.1f, RotateMode.FastBeyond360);  
                    // }  
                    // else if(transform.rotation.eulerAngles.z<225&&transform.rotation.eulerAngles.z> 135){

                    //     float remaining = transform.rotation.eulerAngles.z-360;
                    //     rb.DORotate(new Vector3(0, 0, remaining-transform.rotation.eulerAngles.z-360), 1.1f, RotateMode.FastBeyond360);

                    // }else if(transform.rotation.eulerAngles.z<135&&transform.rotation.eulerAngles.z>45){

                    //     float remaining = transform.rotation.eulerAngles.z-360;
                    //      rb.DORotate(new Vector3(0, 0, remaining-transform.rotation.eulerAngles.z-360), 1.1f, RotateMode.FastBeyond360);
                       
                    // }
                    // else{
                    //     rb.DORotate(new Vector3(0, 0, 0), 1.1f, RotateMode.Fast);
                    // }

                     
    }
}
