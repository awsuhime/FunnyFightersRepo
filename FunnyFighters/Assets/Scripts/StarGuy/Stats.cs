using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float damageBonus = 1;
    private Dictionary<string, float> damagePercentage = new Dictionary<string, float>();
    private Dictionary<string, float> damageDurations = new Dictionary<string, float>();
    private Dictionary<string, float> damDurStart = new Dictionary<string, float>();

    public void Update()
    {
        
        foreach(string i in damagePercentage.Keys)
        {
            float left = Time.time - damDurStart[i];
            if (left > damageDurations[i])
            {
                damageBonus /= damagePercentage[i];
                damagePercentage.Remove(i);
                damageDurations.Remove(i);
                damDurStart.Remove(i);
            }
        }
    }
    public void damageBuff(string name, float percent, float duration)
    {
        if (!damageDurations.ContainsKey(name))
        {
            damageBonus *= percent;
            damagePercentage[name] = percent;
            damageDurations[name] = duration;
            damDurStart[name] = Time.time;

        }
        else
        {
            damDurStart[name] = Time.time;
        }
    }

    public void testBuff()
    {
        damageBuff("Test", 2, 5);
    }
}
