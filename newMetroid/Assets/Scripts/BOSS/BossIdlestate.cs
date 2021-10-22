using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class BossIdleState : BossIState//Õ¾Á¢×´Ì¬
{
    private BOSSFSM Bossmanager;
    private BossParameter parameter;
    private float timer;
    public BossIdleState(BOSSFSM Bossmanager)
    {
        this.Bossmanager = Bossmanager;
        this.parameter = Bossmanager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Boss");
        Debug.Log("Õ¾Á¢");
    }


    public void OnUpdate()
    {
        timer += Time.deltaTime;
        
        int modelindex = Random.Range(0, 4);
         //int modelindex =2;
        if (timer >= parameter.idleTime)
        {
            if (modelindex==0)
            {
                Bossmanager.TransitionState(BossStateType.BossIdle);
                Debug.Log("Õ¾Á¢");
            }
            if (modelindex ==1)
            {
                Bossmanager.TransitionState(BossStateType.BossChase);
                Debug.Log("×·»÷");
            }
            if (modelindex == 2)
            {
                Bossmanager.TransitionState(BossStateType.BossCharge);
                Debug.Log("³å·æ");
            }
            if (modelindex ==3)
            {
                Bossmanager.TransitionState(BossStateType.BossCharge);
                Debug.Log("Í¶ÖÀ");
            }
            


        }

            
            

            

       
            

           
       

    }
    public void OnExit()
    {

    }




}
   
    

   



public class BossChaseState : BossIState
{
    public bool chase = true;
    private BOSSFSM manager;
    private BossParameter parameter;
    private float timer = 0;
    

    

    public BossChaseState(BOSSFSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
        
    }
    
    public void OnEnter()
    {
        

    }


    public void OnUpdate()
    {
        
        timer += Time.deltaTime;
        manager.FlipTO(parameter.target);
        
        if (timer<=10)
        {
            manager.transform.up = parameter.target.position - manager.transform.position;
            manager.transform.position = Vector2.MoveTowards(manager.transform.position,
        parameter.target.position, parameter.chaseSpeed * Time.deltaTime);//×·»÷Íæ¼Ò
        }
        if (timer>10)
        {
           manager.TransitionState(BossStateType.BossIdle);
            timer = 0;
        }
       
        
    }

    
    public void OnExit()
    {
        
    }
}

public class BossChargeState : BossIState
{
    private BOSSFSM Bossmanager;
    private BossParameter parameter;
    private float timer = 0;
    public BossChargeState(BOSSFSM Bossmanager)
    {
        this.Bossmanager = Bossmanager;
        this.parameter = Bossmanager.parameter;
    }
    public void OnEnter()
    {
        int modelindex = Random.Range(0, 3);
        if (modelindex == 0)
        {
            Bossmanager.transform.position = new Vector3(11, -3, 0);
        }
        if (modelindex == 1)
        {
            Bossmanager.transform.position = new Vector3(11, 0, 0);
        }
        if (modelindex == 2)
        {
            Bossmanager.transform.position = new Vector3(11, 3, 0);
        }

    }



    public void OnUpdate()
    {

        //int modelindex = Random.Range(0, 3);
        int modelindex = 0;
        if (modelindex == 0)
        {
            timer += Time.deltaTime;
            
            
            if (timer <= 1.25)
            {
               Bossmanager.transform.position = Bossmanager.transform.position-new Vector3 ( parameter.chargeSpeed * Time.deltaTime,0,0);
            }
            if (timer >1.25)
            {
                Bossmanager.TransitionState(BossStateType.BossIdle);
                timer = 0;
            }
        }
        
    }

    public void OnExit()
    {
        
       
    }
}

public class BossThrowState : BossIState
{
    private BOSSFSM Bossmanager;
    private BossParameter parameter;

    public BossThrowState(BOSSFSM Bossmanager)
    {
        this.Bossmanager = Bossmanager;
        this.parameter = Bossmanager.parameter;
    }
    public void OnEnter()
    {

    }


    public void OnUpdate()
    {

    }

    public void OnExit()
    {

    }
}