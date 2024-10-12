using UnityEngine;

namespace Core.Objects
{
    public class DynamicMonoInstance<T> : MonoBehaviour , IDynamicInstance
        where T : MonoBehaviour , IDynamicInstance
    {
        private static T _instance;

        public static T Instance
        {
            get
            {

                if(_instance == null)
                {
                    var finds = FindObjectsOfType<T>(true);

                    if(finds.Length == 1)
                    {
                        _instance = finds[0];

                        DynamicInstanceManager.Regist(_instance);
                    }
                    else if(finds.Length == 0)
                    {
                        _instance = new GameObject(typeof(T).Name).AddComponent<T>();

                        DynamicInstanceManager.Regist(_instance);
                    }
                    else
                    {
                        Debug.Assert(finds.Length < 2, "Too many static objects!", finds[^1]);
                    }
                }
                return _instance;
            }
        }

        void IDynamicInstance.Destroy()
        {
            _instance = null;
        }
    }

}