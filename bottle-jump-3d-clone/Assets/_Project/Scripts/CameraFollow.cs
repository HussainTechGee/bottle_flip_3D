using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform TargetPlayer;
    public Vector3 offset;
    Vector3 newPos;
    // Update is called once per frame
private void Start() {
    Application.targetFrameRate =60;
}
    void LateUpdate()
    {
        newPos = TargetPlayer.position + offset;
        newPos.y = transform.position.y;
        transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * 8f);
    }
}
