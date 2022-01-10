using Assets.Script.WebSocket;
using Assets.Scripts.WebSocket;
using UnityEngine;

[RequireComponent(typeof(SocketConfig))]
public class ServerCommunication : MonoBehaviour
{

    // Final server address
    private SocketConfig serverConfig;

    private string server;

    // WebSocket Client 
    private WsClient client;

    /// <summary>
    /// Unity method called on initialization
    /// </summary>
    private void Awake()
    {
        serverConfig = GetComponent<SocketConfig>();
        server = serverConfig.GetSocketHost();
        client = new WsClient(server);
    }

    /// <summary>
    /// Unity method called every frame
    /// </summary>
    private void Update()
    {
        // Check if server send new messages
        var cqueue = client.receiveQueue;
        string msg;
        while (cqueue.TryPeek(out msg))
        {
            // Parse newly received messages
            cqueue.TryDequeue(out msg);
            HandleMessage(msg);
        }
    }

    /// <summary>
    /// Method responsible for handling server messages
    /// </summary>
    /// <param name="msg">Message.</param>
    private void HandleMessage(string msg)
    {
        Debug.Log("Server: " + msg);
    }


    /// <summary>
    /// Call this method to connect to the server
    /// </summary>
    public async void ConnectToServer()
    {
        await client.Connect();
    }

    /// <summary>
    /// Method which sends data through websocket
    /// </summary>
    /// <param name="message">Message.</param>
    public void SendRequest(string message)
    {
        client.Send(message);
    }

    public async void DisconectToServer()
    {
        await client.Disconect();
    }
}