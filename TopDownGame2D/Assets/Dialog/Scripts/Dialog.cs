using UnityEngine;
using UnityEngine.Events;

namespace Dialog
{
    [CreateAssetMenu()]
    public class Dialog : ScriptableObject
    {
        [SerializeField] private Story[] _storys;
        [SerializeField] private Answer[] _answers;
        [SerializeField] private UnityEvent _storyEnded;
        public Story[] Storys => _storys;
        public Answer[] Answers => _answers;
        public UnityEvent StoryEnded => _storyEnded;
    }
}