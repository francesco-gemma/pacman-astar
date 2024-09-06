using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "CollisionRequest")]
	public sealed class CollisionRequestGameEventListener : BaseGameEventListener<CollisionRequest, CollisionRequestGameEvent, CollisionRequestUnityEvent>
	{
	}
}