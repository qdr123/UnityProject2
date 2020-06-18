﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //카메라가 플레이어를 따라다니기
    //플레이어한테 바로 카메라를 붙여서 이동해도 상관없다
    //하지만 게임에 따라서 드라마틱한 연출이 필요한 경우에
    //타겟을 따라다니도록 하는게 1인칭에서 3인칭으로 또는 그반대로 변경이 쉽다
    //또한 순간이동이 아닌 슈팅게임에서 꼬랑지가 따라다니는것같은 효과도 연출이 가능하다
    //지금은 우리 눈 역할을 할거라서 그냥 순간이동 시킨다

    //public Transform target; //카메라가 따라다닐 타겟
    public float speed = 10.0f;
    public Transform target1st; //카메라가 따라다닐 타겟
    public Transform target3rd; //카메라가 따라다닐 타겟
    bool isFPS = true;          //1인칭이냐? 3인칭이냐?


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //카메라 위치를 강제로 타겟위치에 고정해둔다
        //transform.position = target.position;

        //FollowTarget();

        //1인칭 to 3인칭, 3인칭 to 1인칭으로 카메라 변경
        ChangeView();
    }

    private void ChangeView()
    {
        if(Input.GetKeyDown("1"))
        {
            isFPS = true;
        }
        if(Input.GetKeyDown("3"))
        {
            isFPS = false;
        }

        if(isFPS)//1인칭이냐?
        {
            //카메라 위치를 강제로 타겟위치에 고정해둔다
            transform.position = target1st.position;
        }
        else//3인칭이냐?
        {
            //카메라 위치를 강제로 타겟위치에 고정해둔다
            transform.position = target3rd.position;
        }
           
    }

    //타겟을 따라다니기
    private void FollowTarget()
    {
        //타겟방향 구하기 (벡터의 뺄셈)
        //방향 = 타겟 - 자기자신
        //Vector3 dir = target.position - transform.position;
        //dir.Normalize();
        //transform.Translate(dir * speed * Time.deltaTime);
        //
        ////문제점 : 타겟에 도착하면 덜덜덜 거림
        //if(Vector3.Distance(transform.position, target.position) < 1.0f)
        //{
        //    transform.position = target.position;
        //}
    }
}
