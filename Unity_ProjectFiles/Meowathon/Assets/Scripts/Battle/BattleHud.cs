using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;
    Cat _cat;

    public void SetData(Cat cat)
    {
        _cat = cat;
        nameText.text = cat.Base.Name;
        levelText.text = "Lvl " + cat.Level;
        hpBar.SetHP((float) cat.HP / cat.MaxHp);
    }
    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float) _cat.HP / _cat.MaxHp);
    }

}
