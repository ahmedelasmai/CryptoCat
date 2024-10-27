using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;
    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3(hpNormalized, 1f);
    }
    public IEnumerator SetHPSmooth(float newHp)
    {
        float curHp = health.transform.localScale.x;
        float changeAmt = curHp - newHp; // Change amount should be set correctly

        while (Mathf.Abs(curHp - newHp) > Mathf.Epsilon) // Change condition for the loop
        {
            curHp = Mathf.MoveTowards(curHp, newHp, changeAmt * Time.deltaTime); // Smoothly change
            health.transform.localScale = new Vector3(curHp, 1f);
            yield return null;
        }
        health.transform.localScale = new Vector3(newHp, 1f);
    }

}
