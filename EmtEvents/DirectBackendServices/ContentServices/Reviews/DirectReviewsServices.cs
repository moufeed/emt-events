using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TamTechSDK.Common.Providers.Requests.Models;
using TamTechSDK.Common.Services.ContentService.Products.Models;
using TamTechSDK.Common.Services.ContentService.Reviews.Models;

namespace EmtEvents.DirectBackendServices.ContentServices.Reviews
{
    public class DirectReviewsServices : TamTechSDK.Common.Services.ContentService.Reviews.IReviewsServices
    {
        public async Task<IRequestProviderResult<List<Review>>> GetAllReviewsAsync()
        {
            return new RequestProviderResult<List<Review>>
            {
                Success = true,
                Data = new List<Review>
                {
                     new Review
                    {
                        Id = "cf2844c5-bf97-42f0-8a78-23cd5ce0b1a5 ",
                        AuthorId = "cd1506ac-9b13-4593-9908-9274e109315b ",
                        ProductId = "9a28a691-e437-4b8b-afff-fb92ea675bab ",
                        Author = "Khaled",
                        Text = "iPhone X like, excellent quality with smooth use. Could get slow sometimes but overall is good product for the price.",
                        ReplyText = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Distinctio facilis fuga voluptatem.",
                        Rate = 5,
                        CreatedDate = new DateTime(2018, 04, 02, 22, 13, 20),
                        Product = new ProductLite()
                        {
                            Name ="BlackBerry Keyone",
                        }
                    },
                    new Review
                    {
                        Id = "606a740f-04ac-4d69-931c-a21cc3a31cda ",
                        AuthorId = "6e2dda3b-dd99-41a2-9567-c8f710791953 ",
                        ProductId = "9a28a691-e437-4b8b-afff-fb92ea675bab ",
                        Author = "Pawan",
                        Text = "Awesome phone",
                        ReplyText = "thanks :) ",
                        Rate = 5,
                        CreatedDate = new DateTime(2018, 04, 02, 18, 29, 15),
                        Product = new ProductLite()
                        {
                            Name = "Huawei Nova 3e",
                        }
                    },
                    new Review
                    {
                        Id = "37a8f12d-e8f7-4547-ba78-a3cf40cf0150 ",
                        AuthorId = "9396f199-8454-4468-bc16-b31cd6ad0c85 ",
                        ProductId = "9a28a691-e437-4b8b-afff-fb92ea675bab ",
                        Author = "Adnan",
                        Text = "WHAT'S GOOD ABOUT THIS PRODUCT: Ram, processors",
                        Rate = 4,
                        ReplyText = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Distinctio facilis fuga voluptatem.",
                        CreatedDate = new DateTime(2018, 04, 02, 12, 21, 15),
                        Product = new ProductLite()
                        {
                             Name = "Huawei Nova 3e",
                        }
                    },
                    new Review
                    {
                        Id = "7117cbf5-7548-4d35-bb1e-782e55ee1ed8 ",
                        AuthorId = "c0890abd-1da8-4007-bced-1cea455a5ca6 ",
                        ProductId = "c2cd81cc-dd4c-4888-ad18-7138a0c970d3 ",
                        Author = "Shamool",
                        Text = "beautiful,Amazing screen,very good phone,i like it WHAT'S GOOD ABOUT THIS PRODUCT:beautiful,Amazing screen",
                        Rate = 3,
                        ReplyText = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Distinctio facilis fuga voluptatem.",
                        CreatedDate = new DateTime(2018, 03, 21, 10, 14, 59),
                        Product = new ProductLite()
                        {
                            Name = "Apple iPhone X",
                        }
                    },
                    new Review
                    {
                        Id = "c726287f-13ce-442e-a757-01fb3091f4ca ",
                        AuthorId = "cd1506ac-9b13-4593-9908-9274e109315b ",
                        ProductId = "c2cd81cc-dd4c-4888-ad18-7138a0c970d3 ",
                        Author = "IDREES",
                        Text = "Good phone, value for money",
                        Rate = 2,
                        ReplyText = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Distinctio facilis fuga voluptatem.",
                        CreatedDate = new DateTime(2018, 04, 28, 11, 12, 50),
                        Product = new ProductLite()
                        {
                             Name = "LG Aurora Black",
                        }
                    },
                    new Review
                    {
                        Id = "a862fcb5-3cb3-4e97-a020-1ff6eaa5ebe8 ",
                        AuthorId = "f39b805b-d120-413a-bd3b-bcd5b934c1a2 ",
                        ProductId = "c2cd81cc-dd4c-4888-ad18-7138a0c970d3 ",
                        Author = "خالد",
                        Text = "ممتاز بس فيه حراره بسيطه",
                        Rate = 1,
                        CreatedDate = new DateTime(2018, 04, 09, 14, 12, 00),
                        Product = new ProductLite()
                        {
                            Name = "LG V10",
                        }
                    },
                    new Review
                    {
                        Id = "eeda7306-faac-474c-959a-2ed86a5031ef ",
                        AuthorId = "6e2dda3b-dd99-41a2-9567-c8f710791953 ",
                        ProductId = "c2cd81cc-dd4c-4888-ad18-7138a0c970d3 ",
                        Author = "Albaraa",
                        Text = "Best value for money",
                        Rate = 5,
                        CreatedDate = new DateTime(2018, 04, 09, 17, 12, 00),
                        Product = new ProductLite()
                        {
                           Name = "One Plus Dual Sim",
                        }
                    },

                    new Review
                    {
                        Id = "d877ad8f-77fa-4457-be4f-e206b8632492 ",
                        AuthorId = "9396f199-8454-4468-bc16-b31cd6ad0c85 ",
                        ProductId = "c2cd81cc-dd4c-4888-ad18-7138a0c970d3 ",
                        Author = "Khaled",
                        Text = "iPhone X like, excellent quality with smooth use. Could get slow sometimes but overall is good product for the price.",
                        Rate = 4,
                        CreatedDate = new DateTime(2018, 04, 02, 10, 15, 14),
                        Product = new ProductLite()
                        {
                             Name = "Samsung Galaxy S9",
                        }
                    },
                    new Review
                    {
                        Id = "0bae591c-6c15-4a71-aa6d-77a06cc2ea99 ",
                        AuthorId = "c0890abd-1da8-4007-bced-1cea455a5ca6 ",
                        ProductId = "c2cd81cc-dd4c-4888-ad18-7138a0c970d3 ",
                        Author = "Pawan",
                        Text = "Awesome phone",
                        Rate = 2,
                        CreatedDate = new DateTime(2018, 04, 02, 02, 12, 25),
                        Product = new ProductLite()
                        {
                            Name = "Huawei Mate 9 Dual Sim - 64 GB, 4 GB RAM, 4G LTE , Mocha Brown",
                        }
                    },
                    new Review
                    {
                        Id = "5af32661-8932-4e32-8408-193708775132 ",
                        AuthorId = "cd1506ac-9b13-4593-9908-9274e109315b ",
                        ProductId = "c2cd81cc-dd4c-4888-ad18-7138a0c970d3 ",
                        Author = "Adnan",
                        Text = "WHAT'S GOOD ABOUT THIS PRODUCT: Ram, processors",
                        Rate = 5,
                        ReplyText = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Distinctio facilis fuga voluptatem.",
                        CreatedDate = new DateTime(2018, 04, 02, 03, 10, 14),
                        Product = new ProductLite()
                        {
                            Name = "Huawei P10 VTR-L29 Dual Sim - 64GB, 4GB RAM, 4G LTE, Dazzling Blue",
                        }
                    },
                    new Review
                    {
                        Id = "58ade5eb-c2a2-4d6c-b591-3eb154cdbf0d ",
                        AuthorId = "f39b805b-d120-413a-bd3b-bcd5b934c1a2 ",
                        ProductId = "36ac42e5-d405-4cff-9943-6344bad809a3 ",
                        Author = "Shamool",
                        Text = "beautiful,Amazing screen,very good phone,i like it WHAT'S GOOD ABOUT THIS PRODUCT:beautiful,Amazing screen",
                        Rate = 1,
                        CreatedDate = new DateTime(2018, 03, 21, 05, 20, 55),
                        Product = new ProductLite()
                        {
                             Name = "Samsung Galaxy S8+ Dual Sim - 64GB, 4G LTE, Midnight Black",
                        }
                    },
                    new Review
                    {
                        Id = "ab724d6d-39ce-4c96-85c3-a814d95e0a9a ",
                        AuthorId = "6e2dda3b-dd99-41a2-9567-c8f710791953 ",
                        ProductId = "36ac42e5-d405-4cff-9943-6344bad809a3 ",
                        Author = "IDREES",
                        Text = "Good phone, value for money",
                        Rate = 3,
                        ReplyText = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Distinctio facilis fuga voluptatem.",
                        CreatedDate = new DateTime(2018, 03, 28, 14, 28, 05),
                        Product = new ProductLite()
                        {
                            Name = "Samsung Galaxy S8+ Dual Sim - 64GB, 4G LTE, Midnight Black",
                        }
                    },
                    new Review
                    {
                        Id = "75aeb6e9-6e6b-4596-b1f1-3e82036d3ae9 ",
                        AuthorId = "9396f199-8454-4468-bc16-b31cd6ad0c85 ",
                        ProductId = "36ac42e5-d405-4cff-9943-6344bad809a3 ",
                        Author = "خالد",
                        Text = "ممتاز بس فيه حراره بسيطه",
                        Rate = 4,
                        CreatedDate = new DateTime(2018, 04, 09, 15, 17, 09),
                        Product = new ProductLite()
                        {
                           Name = "Samsung SL-M2070FW Xpress Mono Multifunction Laser Printer",
                        }
                    },
                    new Review
                    {
                        Id = "78511fee-9380-4df6-b14d-307a918aae62 ",
                        AuthorId = "c0890abd-1da8-4007-bced-1cea455a5ca6 ",
                        ProductId = "36ac42e5-d405-4cff-9943-6344bad809a3 ",
                        Author = "Albaraa",
                        Text = "Best value for money",
                        Rate = 5,
                        CreatedDate = new DateTime(2018, 04, 09, 22, 14, 07),
                        Product = new ProductLite()
                        {
                            Name = "Samsung SL-M2070FW Xpress Mono Multifunction Laser Printer",
                        }
                    },
                }
            };
        }

        public async Task<IRequestProviderResult<Review>> GetReviewByIdAsync(string id)
        {
            return new RequestProviderResult<Review>
            {
                Success = true,
                Data = new Review
                {
                    Id = "c726287f-13ce-442e-a757-01fb3091f4ca ",
                    AuthorId = "cd1506ac-9b13-4593-9908-9274e109315b ",
                    ProductId = "c2cd81cc-dd4c-4888-ad18-7138a0c970d3 ",
                    Author = "IDREES",
                    Text = "Good phone, value for money",
                    Rate = 2,
                    ReplyText = "Lorem ipsum dolor sit, amet consectetur adipisicing elit. Distinctio facilis fuga voluptatem.",
                    CreatedDate = new DateTime(2018, 04, 28, 11, 12, 50),
                    Product = new ProductLite()
                    {
                        Name = "LG Aurora Black",
                    }
                }
            };
        }
    }
}
