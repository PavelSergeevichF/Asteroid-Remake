using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserView : MonoBehaviour
{
    [SerializeField] private SOBullet _sOLaser;

    public SOBullet SOLaser => _sOLaser;
}
