﻿using OnlineStoreAPI.Data;
using OnlineStoreAPI.Interfaces;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Product> GetProductByCategory(int categoryId)
        {
            return _context.ProductCategories.Where(e => e.CategoryId == categoryId).Select(c => c.Product).ToList();
        }

        public ICollection<Category> GetCategoryOfAProduct(int productId)
        {
            return _context.ProductCategories.Where(e => e.ProductId == productId).Select(c => c.Category).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
