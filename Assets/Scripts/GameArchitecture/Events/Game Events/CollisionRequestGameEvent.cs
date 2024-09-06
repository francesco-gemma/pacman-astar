using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "CollisionRequestGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Collision",
	    order = 120)]
	public sealed class CollisionRequestGameEvent : GameEventBase<CollisionRequest>
	{
	}
}