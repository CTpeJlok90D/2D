using UnityEngine;
using Effects;
public class AttackMesh : MonoBehaviour
{
    [SerializeField] private int _damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EffectList effectList))
        {
            effectList.Add(new Damage(_damage));
        }   
    }
}
