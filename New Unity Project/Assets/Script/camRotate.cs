using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRotate : MonoBehaviour
{
    //각도 조절시 값을 크게 
    public float speed = 150; //회전속도(Time.DeltaTime을 통해 1초에 150도 회전)

    float angleX, angleY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        //Vector3 dir = new Vector3(h, v, 0);
        Vector3 dir = new Vector3(-v, h, 0);
        transform.Rotate(dir * speed * Time.deltaTime);


        //유니티엔진에서 제공해주는 함수를 사용함에 있어서
        // Translate함수는 그래도 사용하데 큰 불편 없음
        // 회전을 담당하는 Rotate함수를 사용하면
        // 우리가 제어하기가 힘듬
        // 인스펙터창의 로테이션값은 우리가 보기 편하게 오일러각도로 표시도지만
        //내부적으로는 쿼터니온으로 회전처리가 되고있다.
        //쿼터니온을 사용하는 이유는 짐벌락현상을 방지할 수 있기 때문에
        //회전을 직접 제어할 때는 Rotate함수는 사용하지 않고
        //트렌스폼의 오일러앵글을 사용하면 된다.

        //P = P0 +vt;
        //transform.position +=dir *speed *Time.deltaTime;
        //각도또한 똑같다.
        //transform.eulerAngles +=dir *speed * Time.deltaTime;
        //카메라 문제(-90~90)고정됐다 풀렸다 하는 문제가 있음
        //직접 회전각도를 제한해서 처리히면 된다.
       //Vector3 angle = transform.eulerAngles;
       //angle += dir * speed * Time.deltaTime;
       //if (angle.x > 60) angle.x = 60;
       //if (angle.x < -60) angle.x = -60;
       //transform.eulerAngles = angle;

        //여기에는 또 문제가 있따.
        //유니티 내부적으로 -각도는 360도를 더해서 처리한다.
        //내가 만든 각도를 가지고 계산처리해야 한다.

        angleX += h * speed * Time.deltaTime;
        angleY += v * speed * Time.deltaTime;
        angleY = Mathf.Clamp(angleY, -60, 60);//= //if (angle.x > 60) angle.x = 60;if (angle.x < -60) angle.x = -60;
        transform.eulerAngles = new Vector3(-angleY, angleX, 0);


        
    }
}
