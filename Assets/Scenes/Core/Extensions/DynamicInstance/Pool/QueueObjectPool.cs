using JetBrains.Annotations;
using System.Dynamic;
using UnityEngine;

namespace Core.Objects
{
    public class QueueObjectPool : MonoBehaviour
    {
        private void Awake()
        {
            _cachedTransform = transform;
        }

        private Transform _cachedTransform;

        public int Count => _cachedTransform.childCount;

        public T Rent<T>() where T : Component
        {
            T instance;
            int lastIndex = Count - 1;


            // I1 (true)
            // I2 (false)
            // I3 (false)
            if (Count == 0 ||
                _cachedTransform.GetChild(lastIndex).gameObject.activeSelf is true)
            {
                instance = CreateInstance<T>();
                instance.transform.SetParent(_cachedTransform);
            }
            else
            {
                instance = _cachedTransform.GetChild(lastIndex).GetComponent<T>();
            }
            instance.transform.SetAsFirstSibling();   // 맨위로 
            instance.gameObject.SetActive(true);    // 그 액티브를 true로

            return instance;
        }
        public void Return<T>(T instance)
            where T : Component
        {
            if (instance != null)
            {
                Log(LogType.Warning, "Return instance is NULL");

                return;
            }
            instance.gameObject.SetActive(false);
            instance.transform.SetAsLastSibling();  
        }

        public void DestroyAllOfType<T>()
            where T : Component
        {
            var count = Count;
            for (int i = 0; i < count; ++i)
            {
                var target = _cachedTransform.GetChild(i).gameObject;
                if (target.TryGetComponent<T>(out _))
                {
                    Destroy(target);
                    i--;
                }
            }
        }
        public virtual T CreateInstance<T>()
             where T : Component
        { 
             return new GameObject().AddComponent<T>();        
        }

        [System.Diagnostics.Conditional("DEBUG")]

        private static void Log(LogType type , string message)
             => Debug.unityLogger.Log(type, message);
    }
}
