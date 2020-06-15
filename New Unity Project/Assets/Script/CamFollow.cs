using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    //카메라가 플레이어를 따라다니기
    //플레이어한테 바로 카메라를 붙여서 이동해도 상관없다.
    //하지만 게임에 따라 드라마틱한 연출이 필요한 경우에
    //타겟을 따라 다니도록 하는게 1인칭에서 3인칭으로 또는 그반대로 변경이 쉽다.
    // 순간이동이 아닌 슈팅게임에서 꼬랑지가 따라다니는것같은  효과도 연출
    //지금은 우리 눈 역할을 할거라서 그냥 순간이동 시킨다.

    public Transform target;//카메라가 따라다닐 타겟
    public Transform inchng; //3인칭
    public float followSpeed = 10.0f;
    

    bool camoff= false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = target.position;
        
        FollowTarget();
       
    
    }

    private void FollowTarget()
    {
        //타겟방향 구하기(벡터의 뺄셈)
        //방향 = 타겟 - 자기자신
        

        if (Input.GetKey("1"))
        {
            camoff = true;
            
        }
        if (Input.GetKey("2"))
        {
            camoff = false;
           
        }
        if (camoff)
        {
            Vector3 dir = target.position - transform.position;
            dir.Normalize(); 
            transform.Translate(dir * followSpeed * Time.deltaTime);
            //문제전 : 타겟에 도착하면 덜덜덜 거림 
            if (Vector3.Distance(transform.position, target.position) < 1.0f)
            {
                transform.position = target.position;
            }
        }
        if (!camoff)
        {
            transform.position = inchng.transform.position;
           
        }



    }
}
