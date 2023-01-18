using System.Collections;
using UnityEngine;

namespace PixelCrew.Components.ColliderBased
{
    [RequireComponent(typeof(Collider2D))]
    public class TmpDisableColliderComponent : MonoBehaviour
    {
        [SerializeField] private float _disableTime = 0.3f;
        private Collider2D _collider;
        private Coroutine _coroutine;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnDisable()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }

        public void DisableCollider()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(DisableAndEnable());
        }

        private IEnumerator DisableAndEnable()
        {
            _collider.enabled = false;
            yield return new WaitForSeconds(_disableTime);
            _collider.enabled = true;
        }
    }
}