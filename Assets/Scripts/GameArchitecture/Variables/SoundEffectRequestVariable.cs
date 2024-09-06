using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "SoundEffectRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Sound Effect",
	    order = 120)]
	public class SoundEffectRequestVariable : BaseVariable<SoundEffectRequest>
	{
	}
}