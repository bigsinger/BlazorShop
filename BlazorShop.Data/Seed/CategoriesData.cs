namespace BlazorShop.Data.Seed {
    using Contracts;
    using Models;
    using System;
    using System.Collections.Generic;

    public class CategoriesData : IInitialData {
        public Type EntityType => typeof(Category);

        public IEnumerable<object> GetData()
            => new List<Category> {
                new Category { Id = 101, ParentId=0, Name = "软件" },
                new Category { Id = 102, ParentId=0, Name = "书籍" },
                new Category { Id = 103, ParentId=0, Name = "文档" },
                new Category { Id = 104, ParentId=0, Name = "素材" },
                new Category { Id = 109, ParentId=0, Name = "其他" },

                    //软件子类
                    new Category { Id = 2101, ParentId=101, Name = "效率工具" },
                    new Category { Id = 2102, ParentId=101, Name = "下载工具" },
                    new Category { Id = 2103, ParentId=101, Name = "编程开发" },
                        new Category { Id = 321001, ParentId=2103, Name = "IDE" },
                        new Category { Id = 321002, ParentId=2103, Name = "SDK" },
                        new Category { Id = 321009, ParentId=2103, Name = "其他" },

                    //书籍子类
                    new Category { Id = 2201, ParentId=102, Name = "思想认知" },
                    new Category { Id = 2202, ParentId=102, Name = "管理" },
                    new Category { Id = 2203, ParentId=102, Name = "自然科学" },
                    new Category { Id = 2204, ParentId=102, Name = "人文传记" },
                    new Category { Id = 2205, ParentId=102, Name = "历史" },
                    new Category { Id = 2206, ParentId=102, Name = "小说" },
                    new Category { Id = 2207, ParentId=102, Name = "工具书籍" },

                    //文档子类
                    new Category { Id = 2301, ParentId=103, Name = "PPT" },
                    new Category { Id = 2302, ParentId=103, Name = "答辩" },
                    new Category { Id = 2303, ParentId=103, Name = "论文" },
                    new Category { Id = 2304, ParentId=103, Name = "教学" },

                    //素材子类
                    new Category { Id = 2401, ParentId=104, Name = "游戏图片" },
                    new Category { Id = 2402, ParentId=104, Name = "游戏配音" },
                    new Category { Id = 2403, ParentId=104, Name = "自然声音" },
                    new Category { Id = 2404, ParentId=102, Name = "人声" },
                    new Category { Id = 2405, ParentId=102, Name = "动物声音" },
                    new Category { Id = 2406, ParentId=102, Name = "PNG图片" },
                    new Category { Id = 2407, ParentId=102, Name = "美女图片" },
                    
                    //素材子类
                    new Category { Id = 2901, ParentId=109, Name = "其他" },
            };
    }
}
