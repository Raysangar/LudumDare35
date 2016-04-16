using UnityEngine;
using System.Collections.Generic;

namespace UI {

  [CreateAssetMenu(fileName = "InteractableActionSequence", menuName = "Interface/InteractableActionSequence", order = 1)]
  public class ActionList : ScriptableObject {
    [SerializeField]
    private List<Action> actionList;

		public List<Action> Sequence {
			get { return actionList; }
		}

  }
}