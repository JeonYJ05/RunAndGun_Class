using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Objects
{
    public class DynamicInstance<T> : IDynamicInstance
        where T : class,IDynamicInstance , new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance ??= new T();
                    DynamicInstanceManager.Regist(_instance);
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
