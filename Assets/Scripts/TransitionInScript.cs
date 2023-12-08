using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionInScript : MonoBehaviour
{
    Animator animator;
    AnimatorStateInfo animStateInfo;
    bool transInFinished = false;
    [SerializeField] int NextSceneIndex;
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
        animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x <= 0.03f && !transInFinished)
        {
            gameObject.SetActive (false);
            transInFinished = true;
        }
    }

    public void TransitionOut()
    {
        gameObject.SetActive(true);
        animator.SetBool("isFinished", true);
    }

    public void TransitionOut(int sceneIndex)
    {
        gameObject.SetActive(true);
        animator.SetBool("isFinished", true);
        NextSceneIndex = sceneIndex;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(NextSceneIndex);
    }
}
