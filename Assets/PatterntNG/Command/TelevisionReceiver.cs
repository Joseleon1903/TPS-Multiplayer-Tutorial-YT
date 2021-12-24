using UnityEngine;
namespace PatterntNG.Commands
{
    class TelevisionReceiver : RemoteControlDevice
    {
        public override void TurnOn()
        {
            Debug.Log("TV turned on.");
        }

        public override void TurnOff()
        {
            Debug.Log("TV turned off.");
        }
    }
}