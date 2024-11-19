using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Anim : MonoBehaviour
{
    public Animator anim;
    public Transform player;
    public Transform portal;

    void Update()
    {
        float distance = Vector3.Distance(player.position, portal.position);

        if (distance <= 7)
        {
            anim.SetBool("Near", true);
        }
        else
        {
            anim.SetBool("Near", false);
        }
    }
}