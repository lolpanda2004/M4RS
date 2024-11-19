using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Animation : MonoBehaviour
{
    public Animator anim;
    public Transform player;
    public Transform door;

    void Update()
    {
        float distance = Vector3.Distance(player.position, door.position);

        if (distance <= 15)
        {
            anim.SetBool("Near", true);
        }
        else
        {
            anim.SetBool("Near", false);
        }
    }
}