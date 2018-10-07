using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Arrow controller enables user control to arrow that represent kickin speed and direction
public class ArrowController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float scaleSpeed = 1;
    public float maxSpeed = 10.0f;
    public float minSpeed = 0.1f;
    GameObject pivot;
    public GameObject rod;
    public float rodScaleFactor = 0.1f;

    float speed;


    private void Awake()
    {
        //When ball is kicked arrow should be disabled so add event
        EventSystem.OnKicked += Deactivate;


        //Get ball, beause ball position must be know when arrow is activated
        pivot = GameObject.FindGameObjectWithTag("ball");

        if (pivot == null)
        {
            print("Ball doesnt exist in current scene");
            gameObject.SetActive(false);
            return;
        }

        //At start of scene arrow controller must be activated while game starts with a kick
        Activate();
    }

    private void OnDestroy()
    {
        EventSystem.OnKicked -= Deactivate;
    }



    //Acitvates arrow 
    public void Activate()
    {

        //Set position to position of pivot object
        transform.position = pivot.transform.position;

        //Rotate arrow towards forward
        transform.LookAt(transform.position + Vector3.forward);

        //Set speed to middle speed value
        setSpeed((maxSpeed - minSpeed) / 2);


        gameObject.SetActive(true);

    }

    void Deactivate(){
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");

            transform.RotateAround(pivot.transform.position, Vector3.right, mouseY * rotationSpeed);
            transform.RotateAround(pivot.transform.position, Vector3.up, mouseX * -1 * rotationSpeed);

        }

        setSpeed(speed + Input.GetAxis("Mouse ScrollWheel")*scaleSpeed);


    }

    //Set speeed variable with arranging scale of arrow for representation
    void setSpeed(float s)
    {

        speed = Mathf.Clamp(s, minSpeed, maxSpeed);

        var scale = speed * rodScaleFactor;

        var currentScale = rod.transform.localScale;
        currentScale.z = scale;
        rod.transform.localScale = currentScale;

        //Set position of rod as it is starting point at the center of parent object
        rod.transform.localPosition = scale / 2 * Vector3.forward;
    }

    //Returns direction of arrow
    public Vector3 getDirection()
    {
        return transform.forward;
    }


    public float getSpeed()
    {
        return speed;
    }




}
