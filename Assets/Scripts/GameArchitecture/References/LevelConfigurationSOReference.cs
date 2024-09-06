using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class LevelConfigurationSOReference : BaseReference<LevelConfigurationSO, LevelConfigurationSOVariable>
	{
	    public LevelConfigurationSOReference() : base() { }
	    public LevelConfigurationSOReference(LevelConfigurationSO value) : base(value) { }
	}
}