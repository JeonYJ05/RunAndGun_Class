//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using UnityEngine;

//namespace YeonYJ.Core.Items
//{
//    //  ���ÿ� �ڵ�. ������� ����.
//    public static class SpriteManager
//    {
//        private static readonly List<Sprite> _sprites = new();

//        public static Sprite GetOrCreate(string assetPath)
//        {
//            //  Resources ���� �ȿ� �ִ� ��θ� ����Ͽ� �ؽ�ó�� �ε��Ѵ�.
//            //  Resources/Weapon/Shotgun �̶�� Sprite�� �ִ� ���
//            //  assetPath = Weapon/Shotgun

//            //  ã�ƺ���
//            var name = Path.GetFileNameWithoutExtension(assetPath);
//            var value = _sprites.FirstOrDefault(x => x.name == name);
//            if (value != null)
//            {
//                return value;
//            }

//            value = Resources.Load<Sprite>(assetPath);
//            _sprites.Add(value);

//            return value;
//        }
//    }
//}