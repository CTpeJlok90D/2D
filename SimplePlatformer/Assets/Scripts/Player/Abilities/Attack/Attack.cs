using UnityEngine;
using Effects;

namespace Abilitys
{
    public class Attack : Ability
    {
        [SerializeField] private GameObject _attackPrefub;
        [SerializeField] private CharacterController2D _character;
        [SerializeField] private EffectList _effectList;
        [SerializeField] private float _attackDistance;
        protected override void Execute()
        {
            Vector3 offcet = new(_attackDistance * _character.Direction, 0);
            GameObject AttackMesh = Instantiate(_attackPrefub, _character.transform.position + offcet, Quaternion.identity);
            AttackMesh.transform.SetParent(_character.transform);
        }
    }
}