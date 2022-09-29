using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    internal class TakeItem : ITask
    {
        private static List<Item> _itemsToHaul = new();
        private NavMeshAgent _agent;

        public TakeItem(NavMeshAgent agent)
        {
            _agent = agent;
        }

        public static void AddHaulItem(Item item)
        {
            if (_itemsToHaul.Contains(item)) 
            {
                return;
            }
            _itemsToHaul.Add(item);
        }

        public static void RemoveItem(Item item) 
        {
            _itemsToHaul.Remove(item);
        }

        public void Execute()
        {
            _agent.destination = GetNearestItem().transform.position;
        }

        private Item GetNearestItem()
        {
            Item nearestItem = _itemsToHaul[0];
            float minDistance = Vector3.Distance(_itemsToHaul[0].transform.position, _agent.transform.position);
            float currentDistance;
            foreach (Item item in _itemsToHaul)
            {
                currentDistance = Vector3.Distance(item.transform.position, _agent.transform.position);
                if (Vector3.Distance(item.transform.position, _agent.transform.position) < minDistance)
                {
                    nearestItem = item;
                    minDistance = currentDistance;
                }
            }
            return nearestItem;
        }
    }
}
