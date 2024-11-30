//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using UnityEngine;

//namespace YeonYJ.Core.Items
//{
//    //  예시용 코드. 사용하지 않음.
//    public static class SpriteManager
//    {
//        private static readonly List<Sprite> _sprites = new();

//        public static Sprite GetOrCreate(string assetPath)
//        {
//            //  Resources 폴더 안에 있는 경로를 사용하여 텍스처를 로드한다.
//            //  Resources/Weapon/Shotgun 이라는 Sprite가 있는 경우
//            //  assetPath = Weapon/Shotgun

//            //  찾아보기
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