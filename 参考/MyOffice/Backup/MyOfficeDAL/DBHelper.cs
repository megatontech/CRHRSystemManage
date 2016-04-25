using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/* 
 * ������Σ����ݷ��������
 */
namespace MyOffice.DAL
{
    /// <summary>
    /// SqlHelper����ר���ṩ�����ڸ����ܡ���������sql���ݲ���
    /// </summary>
    public static class DBHelper
    {
        //���ݿ������ַ�����
        //�����ַ����ڽ�����webConfig�������ļ��С�[���Ϊpublic��Ϊ�˴�������������ӣ���Ϊ���ӽ���DAL������д���]
        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        #region ִ��SQL����洢���̣�����Ӱ�������
        /// <summary>
        /// ִ��SQL����洢���̣�����Ӱ�������
        /// </summary>
        /// <param name="commandType">��������(�洢����, �ı�, �����ͼ)</param>
        /// <param name="commandText">�洢�������ƻ���sql�������</param>
        /// <param name="commandParameters">ִ���������ò����ļ���</param>
        /// <returns>ִ��������Ӱ�������</returns>
        public static int ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //ΪʲôҪ����׼��ִ�����������������Ϊ�ڴ˴����Լ���һ��������ơ�
                PrepareCommand(command, connection, null, commandType, commandText, commandParameters);
                int val = command.ExecuteNonQuery();
                command.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region ʹ�����е�SQL����ִ��һ��sql����
        /// <summary>
        ///ʹ�����е�SQL����ִ��һ��sql����
        /// </summary>
        /// <param name="transaction">һ�����е�����</param>
        /// <param name="commandType">��������(�洢����, �ı�, �ȵ�)</param>
        /// <param name="commandText">�洢�������ƻ���sql�������</param>
        /// <param name="commandParameters">ִ���������ò����ļ���</param>
        /// <returns>ִ��������Ӱ�������</returns>
        public static int ExecuteNonQuery(SqlTransaction transaction, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //���ﲻ�ܹر����ӣ���Ϊ����û����ɣ������ӽ�һֱΪ���������ṩ����
            //���ӽ�����ص�DAL����ģ���д�����Ȼ���뱾���������Ա���������ַ���ҪΪPublic
            SqlCommand command = new SqlCommand();
            PrepareCommand(command, transaction.Connection, transaction, commandType, commandText, commandParameters);
            int val = command.ExecuteNonQuery();
            command.Parameters.Clear();
            return val;
        }
        #endregion

        #region ִ��һ�����ض�ȡ����sql����
        /// <summary>
        /// ��ִ�е����ݿ�����ִ��һ�����ض�ȡ����sql����
        /// </summary>
        /// <param name="commandType">��������(�洢����, �ı�, �ȵ�)</param>
        /// <param name="commandText">�洢�������ƻ���sql�������</param>
        /// <param name="commandParameters">ִ���������ò����ļ���</param>
        /// <returns>��������Ķ�ȡ��</returns>
        public static SqlDataReader ExecuteGetReader(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            //����һ��SqlCommand����
            SqlCommand command = new SqlCommand();
            //����һ��SqlConnection����
            SqlConnection connection = new SqlConnection(ConnectionString);

            //������������һ��try/catch�ṹִ��sql�ı�����/�洢���̣���Ϊ��������������һ���쳣����Ҫ�ر����ӣ���Ϊû�ж�ȡ�����ڣ�
            //���commandBehaviour.CloseConnection �Ͳ���ִ��
            try
            {
                //���� PrepareCommand �������� SqlCommand �������ò���
                PrepareCommand(command, connection, null, commandType, commandText, commandParameters);
                
                //���� SqlCommand  �� ExecuteReader ����
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                //�������
                command.Parameters.Clear();
                return reader;  //ע�ⲻ�ܹر����ӣ�������÷��޷���ȡ���ݡ�
            }
            catch
            {
                //�ر����ӣ��׳��쳣
                connection.Close();
                throw;  //�׳�ʲô��
            }
        }
        #endregion

        #region ִ���������DataTable
        /// <summary>
        /// ִ���������DataTable
        /// </summary>
        /// <param name="commandText">��������</param>
        /// <param name="commandType">��������</param>
        /// <param name="commandParameters">����</param>
        /// <returns>DataTable���ݱ�</returns>
        public static DataTable ExecuteGetDataTable(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                PrepareCommand(command, connection, null, commandType, commandText, commandParameters);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                return table;
            }
        }
        #endregion

        #region ִ��һ��������ص�һ��
        /// <summary>
        /// ��ָ�������ݿ������ַ���ִ��һ���������һ�����ݼ��ĵ�һ��
        /// </summary>
        ///<param name="ConnectionString">һ����Ч�������ַ���</param>
        /// <param name="commandType">��������(�洢����, �ı�, �ȵ�)</param>
        /// <param name="commandText">�洢�������ƻ���sql�������</param>
        /// <param name="commandParameters">ִ���������ò����ļ���</param>
        /// <returns>�� Convert.To{Type}������ת��Ϊ��Ҫ�� </returns>
        public static object ExecuteScalar(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                PrepareCommand(command, connection, null, commandType, commandText, commandParameters);
                object val = command.ExecuteScalar();
                command.Parameters.Clear();
                return val;
            }
        }
        #endregion

        #region ׼��ִ��һ������
        /// <summary>
        /// ׼��ִ��һ������
        /// </summary>
        /// <param name="cmd">sql����</param>
        /// <param name="conn">Sql����</param>
        /// <param name="trans">Sql����</param>
        /// <param name="cmdType">������������ �洢���̻����ı�</param>
        /// <param name="cmdText">�����ı�</param>
        /// <param name="cmdParms">ִ������Ĳ���</param>
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            command.Connection = connection;
            command.CommandText = commandText;

            if (transaction != null)
                command.Transaction = transaction;

            command.CommandType = commandType;

            if (commandParameters != null)
                command.Parameters.AddRange(commandParameters);
        }
        #endregion

    }
}
