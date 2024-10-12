#define UNITY_IOS

using UnityEngine;
using System.Collections.Generic;

namespace Core.Objects
{

    public static class DynamicInstanceManager
    {
#if UNITY_EDITOR
        static DynamicInstanceManager()
        {
            UnityEditor.EditorApplication.playModeStateChanged += (state) =>
            {
                switch (state)
                {
                    case UnityEditor.PlayModeStateChange.ExitingPlayMode:
                        {
                            for(int i = 0; i< _list.Count; ++i)
                            {
                                Release(_list[i]);
                            }
                            _list.Clear();
                            return;
                        }
                }
            };
        }
#endif

        private static int _count = 0;


        private readonly static List<IDynamicInstance> _list = new();
        internal static void Regist(IDynamicInstance instance) => _list.Add(instance);
        internal static void Release(IDynamicInstance instance)
        {
            if (instance != null)
            {
                _list.Remove(instance);

                instance.Destroy();


            }
        }
    }
}