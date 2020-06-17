using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//몬스터 유한상태머신
public class EnemyFSM : MonoBehaviour
{
    //몬스터 상태 
    enum EnemyState
    {
        Idle,Move,Attack,Retrun,Damaged,Die
    }
    //몬스터 상태 이넘문
    EnemyState state;


    /// 유용한 기능
    #region "Idel 상태에 필요한 변수들

    float Distance;
    public float Idis=20.0f;//사이의 거리 
    

    #endregion

    #region "Move 상태에 필요한 변수들
    float speed = 5.0f;
    public Transform target;
    #endregion

    #region "Attack 상태에 필요한 변수들
    #endregion

    #region "Retrun 상태에 필요한 변수들
    public Transform point;


    #endregion

    #region "Damaged 상태에 필요한 변수들
    float damage;
    #endregion

    #region "Die 상태에 필요한 변수들
    #endregion




    // Start is called before the first frame update
    void Start()
    {
        //몬스터 상태 초기화
        state = EnemyState.Idle;
        
    }

    // Update is called once per frame
    void Update()
    {
        //상태에 따른 행동 처리 
        switch (state)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Retrun:
                Retrun();
                break;
            case EnemyState.Damaged:
                Damaged();
                break;
            case EnemyState.Die:
                Die();
                break;
            default:
                break;
        }//end of  void Update
    }

    private void Idle()
    {
        //1. 플레이어와 일정범위가 되면 이동상태로 변경(탐지범위)
        //- 플레이어 찾기 (GameObject.Find("Player"))
        //- 일정거리 20미터 (거리비교 :  Distance, magnitud

        Distance = Vector3.Distance(transform.position, target.position);
        if(Distance <= Idis)
        {
            state = EnemyState.Move;
        }
       
       
        //- 상태전환 출력
        Debug.Log("Idle");
    }

    private void Move()
    {
        //1. 플레이어를 향해 이동 후 공격범위 안에 들어오면 공격상태로 변경
        //2. 플레이어를 추격하더라도 처음위치에서 일정범위를 넘어가면 
        //- 플레이어 처럼 캐릭터컨트롤러를 이용하기 
        //- 공격범위 1미터
        Distance = Vector3.Distance(transform.position, target.position);
        Vector3 targetPosition = target.position;
        Vector3 myposition = transform.position;

        transform.position = Vector3.MoveTowards(myposition, targetPosition, speed * Time.deltaTime);
        transform.LookAt(target.transform);
        //- 상태변경 
        if (Distance > Idis)
        {
            state = EnemyState.Retrun;
        }
        //- 상태전환 출력
        Debug.Log("Move");
        
    }

    private void Attack()
    {
        //1. 플레이어가 공격범위 안에 있다면 일정한 시간 간격으로 플레이어 공격
        //2. 플레이어가 공격범위를 벗어나면 이동상태(재추격)로 변경
        //-공격범위 1미터 


        //-상태변경 
        //state = EnemyState.Attack;
        //-상태전환 출력
        Debug.Log("Attack");
    }

    private void Retrun()
    {
        //1. 몬스터가 플레이어를 추격하더라도 처음 위치에서 일정 범위를 벗어나면 다시 돌아옴
        //- 처음위치에서 일정범위 30미터
        Distance = Vector3.Distance(transform.position, target.position);
        transform.position = Vector3.MoveTowards(transform.position,point.position, speed * Time.deltaTime);
        transform.LookAt(point.transform);
        if (Distance <= Idis)
        {
            state = EnemyState.Move;
        }

        //- 상태변경
        //state = EnemyState.Retrun;
        //- 상태전환 출력
        Debug.Log("Retrun");
    }

    private void Damaged()
    {
        //코루틴을 사용하자
        //1. 몬스터 체력이 1이상
        //2. 다시 이전상태로 변경


        //- 상태변경
        state = EnemyState.Damaged;
        //- 상태전환 출력
        Debug.Log("Damaged");
    }

    private void Die()
    {
        //코루틴을 사용하자
        //1. 체력이 0이하
        //2. 몬스터 오브젝트 삭제
        
        //- 상태변경
        state = EnemyState.Die;
        //- 상태전환 출력
        Debug.Log("죽음");
    }
}
