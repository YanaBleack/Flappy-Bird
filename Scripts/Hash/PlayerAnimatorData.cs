using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorData : MonoBehaviour
{
    public class Params
    {
        public static readonly int Go = Animator.StringToHash("Go");
        public static readonly int Attack = Animator.StringToHash("Attack");
    }
}