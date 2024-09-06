using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "LevelConfigurationSOGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "LevelConfigurationSO",
	    order = 120)]
	public sealed class LevelConfigurationSOGameEvent : GameEventBase<LevelConfigurationSO>
	{
	}
}