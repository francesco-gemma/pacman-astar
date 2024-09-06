using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "SoundEffectRequestGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Sound Effect",
	    order = 120)]
	public sealed class SoundEffectRequestGameEvent : GameEventBase<SoundEffectRequest>
	{
	}
}