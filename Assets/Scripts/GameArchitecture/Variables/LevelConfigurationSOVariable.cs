using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "LevelConfigurationSOVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "LevelConfigurationSO",
	    order = 120)]
	public class LevelConfigurationSOVariable : BaseVariable<LevelConfigurationSO>
	{
	}
}