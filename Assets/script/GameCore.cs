using UnityEngine;

namespace Game
{
    public abstract class IGameSystemMono : MonoBehaviour
    {
        public virtual void StartGameSystem(){}
        public virtual void DestoryGameSystem(){}
    }

    public sealed class GameCore : MonoBehaviour
    {
        public static GameObject InstanceGameObject;
        private static GameSystemManager m_SystemManager;
        private static bool m_bIsInitialized = false;

        private void Awake()
        {
            if (m_bIsInitialized)
            {
                Debug.LogError("[GameCore] was initialized");
                Object.Destroy(this);
            }
            else
            {
                m_bIsInitialized = true;
                transform.name = "[GameCore]";
                GameObject.DontDestroyOnLoad(this.gameObject);
                InstanceGameObject = this.gameObject;
                m_SystemManager = new GameSystemManager(InstanceGameObject);
            }
        }

        void Start()
        {
            m_SystemManager.StartInitialSystem();
        }

        // *** System manager method ***
        public static void AddSystem<T>() where T : IGameSystemMono
        {
            m_SystemManager.AddSystem<T>();
        }

        public static void RemoveSystem<T>() where T : IGameSystemMono
        {
            m_SystemManager.RemoveSystem<T>();
        }

        public static void EnableSystem<T>() where T : IGameSystemMono
        {
            m_SystemManager.EnableSystem<T>();
        }

        public static void DisableSystem<T>() where T : IGameSystemMono
        {
            m_SystemManager.DisableSystem<T>();
        }

        public static T GetSystem<T>() where T : IGameSystemMono
        {
            return m_SystemManager.GetSystem<T>();
        }
    }
}