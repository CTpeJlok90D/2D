using System.Collections.Generic;
using UnityEngine;
using Abilitys;
using UnityEngine.Events;

public class XPcontainer : MonoBehaviour
{
    [SerializeField] private int _level = 1;
    [SerializeField] private int _skillPoints = 0;
    [SerializeField] private int _currentXP = 0;
    [SerializeField] private int _XP_ToNextLevel = 100;
    [SerializeField] private float _XP_Boost = 1.15f;
    [SerializeField] private List<Ability> _abilities = new();
    [SerializeField] private UnityEvent<int> _onLevelUp = new();
    
    public int XP
    {
        get 
        {
            return _currentXP;
        }
        set
        {
            _currentXP = value;
            if (_currentXP >= _XP_ToNextLevel)
            {
                _level ++;
                _currentXP = 0;
                _XP_ToNextLevel = (int)(_XP_ToNextLevel * _XP_Boost);
            }
        }
    }

    public void ByAbility(Ability ability)
    {
        if (ability.MinLevelToUnlock <= _level && _skillPoints >= ability.SkillPointCost)
        {
            _abilities.Remove(ability);
            ability.enabled = true;
            _skillPoints -= ability.SkillPointCost;
        }
    }
}
