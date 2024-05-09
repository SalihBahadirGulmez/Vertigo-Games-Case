using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WheelOfFortune.Movement.SpinRotate
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Movement/Spin Rotate Settings")]
    public class SpinRotateSettings : ScriptableObject
    {
        [SerializeField] private float _spinRotateDuration = 4;
        [SerializeField] private int _spinRotateAngleMin = 2000;
        [SerializeField] private int _spinRotateAngleMax = 3000;

        public float SpinRotateDuration { get { return _spinRotateDuration; } }
        public int SpinRotateAngleMin { get { return _spinRotateAngleMin; } }
        public int SpinRotateAngleMax { get { return _spinRotateAngleMax; } }

    }

}
