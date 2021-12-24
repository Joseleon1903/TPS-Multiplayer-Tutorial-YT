﻿using UnityEngine;
using TPS.Script.Players;

namespace TPS.Script.GameCamera
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        [SerializeField] Vector3 cameraOffset;
        [SerializeField] float damping;

        Transform cameraLookTarget;

        Players.Player localPlayer;

        void Awake()
        {
            // listening the gameManager event OnLocalPlayerJoined for execute HandlerOnLocalPlayerJoined
            //GameManager.Instance.OnLocalPlayerJoined += HandlerOnLocalPlayerJoined;

            print("Join a player");
            localPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Players.Player>();
            cameraLookTarget = localPlayer.transform.Find("CameraLookTarget");

            if (cameraLookTarget == null)
                cameraLookTarget = localPlayer.transform;
        }

        private void HandlerOnLocalPlayerJoined(Players.Player player)
        {
            print("Join a player");
            localPlayer = player;
            cameraLookTarget = localPlayer.transform.Find("CameraLookTarget");

            if (cameraLookTarget == null)
                cameraLookTarget = localPlayer.transform;

        }

        void Update()
        {

            Vector3 targetPosition = cameraLookTarget.position +
                localPlayer.transform.forward * cameraOffset.z +
                localPlayer.transform.up * cameraOffset.y +
                localPlayer.transform.right * cameraOffset.x;

            Quaternion targetRotation = Quaternion.LookRotation(cameraLookTarget.position - targetPosition, Vector3.up);

            transform.position = Vector3.Lerp(transform.position, targetPosition, damping * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, damping * Time.deltaTime);

        }



    }
}