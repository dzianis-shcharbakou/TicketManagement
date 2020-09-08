// ****************************************************************************
// <copyright file="VenueRepository.cs" company="EPAM Systems">
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
    internal class VenueRepository : RepositoryBase<Venue>
    {
        public VenueRepository(string connectionString, string provider)
            : base(connectionString, provider)
        {
        }

        protected override void InsertCommandParameters(Venue entity, IDbCommand cmd)
        {
            cmd.CommandText = "CreateVenue";

            cmd.AddParameterWithValue("@Description", entity.Description);
            cmd.AddParameterWithValue("@Address", entity.Address);
            cmd.AddParameterWithValue("@Phone", entity.Phone);
            cmd.AddParameterWithValue("@Name", entity.Name);
        }

        protected override void UpdateCommandParameters(Venue entity, IDbCommand cmd)
        {
            cmd.CommandText = "UpdateVenue";

            cmd.AddParameterWithValue("@Id", entity.Id);
            cmd.AddParameterWithValue("@Description", entity.Description);
            cmd.AddParameterWithValue("@Address", entity.Address);
            cmd.AddParameterWithValue("@Phone", entity.Phone);
            cmd.AddParameterWithValue("@Name", entity.Name);
        }

        protected override void DeleteCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = "DeleteVenue";

            cmd.AddParameterWithValue("@Id", id);
        }

        protected override void GetAllCommandParameters(IDbCommand cmd)
        {
            cmd.CommandText = "select * from Venues";
        }

        protected override void GetByIdCommandParameters(int id, IDbCommand cmd)
        {
            cmd.CommandText = string.Format("SELECT * FROM Venues WHERE Id = {0}", id);
        }

        protected override Venue Map(IDataReader reader)
        {
            Venue venue = new Venue();
            bool isNull = true;

            while (reader.Read())
            {
                isNull = false;
                int index = 0;
                venue.Id = reader.GetInt32(index++);
                venue.Description = reader.GetString(index++);
                venue.Address = reader.GetString(index++);
                venue.Phone = reader.GetString(index++);
                venue.Name = reader.GetString(index++);
            }

            return isNull ? null : venue;
        }

        protected override IEnumerable<Venue> Maps(IDataReader reader)
        {
            ICollection<Venue> venues = new List<Venue>();

            while (reader.Read())
            {
                int index = 0;

                Venue venue = new Venue
                {
                    Id = reader.GetInt32(index++),
                    Description = reader.GetString(index++),
                    Address = reader.GetString(index++),
                    Phone = reader.GetString(index++),
                    Name = reader.GetString(index++),
                };

                venues.Add(venue);
            }

            return venues;
        }
    }
}
