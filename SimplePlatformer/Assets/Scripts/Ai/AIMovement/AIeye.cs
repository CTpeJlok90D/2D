using UnityEngine;

namespace AI
{
    [RequireComponent(typeof(Collider2D))]
    public class AIeye : MonoBehaviour
    {
        [SerializeField] private AI _owner;
        [SerializeField] private float _viewDistance;
        private Collider2D _collider;
        private void OnTriggerEnter2D(Collider2D other) 
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, other.transform.position - transform.position, _viewDistance);
            Debug.DrawRay(transform.position, other.transform.position - transform.position, Color.red);
            foreach (RaycastHit2D hit in hits)
            {
                Debug.Log(hit.collider.name);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _owner.RemoveVisibleObject(other.gameObject);
        }

        private void Awake() 
        {
            _collider = GetComponent<Collider2D>();
        }
    }
}