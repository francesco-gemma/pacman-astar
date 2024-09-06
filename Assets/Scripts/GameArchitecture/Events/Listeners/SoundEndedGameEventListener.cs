using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "SoundEnded")]
	public sealed class SoundEndedGameEventListener : BaseGameEventListener<SoundEnded, SoundEndedGameEvent, SoundEndedUnityEvent>
	{
	}
}