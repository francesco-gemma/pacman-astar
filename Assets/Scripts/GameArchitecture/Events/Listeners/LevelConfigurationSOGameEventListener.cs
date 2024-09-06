using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "LevelConfigurationSO")]
	public sealed class LevelConfigurationSOGameEventListener : BaseGameEventListener<LevelConfigurationSO, LevelConfigurationSOGameEvent, LevelConfigurationSOUnityEvent>
	{
	}
}