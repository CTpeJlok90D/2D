using UnityEngine;

namespace MainMenu
{
    public class EnableButton : MonoBehaviour
    {
        [SerializeField] private GameObject _enableObject;

        public void OnClick()
        {
            _enableObject.SetActive(_enableObject.activeSelf == false);
        }
    }

}