using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using Akredytka.Properties;

namespace Akredytka
{
    class LDB
    {
        public LDB()
        {

        }
        public string getCore(string name)
        {
            DataTable t = new DataTable();
            using (SqlCeConnection c = new SqlCeConnection(ConnectString()))
            {
                try
                {
                    c.Open();
                    using (SqlCeDataAdapter a = new SqlCeDataAdapter("SELECT sval FROM core WHERE id='" + name + "'", c))
                    {
                        a.Fill(t);
                        try
                        {
                            return (string)t.Rows[0][0];
                        }
                        catch (Exception) { }
                    }
                    c.Close();
                }
                catch (SqlCeException) { }
                return "";
            }
        }

        public static void init()
        {
            assureTables();
        }
        private static bool assureTables()
        {
            SqlCeConnection cn = new SqlCeConnection(ConnectString());
            bool ok = true;
            if (cn.State == ConnectionState.Closed) cn.Open();

            SqlCeCommand scmd;

            try
            {
                if (!tableExists(cn, "Bydloes"))
                {
                    scmd = cn.CreateCommand();
                    scmd.CommandText = "CREATE TABLE [Bydloes] (" +
                        "[Id] int  NOT NULL," +
                        "[Imie] nvarchar(4000)  NOT NULL," +
                        "[Nazwisko] nvarchar(4000)  NOT NULL," +
                        "[pesel] nvarchar(4000)  NULL," +
                        "[dowod] nvarchar(4000)  NULL," +
                        "[nick] nvarchar(4000)  NULL," +
                        "[jest] bit  NOT NULL," +
                        "[adres] nvarchar(4000)  NULL" +
                    ");";
                    scmd.ExecuteNonQuery();
                    scmd = cn.CreateCommand();
                    scmd.CommandText = "ALTER TABLE [Bydloes] ADD CONSTRAINT [PK_Bydloes] PRIMARY KEY ([Id] );";
                }
                if (!tableExists(cn, "IdiotFriendlies"))
                {
                    scmd = cn.CreateCommand();
                    scmd.CommandText = "CREATE TABLE [IdiotFriendlies] (" +
                        "[Id] int  NOT NULL," +
                        "[Operacja] nvarchar(4000)  NOT NULL," +
                        "[poszla] bit  NOT NULL" +
                    ");";
                    scmd.ExecuteNonQuery();
                    scmd = cn.CreateCommand();
                    scmd.CommandText = "ALTER TABLE [IdiotFriendlies] ADD CONSTRAINT [PK_IdiotFriendlies] PRIMARY KEY ([Id] );";
                }
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "Oh Crap.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oh Shit.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            finally
            {
                cn.Close();
            }
            return ok;
        }

        private static bool tableExists(SqlCeConnection c, String table)
        {
            String sql = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = @table";
            DataTable t = new DataTable();
            SqlCeCommand cc = new SqlCeCommand(sql, c);
            SqlCeParameter param = null;

            param = new SqlCeParameter("@table", SqlDbType.NVarChar);
            param.Value = table;
            cc.Parameters.Add(param);
            SqlCeDataReader dr = cc.ExecuteReader();
            return dr.Read();
        }
        private static bool createDatabase(string connectionString)
        {
            try
            {
                SqlCeEngine en = new SqlCeEngine(connectionString);
                en.CreateDatabase();
            }
            catch (SqlCeException sqlexception)
            {
                MessageBox.Show(sqlexception.Message, "Oh Crap.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oh Shit.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public static string ConnectString()
        {
            return Settings.Default.dbConn;
            //return string.Format("DataSource=\"{0}\"; Password='{1}'", @"C:\Users\bojer\Documents\db.sdf", "qweasd123");
        }
    }
}
