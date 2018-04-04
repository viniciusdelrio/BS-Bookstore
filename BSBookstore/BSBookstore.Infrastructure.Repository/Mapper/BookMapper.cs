using BSBookstore.Domain.Entity;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Infrastructure.Repository.Mapper
{
    public class BookMapper : ClassMapper<Book>
    {
        #region Constructors

        public BookMapper()
        {
            Table("Book");

            Map(x => x.Id).Column("Id").Key(KeyType.Guid);
            Map(x => x.Title).Column("Title");
            Map(x => x.IdAuthor).Column("IdAuthor").Key(KeyType.NotAKey);
            Map(x => x.IdCategory).Column("IdCategory").Key(KeyType.NotAKey);
            Map(x => x.PublishedYear).Column("PublishedYear");

            Map(x => x.Author).Ignore();
            Map(x => x.Category).Ignore();
        }

        #endregion
    }
}
