using UnityEngine;

public class MeleeEnemyLife : CharacterLife
{
    protected override void Die()
    {
        Debug.Log("Melee enemy died!");
    }
}
