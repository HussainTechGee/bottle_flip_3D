using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Transform GraphicTrans;
    public float force;
    public Vector3 centerMass;
    public ParticleSystem HitParticle;
    public Rigidbody rb;
    public bool down, isJump, secondJump;
    //      ----------------------------------------Instance
    public static PlayerController PlayerControllerInstance;
    [HideInInspector] public bool ground = false, finish = false;

    // Start is called before the first frame update
    void Start()
    {

        PlayerControllerInstance = this;

        rb = GetComponent<Rigidbody>();
      //  rb.centerOfMass = centerMass;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ground)
        {
            if (Input.GetMouseButtonDown(0) && !IsPointerOverGameObject())
            {
                HitParticle.Stop();
                Debug.Log("Mouse Click");
                down = true;
                if (!GameManager.instance.inGame)
                {
                    UIManager.instance.GameStart();
                }

            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Mouse Up");
            }
        }
    }
    public static bool IsPointerOverGameObject()
    {
        //check mouse
        if (EventSystem.current.IsPointerOverGameObject())
            return true;
        //check touch
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return true;
        }

        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position + transform.rotation * centerMass, .1f);
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

                rb.velocity = (new Vector3(2f,4f,0) * Time.fixedDeltaTime * force);
                FlipObject();
                // SecondFlip();
                //StartCoroutine(RotateGraphics(.9f));
            }
            else if (!secondJump)
            {
                Debug.Log("second Jump");
                secondJump = true;
                rb.velocity = (new Vector3(1.7f,4.5f, 0) * Time.fixedDeltaTime * force);
                // StartCoroutine(RotateGraphics(.9f));
                // SecondFlip();
                FlipObject();
            }
        }

    }
    IEnumerator RotateGraphics(float duration)
    {
        Quaternion startRot = GraphicTrans.rotation;
        float t = 0.0f;
        int count = 0;
        while (t < duration)
        {
            //  Debug.Log(count++ + " : " + t);
            t += Time.deltaTime;
            GraphicTrans.rotation = startRot * Quaternion.AngleAxis(t / duration * 360f, Vector3.back); //or transform.right if you want it to be locally based
            yield return null;
        }

       // GraphicTrans.rotation = Quaternion.identity;

    }
    
    void SecondFlip()
    {
        //if (transform.rotation.eulerAngles.z > -45 && transform.rotation.eulerAngles.z < 45)
        //{
        //    Debug.Log("Angle2 1 : " + transform.rotation.eulerAngles.z);
        //    rb.DORotate(new Vector3(0, 0, -360), .9f, RotateMode.LocalAxisAdd);
        //}
        //else if (transform.rotation.eulerAngles.z / 315 ==1)
        //{
        //    Debug.Log("Angle2 2 : " + transform.rotation.eulerAngles.z);
        //    rb.DORotate(new Vector3(0, 0, -360), .9f, RotateMode.LocalAxisAdd);
        //}
        if(transform.rotation.eulerAngles.z>70 && transform.rotation.eulerAngles.z<110)
        {
            Debug.Log("Angle2 1 : " + transform.rotation.eulerAngles.z);
            rb.DORotate(new Vector3(0, 0, 0), 1f, RotateMode.Fast);
        }
        else if(transform.rotation.eulerAngles.z > 250 && transform.rotation.eulerAngles.z < 290)
        {
            Debug.Log("Angle2 2 : " + transform.rotation.eulerAngles.z);
            rb.DORotate(new Vector3(0, 0, 0), 1f, RotateMode.Fast);
        }
        else if(transform.rotation.eulerAngles.z < 45 || transform.rotation.eulerAngles.z > 235)
        {
            Debug.Log("Angle2 3 : " + transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.identity;
            rb.DORotate(new Vector3(0, 0, - 360), 1.1f, RotateMode.LocalAxisAdd);
        }
        else
        {
            Debug.Log("Angle2 4 : " + transform.rotation.eulerAngles.z);
            rb.DORotate(new Vector3(0, 0, 0), 1f, RotateMode.Fast);
        }


    }
    public void FlipObject(){

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
                         rb.DORotate(new Vector3(0, 0, remaining-transform.rotation.eulerAngles.z-360), 1.1f, RotateMode.Fast);
                       
                    }
                    else{
                         float remaining = transform.rotation.eulerAngles.z-360;
                        rb.DORotate(new Vector3(0, 0, remaining-transform.rotation.eulerAngles.z-360), 1.1f, RotateMode.Fast);
                    }
     }
    void FlipObject1()
    {


        if (transform.rotation.eulerAngles.z%330 > 60 && !secondJump)
        {
            Debug.Log("Angle 1 : " + transform.rotation.eulerAngles.z);
            rb.DORotate(new Vector3(0, 0, 0), .9f, RotateMode.FastBeyond360);
        }
        else if (!secondJump && transform.rotation.eulerAngles.z < -10)
        {
            Debug.Log("Angle 2 : " + transform.rotation.eulerAngles.z);
            rb.DORotate(new Vector3(0, 0, 0), .9f, RotateMode.FastBeyond360);
        }
        //else if (secondJump)
        //{
        //    Debug.Log("Angle 3 : " + transform.rotation.eulerAngles.z);
        //    transform.DORotate(new Vector3(0, 0, -360), 1, RotateMode.FastBeyond360);
        //}
        else
        {
            Debug.Log("Angle 4 : " + transform.rotation.eulerAngles.z);
            rb.DORotate(new Vector3(0, 0, -360), .9f, RotateMode.LocalAxisAdd);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("path"))
        {
            isJump = false;
            secondJump = false;
          //  rb.constraints = RigidbodyConstraints.None;
          //  rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }
        else if (collision.gameObject.CompareTag("ground"))
        {
            // Time.timeScale = 0;
            Debug.Log("Game End");
            rb.constraints = RigidbodyConstraints.None; ;
            if (!finish)
            {
             //   rb.constraints = RigidbodyConstraints.None;
                //      ------------------- Bottle reach ground flag
                ground = true;
                UIManager.instance.GameLose();
            }
        }

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            LevelManager.instance.PlayConfittee(other.transform.position);
            if(!finish)
            {
                finish = true;
                 LevelManager.instance.LevelEnd();
            }
            
        }
        else if(other .gameObject.CompareTag("path"))
        {
            HitParticle.Play();
        }
    }
    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.CompareTag("path"))
        {
            //rb.constraints=RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        }
    }
}
