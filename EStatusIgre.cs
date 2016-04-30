using System;
using System.Runtime.Serialization;

namespace HangmanService
{
	[DataContract]
	public enum EStatusIgre
	{
		[EnumMember]
		IGRA_AKTIVNA,
		[EnumMember]
		IGRA_ZAVRSENA_POBEDA,
		[EnumMember]
		IGRA_ZAVRSENA_PORAZ
	}
}

