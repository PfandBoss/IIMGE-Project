using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FighterStats", menuName = "ScriptableObjects/Fighting", order = 1)]
public class FightingStats : ScriptableObject
{
    public float punchSpeed;
    public int baseDamage;
    public float attackMultiplier;
    public float knockback;
    public float comboCooldown;
}
