using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "SoundEndedVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Sound Ended",
	    order = 120)]
	public class SoundEndedVariable : BaseVariable<SoundEnded>
	{
	}
}