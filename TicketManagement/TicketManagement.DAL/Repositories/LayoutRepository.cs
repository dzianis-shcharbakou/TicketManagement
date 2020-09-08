// ****************************************************************************
// <copyright file="LayoutRepository.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;
using System.Data;
using TicketManagement.DAL.Extensions;
using TicketManagement.DAL.Models;
using TicketManagement.DAL.Repositories.Base;

namespace TicketManagement.DAL.Repositories
{
    internal class LayoutRepository : RepositoryBase<Layout>
    {
        public LayoutRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {
        }

        protected override void InsertCommandParameters(Layout entity, IDbCommand cmd)
        {
            cmd.CommandText = "CreateLayout";
            cmd.AddParameterWithValue("@Description", entity.Description);
            cmd.AddParameterWithValue("@VenueId", entity.VenueId);
            cmd.AddParameterWithValue("@Name", entity.Name);
        }

        protected override void UpdateCommandParameters(Layout entity, IDbCommand cmd)
        {
            cmd.CommandText = "UpdateLayout";
            cmd.AddParameterWithValue("@Id", entity.Id);
            cmd.AddParameterWithValue("@Description", entity.Description);
            cmd.AddParameterWithValue("@VenueId", entity.VenueId);
            cmd.AddParameterWithValue("@Name", entity.Name);
        }

        protected override void DeleteCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = "DeleteLayout";
            cmd.AddParameterWithValue("@Id", id);
        }

        protected override void GetByIdCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = string.Format("SELECT * FROM Layouts WHERE Id = {0}", id);
        }

        protected override void GetAllCommandParameters(IDbCommand cmd)
        {
            cmd.CommandText = "select * from Layouts";
        }

        protected override Layout Map(IDataReader reader)
        {
            Layout layout = new Layout();
            bool isNull = true;

            while (reader.Read())
            {
                isNull = false;
                int index = 0;
                layout.Id = reader.GetInt32(index++);
                layout.VenueId = reader.GetInt32(index++);
                layout.Description = reader.GetString(index++);
                layout.Name = reader.GetString(index++);
            }

            return isNull ? null : layout;
        }

        protected override IEnumerable<Layout> Maps(IDataReader reader)
        {
            ICollection<Layout> layouts = new List<Layout>();

            while (reader.Read())
            {
                int index = 0;

                Layout layout = new Layout
                {
                    Id = reader.GetInt32(index++),
                    VenueId = reader.GetInt32(index++),
                    Description = reader.GetString(index++),
                    Name = reader.GetString(index++),
                };
                layouts.Add(layout);
            }

            return layouts;
        }
    }
}
