// ****************************************************************************
// <copyright file="RepositoryFake.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// Author Dzianis Shcharbakou.
// </copyright>
// ****************************************************************************

using System.Collections.Generic;
using System.Linq;
using Moq;
using TicketManagement.DAL.Models.Base;
using TicketManagement.DAL.Repositories.Base;

namespace TicketManagement.UnitTests.FakeRepositories
{
    internal class RepositoryFake<T>
        where T : IEntity, new()
    {
        private readonly List<T> repositoryData;

        public RepositoryFake(List<T> repositoryData)
        {
            this.repositoryData = repositoryData;
        }

        public Mock<IRepository<T>> SetUpFakeRepository(Mock<IRepository<T>> mockRepository)
        {
            mockRepository.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns((int id) => this.repositoryData.FirstOrDefault(x => x.Id == id))
                .Verifiable();

            mockRepository.Setup(x => x.Update(It.IsAny<T>()))
                .Returns((T entity) =>
                {
                    int index = this.repositoryData.FindIndex(x => x.Id == entity.Id);
                    return (object)(index == -1 ? 0 : 1);
                })
                .Callback((T entity) =>
                {
                    int index = this.repositoryData.FindIndex(x => x.Id == entity.Id);
                    if (index != -1)
                    {
                        this.repositoryData.RemoveAt(index);
                        this.repositoryData.Insert(index, entity);
                    }
                }).Verifiable();

            mockRepository.Setup(x => x.Create(It.IsAny<T>()))
                .Returns((T entity) => (object)entity.Id)
                .Callback((T entity) =>
                {
                    this.repositoryData.Add(entity);
                }).Verifiable();

            mockRepository.Setup(x => x.Delete(It.IsAny<int>()))
                .Returns((int id) =>
                    {
                        int index = this.repositoryData.FindIndex(x => x.Id == id);
                        return (object)(index == -1 ? 0 : 1);
                    })
                .Callback((int id) =>
                {
                    int index = this.repositoryData.FindIndex(x => x.Id == id);
                    if (index != -1)
                    {
                        this.repositoryData.RemoveAt(index);
                    }
                }).Verifiable();

            mockRepository.Setup(x => x.GetAll())
                .Returns(() => this.repositoryData.Count == 0 ? null : this.repositoryData)
                .Verifiable();

            return mockRepository;
        }
    }
}
