using System.Data;
using NHibernate.SqlTypes;

namespace yesmarket.NHibernate.Types
{
    public class SqlXmlType : SqlType
    {
        public SqlXmlType() : base(DbType.Xml)
        {
        }
    }
}