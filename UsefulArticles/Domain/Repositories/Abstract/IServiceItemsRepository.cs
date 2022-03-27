using UsefulArticles.Domain.Entities;

namespace UsefulArticles.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();

        ServiceItem GetServiceItemById(Guid id);

        void SaveServiceItem(ServiceItem entity);

        void DeleteServiceItem(Guid id);
    }
}