using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class Shot : MonoBehaviour
    {
        private static List<Shot> _instanses = new();

        [SerializeField] private SimpleBullet _bullet;
        [SerializeField] private GameObject _light;
        private void Init(XPcontainer sender, Transform spawnpointTransform)
        {
            transform.position = spawnpointTransform.position;
            transform.rotation = spawnpointTransform.rotation;
            _light.transform.localPosition = Vector3.zero;
            _light.transform.localRotation = Quaternion.identity;
            _light.SetActive(true);
            _bullet.Init(sender);
        }

        public static Shot Summon(XPcontainer sender, Shot shot, Transform spawnpointTransform)
        {
            Shot shotInstance;
            if (_instanses.Count == 0)
            {
                shotInstance = Instantiate(shot);
            }
            else
            {
                shotInstance = _instanses[0];
            }

            shotInstance.Init(sender, spawnpointTransform);
            shotInstance.gameObject.SetActive(true);
            return shotInstance;
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
