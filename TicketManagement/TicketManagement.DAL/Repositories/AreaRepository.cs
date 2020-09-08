// ****************************************************************************
// <copyright file="AreaRepository.cs" company="EPAM Systems">
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
    internal class AreaRepository : RepositoryBase<Area>
    {
        public AreaRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {
        }

        protected override void InsertCommandParameters(Area entity, IDbCommand cmd)
        {
            cmd.CommandText = "CreateArea";
            cmd.AddParameterWithValue("@Description", entity.Description);
            cmd.AddParameterWithValue("@CoordX", entity.CoordX);
            cmd.AddParameterWithValue("@CoordY", entity.CoordY);
            cmd.AddParameterWithValue("@LayoutId", entity.LayoutId);
        }

        protected override void UpdateCommandParameters(Area entity, IDbCommand cmd)
        {
            cmd.CommandText = "UpdateArea";
            cmd.AddParameterWithValue("@Id", entity.Id);
            cmd.AddParameterWithValue("@Description", entity.Description);
            cmd.AddParameterWithValue("@CoordX", entity.CoordX);
            cmd.AddParameterWithValue("@CoordY", entity.CoordY);
            cmd.AddParameterWithValue("@LayoutId", entity.LayoutId);
        }

        protected override void DeleteCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = "DeleteArea";
            cmd.AddParameterWithValue("@Id", id);
        }

        protected override void GetByIdCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = string.Format("SELECT * FROM Areas WHERE Id = {0}", id);
        }

        protected override void GetAllCommandParameters(IDbCommand cmd)
        {
            cmd.CommandText = "select * from Areas";
        }

        protected override Area Map(IDataReader reader)
        {
            Area area = new Area();
            bool isNull = true;

            while (reader.Read())
                {
                isNull = false;
                int index = 0;

                area.Id = reader.GetInt32(index++);
                area.LayoutId = reader.GetInt32(index++);
                area.Description = reader.GetString(index++);
                area.CoordX = reader.GetInt32(index++);
                area.CoordY = reader.GetInt32(index++);
                }

            return isNull ? null : area;
        }

        protected override IEnumerable<Area> Maps(IDataReader reader)
        {
            ICollection<Area> areas = new List<Area>();

            while (reader.Read())
                {
                int index = 0;

                Area area = new Area
                    {
                    Id = reader.GetInt32(index++),
                    LayoutId = reader.GetInt32(index++),
                    Description = reader.GetString(index++),
                    CoordX = reader.GetInt32(index++),
                    CoordY = reader.GetInt32(index++),
                    };
                areas.Add(area);
                }

            return areas;
        }
    }
}
