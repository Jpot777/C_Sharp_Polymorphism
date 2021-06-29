using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    public override void Start()
    {
        BaseStart();
    }

    protected override void Update()
    {
        BaseUpdate();
    }
}
