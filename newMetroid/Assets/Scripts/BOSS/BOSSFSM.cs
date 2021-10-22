using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum BossStateType
{
    BossIdle,  BossChase, BossCharge, BossThrow
}
[Serializable]

public class BossParameter
{
    public int health;
    public float Speed;
    public float chaseSpeed;
    public float idleTime;
    public float chargeSpeed;
    public Animator animator;
    public Transform target;
    public LayerMask targetLayer;
    public Transform attackPoint;
    public float attackArea;
    public Transform enemy;
    public float enemyvalue;
}

public class BOSSFSM : MonoBehaviour

{
    public BossParameter parameter;
    private BossIState currentState;
    private Dictionary<BossStateType, BossIState> states = new Dictionary<BossStateType, BossIState>();


    void Start()//添加各状态到字典
    {
        states.Add(BossStateType.BossIdle, new BossIdleState(this ));
        states.Add(BossStateType.BossChase, new BossChaseState(this));
        states.Add(BossStateType.BossCharge, new BossChargeState(this));
        states.Add(BossStateType.BossThrow, new BossThrowState(this));
        TransitionState(BossStateType.BossIdle);

        parameter.animator = GetComponent<Animator>();
    

    }

  

    void Update()
    {
        currentState.OnUpdate();
        
    }
    public void FlipTO(Transform target)//使怪物朝向正常
    {
        if (target != null)
        {
            if (transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(9, 9, 9);

            }
            else if (transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(-9, 9, 9);
            }
        }
    }

    public void TransitionState(BossStateType type)
    {
        if (currentState! != null)
            currentState.OnExit();

        currentState = states[type];

        currentState.OnEnter();
    }
}




// Start is called before the first frame update
