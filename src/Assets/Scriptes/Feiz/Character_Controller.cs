using UnityEngine;
using System.Collections;

public class Character_Controller : MonoBehaviour {
    static Character_Controller instance;
    //获取单实例
    public static Character_Controller Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Character_Controller();
            }
            return instance;
        }
    }
    static GameObject character;
    static CharacterController myCController;
    static GameObject mainCamera;
    static Animator animator;
    public string joysticks;
    float gravity = 0.058f;
    float fall_speed = 0;
	// Use this for initialization
	void Start () {
	    
	}


    public void setCharacter(GameObject c)
    {
        character = c;
        c.transform.parent = GameObject.Find("Controller").transform;
        myCController = character.GetComponent<CharacterController>();
        animator = character.GetComponent<Animator>();
        mainCamera = character.transform.FindChild("Camera").gameObject;

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
        if (myCController != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumping();
            }
            if (!myCController.isGrounded)
            {
                fall_speed -= gravity;
                myCController.Move(new Vector3(0, fall_speed, 0));
                mainCamera.transform.position -= new Vector3(0, fall_speed, 0);
            }
            else
            {
                fall_speed = 0;
            }
            //mainCamera.transform.position = new Vector3(character.transform.position.x, 1.5f, character.transform.position.z) - 2 * character.transform.forward;
            mainCamera.transform.position = character.transform.position - 2 * character.transform.forward + 2*Vector3.up;
            mainCamera.transform.localEulerAngles = new Vector3(0, character.transform.localEulerAngles.y, 0);
            mainCamera.transform.LookAt(character.transform.position + Vector3.up);
        }
       
	}

    void jumping()
    {
        fall_speed = 1;
        fall_speed -= gravity;
        myCController.Move(new Vector3(0, fall_speed, 0));
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
        if (character == null)
            return;
        if (move.joystickName == joysticks)
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
        if (character == null)
            return;
        if (move.joystickName != joysticks)
        {

            return;

        }



        //获取摇杆中心偏移的坐标  

        float joyPositionX = move.joystickAxis.x;

        float joyPositionY = move.joystickAxis.y;

        

        if (joyPositionY != 0 || joyPositionX != 0)
        {

            //移动玩家的位置（按朝向位置移动）  
            character.transform.Rotate(new Vector3(0, 1, 0), 5 * joyPositionX);
            myCController.Move(character.transform.forward * Time.deltaTime * joyPositionY * 5);

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
