using System;
using System.Data;
using System.Data.Common;
using System.Xml.Linq;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace yesmarket.NHibernate.Types
{
	public class XElementType : IUserType
	{
		public new bool Equals(object x, object y)
		{
			var xElement = x as XElement;
			var yElement = y as XElement;

			return xElement != null && yElement != null && XNode.DeepEquals(xElement, yElement);
		}

		public int GetHashCode(object x)
		{
			return x.GetHashCode();
		}

		public object NullSafeGet(IDataReader rs, string[] names, object owner)
		{
			if (names.Length != 1)
			{
				throw new InvalidOperationException("names array has more than one element. can't handle this!");
			}

			var val = rs[names[0]] as string;
			return val != null ? XElement.Parse(val) : null;
		}

		public void NullSafeSet(IDbCommand cmd, object value, int index)
		{
			var parameter = (DbParameter) cmd.Parameters[index];
			if (value == null)
			{
				parameter.Value = DBNull.Value;
				return;
			}

			parameter.Value = ((XElement) value).ToString(SaveOptions.None);
		}

		public object DeepCopy(object value)
		{
			var xElement = value as XElement;
			return xElement != null ? new XElement(xElement) : null;
		}

		public object Replace(object original, object target, object owner)
		{
		    return target;
		}

		public object Assemble(object cached, object owner)
		{
			var str = cached as string;
			return str != null ? XElement.Parse(str) : null;
		}

		public object Disassemble(object value)
		{
			var val = value as XElement;
			return val != null ? val.ToString(SaveOptions.None) : null;
		}

		public SqlType[] SqlTypes
		{
            get { return new SqlType[] { new SqlXmlType() }; }
		}

		public Type ReturnedType
		{
			get { return typeof(XElement); }
		}

		public bool IsMutable
		{
			get { return true; }
		}
	}
}