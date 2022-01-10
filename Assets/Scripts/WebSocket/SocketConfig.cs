using UnityEngine;

namespace Assets.Script.WebSocket
{
    class SocketConfig : MonoBehaviour
    {
        // Server IP address
        [SerializeField]
        private string hostIP;

        // Server port
        [SerializeField]
        private int port = 8080;

        // Flag to use localhost
        [SerializeField]
        private bool useLocalhost = true;

        [SerializeField]
        private string remoteHost;

        public string GetSocketHost()
        {

            string url = "ws://";

            if (useLocalhost)
            {

                return $"ws://91933459b031.ngrok.io/lobby-manager";

            }

            return url + remoteHost + "/lobby-manager";

        }
    }
}