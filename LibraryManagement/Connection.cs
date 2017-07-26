using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LibraryManagement
{
    public class Connection
    {
        public OracleConnection thisConnection = new OracleConnection("Data Source=XE;User ID=rko;Password=rko123;");
    }
}