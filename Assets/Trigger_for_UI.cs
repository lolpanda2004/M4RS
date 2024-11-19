using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_for_UI : MonoBehaviour
{
    public Animator anim;
    public Transform player;
    public Transform ui;


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.position, ui.position);
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
