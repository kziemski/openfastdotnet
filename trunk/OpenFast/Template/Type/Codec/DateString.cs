/*

The contents of this file are subject to the Mozilla Public License
Version 1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.mozilla.org/MPL/

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is OpenFAST.

The Initial Developer of the Original Code is The LaSalle Technology
Group, LLC.  Portions created by Shariq Muhammad
are Copyright (C) Shariq Muhammad. All Rights Reserved.

Contributor(s): Shariq Muhammad <shariq.muhammad@gmail.com>

*/
using System;
using DateValue = OpenFAST.DateValue;
using Global = OpenFAST.Global;
using ScalarValue = OpenFAST.ScalarValue;
using StringValue = OpenFAST.StringValue;

namespace OpenFAST.Template.Type.Codec
{
	[Serializable]
	public sealed class DateString:TypeCodec
	{
		private const long serialVersionUID = 1L;
		private System.Globalization.DateTimeFormatInfo formatter;
        private string FormatString;
		
		public DateString(string format)
		{
            formatter = new System.Globalization.DateTimeFormatInfo();
            FormatString = format;
		}
		
		public override ScalarValue Decode(System.IO.Stream in_Renamed)
		{
			try
			{
				System.DateTime tempAux = System.DateTime.Parse(TypeCodec.ASCII.Decode(in_Renamed).ToString(), formatter);
				return new DateValue(ref tempAux);
			}
			catch (System.FormatException e)
			{
				Global.HandleError(OpenFAST.Error.FastConstants.PARSE_ERROR, "", e);
				return null;
			}
		}
		
		public override byte[] EncodeValue(ScalarValue value_Renamed)
		{
			return TypeCodec.ASCII.Encode(new StringValue(SupportClass.FormatDateTime(formatter, ((DateValue) value_Renamed).value_Renamed)));
		}
		
		public  override bool Equals(System.Object obj)
		{
			return obj != null && obj.GetType() == GetType();
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}