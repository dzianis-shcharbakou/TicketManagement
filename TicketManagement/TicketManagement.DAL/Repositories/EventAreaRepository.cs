// ****************************************************************************
// <copyright file="EventAreaRepository.cs" company="EPAM Systems">
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
    internal class EventAreaRepository : RepositoryBase<EventArea>
    {
        public EventAreaRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {
        }

        protected override void InsertCommandParameters(EventArea entity, IDbCommand cmd)
        {
            cmd.CommandText = "CreateEventArea";
            cmd.AddParameterWithValue("@Description", entity.Description);
            cmd.AddParameterWithValue("@CoordX", entity.CoordX);
            cmd.AddParameterWithValue("@CoordY", entity.CoordY);
            cmd.AddParameterWithValue("@Price", entity.Price);
            cmd.AddParameterWithValue("@EventId", entity.EventId);
        }

        protected override void UpdateCommandParameters(EventArea entity, IDbCommand cmd)
        {
            cmd.CommandText = "UpdateEventArea";
            cmd.AddParameterWithValue("@Id", entity.Id);
            cmd.AddParameterWithValue("@Description", entity.Description);
            cmd.AddParameterWithValue("@CoordX", entity.CoordX);
            cmd.AddParameterWithValue("@CoordY", entity.CoordY);
            cmd.AddParameterWithValue("@Price", entity.Price);
            cmd.AddParameterWithValue("@EventId", entity.EventId);
        }

        protected override void DeleteCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = "DeleteEventArea";
            cmd.AddParameterWithValue("@Id", id);
        }

        protected override void GetByIdCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = string.Format("SELECT * FROM EventAreas WHERE Id = {0}", id);
        }

        protected override void GetAllCommandParameters(IDbCommand cmd)
        {
            cmd.CommandText = "select * from EventAreas";
        }

        protected override EventArea Map(IDataReader reader)
        {
            EventArea eventArea = new EventArea();
            bool isNull = true;

            while (reader.Read())
                {
                isNull = false;
                int index = 0;
                eventArea.Id = reader.GetInt32(index++);
                eventArea.EventId = reader.GetInt32(index++);
                eventArea.Description = reader.GetString(index++);
                eventArea.CoordX = reader.GetInt32(index++);
                eventArea.CoordY = reader.GetInt32(index++);
                eventArea.Price = reader.GetDecimal(index++);
                }

            return isNull ? null : eventArea;
        }

        protected override IEnumerable<EventArea> Maps(IDataReader reader)
        {
            ICollection<EventArea> eventAreas = new List<EventArea>();

            while (reader.Read())
                {
                int index = 0;

                EventArea eventArea = new EventArea
                    {
                        Id = reader.GetInt32(index++),
                        EventId = reader.GetInt32(index++),
                        Description = reader.GetString(index++),
                        CoordX = reader.GetInt32(index++),
                        CoordY = reader.GetInt32(index++),
                        Price = reader.GetDecimal(index++),
                    };
                eventAreas.Add(eventArea);
                }

            return eventAreas;
        }
    }
}
