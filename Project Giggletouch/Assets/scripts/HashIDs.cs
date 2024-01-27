using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HashIDs : MonoBehaviour
{

    public int sprintBool;
    public int jumpBool;

    public int speedFloatH;
    public int speedFloatV;


    private void Awake()
    {
        sprintBool = Animator.StringToHash("Sprinting");
        jumpBool = Animator.StringToHash("Jump");
        speedFloatH = Animator.StringToHash("Sideways_Speed");
        speedFloatV = Animator.StringToHash("Forwards_Speed");
    }
}
