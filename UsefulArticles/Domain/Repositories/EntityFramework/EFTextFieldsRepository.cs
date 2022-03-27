using Microsoft.EntityFrameworkCore;
using UsefulArticles.Domain.Entities;
using UsefulArticles.Domain.Repositories.Abstract;

namespace UsefulArticles.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext? context;

        public EFTextFieldsRepository(AppDbContext context) => this.context = context;

        public IQueryable<TextField> GetTextFields() => context.TextFields;

        public TextField GetTextFieldByCodeWord(string codeword) => context.TextFields.FirstOrDefault(x => x.CodeWord == codeword);

        public TextField GetTextFieldById(Guid id) => context.TextFields.FirstOrDefault(x => x.Id == id);

        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default) context.Entry(entity).State = EntityState.Added;
            else context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }
    }
}