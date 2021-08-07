using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Unit
{
    public override void Start()
    {
        base.Start();

        m_targetColor = new Color(0.0f, 1.0f, 0.0f);        // Monster target color은 '초록색'
        m_bodyColor = m_targetColor;
    }

    public void BaseStart()
    {
        base.Start();       // Monster 스크립트의 Start 부분을 우회해서 조부모 class 함수만 호출하고 싶은 경우!
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKey(KeyCode.M))
        {
            this.transform.Translate(Vector3.right * 20.0f * Time.deltaTime);

            Vector3 a_scPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -Camera.main.transform.position.z));

            if(a_scPos.x - .5f < this.transform.position.x)
            {
                this.transform.position =  
                                    new Vector3(-a_scPos.x + .5f, this.transform.position.y, this.transform.position.z);
            }
        }
    }
    
    public void BaseUpdate()
    {
        base.Update();          // Monster 스크립트의 Update 부분을 우회해서 조부모 class함수만 호출하고 싶은 경우!
    }

    /// <Summary>
    /// A 키를 눌렀을 때 Monster Obj에서 실행되는 함수
    /// </Summary>
    public override void Attack()
    {
        this.transform.localScale = new Vector3(1.0f, 1.7f, 1.0f);

        Invoke("ReturnAt", .5f);
    }

    /// <Summary>
    /// Attack 함수 호출 이후 .5초 뒤 호출될 함수 (크기 초기화)
    /// </Summary>
    private void ReturnAt()
    {
        this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}
