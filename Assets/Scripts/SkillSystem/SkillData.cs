using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// weapon type
/// </summary>
public enum weaponType
{
    Long,
    Short,
    Curved
}

/// <summary>
/// effect by the net attack
/// </summary>
public enum netAttackEffect
{
    TwoSecond,
    FourSecond,
    Forever,
    Dodge
}

/// <summary>
/// armor type
/// </summary>
public enum armorType
{
    None,
    Light,
    Medium,
    Heavy
}

/// <summary>
/// shield type
/// </summary>
public enum shieldType
{
    None,
    Large
}

/// <summary>
/// This is Skill Data Store Template 
/// </summary>
[CreateAssetMenu(menuName = "Skill Data", fileName = "New Skill Data")]
public class SkillData : ScriptableObject
{
    [Header("Gladiator State")]
    [SerializeField] weaponType weaponType;
    [SerializeField] armorType armorType;
    [SerializeField] public float speedValue;
    [SerializeField] netAttackEffect netAttackEffect;
    [SerializeField] shieldType shieldType;
    [SerializeField] bool hasNet;

    [Header("Attack Damage")]
    [SerializeField] public float attackDamage;
    [SerializeField] public float skillDamage;

    [Header("Cooldown Time")]
    [SerializeField] public float attackCooldown;
    [SerializeField] public float skillCooldown;

}
