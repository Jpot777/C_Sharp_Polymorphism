using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private MeshRenderer m_renderer = null;
    private bool m_tiktok = true;
    protected Color m_bodyColor = Color.white;
    protected Color m_targetColor = Color.white;


    public virtual void Start()
    {
        m_renderer = this.gameObject.GetComponent<MeshRenderer>();        
    }

    protected virtual void Update()
    {
        if(m_renderer != null)
        {
            if(m_tiktok == true)
            {
                m_bodyColor = Color.Lerp(m_bodyColor, Color.white, 1.7f * Time.deltaTime);      // => 몸체 색을 흰색으로

                if(.9f < m_bodyColor.r && 
                    .9f < m_bodyColor.g && 
                    .9f < m_bodyColor.b)
                        m_tiktok = false;
            }
            else
            {
                m_bodyColor = Color.Lerp(m_bodyColor, m_targetColor, 1.7f * Time.deltaTime);    // => 몸체 색을 target색으로

                if(m_bodyColor.r < m_targetColor.r + .1f &&
                    m_bodyColor.g < m_targetColor.g + .1f &&
                    m_bodyColor.b < m_targetColor.b + .1f)
                        m_tiktok = true;
            }

            m_renderer.material.color = m_bodyColor;
        }
    }

    /// <Summary>
    /// A 키를 눌렀을 때 실행되는 함수 (Pc, Monster, Boss)
    /// </Summary>
    public virtual void Attack()
    {
        this.transform.localScale = new Vector3(.1f, .1f, .1f);
    }
}
