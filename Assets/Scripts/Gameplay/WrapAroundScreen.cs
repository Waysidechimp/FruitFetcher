using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAroundScreen : MonoBehaviour
{
    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float bottomConstraint = Screen.height;
    float topConstraint = Screen.height;
    float buffer = .5f;
    Camera cam;
    float distanceZ;
    [SerializeField] bool wrapAroundX;
    [SerializeField] bool wrapAroundY;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wrapAroundX)
        {
            if (transform.position.x < leftConstraint - buffer)
            {
                transform.position = new Vector3(rightConstraint + buffer, transform.position.y, transform.position.z);
            }
            if (transform.position.x > rightConstraint + buffer)
            {
                transform.position = new Vector3(leftConstraint - buffer, transform.position.y, transform.position.z);
            }
        }
        if (wrapAroundY)
        {
            if (transform.position.y < bottomConstraint - buffer)
            {
                transform.position = new Vector3(transform.position.x, topConstraint + buffer, transform.position.z);
            }
            if (transform.position.y > topConstraint + buffer)
            {
                transform.position = new Vector3(transform.position.x, bottomConstraint - buffer, transform.position.z);
            }
        }
    }
}
