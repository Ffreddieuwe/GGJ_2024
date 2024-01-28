using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speedDampTime = 0.01f;
    public float sensitivityX = 10.0f;

    public float animationSpeedV = 1.5f;
    public float animationSpeedH = 1.5f;

    public AudioSource audioSource;
    public AudioClip audioClip;

    bool lockedCursor = true;

    private Animator anim;
    private HashIDs hash;

    private bool walking;
    private bool running;

    public bool frozen; 

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

        running = false;
        walking = false;

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        float turn = Input.GetAxis("Turn");
        bool sprint = Input.GetButton("Sprint");
        bool jump = Input.GetButton("Jump");


        Rotate(turn);

        if (frozen)
        {
            v = 0;
            h = 0;
           
        }

        if (v!=0 || h!=0)
        {
            if (sprint)
            {
                running = true;
            }
            else
            {
                walking = true;
            }
        }

        Movement(v, sprint, h);


        anim.SetBool(hash.jumpBool, jump);

        AudioManagement();

        

    }

    void Rotate(float turn)
    {
        Rigidbody body = this.GetComponent<Rigidbody>();

        if (turn != 0)
        {
            float temp = 0.0f;

            if (turn>0)
            {
                temp = 30000.0f;
            }
            else
            {
                temp = -30000.0f;
            }

            Quaternion deltaRotation = Quaternion.Euler(0f, temp * sensitivityX * 3, 0f);
            body.MoveRotation(body.rotation * deltaRotation);

        }
    }

    void Movement(float vertical, bool sprinting, float horizontal)
    {

        anim.SetBool(hash.sprintBool, sprinting);


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

    void AudioManagement()
    {
        if (walking)
        {
            if (!audioSource.isPlaying)
            {
                //audioSource.pitch = 1f;
               // audioSource.PlayOneShot(audioClip);
            }
        }
        else if (running)
        {
            if (!audioSource.isPlaying)
            {
// audioSource.pitch = 1.25f;
                //audioSource.PlayOneShot(audioClip);
            }
        }
    }

}