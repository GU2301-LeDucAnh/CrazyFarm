using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public SkinnedMeshRenderer baseSkin;
    public SkinnedMeshRenderer hatSkin;
    public Rigidbody rb;

    public FixedJoystick joystick;
    public ChangeCollisionFace facePosCheck;

    [SerializeField] private float speed;

    private Transform cameraTrans;

    private string curState;
    private Animator animator;
    //private NavMeshAgent agent;
    const string PLAYER_IDLE = "Idle";
    const string PLAYER_WALK = "Walk";
    const string PLAYER_RUN = "Run";

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        cameraTrans = Camera.main.transform;
        animator = GetComponent<Animator>();
        ChangeAnimationState(PLAYER_IDLE);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        //    {
        //        agent.destination = hit.point;
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //}

        Vector3 inputDirection = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        inputDirection = inputDirection.normalized;

        Vector3 worldDirection = cameraTrans.TransformDirection(inputDirection);
        worldDirection.y = 0f;

        Vector3 moveVel = worldDirection * speed;

        //rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);

        rb.velocity = new Vector3(moveVel.x, rb.velocity.y, moveVel.z);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            ChangeAnimationState(PLAYER_WALK);
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            ChangeAnimationState(PLAYER_IDLE);
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (newState == curState)
        {
            return;
        }

        animator.Play(newState);

        curState = newState;
    }

    bool isAnimationPlaying(Animator animator, string stateName)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(stateName)&& animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}