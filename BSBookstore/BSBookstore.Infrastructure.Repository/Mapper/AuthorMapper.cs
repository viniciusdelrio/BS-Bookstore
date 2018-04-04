using BSBookstore.Domain.Entity;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Infrastructure.Repository.Mapper
{
    public class AuthorMapper : ClassMapper<Author>
    {
        #region Constructors

        public AuthorMapper()
        {
            Table("Author");

            Map(x => x.Id).Column("Id").Key(KeyType.Guid);
            Map(x => x.Name).Column("Name");
            Map(x => x.Books).Ignore();
        }

        #endregion
    }
}
