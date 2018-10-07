using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Controls camera behaviors of level
public class CameraController : MonoBehaviour
{

    public float lerpSpeed = 0.5f;
    public GameObject human;
    public GameObject ball;

    //Offset position from center of focused object (parent object)
    public Vector3 offsetPositon = new Vector3(0,5,-10);

    //public float rotationSpeed = 30;

    GameObject focusedObject;

    //float rotation = 0;

    void Start()
    {
        focusObject(human);

        EventSystem.OnKicked += delegate {
            focusObject(ball);
        };



    }
    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }

    private void Update()
    {
        //float rotateDelta=0;

        //if (Input.GetMouseButton(2))
        //{
        //    rotateDelta = Input.GetAxis("Mouse X")* Time.deltaTime * rotationSpeed;
        //    rotation = +rotateDelta;

        //    print(rotation);

        //}



        Vector3 aim = focusedObject.transform.position + offsetPositon;

        //aim = RotatePointAroundPivot(aim, focusedObject.transform.position, rotation*Vector3.up);
        transform.position = Vector3.Lerp(transform.position, aim, Time.deltaTime);
        //transform.LookAt(focusedObject.transform.position);

    }


    void focusObject(GameObject objectToFocus){
        focusedObject = objectToFocus;
    }





}
