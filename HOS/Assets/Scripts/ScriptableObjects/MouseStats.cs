using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HOS;

[CreateAssetMenu (menuName = "PluggableAI/EnemyStats")] 
public class MouseStats : ScriptableObject {

    public float moveSpeed = 1;
    public float lookRange = 40f;
    public float lookSphereCastRadius = 1f;

    public float attackDamage = 10;

    public float searchDuration = 4f;
    public float searchingTurnSpeed = 120f;


}
