using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMethods : MonoBehaviour
{
    [SerializeField] GameObject transitionObject;
    TransitionInScript transition;

    private void Awake()
    {
        transition = transitionObject.GetComponent<TransitionInScript>();
    }

    public void GoToLevelOne()
    {
        transition.TransitionOut(1);
    }
    public void GoToLevelTwo()
    {
        transition.TransitionOut(2);
    }
    public void GoToLevelThree()
    {
        transition.TransitionOut(3);
    }
    public void GoToLevelFour()
    {
        transition.TransitionOut(4);
    }
    public void GoToLevelFive()
    {
        transition.TransitionOut(5);
    }
}
