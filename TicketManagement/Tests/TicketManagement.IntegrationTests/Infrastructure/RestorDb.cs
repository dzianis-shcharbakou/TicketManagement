// ****************************************************************************
// <copyright file="RestorDb.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;

namespace TicketManagement.IntegrationTests.Infrastructure
{
    internal class RestorDb
    {
        public void Execute(string scriptPath)
        {
            DbProviderFactory providerFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["TicketManagementTest"].ProviderName);
            string connectionString = ConfigurationManager.ConnectionStrings["TicketManagementTest"].ConnectionString;

            string script = this.Read(scriptPath);
            string[] scriptSplit = this.Split(script);

            using (IDbConnection connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();

                foreach (string str in scriptSplit)
                {
                    using (var cm2 = connection.CreateCommand())
                    {
                        cm2.CommandText = str;
                        cm2.CommandType = CommandType.Text;
                        cm2.ExecuteNonQuery();
                    }
                }
            }
        }

        private string Read(string path)
        {
            return File.ReadAllText(path);
        }

        private string[] Split(string script)
        {
            string[] splitString = script.Split(new[] { string.Empty }, StringSplitOptions.RemoveEmptyEntries);
            return splitString;
        }
    }
}
