using UnityEngine;

namespace MainMenu
{
    public class MenuLoad : MonoBehaviour
    {
        [SerializeField] private bool _firstInput = true;
        [SerializeField] private GameObject _onFirstInputLoad;
        [SerializeField] private GameObject _standartInputLoad;
        private void Start()
        {
            _onFirstInputLoad.SetActive(_firstInput);
            _standartInputLoad.SetActive(_firstInput == false);
        }
    }
}