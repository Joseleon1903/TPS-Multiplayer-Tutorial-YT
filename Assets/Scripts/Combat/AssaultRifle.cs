public class AssaultRifle : Shooter
{


    public override void Fire()
    {
        base.Fire();

        if (canFire) { 
            //we fire the gun
        
        }

    }

    void Update() {

        if (GameManager.Instance.InputController.Reload) { 
            Reload();
        }

    
    }
}
