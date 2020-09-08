// ****************************************************************************
// <copyright file="EventRepository.cs" company="EPAM Systems">
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
    internal class EventRepository : RepositoryBase<Event>
    {
        public EventRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {
        }

        protected override void InsertCommandParameters(Event entity, IDbCommand cmd)
        {
            cmd.CommandText = "CreateEvent";
            cmd.AddParameterWithValue("@Name", entity.Name);
            cmd.AddParameterWithValue("@BeginDate", entity.BeginDate);
            cmd.AddParameterWithValue("@EndDate", entity.EndDate);
            cmd.AddParameterWithValue("@Description", entity.Description);
            cmd.AddParameterWithValue("@LayoutId", entity.LayoutId);
        }

        protected override void UpdateCommandParameters(Event entity, IDbCommand cmd)
        {
            cmd.CommandText = "UpdateEvent";
            cmd.AddParameterWithValue("@Id", entity.Id);
            cmd.AddParameterWithValue("@Name", entity.Name);
            cmd.AddParameterWithValue("@BeginDate", entity.BeginDate);
            cmd.AddParameterWithValue("@EndDate", entity.EndDate);
            cmd.AddParameterWithValue("@Description", entity.Description);
            cmd.AddParameterWithValue("@LayoutId", entity.LayoutId);
        }

        protected override void DeleteCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = "DeleteEvent";
            cmd.AddParameterWithValue("@Id", id);
        }

        protected override void GetByIdCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = string.Format("SELECT * FROM Events WHERE Id = {0}", id);
        }

        protected override void GetAllCommandParameters(IDbCommand cmd)
        {
            cmd.CommandText = "select * from Events";
        }

        protected override Event Map(IDataReader reader)
        {
            Event @event = new Event();
            bool isNull = true;

            while (reader.Read())
                {
                isNull = false;
                int index = 0;
                @event.Id = reader.GetInt32(index++);
                @event.Name = reader.GetString(index++);
                @event.Description = reader.GetString(index++);
                @event.LayoutId = reader.GetInt32(index++);
                @event.BeginDate = reader.GetDateTime(index++);
                @event.EndDate = reader.GetDateTime(index++);
                }

            return isNull ? null : @event;
        }

        protected override IEnumerable<Event> Maps(IDataReader reader)
        {
            ICollection<Event> events = new List<Event>();

            while (reader.Read())
                {
                int index = 0;

                Event @event = new Event
                    {
                    Id = reader.GetInt32(index++),
                    Name = reader.GetString(index++),
                    Description = reader.GetString(index++),
                    LayoutId = reader.GetInt32(index++),
                    BeginDate = reader.GetDateTime(index++),
                    EndDate = reader.GetDateTime(index++),
                    };
                events.Add(@event);
                }

            return events;
        }
    }
}
