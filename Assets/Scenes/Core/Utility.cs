using UnityEngine;

namespace Core
{
    public static class Utility
    {
        public static Quaternion Euler2D(Vector2 position , Vector2 point)                 // 0���� ��ü ���ʹϾ����� 
        {
            var dir = point - position; 
            var angle = Mathf.Atan2(dir.y , dir.x) * Mathf.Rad2Deg - 90f;

            return Quaternion.Euler(0,0,angle);
        }
    }
}