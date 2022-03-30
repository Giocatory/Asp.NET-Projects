using MyCompany.Domain.Entities;
using System;
using System.Linq;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();

        ServiceItem GetServiceItemById(Guid id);

        void SaveServiceItem(ServiceItem entity);

        void DeleteServiceItem(Guid id);
    }
}