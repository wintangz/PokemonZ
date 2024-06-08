using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;
    [SerializeField] Image image;
    [SerializeField] Sprite green;
    [SerializeField] Sprite yellow;
    [SerializeField] Sprite red;
    [SerializeField] Sprite empty;

    void Start()
    {
    }

    public void SetHP(float hpNormalized)
    {
        if (hpNormalized <= 0.2f)
        {
            image.sprite = red;
        }
        else if (hpNormalized >= 0.2f && hpNormalized <= 0.5f)
        {
            image.sprite = yellow;
        }
        else if (image.sprite != null && hpNormalized >= 0.5f)
        {
            image.sprite = green;
        }
        health.transform.localScale = new Vector3(hpNormalized, 1f);
    }

    public IEnumerator SetHPSmooth(float newHP)
    {
        float curHP = health.transform.localScale.x;
        float changeAmt = curHP - newHP;

        while (curHP - newHP > Mathf.Epsilon)
        {
            curHP -= changeAmt * Time.deltaTime;
            health.transform.localScale = new Vector3(curHP, 1f);
            yield return null;
        }

        if (newHP <= 0.2f)
        {
            image.sprite = red;
        }
        else if (newHP >= 0.2f && newHP <= 0.5f)
        {
            image.sprite = yellow;
        }
        else if (image.sprite != null && newHP >= 0.5f)
        {
            image.sprite = green;
        }
        health.transform.localScale = new Vector3(newHP, 1f);
    }
}
