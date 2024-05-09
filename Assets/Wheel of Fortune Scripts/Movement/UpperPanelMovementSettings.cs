using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WheelOfFortune.Movement.UpperPanel
{
    [CreateAssetMenu(menuName = "Wheel of Fortune/Movement/UpperPanel Movement Settings")]

    public class UpperPanelMovementSettings : ScriptableObject
    {
        [SerializeField] private float _nextRoundMovementDuration = 0.5f;

        public float NextRoundMovementDuration { get { return _nextRoundMovementDuration; } }

    }
}
