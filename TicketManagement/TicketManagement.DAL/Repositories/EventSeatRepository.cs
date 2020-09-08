// ****************************************************************************
// <copyright file="EventSeatRepository.cs" company="EPAM Systems">
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
    internal class EventSeatRepository : RepositoryBase<EventSeat>
    {
        public EventSeatRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {
        }

        protected override void InsertCommandParameters(EventSeat entity, IDbCommand cmd)
        {
            cmd.CommandText = "CreateEventSeat";
            cmd.AddParameterWithValue("@Row", entity.Row);
            cmd.AddParameterWithValue("@Number", entity.Number);
            cmd.AddParameterWithValue("@State", entity.State);
            cmd.AddParameterWithValue("@EventAreaId", entity.EventAreaId);
        }

        protected override void UpdateCommandParameters(EventSeat entity, IDbCommand cmd)
        {
            cmd.CommandText = "UpdateEventSeat";
            cmd.AddParameterWithValue("@Id", entity.Id);
            cmd.AddParameterWithValue("@Row", entity.Row);
            cmd.AddParameterWithValue("@Number", entity.Number);
            cmd.AddParameterWithValue("@State", entity.State);
            cmd.AddParameterWithValue("@EventAreaId", entity.EventAreaId);
        }

        protected override void DeleteCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = "DeleteEventSeat";
            cmd.AddParameterWithValue("@Id", id);
        }

        protected override void GetByIdCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = string.Format("SELECT * FROM EventSeats WHERE Id = {0}", id);
        }

        protected override void GetAllCommandParameters(IDbCommand cmd)
        {
            cmd.CommandText = "select * from EventSeats";
        }

        protected override EventSeat Map(IDataReader reader)
        {
            EventSeat eventSeat = new EventSeat();
            bool isNull = true;

            while (reader.Read())
                {
                isNull = false;
                int index = 0;
                eventSeat.Id = reader.GetInt32(index++);
                eventSeat.EventAreaId = reader.GetInt32(index++);
                eventSeat.Row = reader.GetInt32(index++);
                eventSeat.Number = reader.GetInt32(index++);
                eventSeat.State = reader.GetInt32(index++);
                }

            return isNull ? null : eventSeat;
        }

        protected override IEnumerable<EventSeat> Maps(IDataReader reader)
        {
            ICollection<EventSeat> eventSeats = new List<EventSeat>();

            while (reader.Read())
                {
                int index = 0;

                EventSeat eventSeat = new EventSeat
                    {
                        Id = reader.GetInt32(index++),
                        EventAreaId = reader.GetInt32(index++),
                        Row = reader.GetInt32(index++),
                        Number = reader.GetInt32(index++),
                        State = reader.GetInt32(index++),
                    };
                eventSeats.Add(eventSeat);
                }

            return eventSeats;
        }
    }
}
