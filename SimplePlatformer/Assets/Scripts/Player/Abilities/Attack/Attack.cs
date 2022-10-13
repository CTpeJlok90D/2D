using UnityEngine;

namespace Abilitys
{
    public class Attack : Ability
    {
        [SerializeField] private GameObject _attackPrefub;
        [SerializeField] private CharacterController2D _character;
        [SerializeField] private EffectList _effectList;
        [SerializeField] private float _attackMeshSpawnDistance;

        protected override bool UseCondiction => _effectList.Stunned == false;

        protected override void Execute()
        {
            Vector3 offcet = new(_attackMeshSpawnDistance * _character.Direction, 0);
            GameObject AttackMesh = Instantiate(_attackPrefub, _character.transform.position + offcet, Quaternion.identity);
            AttackMesh.transform.rotation = _character.transform.rotation;
            AttackMesh.transform.SetParent(_character.transform);
        }
    }
}