using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public static PlayerCtrl Instance //sigleton
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PlayerCtrl>();
                if (Instance == null)
                {
                    var instanceContainer = new GameObject("PlayerCtrl");
                    instance = instanceContainer.AddComponent<PlayerCtrl>();
                }
            }
            return instance;
        }
    }
    private static PlayerCtrl instance;
    public float _speed = 10f;
    public Animator player_anim;
    Rigidbody rb;
    public GameObject[] enemy1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player_anim = GetComponent<Animator>();
        enemy1 = GameObject.FindGameObjectsWithTag("Enemy1");//임시 공격 코드 위한 Search문.
    }
    private void Update()
    {
        //임시 공격 코드.
        if(Input.GetKeyDown(KeyCode.A))
        {
            for(int i=0; i<enemy1.Length; i++)
            {
                enemy1[i].GetComponent<EnemyCtrl>().TakeDamage(5);
            }
        }
    }

    //void FixedUpdate()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");

    //    rb.velocity = new Vector3(moveHorizontal * _speed, rb.velocity.y, moveVertical * _speed);
    //     if(JoystickMovement.Instance.joystickVec.x != 0 || JoystickMovement.Instance.joystickVec.y != 0)
    //    {
    //        rb.velocity = new Vector3(JoystickMovement.Instance.joystickVec.x, rb.velocity.y, JoystickMovement.Instance.joystickVec.y);
    //        rb.rotation = Quaternion.LookRotation(new Vector3(JoystickMovement.Instance.joystickVec.x, 0, JoystickMovement.Instance.joystickVec.y));
    //    }
    //}
}
