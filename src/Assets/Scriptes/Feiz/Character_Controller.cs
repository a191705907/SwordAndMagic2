using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {
    CharacterController myCController;
    GameObject mainCamera;
    Animator animator;
	// Use this for initialization
	void Start () {
	    myCController = GetComponent<CharacterController>();
        mainCamera = GameObject.Find("Main Camera");
        animator = GetComponent<Animator>();
	}

    State currentState
    {
        get
        {
            State state = State.Idle;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
                state = State.Idle;
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                state = State.Run;
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
                state = State.Walk;
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
                state = State.Death;
            else if (animator.GetCurrentAnimatorStateInfo(1).IsName("Attack1"))
                state = State.Attack1;
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("TakeDamage2"))
                state = State.TakeDamage;
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("TakeDamage1"))
                state = State.TakeDamage;
            else if (animator.GetCurrentAnimatorStateInfo(1).IsName("Skill02"))
                state = State.Skill1;
            else if (animator.GetCurrentAnimatorStateInfo(1).IsName("Skill01"))
                state = State.Skill2;

            return state;
        }
    }

    enum State
    {
        Idle,
        Run,
        Death,
        Attack1,
        TakeDamage,
        Skill1,
        Skill2,
        Walk
    };


	// Update is called once per frame
	void Update () {
        
	}
    void OnEnable()
    {

        EasyJoystick.On_JoystickMove += OnJoystickMove;

        EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;

    }

    //移动摇杆结束  

    void OnJoystickMoveEnd(MovingJoystick move)
    {

        //停止时，角色恢复idle  

        if (move.joystickName == "MoveJoystick")
        {

            if (currentState != State.TakeDamage)
                animator.SetTrigger("idle");

        }

    }

    //移动摇杆中  

    void OnJoystickMove(MovingJoystick move)
    {
        //if (damage || game.pause || game.finish)
        //{
        //    return;
        //}
        if (move.joystickName != "MoveJoystick")
        {

            return;

        }



        //获取摇杆中心偏移的坐标  

        float joyPositionX = move.joystickAxis.x;

        float joyPositionY = move.joystickAxis.y;


        mainCamera.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z) - 2 * transform.forward;
        mainCamera.transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
        mainCamera.transform.LookAt(transform.position + Vector3.up);


        if (joyPositionY != 0 || joyPositionX != 0)
        {

            //移动玩家的位置（按朝向位置移动）  
            transform.Rotate(new Vector3(0, 1, 0), 5 * joyPositionX);
            myCController.Move(transform.forward * Time.deltaTime * joyPositionY * 10);


            //播放奔跑动画  
            if (joyPositionY < 0.5 && joyPositionY > -0.5)
            {
                if (currentState != State.Walk)
                {
                    animator.SetTrigger("walk");
                }
            }
            else
            {
                if (currentState != State.Run)
                {
                    animator.SetTrigger("run");
                }
            }
           

        }

    }


}
