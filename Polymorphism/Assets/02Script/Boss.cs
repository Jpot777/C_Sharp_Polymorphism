using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    public override void Start()
    {
        BaseStart();

        m_targetColor = new Color(0.0f, 0.0f, 1.0f);            // Boss target color은 '파랑색'
        m_bodyColor = m_targetColor;
    }

    protected override void Update()
    {
        BaseUpdate();

        if(Input.GetKey(KeyCode.M))
        {
            this.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 500.0f));
        }
    }

    /// <Summary>
    /// A 키를 눌렀을 때 Boss Obj에서 실행되는 함수
    /// </Summary>
    public override void Attack()
    {
        this.transform.localScale = new Vector3(1.7f, 1.7f, 1.0f);

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
