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
    public GameObject obj_player;        
    Animator player_anim;
    Rigidbody rb;
    public GameObject[] enemy1;

    void Start()
    {
        rb = obj_player.GetComponent<Rigidbody>();
        player_anim = obj_player.GetComponent<Animator>();
        enemy1 = GameObject.FindGameObjectsWithTag("Enemy1");//�ӽ� ���� �ڵ� ���� Search��.
    }

    private void Update()
    {
        //�ӽ� ���� �ڵ�.
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < enemy1.Length; i++)
            {
                enemy1[i].GetComponent<EnemyCtrl>().TakeDamage(5);
            }
        }
    }

    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor) //Editor���� �׽�Ʈ�ϱ� ���ϵ���
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            player_anim.SetFloat("Move", Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical)); //�ִϸ��̼� SetTrigger -> Float���� ����

            rb.velocity = new Vector3(moveHorizontal * _speed, 0, moveVertical * _speed);            
        }        
    }
}