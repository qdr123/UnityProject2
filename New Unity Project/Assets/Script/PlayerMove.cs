using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 pos;
    public float moveSpeed = 10.0f;
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
        pos = (Vector3.forward * v) + (Vector3.right * h);
        //pos.Normalize();//대각선이동 속도를 상
        this.transform.Translate(pos * moveSpeed * Time.deltaTime);

        pos = Camera.main.transform.TransformDirection(pos);
        //transform.Translate(pos * moveSpeed * Time.deltaTime)
        //심각한 문제 : 하늘 날라다님 , 땅 뚫음, 충돌처리 안됨
        //캐릭터컨트롤러를 사용한다.
        // 

        cc.Move(pos * moveSpeed * Time.deltaTime);
    }
}
