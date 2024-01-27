using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speedDampTime = 0.01f;
    public float sensitivityX = 10.0f;

    public float animationSpeedV = 1.5f;
    public float animationSpeedH = 1.5f;

    bool lockedCursor = true;

    private Animator anim;
    private HashIDs hash;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();

        //anim.SetLayerWeight(1, 1f);
    }

    private void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        float turn = Input.GetAxis("Turn");
        bool sprint = Input.GetButton("Sprint");
        bool jump = Input.GetButton("Jump");

        Movement(v, sprint, h);


        anim.SetBool(hash.jumpBool, jump);


        Rotate(turn);

    }

    void Rotate(float turn)
    {
        Rigidbody body = this.GetComponent<Rigidbody>();

        if (turn != 0)
        {
            Quaternion deltaRotation = Quaternion.Euler(0f, turn * sensitivityX * 3, 0f);
            body.MoveRotation(body.rotation * deltaRotation);
        }
    }

    void Movement(float vertical, bool sprinting, float horizontal)
    {

        anim.SetBool(hash.sprintBool, sprinting);

        Debug.Log(vertical);
        Debug.Log(horizontal);

        if (vertical != 0)
        {
            anim.SetFloat(hash.speedFloatV, vertical, speedDampTime, Time.deltaTime);
        }
        else
        {
            anim.SetFloat(hash.speedFloatV, 0);
        }

        if (horizontal != 0)
        {
            anim.SetFloat(hash.speedFloatH, horizontal, speedDampTime, Time.deltaTime);
        }
        else
        {
            anim.SetFloat(hash.speedFloatH, 0);
        }

    }

}