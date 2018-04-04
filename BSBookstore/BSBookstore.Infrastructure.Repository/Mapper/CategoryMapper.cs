using BSBookstore.Domain.Entity;
using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Infrastructure.Repository.Mapper
{
    public class CategoryMapper : ClassMapper<Category>
    {
        #region Constructors

        public CategoryMapper()
        {
            Table("Category");

            Map(x => x.Id).Column("Id").Key(KeyType.Guid);
            Map(x => x.Name).Column("Name");
            Map(x => x.Books).Ignore();
        }

        #endregion
    }
}
