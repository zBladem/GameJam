using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Reloj : MonoBehaviour
{
    [SerializeField] private GameObject reloj;
    [SerializeField] Transform shootposition;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Shoot");
            LanzarReloj();
        }
    }
         
        

    private void LanzarReloj()
    {
        Instantiate(reloj, shootposition.position, Quaternion.identity);
    }


}

