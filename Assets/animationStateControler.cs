using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateControler : MonoBehaviour
{

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Run", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Run", false);
        }
    }
}