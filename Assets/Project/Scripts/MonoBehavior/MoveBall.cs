using UnityEngine;

namespace Project.Scripts.MonoBehavior
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveBall : MonoBehaviour
    {
        [SerializeField] private float speed;
        
        private Rigidbody _rb;

        private void Start()
        {
            
        }
        
        private void OnValidate()
        {
            _rb ??= GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            _rb.AddForce(new Vector3(horizontal, 0, z: vertical) * (speed * Time.deltaTime));
        }
    }
}
