using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public Animator anim;
    public Transform player;
    public Transform door;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, door.position);
        if (distance <= 15)
        {
            anim.SetBool("Near", false);

        }
        else
        {
            anim.SetBool("Near", true);
        }
    }
}
