using TPS.Share;
using UnityEngine;

namespace TPS.Script.Players
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] Shooter assaultRifle;

        void Update()
        {

            if (GameManager.Instance.InputController.Fire1)
            {
                assaultRifle.Fire();
            }
        }
    }
}