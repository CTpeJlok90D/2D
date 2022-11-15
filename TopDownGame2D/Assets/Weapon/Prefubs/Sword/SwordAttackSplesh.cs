using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class SwordAttackSplesh : MonoBehaviour
    {
        private static List<SwordAttackSplesh> _instanses = new();

        public static SwordAttackSplesh Summon(SwordAttackSplesh prefub, Transform summonTransform)
        {
            SwordAttackSplesh result;
            if (_instanses.Count == 0)
            {
                result = Instantiate(prefub);
            }
            else
            {
                result = _instanses[0];
            }
            result.gameObject.SetActive(true);
            result.Init(summonTransform);
            return result;
        }

        private void Init(Transform summonTransofrm)
        {
            transform.position = summonTransofrm.position;
            transform.rotation = summonTransofrm.rotation;
        }

        private void OnEnable()
        {
            _instanses.Remove(this);
        }

        private void OnDisable()
        {
            _instanses.Add(this);
        }
    }
}
