using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 pos;
    public float moveSpeed = 5.0f;
    public float velocityY;
    public float jumpPower = 10.0f;
    public float gravity = -20.0f;
    int jumpCount = 0;
    CharacterController cc; //캐릭터컨트롤러 컴포넌트
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
       
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        pos = new Vector3(h,0,v);
        //pos.Normalize();//대각선이동 속도를 상
        //transform.Translate(pos * moveSpeed * Time.deltaTime);

        pos = Camera.main.transform.TransformDirection(pos);
        //transform.Translate(pos * moveSpeed * Time.deltaTime)
        //심각한 문제 : 하늘 날라다님 , 땅 뚫음, 충돌처리 안됨
        //캐릭터컨트롤러를 사용한다.
        // 

        

        //캐릭터 점프
        //점프버튼을 누르면 수직속도에 점프 파워를 넣는다.
        //if(cc.isGrounded)//땅에 닿았냐?
        //{
        //
        //}
        //if(cc.collisionFlags==CollisionFlags.Below)
        //{
        //    velocityY = 0;
        //}
        //if(Input.GetButtonDown("Jump"))
        //{
        //    velocityY = jumpPower;
        //}

        //2단점프만 가능하도록
        //if(cc.isGrounded)
        //{
        //    velocityY = 0;
        //    jumpCount = 0;
        //}
        if(cc.collisionFlags==CollisionFlags.Below)
        {
            velocityY = 0;
            jumpCount = 0;
        }
        else
        {
            velocityY += gravity * Time.deltaTime;
            pos.y = velocityY;
        }
        if(Input.GetButtonDown("Jump")&&jumpCount<2)
        {
            velocityY = jumpPower;
            jumpCount++;
        }
        cc.Move(pos * moveSpeed * Time.deltaTime);
    }
}
