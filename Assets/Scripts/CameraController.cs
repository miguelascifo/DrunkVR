// *************************************************************************************
// NOTE: I DON'T RECOMMEND USING THIS SCRIPT FOR VR! IT TENDS TO MAKE PEOPLE FEEL ILL!!!
// IF YOU MUST FOLLOW THINGS AROUND, USE THE SCRIPT FROM CHAPTER 12 OF THE BOOK, INSTEAD
// BECAUSE IT'S MUCH FRIENDLIER!!
// *************************************************************************************

using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform cameraTarget;
    public Transform lookAtTarget;

    private Transform myTransform;

    public Vector3 targetOffset = new Vector3(0, 0, -1);

    void Start()
    {
        // grab a ref to the transform
        myTransform = transform;
    }

    void LateUpdate()
    {
        // move this gameObject's transform around to follow the target (using Lerp to move smoothly)
        myTransform.position = Vector3.Lerp(myTransform.position, cameraTarget.position + targetOffset, Time.deltaTime);
        // look at our target object
        myTransform.LookAt(lookAtTarget);
    }
}
