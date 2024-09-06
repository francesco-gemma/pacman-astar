using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "SoundEffectRequest")]
	public sealed class SoundEffectRequestGameEventListener : BaseGameEventListener<SoundEffectRequest, SoundEffectRequestGameEvent, SoundEffectRequestUnityEvent>
	{
	}
}