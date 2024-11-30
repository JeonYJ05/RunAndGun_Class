using System.Collections.Generic;

namespace YeonYJ.Core.Items
{
    public enum ItemType : int
    {
        None = 0,
        Weapon,     //  무기
        Consumable, //  소비성 아이템. (포션 등등..)
    }

    //  이 클래스는 정말 '아이템' 이라는 데이터만 관리한다
    //  추가, 생성, 물리데이터 저장, 불러오기
    public static class ItemManager
    {
        private static readonly Dictionary<string, IBaseItemDescription> _items = new();

        //  물리데이터로 저장
        public static void Save()
        {
            //  Newtonsofr.JsonConvert.Serialize
            //  JsonSerializer
        }

        public static void Load()
        {
            //  Newtonsofr.JsonConvert.Deserialize
            //  JsonSerializer
        }

        //  아이템을 추가한다.
        public static T GetItem<T>() where T : class, IBaseItemDescription
        {
            foreach (var i in _items)
            {
                if (i.Value.GetType() == typeof(T))
                {
                    return (T)i.Value;
                }
            }

            return null;
        }

        public static T GetItem<T>(string name) where T : class, IBaseItemDescription
        {
            if (_items.TryGetValue(name, out var item))
            {
                return (T)item;
            }

            return null;
        }

        public static void AddItem<T>(T item) where T : class, IBaseItemDescription
        {
            if (_items.ContainsValue(item))
            {
                throw new System.ArgumentException($"{typeof(T)}:{item} 아이템은 이미 추가되어 있습니다!");
            }

            _items.Add(typeof(T).Name, item);
        }

        public static void RemoveItem<T>(T item) where T : class, IBaseItemDescription
        {

        }
    }
}
