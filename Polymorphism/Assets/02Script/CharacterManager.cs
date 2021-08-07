using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum eCharacterType
{
    CT_Pc,
    CT_Mon,
    CT_Boss,
    CT_Count,

    None
}


public class CharacterManager : MonoBehaviour
{
    public GameObject m_characterObjRoot = null;

    [SerializeField] private eCharacterType m_curCharacterType = eCharacterType.CT_Pc;

    private int m_pcLastIdx = 3;
    private int m_monLastIdx = 3;
    private int m_bossLastIdx = 3;


    void Start()
    {
        ChangeActive();
    }

    void Update()
    {
        // === 캐릭터 타입 변경 === //
        if(Input.GetKeyDown(KeyCode.C))
        {
            m_curCharacterType++;
            if(m_curCharacterType >= eCharacterType.CT_Count)
                m_curCharacterType = eCharacterType.CT_Pc;

            ChangeActive();
        }
        // === 캐릭터 타입 변경 === //


        // === 캐릭터별 고유 행동 === //
        if(Input.GetKeyDown(KeyCode.A))
        {
           Unit[] a_charArr = m_characterObjRoot.GetComponentsInChildren<Unit>(true);

           foreach(Unit a_char in a_charArr)
           {
               if(a_char.gameObject.activeSelf == true)
                    a_char.Attack();
           }
        }
        // === 캐릭터별 고유 행동 === //


        // === 캐릭터 동적 스폰 === //
        if(Input.GetKeyDown(KeyCode.I))
        {
            AddCharacter();
        }
        // === 캐릭터 동적 스폰 === // 
    }


    private void ChangeActive()
    {
        // C# 의 as 연산자는 객체를 지정된 클래스 타입으로 변환하는데 사용한다!
        // 만약 변환이 성공하면 해당 클래스 타입으로 캐스팅하고, 변환이 실패하면 null을 리턴한다.
        // 이와는 대조적으로 캐스팅(casting)을 사용하면, 변환이 실패했을 때 Exception을 발생시키게 되는데,
        // 이를 catch하지 않으면 프로그램을 중지하게 된다.

        // Hierarchy에 설치된 오브젝트 중에 Unit을 상속 받은 모든 오브젝트를 찾아 오는 함수
        // Unir[] a_charArr == Resources.FindObjectsOfTypeAll(typeof(Unit)) as Unit[];
        Unit[] a_charArr = m_characterObjRoot.GetComponentsInChildren<Unit>(true);

        foreach(Unit a_char in a_charArr)
        {
            Pc a_Pc = a_char as Pc;
            if(a_Pc != null)
            {
                if(m_curCharacterType == eCharacterType.CT_Pc)
                {
                    a_char.gameObject.SetActive(true);
                }
                else
                {
                    a_char.gameObject.SetActive(false);
                }
            }

            Monster a_mon = a_char as Monster;
            if(a_mon != null)
            {
                if(m_curCharacterType == eCharacterType.CT_Mon)
                {
                    a_char.gameObject.SetActive(true);
                }
                else
                {
                    a_char.gameObject.SetActive(false);
                }
            }

            Boss a_boss = a_char as Boss;
            if(a_boss != null)
            {
                if(m_curCharacterType == eCharacterType.CT_Boss)
                {
                    a_char.gameObject.SetActive(true);
                }
                else
                {
                    a_char.gameObject.SetActive(false);
                }
            }
        }
    }


    private void AddCharacter()
    {
        string a_findStr = "";

        if(m_curCharacterType == eCharacterType.CT_Pc)
        {
            if(m_pcLastIdx >= 5)
                return;

            a_findStr = "Player_" + m_pcLastIdx.ToString();
        }
        else if(m_curCharacterType == eCharacterType.CT_Mon)
        {
            if(m_monLastIdx >= 5)
                return;

            a_findStr = "Mon_" + m_monLastIdx.ToString();
        }
        else if(m_curCharacterType == eCharacterType.CT_Boss)
        {
            if(m_bossLastIdx >= 5)
                return;

            a_findStr = "Boss_" + m_bossLastIdx.ToString();
        }


        Vector3 a_lastPos = Vector3.zero;
        bool a_findName = false;
        Unit[] a_charArr = m_characterObjRoot.GetComponentsInChildren<Unit>(true);

        foreach(Unit a_char in a_charArr)
        {
            if(a_char.gameObject.name == a_findStr)
            {
                a_findName = true;
                a_lastPos = a_char.transform.position;
            }
        }

        if(a_findName == false)
            return;

        a_lastPos.x = a_lastPos.x + 2.55f;

        if(m_curCharacterType == eCharacterType.CT_Pc)
        {
            m_pcLastIdx++;
            GameObject a_rscObj = Resources.Load("PlayerPrefab") as GameObject;
            GameObject a_cloneObj = (GameObject)(GameObject.Instantiate(a_rscObj, a_lastPos, Quaternion.identity));
            a_cloneObj.transform.SetParent(m_characterObjRoot.transform);
            a_cloneObj.name = "Player_" + m_pcLastIdx.ToString();
            a_cloneObj.SetActive(true);
        }
        else if(m_curCharacterType == eCharacterType.CT_Mon)
        {
            Vector3 a_scPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -Camera.main.transform.position.z));

            if(a_scPos.x - .5f < a_lastPos.x)
            {
                a_lastPos.x = -a_scPos.x + .5f + 1.5f;
            }

            m_monLastIdx++;
            GameObject a_rscObj = Resources.Load("MonsterPrefab") as GameObject;
            GameObject a_cloneObj = (GameObject)(GameObject.Instantiate(a_rscObj, a_lastPos, Quaternion.identity));
            a_cloneObj.transform.SetParent(m_characterObjRoot.transform);
            a_cloneObj.name = "Mon_" + m_monLastIdx.ToString();
            a_cloneObj.SetActive(true);
        }
        else if(m_curCharacterType == eCharacterType.CT_Boss)
        {
            m_bossLastIdx++;
            GameObject a_rscObj = Resources.Load("BossPrefab") as GameObject;
            GameObject a_cloneObj = (GameObject)(GameObject.Instantiate(a_rscObj, a_lastPos, Quaternion.identity));
            a_cloneObj.transform.SetParent(m_characterObjRoot.transform);
            a_cloneObj.name = "Boss_" + m_bossLastIdx.ToString();
            a_cloneObj.SetActive(true);
        }
    }
}
