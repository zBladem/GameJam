using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{

    public Transform target;
    public Transform bg1;
    public Transform bg2;
    private float size;


    private void Start()
    {
        size=bg1.GetComponent<BoxCollider2D>().size.y;
    }
    private void FixedUpdate()
    {
        Vector3 targetpos=new Vector3(target.position.x,target.position.y,transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetpos, 0.2f);

        if(transform.position.y > bg2.position.y)
        {
            bg1.position = new Vector3(bg1.position.x, bg2.position.y + size, bg1.position.z);
            SwitchBG();
        }

    }

    private void SwitchBG()
    {
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }
}
