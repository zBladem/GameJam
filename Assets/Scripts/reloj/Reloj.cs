using System;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
    [SerializeField] private GameObject reloj;
    [SerializeField] Transform shootposition;
    Animator animator;
    [SerializeField] Button button;
    [SerializeField] Button button2;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        if(button!=null&&button2!=null)
        {
            button.onClick.AddListener(Shoot);
            button2.onClick.AddListener(Shoot);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        animator.SetTrigger("Shoot");
        LanzarReloj();
    }
         
        

    private void LanzarReloj()
    {
        Instantiate(reloj, shootposition.position, Quaternion.identity);
    }


}

