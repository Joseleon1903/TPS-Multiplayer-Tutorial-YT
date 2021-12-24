﻿using TPS.Share;
using UnityEngine;

namespace TPS.Script.Combat
{
    public class Health : Destructable
    {

        [SerializeField] float inSeconds;

        public override void Die()
        {
            base.Die();

            GameManager.Instance.Respawner.Despawn(gameObject, inSeconds);

            print("We Die");
        }

        void OnEnable()
        {

            Reset();
        }

        public override void TakeDamanage(float amount)
        {
            print("Remain : " + HitPointsRemaining);

            base.TakeDamanage(amount);
        }
    }
}