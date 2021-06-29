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

    private eCharacterType m_curCharacterType = eCharacterType.CT_Pc;

    private int m_pcLastIdx = 3;
    private int m_monLastIdx = 3;
    private int m_bossLastIdx = 3;


    void Start()
    {
        ChangeActive();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            m_curCharacterType++;
            if(eCharacterType.CT_Count <= m_curCharacterType)
                m_curCharacterType = eCharacterType.CT_Pc;

            ChangeActive();
        }


        if(Input.GetKeyDown(KeyCode.A))
        {

        }


        if(Input.GetKeyDown(KeyCode.I))
        {
            AddCharacter();
        }
    }


    private void ChangeActive()
    {

    }


    private void AddCharacter()
    {
        
    }
}
