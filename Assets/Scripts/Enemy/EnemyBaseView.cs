using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseView : MonoBehaviour
{
    [SerializeField] private SOEnemyBase _sOEnemyBase;

    public SOEnemyBase SOEnemyBase => _sOEnemyBase;
}
