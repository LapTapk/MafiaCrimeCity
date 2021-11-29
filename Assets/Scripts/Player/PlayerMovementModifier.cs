using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;

using UnityEngine;

public class PlayerMovementModifier : MonoBehaviour
{
    public float TotalValue => _modifiers.Aggregate(1f, (prev, cur) => prev *= cur.Value());
    public float AimingSpeedReduce = 0.7f;
    [HideInInspector] public bool IsAiming = false;
    private Dictionary<int, Func<float>> _modifiers = new Dictionary<int, Func<float>>();

    private void Awake()
    {
        Add(() => (IsAiming ? AimingSpeedReduce : 1));
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

    public void Add(Func<float> modifier, float duration)
    {
        StartCoroutine(CoroutineAddTemp(modifier, duration));
    }

    private IEnumerator CoroutineAddTemp(Func<float> modifier, float duration)
    {
        var id = Add(modifier);

        yield return new WaitForSeconds(duration);

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
