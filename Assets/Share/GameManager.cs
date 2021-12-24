using TPS.Script.Controllers;
using TPS.Script.Players;
using UnityEngine;

namespace TPS.Share
{
    public class GameManager
    {
        public event System.Action<Player> OnLocalPlayerJoined;

        private GameObject gameobject;

        private static GameManager m_Instance;

        public static GameManager Instance
        {

            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new GameManager();
                    m_Instance.gameobject = new GameObject("_gameManager");
                    m_Instance.gameobject.AddComponent<InputController>();
                    m_Instance.gameobject.AddComponent<Timer>();
                    m_Instance.gameobject.AddComponent<Respawner>();
                }
                return m_Instance;
            }
        }

        private InputController m_InputController;

        public InputController InputController
        {
            get
            {
                if (m_InputController == null)
                {
                    m_InputController = gameobject.GetComponent<InputController>();
                }
                return m_InputController;
            }
        }

        private Player m_LocalPlayer;

        public Player LocalPlayer
        {

            get
            {
                return m_LocalPlayer;
            }

            set
            {
                m_LocalPlayer = value;
                if (OnLocalPlayerJoined != null)
                {
                    OnLocalPlayerJoined(m_LocalPlayer);
                }
            }
        }

        private Timer m_timer;

        public Timer Timer
        {
            get
            {
                if (m_timer == null)
                {
                    m_timer = gameobject.GetComponent<Timer>();
                }
                return m_timer;
            }
        }

        private Respawner m_respawner;

        public Respawner Respawner
        {
            get
            {
                if (m_respawner == null)
                {
                    m_respawner = gameobject.GetComponent<Respawner>();
                }
                return m_respawner;
            }
        }

    }
}