using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class PlayerMovementModifier
{
    public float TotalValue => _modifiers.Aggregate(1f, (prev, cur) => prev *= cur.Value());
    [HideInInspector] public bool IsAiming = false;
    public float AimingSpeedReduce = 0.7f;
    private Dictionary<int, Func<float>> _modifiers = new Dictionary<int, Func<float>>();

    public PlayerMovementModifier()
    {
        _modifiers.Add(0, () => (IsAiming ? AimingSpeedReduce : 1));
    }

    public int Add(Func<float> modifier)
    {
        var id = GenerateID();
        _modifiers.Add(id, modifier);

        return id;
    }

    public void Remove(int id)
    {
        _modifiers.Remove(id);
    }

    public async void AddTempAsync(Func<float> modifier, float duration)
    {
        var id = Add(modifier);

        await Task.Delay((int)(duration * 1e3));

        Remove(id);
    }

    private int GenerateID()
    {
        var rnd = new System.Random();
        int val;

        do
            val = rnd.Next();
        while (_modifiers.ContainsKey(val));

        return val;
    }
}
