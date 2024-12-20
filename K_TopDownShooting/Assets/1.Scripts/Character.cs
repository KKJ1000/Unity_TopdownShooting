using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float MaxHp = 3;
    public GameObject HPGauge;
    private float HP;
    float HPMaxWidth;

    void Start()
    {
        HP = MaxHp;
        if (HPGauge != null)
        {
            HPMaxWidth = HPGauge.GetComponent<RectTransform>().sizeDelta.x;
        }
    }

    public void Initialize()
    {
        HP = MaxHp;
    }

    //살아있으면 true를 리턴한다.
    public bool Hit(float damage)
    {
        HP -= damage;

        if (HP < 0)
        {
            HP = 0;
        }

        if (HPGauge != null)
        {
            HPGauge.GetComponent<RectTransform>().sizeDelta = new Vector2(HP / MaxHp * HPMaxWidth,
            HPGauge.GetComponent<RectTransform>().sizeDelta.y);
        }
        return HP > 0;
    }
}
