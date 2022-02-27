using TPS.Share;
using UnityEngine;


namespace TPS.Script.Combat
{
    public class WeaponReloader : MonoBehaviour
    {
        [SerializeField] int maxAmmo;
        [SerializeField] float reloadTime;
        [SerializeField] int clipSize;

        [SerializeField] Container inventory;

        public int shotsFiredInClip;
        bool isReloading;
        System.Guid conteinerId;

        public int RoundsRemaningInCLip
        {
            get { return clipSize - shotsFiredInClip; }
        }

        public bool IsReloading
        {

            get { return isReloading; }
        }

        void Awake() {
            conteinerId = inventory.Add(this.name, maxAmmo);
        }

        public void Reload()
        {
            if (isReloading)
            {
                return;
            }
            print("Reload Executed");

            isReloading = true;
            GameManager.Instance.Timer.Add(() => {
                ExecuteReload(inventory.TakeFromConteiners(conteinerId, clipSize - RoundsRemaningInCLip));
                }, reloadTime);
        }

        private void ExecuteReload(int amount)
        {
            print("Reload Complete");
            isReloading = false;
            shotsFiredInClip -= amount;
        }

        public void TakeFromClip(int clip)
        {
            shotsFiredInClip += clip;
        }

    }
}