using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    int currentPoints = 0;
    public int maxPoints = 0;
    GameObject[] pointPool;
    GameObject endPoint;

    private void Start()
    {
        pointPool = GameObject.FindGameObjectsWithTag("Pickup");
        endPoint = GameObject.FindGameObjectWithTag("Finish");
        endPoint.SetActive(false);
        CountTotalPoints();
    }

    void CountTotalPoints()
    {
        foreach (GameObject point in pointPool)
        {
            maxPoints += point.GetComponent<PickupScript>().pointValue;
        }
    }

    public void AddPoint(int pointsAdded)
    {
        currentPoints += pointsAdded;
        OpenDoor();
    }

    void OpenDoor()
    {
        if(currentPoints == maxPoints)
        {
            endPoint.SetActive(true);
            Debug.Log("Door is unlocked");
        }
    }
}
