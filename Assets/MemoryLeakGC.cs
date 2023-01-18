using UnityEngine;

public class MemoryLeakGC : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;

    private void Update()
    {
        for (int i = 0; i < 100; i++)
        {
            var instance = Instantiate(_sprite);
            Destroy(instance);
        }
    }
}