using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class SoundEffectRequestReference : BaseReference<SoundEffectRequest, SoundEffectRequestVariable>
	{
	    public SoundEffectRequestReference() : base() { }
	    public SoundEffectRequestReference(SoundEffectRequest value) : base(value) { }
	}
}