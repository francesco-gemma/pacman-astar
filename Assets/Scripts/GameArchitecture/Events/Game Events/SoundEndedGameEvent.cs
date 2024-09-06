using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "SoundEndedGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Sound Ended",
	    order = 120)]
	public sealed class SoundEndedGameEvent : GameEventBase<SoundEnded>
	{
	}
}