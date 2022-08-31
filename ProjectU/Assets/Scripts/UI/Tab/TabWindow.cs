using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabWindow : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tabs = new();
    [SerializeField] private List<Button> _buttons = new();

    public void EnableTab(int tabIndex)
    {
        DisableAll();
        _tabs[tabIndex].SetActive(true);
    }

    public void EnableTab(GameObject panel)
    {
        DisableAll();
        panel.SetActive(true);
    }

    private void DisableAll()
    {
        _tabs.ForEach((GameObject panel) =>
        {
            panel.SetActive(false);
        });
    }

    private void Awake()
    {
        for (int i = 0; i < _tabs.Count; i++)
        {
            int t = i;
            _buttons[i].onClick.AddListener(() => EnableTab(t));
        }
    }

    private void OnValidate()
    {
        while (_tabs.Count != _buttons.Count)
        {
            if (_tabs.Count > _buttons.Count)
            {
                _buttons.Add(null);
            }
            else
            {
                _buttons.RemoveAt(_buttons.Count - 1);
            }
        }
    }
}