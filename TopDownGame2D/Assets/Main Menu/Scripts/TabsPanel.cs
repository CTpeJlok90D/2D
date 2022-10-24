using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class TabsPanel : MonoBehaviour
    {
        [SerializeField] private List<Button> _buttons;
        [SerializeField] private List<GameObject> _panels;

        public void AddTab(Button button, GameObject panel)
        {
            _buttons.Add(button);
            _panels.Add(panel);

            button.onClick.AddListener(() =>
            {
                DisableAllPanels();
                panel.SetActive(true);
            });
        }

        public void RemoveTab(int tabNumber)
        {
            if (_buttons.Count <= tabNumber)
            {
                _buttons.RemoveAt(tabNumber);
                _panels.RemoveAt(tabNumber);
            }
        }

        private void Start()
        {
            if (_buttons.Count != _panels.Count)
            {
                Debug.LogError("The number of buttons does not match the number of panels");
            }

            for (int i = 0; i < _buttons.Count; i++)
            {
                Button button = _buttons[i];
                GameObject panel = _panels[i];

                button.onClick.AddListener(() =>
                {
                    DisableAllPanels();
                    panel.SetActive(true);
                });
            }
        }

        private void DisableAllPanels()
        {
            foreach(GameObject panel in _panels)
            {
                panel.SetActive(false);
            }
        }
    }
}