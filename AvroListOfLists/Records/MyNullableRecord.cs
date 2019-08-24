// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.9.0.0
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace AvroListOfLists.Records
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using Avro;
	using Avro.Specific;
	
	public partial class MyNullableRecord : ISpecificRecord
	{
		public static Schema _SCHEMA = Avro.Schema.Parse("{\"type\":\"record\",\"name\":\"MyNullableRecord\",\"namespace\":\"AvroListOfLists.Records\"," +
				"\"fields\":[{\"name\":\"MyNullable\",\"type\":[\"null\",\"int\"]}]}");
		private System.Nullable<int> _MyNullable;
		public virtual Schema Schema
		{
			get
			{
				return MyNullableRecord._SCHEMA;
			}
		}
		public System.Nullable<int> MyNullable
		{
			get
			{
				return this._MyNullable;
			}
			set
			{
				this._MyNullable = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.MyNullable;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.MyNullable = (System.Nullable<int>)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}
