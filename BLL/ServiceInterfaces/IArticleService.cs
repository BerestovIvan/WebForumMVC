﻿using BLL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.ServiceInterfaces
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleModel>> Get(QueryParamsModel queryParamsModel);
        Task<ArticleModel> Get(Guid id);
        Task<ArticleModel> Create(ArticleModel articleModel);
        Task<ArticleModel> Update(ArticleModel articleModel);
        Task Delete(Guid id);
    }
}