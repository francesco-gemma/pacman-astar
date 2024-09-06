using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[CreateAssetMenu(
	    fileName = "LoadSceneRequestVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Load Scene",
	    order = 120)]
	public class LoadSceneRequestVariable : BaseVariable<LoadSceneRequest>
	{
	}
}