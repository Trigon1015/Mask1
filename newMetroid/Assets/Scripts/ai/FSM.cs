using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum StateType
{
    Idle,Patrol,Chase,React,Attack,Hit
}
[Serializable ]

public class Parameter
{
    public int health;
    public float moveSpeed;
    public float chaseSpeed;
    public float idleTime;
    public Transform[] patrolPoints;
    public Transform[] chasePoints;
    public Animator animator;
    public Transform target;
    public LayerMask targetLayer;
    public Transform attackPoint;
    public float attackArea;
    public Transform enemy ;
    public float enemyvalue;
    

}
public class FSM : MonoBehaviour
   
{
    public Parameter parameter;
    private IState currentState;
    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>() ;

 
   

    // Start is called before the first frame update
    void Start()//添加各状态到字典
    {
        states.Add(StateType.Idle, new IdleState(this ));
        states.Add(StateType.Patrol, new PatrolState(this ));
        states.Add(StateType.Chase , new ChaseState(this ));
        states.Add(StateType.React , new ReactState(this ));
        states.Add(StateType.Attack , new AttackState(this ));

        TransitionState(StateType.Idle);

        parameter.animator = GetComponent<Animator>();
        parameter.target = null;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
    }

    public  void TransitionState(StateType type)
    {
        if (currentState! != null)
            currentState.OnExit();
        
        currentState = states[type];
       
        currentState.OnEnter();
    }

    public  void FlipTO(Transform target)//使怪物朝向正常
    {
        if (target != null )
        {
            if (transform .position .x >target .position .x )
            {
                transform.localScale = new Vector3(5, 5, 5);
                
            }
            else if (transform .position .x <target .position .x )
            {
                transform.localScale = new Vector3(-5, 5, 5);
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)//检测玩家是否进入怪物视野
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = other.transform;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)//检测玩家是否离开怪物视野
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = null;
           
        }
    }

   // private void OnDrawGizmos()
   // {
   //     Gizmos.DrawWireSphere(parameter.attackPoint.position, parameter.attackArea); 
   // }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parameter.enemy .position, parameter.enemyvalue );
    }
}
