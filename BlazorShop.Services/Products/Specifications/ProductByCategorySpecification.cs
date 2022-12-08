namespace BlazorShop.Services.Products.Specifications {
    using Data.Models;
    using System;
    using System.Linq.Expressions;

    internal class ProductByCategorySpecification : Specification<Product> {
        private readonly long? category;

        internal ProductByCategorySpecification(long? category)
            => this.category = category;

        protected override bool Include => this.category != null;

        public override Expression<Func<Product, bool>> ToExpression()
            => product => product.Category.Id == this.category;
    }
}