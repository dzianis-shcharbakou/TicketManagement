// ****************************************************************************
// <copyright file="SeatRepository.cs" company="EPAM Systems">
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
    internal class SeatRepository : RepositoryBase<Seat>
    {
        public SeatRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {
        }

        protected override void InsertCommandParameters(Seat entity, IDbCommand cmd)
        {
            cmd.CommandText = "CreateSeat";
            cmd.AddParameterWithValue("@Row", entity.Row);
            cmd.AddParameterWithValue("@Number", entity.Number);
            cmd.AddParameterWithValue("@AreaId", entity.AreaId);
        }

        protected override void UpdateCommandParameters(Seat entity, IDbCommand cmd)
        {
            cmd.CommandText = "UpdateSeat";
            cmd.AddParameterWithValue("@Id", entity.Id);
            cmd.AddParameterWithValue("@Row", entity.Row);
            cmd.AddParameterWithValue("@Number", entity.Number);
            cmd.AddParameterWithValue("@AreaId", entity.AreaId);
        }

        protected override void DeleteCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = "DeleteSeat";
            cmd.AddParameterWithValue("@Id", id);
        }

        protected override void GetByIdCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = string.Format("SELECT * FROM Seats WHERE Id = {0}", id);
        }

        protected override void GetAllCommandParameters(IDbCommand cmd)
        {
            cmd.CommandText = "select * from Seats";
        }

        protected override Seat Map(IDataReader reader)
        {
            Seat seat = new Seat();
            bool isNull = true;

            while (reader.Read())
                {
                isNull = false;
                int index = 0;
                seat.Id = reader.GetInt32(index++);
                seat.AreaId = reader.GetInt32(index++);
                seat.Row = reader.GetInt32(index++);
                seat.Number = reader.GetInt32(index++);
            }

            return isNull ? null : seat;
        }

        protected override IEnumerable<Seat> Maps(IDataReader reader)
        {
            ICollection<Seat> seats = new List<Seat>();

            while (reader.Read())
                {
                int index = 0;

                Seat seat = new Seat
                    {
                    Id = reader.GetInt32(index++),
                    AreaId = reader.GetInt32(index++),
                    Row = reader.GetInt32(index++),
                    Number = reader.GetInt32(index++),
                    };
                seats.Add(seat);
                }

            return seats;
        }
    }
}
