using UnityEngine;
using System.Collections.Generic;

namespace UI {
	[System.Serializable]
	public class Action {
	  
	  public float width;

	  public float offset;

		public EventManager.ActionType actionType;

		public Action (float width, float offset, EventManager.ActionType actionType) {
			this.actionType = actionType;
		    this.width = width;
		    this.offset = offset;
	  }
	}
}
