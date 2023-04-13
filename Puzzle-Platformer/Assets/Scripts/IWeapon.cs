using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    float GetAttackDamage();
    float GetAttackRange();
    float GetAttackSpeed();
    float Attack();
}
