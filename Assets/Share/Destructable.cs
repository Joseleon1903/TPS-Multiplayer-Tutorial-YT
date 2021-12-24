using UnityEngine;

namespace TPS.Share
{
    public class Destructable : MonoBehaviour
    {
        [SerializeField] float hitPoints;

        public event System.Action OnDeath;

        public event System.Action OnDamageRecive;

        float damageTaken;

        public float HitPointsRemaining
        {

            get { return hitPoints - damageTaken; }
        }

        public bool IsAlive
        {

            get { return HitPointsRemaining > 0; }
        }

        public virtual void Die()
        {

            if (!IsAlive)
                return;

            if (OnDeath != null)
                OnDeath();

        }

        public virtual void TakeDamanage(float amount)
        {
            damageTaken += amount;

            if (OnDamageRecive != null)
                OnDamageRecive();

            if (HitPointsRemaining <= 0)
            {
                Die();
            }

        }

        public void Reset()
        {
            damageTaken = 0;
        }

    }
}