// ****************************************************************************
// <copyright file="RepositoryBase.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using TicketManagement.DAL.Models.Base;

namespace TicketManagement.DAL.Repositories.Base
{
    internal abstract class RepositoryBase<T> : IRepository<T>
        where T : IEntity, new()
    {
        private readonly DbProviderFactory providerFactory;
        private readonly string connectionString;

        protected RepositoryBase(string connectionString, string provider)
        {
            this.providerFactory = DbProviderFactories.GetFactory(provider);
            this.connectionString = connectionString;
        }

        public object Create(T entity)
        {
            var res = this.CommandExecuteScalar<T>(entity, this.InsertCommandParameters, CommandType.StoredProcedure);
            return res;
        }

        public object Update(T entity)
        {
            var res = this.CommandExecuteScalar<T>(entity, this.UpdateCommandParameters, CommandType.StoredProcedure);
            return res;
        }

        public object Delete(int id)
        {
            var res = this.CommandExecuteScalar<int>(id, this.DeleteCommandParameters, CommandType.StoredProcedure);
            return res;
        }

        public T GetById(int id)
        {
            var res = this.CommandExecuteReaderById<int>(id, this.GetByIdCommandParameters, CommandType.Text);
            return res;
        }

        public IEnumerable<T> GetAll()
        {
            var res = this.CommandExecuteReaderAll(this.GetAllCommandParameters, CommandType.Text);
            return res;
        }

        protected abstract void InsertCommandParameters(T entity, IDbCommand cmd);

        protected abstract void UpdateCommandParameters(T entity, IDbCommand cmd);

        protected abstract void DeleteCommandParameters(int id, IDbCommand cmd);

        protected abstract void GetByIdCommandParameters(int id, IDbCommand cmd);

        protected abstract void GetAllCommandParameters(IDbCommand cmd);

        protected abstract T Map(IDataReader reader);

        protected abstract IEnumerable<T> Maps(IDataReader reader);

        private object CommandExecuteScalar<TU>(TU param, Action<TU, IDbCommand> operation, CommandType commandType)
        {
            using (IDbConnection connection = this.providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = commandType;
                    operation(param, cmd);
                    return cmd.ExecuteScalar();
                }
            }
        }

        private T CommandExecuteReaderById<TIdType>(TIdType id, Action<TIdType, IDbCommand> operation, CommandType commandType)
        {
            using (IDbConnection connection = this.providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = commandType;
                    operation(id, cmd);
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        return this.Map(reader);
                    }
                }
            }
        }

        private IEnumerable<T> CommandExecuteReaderAll(Action<IDbCommand> operation, CommandType commandType)
        {
            using (IDbConnection connection = this.providerFactory.CreateConnection())
            {
                connection.ConnectionString = this.connectionString;
                connection.Open();

                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandType = commandType;
                    operation(cmd);
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        return this.Maps(reader);
                    }
                }
            }
        }
    }
}
