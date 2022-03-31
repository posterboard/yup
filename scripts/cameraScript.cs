using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera myCamera = null;
    [SerializeField] private CinemachineVirtualCamera myCineMachine = null;
    [SerializeField] private GameObject followPointer = null;

    [SerializeField] private GameObject unitGameObject = null;

    Vector3 mousePosition = new Vector3();
    Vector3 followPointerPosition = new Vector3();
    // Update is called once per frame
    void Update()
    {
        mousePosition = myCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        followPointerPosition = (mousePosition + unitGameObject.transform.position) / 2;
        followPointerPosition = (followPointerPosition + unitGameObject.transform.position)/2;
        followPointer.transform.position = followPointerPosition;
    }
}
