using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject targetObject;
    private float distanceToTarget;

	// Use this for initialization
    //void Start () {
    //    distanceToTarget = transform.position.z - targetObject.transform.position.z;
    //}
	
    //// Update is called once per frame
    //void Update()
    //{
    //    float targetObjectZ = targetObject.transform.position.z;

    //    Vector3 newCameraPosition = transform.position;
    //    newCameraPosition.z = targetObjectZ + distanceToTarget;
    //    transform.position = newCameraPosition;
    //}

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - targetObject.transform.position;
    }

    void LateUpdate()
    {
        transform.position = targetObject.transform.position + offset;
    }

}
