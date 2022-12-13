namespace BlazorShop.Data.Seed {
    using Contracts;
    using Models;
    using System;
    using System.Collections.Generic;

    public class ProductsData : IInitialData {
        public Type EntityType => typeof(Product);

        public IEnumerable<object> GetData()
            => new List<Product>
            {
                new Product
                {
                    Id= 1,
                    Name = "《大明王朝1566》",
                    Description = "刘和平著的《大明王朝(1566上下)》对宦官的描写真绝！将“王权主义”写到他们骨头里去了。书中有两个最具命运感的人物，一个是海瑞，一个是嘉靖帝，他们在命运的催化下复活。作品用一出出可歌可泣的好戏，揭示了中国传统政治中儒道互补的运作规律。本书是高品位文化之作，故事新颖，扣人心弦，引人入胜。在许多情节、多种场景的往复切换中，表现出作者的大器局，胸有丘壑。",
                    ImageSource = "https://img1.baidu.com/it/u=1459856355,3223393159&fm=253&fmt=auto&app=138&f=JPEG?w=500&h=647",
                    Price = 9.99m,
                    Quantity = 999,
                    CategoryId = 102
                },
                new Product
                {
                    Id = 2,
                    Name = "FFmpeg",
                    Description = "FFmpeg是一套可以用来记录、转换数字音频、视频，并能将其转化为流的开源计算机程序。采用LGPL或GPL许可证。它提供了录制、转换以及流化音视频的完整解决方案。",
                    ImageSource = "https://img2.baidu.com/it/u=3478002248,2854966811&fm=253&fmt=auto&app=138&f=JPEG?w=889&h=500",
                    Price = 5.9m,
                    Quantity = 30,
                    CategoryId = 101
                },
                new Product
                {
                    Id = 3,
                    Name = "方可云仓库进销存",
                    Description = "网页版B/S在线进销存、仓库软件免安装，手机、平板、PC数据同步，只需要一个上网浏览器即可使用。集采购进货、销售、库存、财务于一体，无需培训，人人会用",
                    ImageSource = "https://img1.baidu.com/it/u=3772627597,2855505711&fm=253&fmt=auto&app=138&f=PNG?w=500&h=250",
                    Price = 109.60m,
                    Quantity = 10,
                    CategoryId = 101
                },
                new Product
                {
                    Id = 4,
                    Name = "苹果数据恢复精灵",
                    Description = "淘晶苹果数据恢复精灵，操作简单，无需越狱，支持所有苹果IOS设备，可恢复浏览短信、联系人、通话记录、QQ、微信、相册等数据（经测试碎片查找能力行业领先），并可轻松导出为明文备份。 本软件适配苹果官方手机助手itunes工具备份的镜像，免去进入手机内部扫描的风险。强大的镜像碎片提取引擎让您不在为删除的数据而烦恼，是一款苹果设备必备工具。",
                    ImageSource = "https://img0.baidu.com/it/u=1912789850,404984198&fm=253&fmt=auto&app=138&f=PNG?w=500&h=500",
                    Price = 366.98m,
                    Quantity = 10,
                    CategoryId = 101
                },
                new Product
                {
                    Id = 5,
                    Name = "安卓手机数据恢复精灵",
                    Description = "支持安卓手机中的短信、联系人、通话记录、微信、QQ等常见应用的数据的导出查看及一键恢复，且只要相关碎片存在即可完全恢复出删除的数据，建议给手机ROOT权限，方便一键导出功能的使用，也可以支持部份手机免ROOT导出数据查看与恢复。",
                    ImageSource = "https://img0.baidu.com/it/u=475388606,3830604471&fm=253&fmt=auto&app=138&f=JPEG?w=499&h=333",
                    Price = 35.99m,
                    Quantity = 10,
                    CategoryId = 101
                },
                new Product
                {
                    Id = 6,
                    Name = "家庭电脑屏幕录制记录器",
                    Description = "一款针对电脑屏幕的录制，可用于协助您看管家中上网的孩子，了解他是否遭受到网络上不良信息的干扰，及时与孩子勾通，给他一个安全纯净的生长空间。",
                    ImageSource = "https://img2.baidu.com/it/u=2392206097,2280036916&fm=253&fmt=auto&app=138&f=GIF?w=500&h=281",
                    Price = 28.95m,
                    Quantity = 10,
                    CategoryId = 101
                }
            };
    }
}
